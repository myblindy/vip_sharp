using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vip_sharp
{
    public class VIPGenerator : IVIPNodeVisitor
    {
        public StringBuilder Code = new StringBuilder();

        private const string VIPUtilsClass = "vip_sharp.VIPUtils";
        private const string VIPUtilsInstance = VIPUtilsClass + ".Instance";
        private const string VIPArrayClass = "vip_sharp.BipolarArray";

        class VIPTypeComparer : IEqualityComparer<string[]>
        {
            public bool Equals(string[] x, string[] y) => x.SequenceEqual(y);
            public int GetHashCode(string[] obj) => obj.Sum(o => o.GetHashCode());
        }
        class TypedefDataClass
        {
            internal string[] Fields;
        }
        Dictionary<string[], TypedefDataClass> Typedefs = new Dictionary<string[], TypedefDataClass>(new VIPTypeComparer());
        HashSet<string> ValueTypes = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { "double", "int", "bool", "true", "false", "char" };

        bool IsValueType(VIPTypeIdentifierNode node) => node.Parts.Length == 1 && ValueTypes.Contains(node.Parts[0]);

        string PrefixForValueType(bool valuetype) => valuetype ? "" : "__";

        string LastObjectName;

        public VIPGenerator()
        {
        }

        public void Visit(VIPStringNode node)
        {
        }

        public void Visit(VIPNumberNode node)
        {
            Code.Append(node.Value);
        }

        public void Visit(VIPDefsNode node)
        {
            foreach (VIPNode typedef in node.ChildNodes)
                typedef.Accept(this);
        }

        public void Visit(VIPVariableDefinitionNode node)
        {
            Code.Append("public ");
            node.Type.Accept(this);
            Code.AppendLine($" __{node.Identifier};");
        }

        public void Visit(VIPPlainIdentifierNode node)
        {
            Code.Append($"__{node.Name}");
        }

        public void Visit(VIPQualifiedIdentifierNode node)
        {
            bool first = true;
            foreach (var part in node.Parts)
            {
                if (first) first = false; else Code.Append('.');
                var prefix = ValueTypes.Contains(part.Item1) ? "" : "__";
                var name = part.Item1.EqualsI("system") ? $"{VIPUtilsInstance}.VIPSystemClass" : prefix + part.Item1;
                Code.Append(name);
                if (part.Item2 != null)
                {
                    Code.Append('[');
                    part.Item2.Accept(this);
                    Code.Append(']');
                }
            }
        }

        public void Visit(VIPExpressionListNode node)
        {
            bool first = true;
            foreach (VIPNode exprnode in node.ChildNodes)
            {
                if (first) first = false; else Code.Append(',');
                exprnode.Accept(this);
            }
        }

        public void Visit(VIPFullVariableDefinitionNode node)
        {
            if (node.ArraySize != null || node.ArraySizeAuto)
            {
                Code.Append($"{VIPArrayClass}<");
                node.Type.Accept(this);
                Code.Append($"> __{node.Name} = new {VIPArrayClass}<");
                node.Type.Accept(this);
                Code.Append(">(");
                node.ArraySize?.Accept(this);

                if (node.InitValues != null)
                {
                    Code.Append(") {");

                    var fields = Typedefs[node.Type.Parts].Fields;
                    var itemsintype = fields.Length;
                    for (int idx = 0; idx < node.InitValues.Length; idx += itemsintype)
                    {
                        if (idx != 0) Code.Append(',');
                        Code.Append("new ");
                        node.Type.Accept(this);
                        Code.Append('{');

                        for (int initvalidx = idx; initvalidx < idx + fields.Length; ++initvalidx)
                        {
                            if (initvalidx != idx) Code.Append(',');
                            Code.Append($"__{fields[initvalidx - idx]} = ");
                            node.InitValues[initvalidx].Accept(this);
                        }

                        Code.Append('}');
                    }
                    Code.Append('}');
                }
                else if (node.InitValue != null)
                {
                    if (node.ArraySize != null) Code.Append(',');
                    node.InitValue.Accept(this);
                    Code.Append(')');
                }
                Code.AppendLine(";");
            }
            else if (!IsValueType(node.Type))
            {
                if (node.InitValues != null)
                {
                    var fields = Typedefs[node.Type.Parts].Fields;
                    node.Type.Accept(this);
                    Code.Append($" __{node.Name} = new ");
                    node.Type.Accept(this);
                    Code.Append('{');

                    for (int initvalidx = 0; initvalidx < fields.Length; ++initvalidx)
                    {
                        if (initvalidx != 0) Code.Append(',');
                        Code.Append(fields[initvalidx] + " = ");
                        node.InitValues[initvalidx].Accept(this);
                    }

                    Code.AppendLine("};");
                }
                else
                {
                    node.Type.Accept(this);
                    Code.Append($" __{node.Name} = new ");
                    node.Type.Accept(this);
                    Code.AppendLine("();");
                }
            }
            else
            {
                node.Type.Accept(this);
                Code.Append($" __{node.Name} = ");
                if (node.InitValue != null)
                    node.InitValue.Accept(this);
                else
                {
                    // try to figure out what to initialize this thing with
                    if (node.Type.Parts[0].EqualsI("bool"))
                        Code.Append("false");
                    else
                        Code.Append('0');
                }
                Code.AppendLine(";");
            }
        }

        public void Visit(VIPVariableDefinitionsNode node)
        {
        }

        public void Visit(VIPTypeDefinitionNode node)
        {
            Typedefs.Add(new[] { node.Name }, new TypedefDataClass
            {
                Fields = node.ChildNodes.Cast<VIPVariableDefinitionNode>().Select(n => n.Identifier).ToArray()
            });

            Code.AppendLine($"public class __{node.Name} {{ ");
            foreach (VIPNode defnode in node.ChildNodes)
                defnode.Accept(this);
            Code.AppendLine("}");
        }

        public void Visit(VIPMainNode node)
        {
            Code.AppendLine("public void Run() {");
            foreach (VIPNode command in node.ChildNodes)
                command.Accept(this);
            Code.AppendLine("}");
        }

        public void Visit(VIPTranslateCommandNode node)
        {
            Code.Append($"{VIPUtilsInstance}.Translate(");
            node.X.Accept(this);
            Code.Append(", ");
            node.Y.Accept(this);
            Code.AppendLine(");");
        }

        public void Visit(VIPScaleCommandNode node)
        {
            Code.Append($"{VIPUtilsInstance}.Scale(");
            node.Scale.Accept(this);
            Code.AppendLine(");");
        }

        public void Visit(VIPRotateCommandNode node)
        {
            Code.Append($"{VIPUtilsInstance}.Rotate(");
            node.Angle.Accept(this);
            Code.AppendLine(");");
        }

        public void Visit(VIPCommandNode node)
        {
        }

        public void Visit(VIPCommandsNode node)
        {
        }

        public void Visit(VIPProgramNode node)
        {
            Code.AppendLine("using System;");
            Code.AppendLine("public class __MainClass {");
            foreach (VIPNode entry in node.ChildNodes)
                entry.Accept(this);
            Code.AppendLine("}");
        }

        public void Visit(VIPPolygonCommandNode node)
        {
            if (node.VerticesIdentifier != null && node.ColorsIdentifier != null)
            {
                Code.Append($"{VIPUtilsInstance}.Polygon(");
                node.VerticesIdentifier.Accept(this);
                Code.Append(",");
                node.ColorsIdentifier.Accept(this);
                Code.AppendLine(");");
            }
        }

        public void Visit(VIPAssignmentCommandNode node)
        {
            node.Variable.Accept(this);
            Code.Append(" = ");
            node.Expression.Accept(this);
            Code.AppendLine(";");
        }

        public void Visit(VIPExpressionNode node)
        {
            if (node.ChildNodes.Count == 2 && node.ChildNodes[0] is VIPQualifiedIdentifierNode && node.ChildNodes[1] is VIPExpressionListNode)
            {
                // special case for functions
                ((VIPNode)node.ChildNodes[0]).Accept(this);
                Code.Append('(');

                var first = true;
                foreach (VIPNode argnode in node.ChildNodes[1].ChildNodes)
                {
                    if (first) first = false; else Code.Append(',');
                    argnode.Accept(this);
                }
                Code.Append(')');
            }
            else
                foreach (VIPNode subnode in node.ChildNodes)
                {
                    if (subnode.ChildNodes.Count > 1) Code.Append('(');
                    subnode.Accept(this);
                    if (subnode.ChildNodes.Count > 1) Code.Append(')');
                }
        }

        public void Visit(VIPOperatorNode node)
        {
            switch (node.Operator)
            {
                case ".and.":
                    Code.Append("&&");
                    break;
                case ".or.":
                    Code.Append("||");
                    break;
                default:
                    Code.Append(node.Operator);
                    break;
            }
        }

        public void Visit(VIPDefNode node)
        {
        }

        public void Visit(VIPFunctionDefinitionNode node)
        {
            Code.Append("public ");
            node.Type.Accept(this);
            Code.Append($" __{node.Name} (");

            bool first = true;
            foreach (var arg in node.Arguments)
            {
                if (first) first = false; else Code.Append(',');
                arg.Item1.Accept(this);
                Code.Append($" __{arg.Item2}");
            }
            Code.AppendLine(") {");
            foreach (VIPNode cmd in node.ChildNodes)
                cmd.Accept(this);
            Code.AppendLine("}");
        }

        public void Visit(VIPFunctionDefinitionArgumentListNode node)
        {
            throw new NotImplementedException();
        }

        public void Visit(VIPFunctionDefinitionArgument node)
        {
            ((VIPTypeIdentifierNode)node.ChildNodes[0]).Accept(this);
            Code.Append(' ');
            ((VIPPlainIdentifierNode)node.ChildNodes[1]).Accept(this);
        }

        public void Visit(VIPReturnCommandNode node)
        {
            Code.Append("return ");
            node.Expression.Accept(this);
            Code.AppendLine(";");
        }

        public void Visit(VIPIdentifierNode node)
        {
            Code.Append($"__{node.Name}");
            if (node.Index != null)
            {
                Code.Append('[');
                node.Index.Accept(this);
                Code.Append(']');
            }
        }

        public void Visit(VIPTypeIdentifierNode node)
        {
            bool first = true;
            if (IsValueType(node))
                Code.Append($"{node.Parts[0]}");
            else
                foreach (var part in node.Parts)
                {
                    if (first) first = false; else Code.Append('.');
                    Code.Append($"__{part}");
                }
        }

        public void Visit(VIPBitmapResDefinitionNode node)
        {
            var type = node.Type.EqualsI("RGB") ? "RGB"
                : node.Type.EqualsI("RGBA") ? "RGBA"
                : node.Type.EqualsI("HARD_MASK") ? "HardMask"
                : "SoftMask";
            var filter = node.Filter.EqualsI("LINEAR") ? "Linear"
                : node.Filter.EqualsI("NEAREST") ? "Nearest"
                : "MipMap";
            var clamp = node.ClampMode.EqualsI("CLAMP") ? "Clamp" : "Repeat";

            Code.AppendLine($"{VIPUtilsClass}.BitmapRes __{node.Handle} = new {VIPUtilsClass}.BitmapRes(" +
                $"{VIPUtilsClass}.BitmapType.{type}, {VIPUtilsClass}.BitmapFilter.{filter}, {VIPUtilsClass}.BitmapClamp.{clamp}, " +
                "@\"" + node.Path + "\");");
        }

        public void Visit(VIPPathIdentifierNode node)
        {
        }

        public void Visit(VIPBitmapCommandNode node)
        {
            var blend = node.Blend.EqualsI("BLEND") ? "Blend"
                : node.Blend.EqualsI("MODULATE") ? "Modulate"
                : node.Blend.EqualsI("DECAL") ? "Decal"
                : "Replace";

            Code.Append($"{VIPUtilsInstance}.Bitmap(");
            node.Handle.Accept(this);
            Code.Append($", {VIPUtilsClass}.BitmapBlend.{blend}, ");
            node.X.Accept(this); Code.Append(','); node.Y.Accept(this); Code.Append(',');
            node.W.Accept(this); Code.Append(','); node.H.Accept(this); Code.Append(',');
            Code.Append($"{VIPUtilsClass}.PositionRef.{node.Ref},");
            node.Vertices.Accept(this);
            Code.AppendLine(");");
        }

        public void Visit(VIPIfCommandNode node)
        {
            Code.Append("if(");
            node.Test.Accept(this);
            Code.AppendLine(") {");
            foreach (VIPNode cmd in node.ChildNodes)
                cmd.Accept(this);
            Code.AppendLine("}");
        }

        public void Visit(VIPObjectDefinitionNode node)
        {
            LastObjectName = node.Name;

            Code.AppendLine($"public class __{node.Name} : {VIPUtilsClass}.IVIPObject {{");
            Code.AppendLine("public double X=0, Y=0;");
            Code.AppendLine("public double GetX() { return X; }");
            Code.AppendLine("public double GetY() { return Y; }");
            foreach (var defnode in node.Definitions)
                ((VIPNode)defnode.ChildNodes[0].AstNode).Accept(this);
            Code.AppendLine("}");
        }

        public void Visit(VIPInstanceDefinitionNode node)
        {
            node.Object.Accept(this);
            Code.Append($" __{node.Name} = new ");
            node.Object.Accept(this);

            Code.Append('(');

            bool first = true;
            if (node.ConstructorArguments != null)
                foreach (var constrarg in node.ConstructorArguments)
                {
                    if (first) first = false; else Code.Append(',');
                    ((VIPNode)constrarg.AstNode).Accept(this);
                }

            Code.Append(") { ");

            first = true;
            foreach (var argnode in node.SpecialArguments)
            {
                if (first) first = false; else Code.Append(',');
                ((VIPNode)argnode.AstNode).Accept(this);
            }

            Code.AppendLine("};");
        }

        public void Visit(VIPNamedArgumentListNode node)
        {
            throw new NotImplementedException();
        }

        public void Visit(VIPNamedArgumentNode node)
        {
            Code.Append($"{node.Name} = ");
            node.Expression.Accept(this);
        }

        public void Visit(VIPDrawCommandNode node)
        {
            Code.Append($"{VIPUtilsInstance}.Draw(");
            node.ObjectName.Accept(this);
            Code.AppendLine(");");
        }

        public void Visit(VIPMacroDefinitionNode node)
        {
            throw new NotImplementedException();
        }

        public void Visit(VIPPlainIdentifierListNode vIPPlainIdentifierListNode)
        {
            throw new NotImplementedException();
        }

        public void Visit(VIPFunctionCallCommandNode node)
        {
            // special commands
            if (node.Name.Parts.Length == 1)
            {
                var qname = node.Name.Parts[0].Item1;
                string sfn = null;
                if (qname.EqualsI("line_width"))
                    sfn = "LineWidth";
                else if (qname.EqualsI("arc_line"))
                    sfn = "ArcLine";

                if (sfn != null)
                {
                    Code.Append($"{VIPUtilsInstance}.{sfn}(");

                    bool first = true;
                    foreach (var argnode in node.Arguments)
                    {
                        if (first) first = false; else Code.Append(',');
                        ((VIPNode)argnode.AstNode).Accept(this);
                    }

                    Code.AppendLine(");");
                    return;
                }
            }

            throw new NotImplementedException();
        }

        public void Visit(VIPStructDefinitionNode node)
        {
            Code.Append($"public class __struct_{node.Name} {{");
            foreach (VIPNode varnode in node.ChildNodes)
                varnode.Accept(this);
            Code.AppendLine($"}} public __struct_{node.Name} __{node.Name}=new __struct_{node.Name}();");
        }

        public void Visit(VIPObjectDefsNode vIPObjectDefsNode)
        {
            throw new NotImplementedException();
        }

        public void Visit(VIPObjectDefNode vIPObjectDefNode)
        {
            throw new NotImplementedException();
        }

        public void Visit(VIPObjectInitDefinition node)
        {
            Code.Append($"public __{LastObjectName}(");

            bool first = true;
            foreach (var argnode in node.Arguments)
            {
                if (first) first = false; else Code.Append(',');
                ((VIPNode)argnode.AstNode).Accept(this);
            }

            Code.AppendLine(") {");

            foreach (VIPNode cmdnode in node.ChildNodes)
                cmdnode.Accept(this);

            Code.AppendLine("}");
        }

        public void Visit(VIPObjectEntryDefinition node)
        {
            Code.AppendLine("public void Run() {");
            foreach (VIPNode cmdnode in node.ChildNodes)
                cmdnode.Accept(this);
            Code.AppendLine("}");
        }

        public void Visit(VIPColorCommandNode node)
        {
            if (node.Save)
                Code.AppendLine($"{VIPUtilsInstance}.ColorSave();");
            else if (node.Restore)
                Code.AppendLine($"{VIPUtilsInstance}.ColorRestore();");
            else if (node.R != null && node.G != null && node.B != null)
            {
                Code.Append($"{VIPUtilsInstance}.Color(");
                node.R.Accept(this);
                Code.Append(',');
                node.G.Accept(this);
                Code.Append(',');
                node.B.Accept(this);
                if (node.A != null)
                {
                    Code.Append(',');
                    node.A.Accept(this);
                }
                Code.AppendLine(");");
            }
            else
            {
                Code.Append($"{VIPUtilsInstance}.Color(");
                node.ArrayName.Accept(this);
                Code.AppendLine(");");
            }
        }

        public void Visit(VIPCircleCommandNode node)
        {
            Code.Append($"{VIPUtilsInstance}.Circle(");
            node.X.Accept(this);
            Code.Append(',');
            node.Y.Accept(this);
            Code.Append(',');
            node.Radius.Accept(this);
            Code.Append(',');
            node.Steps.Accept(this);
            Code.AppendLine($",{node.Filled.ToString().ToLower()});");
        }

        public void Visit(VIPStringLiteralNode node)
        {
            Code.Append($"\"{node.Value}\"");
        }

        public void Visit(VIPMatrixCommandNode node)
        {
            if (node.Type.EqualsI("save"))
                Code.AppendLine($"{VIPUtilsInstance}.MatrixSave();");
            else if (node.Type.EqualsI("restore"))
                Code.AppendLine($"{VIPUtilsInstance}.MatrixRestore();");
            else if (node.Type.EqualsI("identity"))
                Code.AppendLine($"{VIPUtilsInstance}.MatrixIdentity();");
        }

        public void Visit(VIPListDefinition node)
        {
            Code.AppendLine($"{VIPUtilsClass}.DisplayList __{node.Name} = new {VIPUtilsClass}.DisplayList(()=>{{");
            foreach (VIPNode cmdnode in node.ChildNodes)
                cmdnode.Accept(this);
            Code.AppendLine("});");
        }

        public void Visit(VIPShapeCommandNode node)
        {
            string cmd;
            if (node.Command.EqualsI("line_strip"))
                cmd = "LineStrip";
            else if (node.Command.EqualsI("polygon"))
                cmd = "Polygon";
            else if (node.Command.EqualsI("quad"))
                cmd = "Quad";
            else if (node.Command.EqualsI("triangle"))
                cmd = "Triangle";
            else if (node.Command.EqualsI("line"))
                cmd = "Line";
            else if (node.Command.EqualsI("closed_line"))
                cmd = "ClosedLine";
            else
                throw new NotImplementedException();

            Code.Append($"{VIPUtilsInstance}.{cmd}(");
            node.ExpressionList.Accept(this);
            Code.AppendLine(");");
        }

        public void Visit(VIPStringCommandNode node)
        {
            Code.Append($"{VIPUtilsInstance}.DrawString(");
            node.X.Accept(this); Code.Append(',');
            node.Y.Accept(this); Code.Append(',');
            Code.Append($"{VIPUtilsClass}.PositionRef.{node.Ref},");
            node.StringData.Accept(this); Code.Append(',');
            node.CharCount.Accept(this); Code.Append(',');
            node.BaseList.Accept(this); Code.Append(',');
            node.ScaleX.Accept(this); Code.Append(',');
            node.ScaleY.Accept(this); Code.Append(',');
            node.SpaceX.Accept(this);
            if (node.SpaceY != null)
            {
                Code.Append(',');
                node.SpaceY.Accept(this);
            }
            Code.AppendLine(");");
        }
    }
}
