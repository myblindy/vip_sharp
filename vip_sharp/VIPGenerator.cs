using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static vip_sharp.VIPRuntime;

namespace vip_sharp
{
    public partial class VIPGenerator : IVIPNodeVisitor
    {
        public ContinuationStringBuilder Code = new ContinuationStringBuilder();
        private MyStringBuilder ConstructorCode = null;
        private Stack<MyStringBuilder> ConstructorCodeStack = new Stack<MyStringBuilder>();
        private MyStringBuilder ConstructorArgsCode = null;
        private Stack<MyStringBuilder> ConstructorArgsCodeStack = new Stack<MyStringBuilder>();
        private bool BuildConstructorArgs = false;
        private bool BuildConstructor = false;
        private bool InObjectDefinition = false;
        private Dictionary<string, ContinuationStringBuilder.Range> ObjectRanges = new Dictionary<string, ContinuationStringBuilder.Range>();
        private uint LastObjectID = 0;
        private List<Tuple<string[], string, bool>> FunctionArguments = new List<Tuple<string[], string, bool>>();

        private const string VIPRuntimeClass = "vip_sharp.VIPRuntime";
        private const string VIPRuntimeInstance = VIPRuntimeClass + ".Instance";
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
        HashSet<string> ValueTypes = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { "double", "float", "int", "bool", "true", "false", "char" };

        public VIPGenerator()
        {
            CurrentSymbolRoot = SymbolsRoot;
            AddBuiltInTypeSymbol("double");
            AddBuiltInTypeSymbol("int");
            AddBuiltInTypeSymbol("float");
            AddBuiltInTypeSymbol("bool");
            AddBuiltInTypeSymbol("char");
        }

        bool IsValueType(VIPTypeIdentifierNode node) => node.Parts.Length == 1 && ValueTypes.Contains(node.Parts[0]);

        string PrefixForValueType(bool valuetype) => valuetype ? "" : "__";

        string LastObjectName;

        private string GetValue(VIPNode node)
        {
            var sb = Code;

            Code = new ContinuationStringBuilder();
            bool oldbc = BuildConstructor, oldbca = BuildConstructorArgs, iod = InObjectDefinition;
            BuildConstructor = BuildConstructorArgs = InObjectDefinition = false;
            node.Accept(this);
            var s = Code.ToString();

            Code = sb;
            BuildConstructor = oldbc; BuildConstructorArgs = oldbca; InObjectDefinition = iod;

            return s;
        }

        public void Visit(VIPStringNode node)
        {
        }

        public void Visit(VIPNumberNode node)
        {
            var code = BuildConstructor || InObjectDefinition ? ConstructorCode : Code;

            code.Append(node.Value);
        }

        public void Visit(VIPDefsNode node)
        {
            //InObjectDefinition = true;
            foreach (VIPNode typedef in node.ChildNodes)
                typedef.Accept(this);
            //InObjectDefinition = false;
        }

        public void Visit(VIPVariableDefinitionNode node)
        {
            var type = GetValue(node.Type);
            Code.AppendLine($"public {type} __{node.Identifier};");

            AddVariableSymbol(node.Identifier, type, false, 0);
        }

        public void Visit(VIPPlainIdentifierNode node)
        {
            Code.Append($"__{node.Name}");
        }

        void OutputQualifiedIdentifierPart(MyStringBuilder code, string name, VIPExpressionNode idx)
        {
            var prefix = ValueTypes.Contains(name) ? "" : "__";
            var n = name.EqualsI("system") ? $"{VIPRuntimeInstance}.VIPSystemClass" : prefix + name;
            code.Append(n);
            if (idx != null)
            {
                code.Append('[');
                idx.Accept(this);
                code.Append(']');
            }
        }

        public void Visit(VIPQualifiedIdentifierNode node)
        {
            var code = BuildConstructor || InObjectDefinition ? ConstructorCode : Code;

            // global?
            bool pointer = false;
            if (!node.Parts[0].Item1.EqualsI("system") && !node.Parts[0].Item1.EqualsI("true") && !node.Parts[0].Item1.EqualsI("false"))
            {
                var symbol = GetSymbolNode("__" + node.Parts[0].Item1);
                pointer = symbol.Details.TypePointer;
                if (symbol.Parent == SymbolsRoot && CurrentSymbolRoot != SymbolsRoot && symbol.SymbolType != SymbolType.Object)
                {
                    code.Append($"GlobalState.MainClass.");
                    //OutputQualifiedIdentifierPart(code, node.Parts[0].Item1, node.Parts[0].Item2);
                    //return;
                }
            }

            bool first = true;
            foreach (var part in node.Parts)
            {
                if (!first) code.Append('.');
                OutputQualifiedIdentifierPart(code, part.Item1, part.Item2);
                if (first && pointer) code.Append("[0]");
                first = false;
            }
        }

        public void Visit(VIPExpressionListNode node)
        {
            var code = BuildConstructor ? ConstructorCode : Code;

            bool first = true;
            foreach (VIPNode exprnode in node.ChildNodes)
            {
                if (first) first = false; else code.Append(',');
                exprnode.Accept(this);
            }
        }

        public void Visit(VIPFullVariableDefinitionNode node)
        {
            var initcode = InObjectDefinition ? ConstructorCode : Code;
            var type = GetValue(node.Type);
            var specifier = CurrentSymbolRoot.SymbolType != SymbolType.Function ? "public " : "";

            if (node.ArraySize != null || node.ArraySizeAuto)
            {
                Code.Append($"{specifier}{VIPArrayClass}<{type}> __{node.Name}");

                if (InObjectDefinition)
                {
                    Code.AppendLine(";");
                    initcode.Append($"this.__{ node.Name}");
                }

                initcode.Append($"= new {VIPArrayClass}<{type}>(");
                node.ArraySize?.Accept(this);

                if (node.InitValues != null)
                {
                    initcode.Append(") {");

                    var fields = Typedefs[node.Type.Parts].Fields;
                    var itemsintype = fields.Length;
                    for (int idx = 0; idx < node.InitValues.Length; idx += itemsintype)
                    {
                        if (idx != 0) initcode.Append(',');
                        initcode.Append($"new {type} {{");

                        for (int initvalidx = idx; initvalidx < idx + fields.Length; ++initvalidx)
                        {
                            if (initvalidx != idx) initcode.Append(',');
                            initcode.Append($"__{fields[initvalidx - idx]} = ");
                            node.InitValues[initvalidx].Accept(this);
                        }

                        initcode.Append('}');
                    }
                    initcode.Append('}');
                }
                else if (node.InitValue != null)
                {
                    if (node.ArraySize != null) initcode.Append(',');
                    node.InitValue.Accept(this);
                    initcode.Append(')');
                }
                else
                    initcode.Append(')');
                initcode.AppendLine(";");

                AddVariableSymbol("__" + node.Name, type, false, 1);
            }
            else if (!IsValueType(node.Type))
            {
                if (node.InitValues != null)
                {
                    var fields = Typedefs[node.Type.Parts].Fields;
                    Code.Append($"{specifier}{type} __{node.Name}");

                    if (InObjectDefinition)
                    {
                        Code.AppendLine(";");
                        initcode.Append($"this.__{node.Name}");
                    }

                    initcode.Append($"= new {type} {{");

                    for (int initvalidx = 0; initvalidx < fields.Length; ++initvalidx)
                    {
                        if (initvalidx != 0) Code.Append(',');
                        initcode.Append(fields[initvalidx] + " = ");
                        node.InitValues[initvalidx].Accept(this);
                    }

                    initcode.AppendLine("};");

                    AddVariableSymbol("__" + node.Name, type, false, 0);
                }
                else
                {
                    Code.Append($"{specifier}{type} __{node.Name}");

                    if (InObjectDefinition)
                    {
                        Code.AppendLine(";");
                        initcode.Append($"this.__{node.Name}");
                    }

                    initcode.AppendLine($" = new {type}();");

                    AddVariableSymbol("__" + node.Name, type, false, 0);
                }
            }
            else
            {
                Code.Append($"{specifier}{type} __{node.Name}");

                if (InObjectDefinition)
                {
                    Code.AppendLine(";");
                    initcode.Append($"this.__{node.Name}");
                }

                initcode.Append(" = ");

                if (node.InitValue != null)
                    node.InitValue.Accept(this);
                else
                {
                    // try to figure out what to initialize this thing with
                    if (node.Type.Parts[0].EqualsI("bool"))
                        initcode.Append("false");
                    else
                        initcode.Append('0');
                }
                initcode.AppendLine(";");

                AddVariableSymbol("__" + node.Name, type, false, 0);
            }
        }

        public void Visit(VIPVariableDefinitionsNode node)
        {
        }

        public void Visit(VIPTypeDefinitionNode node)
        {
            var iod = InObjectDefinition; InObjectDefinition = true;

            Typedefs.Add(new[] { node.Name }, new TypedefDataClass
            {
                Fields = node.ChildNodes.Cast<VIPVariableDefinitionNode>().Select(n => n.Identifier).ToArray()
            });

            AddTypeDefSymbolAndGoDown("__" + node.Name);

            Code.AppendLine($"public class __{node.Name} {{ ");
            foreach (VIPNode defnode in node.ChildNodes)
                defnode.Accept(this);
            Code.AppendLine("}");

            GoUpSymbol();

            InObjectDefinition = iod;
        }

        public void Visit(VIPMainNode node)
        {
            AddFunctionSymbol("entry", null, null);
            Code.AppendLine("public override void Run() {");
            foreach (VIPNode command in node.ChildNodes)
                command.Accept(this);
            Code.AppendLine("}");
            GoUpSymbol();
        }

        public void Visit(VIPTranslateCommandNode node)
        {
            var code = BuildConstructor ? ConstructorCode : Code;

            code.Append($"{VIPRuntimeInstance}.Translate(");
            node.X.Accept(this);
            code.Append(", ");
            node.Y.Accept(this);
            code.AppendLine(");");
        }

        public void Visit(VIPScaleCommandNode node)
        {
            var code = BuildConstructor ? ConstructorCode : Code;

            code.Append($"{VIPRuntimeInstance}.Scale(");
            node.Scale.Accept(this);
            code.AppendLine(");");
        }

        public void Visit(VIPRotateCommandNode node)
        {
            var code = BuildConstructor ? ConstructorCode : Code;

            code.Append($"{VIPRuntimeInstance}.Rotate(");
            node.Angle.Accept(this);
            code.AppendLine(");");
        }

        public void Visit(VIPCommandNode node)
        {
            foreach (VIPNode subnode in node.ChildNodes)
                subnode.Accept(this);
        }

        public void Visit(VIPCommandsNode node)
        {
            var code = BuildConstructor ? ConstructorCode : Code;

            code.AppendLine("{");
            foreach (VIPNode subnode in node.ChildNodes)
                subnode.Accept(this);
            code.AppendLine("}");
        }

        public void Visit(VIPProgramNode node)
        {
            Code.AppendLine("using System;");
            Code.AppendLine("public static class GlobalState { public static MainClass MainClass; }");
            Code.AppendLine("public class MainClass : vip_sharp.VIPRuntime.VIPObject {");
            Code.AppendLine("public MainClass() {");
            Code.AppendLine("GlobalState.MainClass = this;");
            ConstructorCode = Code.InsertContinuation();
            Code.AppendLine("}");
            foreach (VIPNode entry in node.ChildNodes)
                entry.Accept(this);
            Code.AppendLine("}");
        }

        public void Visit(VIPPolygonCommandNode node)
        {
            var code = BuildConstructor ? ConstructorCode : Code;

            if (node.VerticesIdentifier != null && node.ColorsIdentifier != null)
            {
                code.Append($"{VIPRuntimeInstance}.Polygon(");
                node.VerticesIdentifier.Accept(this);
                code.Append(",");
                node.ColorsIdentifier.Accept(this);
                code.AppendLine(");");
            }
        }

        public void Visit(VIPAssignmentCommandNode node)
        {
            var code = BuildConstructor ? ConstructorCode : Code;

            node.Variable.Accept(this);
            code.Append(" = ");
            node.Expression.Accept(this);
            code.AppendLine(";");
        }

        public void Visit(VIPExpressionNode node)
        {
            var code = BuildConstructor || InObjectDefinition ? ConstructorCode : Code;

            if (node.ChildNodes.Count == 2 && node.ChildNodes[0] is VIPQualifiedIdentifierNode && node.ChildNodes[1] is VIPExpressionListNode)
            {
                // special case for functions
                ((VIPNode)node.ChildNodes[0]).Accept(this);
                code.Append('(');

                var first = true;
                foreach (VIPNode argnode in node.ChildNodes[1].ChildNodes)
                {
                    if (first) first = false; else code.Append(',');
                    argnode.Accept(this);
                }
                code.Append(')');
            }
            else
                foreach (VIPNode subnode in node.ChildNodes)
                {
                    if (subnode.ChildNodes.Count > 1) code.Append('(');
                    subnode.Accept(this);
                    if (subnode.ChildNodes.Count > 1) code.Append(')');
                }
        }

        public void Visit(VIPOperatorNode node)
        {
            var code = BuildConstructor || InObjectDefinition ? ConstructorCode : Code;

            switch (node.Operator)
            {
                case ".and.":
                    code.Append("&&");
                    break;
                case ".or.":
                    code.Append("||");
                    break;
                default:
                    code.Append(node.Operator);
                    break;
            }
        }

        public void Visit(VIPDefNode node)
        {
        }

        public void Visit(VIPFunctionDefinitionNode node)
        {
            Code.Append("public ");
            if (node.Type == null) Code.Append("void"); else node.Type.Accept(this);
            Code.Append($" __{node.Name} (");

            bool first = true;
            FunctionArguments.Clear();
            foreach (var arg in node.Arguments)
            {
                if (first) first = false; else Code.Append(',');
                arg.Accept(this);
            }
            AddFunctionSymbol("__" + node.Name, node.Type == null ? null : "__" + node.Type.Parts[0], FunctionArguments);
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
            var code = BuildConstructorArgs ? ConstructorArgsCode : Code;

            var type = GetValue((VIPTypeIdentifierNode)node.ChildNodes[0]);
            var reference = ((VIPReferenceIdentifier)node.ChildNodes[1]).Available;
            var name = ((VIPPlainIdentifierNode)node.ChildNodes[2]).Name;

            if (reference) code.Append($"{VIPArrayClass}< ");
            code.Append(type);
            if (reference) code.Append(">");
            code.Append($" __{name}");

            FunctionArguments.Add(Tuple.Create(new[] { type }, "__" + name, reference));
        }

        public void Visit(VIPReturnCommandNode node)
        {
            var code = BuildConstructor ? ConstructorCode : Code;

            code.Append("return ");
            node.Expression.Accept(this);
            code.AppendLine(";");
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
            var code = BuildConstructorArgs ? ConstructorArgsCode : Code;

            bool first = true;
            if (IsValueType(node))
                code.Append($"{node.Parts[0]}");
            else
                foreach (var part in node.Parts)
                {
                    if (first) first = false; else code.Append('.');
                    code.Append($"__{part}");
                }
        }

        public void Visit(VIPBitmapResDefinitionNode node)
        {
            var initcode = /*BuildConstructor || InObjectDefinition ?*/ ConstructorCode /*: Code*/;
            var type = node.Type.EqualsI("RGB") ? "RGB"
                : node.Type.EqualsI("RGBA") ? "RGBA"
                : node.Type.EqualsI("HARD_MASK") ? "HardMask"
                : "SoftMask";
            var filter = node.Filter.EqualsI("LINEAR") ? "Linear"
                : node.Filter.EqualsI("NEAREST") ? "Nearest"
                : "MipMap";
            var clamp = node.ClampMode.EqualsI("CLAMP") ? "Clamp" : "Repeat";

            Code.Append($"public {VIPRuntimeClass}.BitmapRes __{node.Handle}");

            //if (InObjectDefinition)
            //{
            Code.AppendLine(";");
            initcode.Append($"__{node.Handle}");
            //}

            initcode.AppendLine($"= new {VIPRuntimeClass}.BitmapRes(" +
                $"{VIPRuntimeClass}.BitmapType.{type}, {VIPRuntimeClass}.BitmapFilter.{filter}, {VIPRuntimeClass}.BitmapClamp.{clamp}, " +
                "@\"" + node.Path + "\");");

            AddBitmapResSymbol("__" + node.Handle);
        }

        public void Visit(VIPPathIdentifierNode node)
        {
        }

        public void Visit(VIPBitmapCommandNode node)
        {
            var code = BuildConstructor ? ConstructorCode : Code;

            var blend = node.Blend.EqualsI("BLEND") ? "Blend"
                : node.Blend.EqualsI("MODULATE") ? "Modulate"
                : node.Blend.EqualsI("DECAL") ? "Decal"
                : "Replace";

            code.Append($"{VIPRuntimeInstance}.Bitmap(");
            node.Handle.Accept(this);
            code.Append($", {VIPRuntimeClass}.BitmapBlend.{blend}, ");
            node.X.Accept(this); code.Append(','); node.Y.Accept(this); code.Append(',');
            node.W.Accept(this); code.Append(','); node.H.Accept(this); code.Append(',');
            code.Append($"{VIPRuntimeClass}.PositionRef.{node.Ref}");
            if (node.UVCoords != null)
            {
                code.Append(',');
                node.UVCoords.Accept(this);
            }
            code.AppendLine(");");
        }

        public void Visit(VIPIfCommandNode node)
        {
            var code = BuildConstructor ? ConstructorCode : Code;

            code.Append("if(Convert.ToBoolean(");
            node.Test.Accept(this);
            code.AppendLine("))");
            foreach (VIPNode cmd in node.ChildNodes)
                cmd.Accept(this);

            if (node.ElseCommands != null)
            {
                code.AppendLine("else");
                foreach (var cmd in node.ElseCommands)
                    cmd.Accept(this);
            }
        }

        public void Visit(VIPObjectDefinitionNode node)
        {
            var r = new ContinuationStringBuilder.Range();
            r.MarkBeginning(Code);

            LastObjectName = node.Name;
            AddObjectSymbolAndGoDown("__" + node.Name);

            Code.AppendLine($"public class __{node.Name} : {VIPRuntimeClass}.VIPObject {{");

            Code.Append($"public __{node.Name}(");
            ConstructorArgsCodeStack.Push(ConstructorArgsCode); ConstructorArgsCode = Code.InsertContinuation();
            Code.AppendLine(") {");
            ConstructorCodeStack.Push(ConstructorCode); ConstructorCode = Code.InsertContinuation();
            Code.AppendLine("}");

            InObjectDefinition = true;
            foreach (var defnode in node.Definitions)
                ((VIPNode)defnode.ChildNodes[0].AstNode).Accept(this);
            InObjectDefinition = false;

            Code.AppendLine("}");

            ConstructorArgsCode = ConstructorArgsCodeStack.Pop();
            ConstructorCode = ConstructorCodeStack.Pop();

            GoUpSymbol();
            r.MarkEnding(Code);
            ObjectRanges.Add(node.Name, r);
        }

        public void Visit(VIPInstanceDefinitionNode node)
        {
            var type = GetValue(node.Object);
            Code.AppendLine($"public {type} __{node.Name};");
            ConstructorCode.Append($"__{node.Name} = new {type}(");

            bool first = true;
            var bc = BuildConstructor; BuildConstructor = true;
            if (node.ConstructorArguments != null)
                foreach (var constrarg in node.ConstructorArguments)
                {
                    if (first) first = false; else ConstructorCode.Append(',');
                    ((VIPNode)constrarg.AstNode).Accept(this);
                }

            ConstructorCode.Append(") { ");

            first = true;
            foreach (var argnode in node.SpecialArguments)
            {
                if (first) first = false; else ConstructorCode.Append(',');
                ((VIPNode)argnode.AstNode).Accept(this);
            }
            BuildConstructor = false;

            ConstructorCode.AppendLine("};");

            AddVariableSymbol("__" + node.Name, type, false, 0);
        }

        public void Visit(VIPNamedArgumentListNode node)
        {
            throw new NotImplementedException();
        }

        public void Visit(VIPNamedArgumentNode node)
        {
            var code = BuildConstructor ? ConstructorCode : Code;
            code.Append($"{node.Name} = ");
            node.Expression.Accept(this);
        }

        public void Visit(VIPDrawCommandNode node)
        {
            var code = BuildConstructor ? ConstructorCode : Code;

            code.Append($"{VIPRuntimeInstance}.Draw(");
            node.ObjectName.Accept(this);
            code.AppendLine(");");
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
            var code = BuildConstructor ? ConstructorCode : Code;
            bool first = true;

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
                    code.Append($"{VIPRuntimeInstance}.{sfn}(");

                    foreach (var argnode in node.Arguments)
                    {
                        if (first) first = false; else code.Append(',');
                        ((VIPNode)argnode.AstNode).Accept(this);
                    }

                    code.AppendLine(");");
                    return;
                }
            }

            // normal function call
            var symbol = GetSymbolNode(node.Name.Parts.Select(w => "__" + w.Item1).ToArray());
            code.AppendLine("{");

            // copy any pointers to "arrays"
            for (int idx = 0; idx < symbol.Arguments.Count; ++idx)
                if (symbol.Arguments[idx].Details.TypePointer)
                {
                    code.Append($"var _arg{idx} = new {VIPArrayClass}<");
                    AppendSymbolNode(code, symbol.Arguments[idx].Details.TypeNode);
                    code.Append(">(1) { ");
                    ((VIPNode)node.Arguments[idx].AstNode).Accept(this);
                    code.AppendLine(" };");
                }

            node.Name.Accept(this);
            code.Append('(');
            for (int idx = 0; idx < symbol.Arguments.Count; ++idx)
            {
                if (idx > 0) code.Append(',');
                if (symbol.Arguments[idx].Details.TypePointer)
                    code.Append($"_arg{idx}");
                else
                    ((VIPNode)node.Arguments[idx].AstNode).Accept(this);
            }
            code.AppendLine(");");

            // copy the pointer "arrays" back to their values
            for (int idx = 0; idx < symbol.Arguments.Count; ++idx)
                if (symbol.Arguments[idx].Details.TypePointer)
                {
                    ((VIPNode)node.Arguments[idx].AstNode).Accept(this);
                    code.Append($" = _arg{idx}[0];");
                }

            code.AppendLine("}");
        }

        static void AppendSymbolNode(MyStringBuilder sb, SymbolNode n)
        {
            sb.Append(n.Details.Name);
        }

        public void Visit(VIPStructDefinitionNode node)
        {
            AddStructSymbolAndGoDown("__" + node.Name);

            Code.AppendLine($"public class __struct_{node.Name} {{");
            foreach (VIPNode varnode in node.ChildNodes)
                varnode.Accept(this);
            Code.AppendLine("}");
            Code.AppendLine($"public __struct_{node.Name} __{node.Name}=new __struct_{node.Name}();");

            GoUpSymbol();
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
            InObjectDefinition = false;

            bool first = true;
            BuildConstructorArgs = true;
            FunctionArguments.Clear();
            foreach (var argnode in node.Arguments)
            {
                if (first) first = false; else ConstructorArgsCode.Append(',');
                ((VIPNode)argnode.AstNode).Accept(this);
            }
            BuildConstructorArgs = false;

            AddFunctionSymbol("init", null, FunctionArguments);

            BuildConstructor = true;
            foreach (VIPNode cmdnode in node.ChildNodes)
                cmdnode.Accept(this);
            BuildConstructor = false;

            GoUpSymbol();

            InObjectDefinition = true;
        }

        public void Visit(VIPObjectEntryDefinition node)
        {
            InObjectDefinition = false;
            AddFunctionSymbol("entry", null, null);
            Code.AppendLine("public override void Run() {");
            foreach (VIPNode cmdnode in node.ChildNodes)
                cmdnode.Accept(this);
            Code.AppendLine("}");
            GoUpSymbol();
            InObjectDefinition = true;
        }

        public void Visit(VIPColorCommandNode node)
        {
            var code = BuildConstructor ? ConstructorCode : Code;

            if (node.Save)
                code.AppendLine($"{VIPRuntimeInstance}.ColorSave();");
            else if (node.Restore)
                code.AppendLine($"{VIPRuntimeInstance}.ColorRestore();");
            else if (node.R != null && node.G != null && node.B != null)
            {
                code.Append($"{VIPRuntimeInstance}.Color(");
                node.R.Accept(this);
                code.Append(',');
                node.G.Accept(this);
                code.Append(',');
                node.B.Accept(this);
                if (node.A != null)
                {
                    code.Append(',');
                    node.A.Accept(this);
                }
                code.AppendLine(");");
            }
            else if (node.ArrayName != null)
            {
                code.Append($"{VIPRuntimeInstance}.Color(");
                node.ArrayName.Accept(this);
                code.AppendLine(");");
            }
            else
            {
                code.Append($"{VIPRuntimeInstance}.Color(");
                node.C.Accept(this);
                if (node.A != null)
                {
                    code.Append(',');
                    node.A.Accept(this);
                }
                code.AppendLine(");");
            }
        }

        public void Visit(VIPCircleCommandNode node)
        {
            var code = BuildConstructor ? ConstructorCode : Code;

            code.Append($"{VIPRuntimeInstance}.Circle(");
            node.X.Accept(this);
            code.Append(',');
            node.Y.Accept(this);
            code.Append(',');
            node.Radius.Accept(this);
            code.Append(',');
            node.Steps.Accept(this);
            code.AppendLine($",{node.Filled.ToString().ToLower()});");
        }

        public void Visit(VIPStringLiteralNode node)
        {
            Code.Append($"\"{node.Value}\"");
        }

        public void Visit(VIPMatrixCommandNode node)
        {
            var code = BuildConstructor ? ConstructorCode : Code;

            if (node.Type.EqualsI("save"))
                code.AppendLine($"{VIPRuntimeInstance}.MatrixSave();");
            else if (node.Type.EqualsI("restore"))
                code.AppendLine($"{VIPRuntimeInstance}.MatrixRestore();");
            else if (node.Type.EqualsI("identity"))
                code.AppendLine($"{VIPRuntimeInstance}.MatrixIdentity();");
        }

        public void Visit(VIPListDefinition node)
        {
            var bc = BuildConstructor; BuildConstructor = true;
            var initcode = BuildConstructor || InObjectDefinition ? ConstructorCode : Code;

            Code.Append($"public {VIPRuntimeClass}.DisplayList __{node.Name}");

            //if (InObjectDefinition)
            //{
            Code.AppendLine(";");
            initcode.Append($"__{node.Name}");
            //}

            initcode.AppendLine($" = new { VIPRuntimeClass }.DisplayList(() => {{");
            foreach (VIPNode cmdnode in node.ChildNodes)
                cmdnode.Accept(this);
            initcode.AppendLine("});");
            BuildConstructor = bc;

            AddDisplayListSymbol("__" + node.Name);
        }

        private static readonly Dictionary<string, string> ShapeFunctionMapping = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            { "line_strip", "LineStrip" },
            { "polygon", "Polygon" },
            { "quad", "Quad" },
            { "triangle", "Triangle" },
            { "line", "Line" },
            { "closed_line", "ClosedLine" },
            { "rotate", "Rotate" },
        };

        public void Visit(VIPShapeCommandNode node)
        {
            var code = BuildConstructor ? ConstructorCode : Code;

            var cmd = ShapeFunctionMapping[node.Command];
            code.Append($"{VIPRuntimeInstance}.{cmd}(");
            node.ExpressionList.Accept(this);
            code.AppendLine(");");
        }

        public void Visit(VIPStringCommandNode node)
        {
            Code.Append($"{VIPRuntimeInstance}.DrawString(");
            node.X.Accept(this); Code.Append(',');
            node.Y.Accept(this); Code.Append(',');
            Code.Append($"{VIPRuntimeClass}.PositionRef.{node.Ref},");
            node.StringData.Accept(this); Code.Append(',');
            node.CharCount.Accept(this); Code.Append(',');

            if (node.StringRes == null)
            {
                node.BaseList.Accept(this); Code.Append(',');
                node.ScaleX.Accept(this); Code.Append(',');
                node.ScaleY.Accept(this); Code.Append(',');
                node.SpaceX.Accept(this);
                if (node.SpaceY != null)
                {
                    Code.Append(',');
                    node.SpaceY.Accept(this);
                }
            }
            else
                node.StringRes.Accept(this);
            Code.AppendLine(");");
        }

        public void Visit(VIPHotSpotCommandNode node)
        {
            Code.Append($"{VIPRuntimeInstance}.HotSpot({++LastObjectID}, this,");
            node.X.Accept(this); Code.Append(',');
            node.Y.Accept(this); Code.Append(',');
            node.W.Accept(this); Code.Append(',');
            node.H.Accept(this); Code.Append(',');
            Code.Append($"{VIPRuntimeClass}.PositionRef.{node.Ref},");
            Code.Append("ref "); node.Var.Accept(this); Code.Append(',');
            Code.Append($"{VIPRuntimeClass}.HotSpotTrigger.{Enum.GetName(typeof(HotSpotTrigger), node.Trigger)},");
            Code.Append($"{VIPRuntimeClass}.HotSpotType.{Enum.GetName(typeof(HotSpotType), node.Type)},");
            node.TrueValue.Accept(this); Code.Append(',');
            node.FalseValue.Accept(this); Code.Append(',');
            Code.Append($"{VIPRuntimeClass}.HoverBox.{Enum.GetName(typeof(HoverBox), node.HoverBox)}");
            if (node.DisplayObject != null)
            {
                Code.Append(',');
                node.DisplayObject.Accept(this);
            }
            Code.AppendLine(");");
        }

        public void Visit(VIPFormatCommandNode node)
        {
            Code.Append($"{VIPRuntimeInstance}.Format(");
            node.Result.Accept(this); Code.Append(',');
            node.Format.Accept(this); Code.Append(',');
            node.Value.Accept(this);
            Code.AppendLine(");");
        }

        public void Visit(VIPRotaryKnobCommandNode node)
        {
            Code.Append($"{VIPRuntimeInstance}.RotaryKnob({++LastObjectID}, this,");
            node.X.Accept(this); Code.Append(',');
            node.Y.Accept(this); Code.Append(',');
            node.R.Accept(this); Code.Append(',');
            Code.Append("ref "); node.Var.Accept(this); Code.Append(',');
            node.StartAngle.Accept(this); Code.Append(',');
            node.EndAngle.Accept(this); Code.Append(',');
            node.MinValue.Accept(this); Code.Append(',');
            node.MaxValue.Accept(this); Code.Append(',');
            Code.Append($"{VIPRuntimeClass}.HoverBox.{Enum.GetName(typeof(HoverBox), node.HoverBox)},");
            node.WheelDelta.Accept(this);
            if (node.DisplayObject != null)
            {
                Code.Append(',');
                node.DisplayObject.Accept(this);
            }
            Code.AppendLine(");");
        }

        public void Visit(VIPLightCommandNode node)
        {
            if (node.On)
                Code.AppendLine($"{VIPRuntimeInstance}.LightOn();");
            else if (node.Off)
                Code.AppendLine($"{VIPRuntimeInstance}.LightOff();");
            else
            {
                Code.Append($"{VIPRuntimeInstance}.Light(");
                node.Intensity.Accept(this);
                Code.AppendLine(");");
            }
        }

        public void Visit(VIPLightColorCommandNode node)
        {
            var code = BuildConstructor ? ConstructorCode : Code;

            if (node.Save)
                code.AppendLine($"{VIPRuntimeInstance}.LightSave();");
            else if (node.Restore)
                code.AppendLine($"{VIPRuntimeInstance}.LightRestore();");
            else if (node.R != null && node.G != null && node.B != null)
            {
                code.Append($"{VIPRuntimeInstance}.LightColor(");
                node.R.Accept(this); code.Append(',');
                node.G.Accept(this); code.Append(',');
                node.B.Accept(this);
                if (node.A != null)
                {
                    code.Append(',');
                    node.A.Accept(this);
                }
                code.AppendLine(");");
            }
            else if (node.ArrayName != null)
            {
                code.Append($"{VIPRuntimeInstance}.LightColor(");
                node.ArrayName.Accept(this);
                code.AppendLine(");");
            }
            else
            {
                code.Append($"{VIPRuntimeInstance}.LightColor(");
                node.C.Accept(this);
                if (node.A != null)
                {
                    code.Append(',');
                    node.A.Accept(this);
                }
                code.AppendLine(");");
            }
        }

        public void Visit(VIPSliderCommandNode node)
        {
            Code.Append($"{VIPRuntimeInstance}.Slider({++LastObjectID}, this,");
            node.X.Accept(this); Code.Append(',');
            node.Y.Accept(this); Code.Append(',');
            node.W.Accept(this); Code.Append(',');
            node.H.Accept(this); Code.Append(',');
            Code.Append($"{VIPRuntimeClass}.PositionRef.{node.Ref},");
            node.Angle.Accept(this); Code.Append(',');
            Code.Append("ref "); node.Var.Accept(this); Code.Append(',');
            node.MinValue.Accept(this); Code.Append(',');
            node.MaxValue.Accept(this); Code.Append(',');
            Code.Append($"{VIPRuntimeClass}.HoverBox.{Enum.GetName(typeof(HoverBox), node.HoverBox)},");
            node.WheelDelta.Accept(this);
            if (node.DisplayObject != null)
            {
                Code.Append(',');
                node.DisplayObject.Accept(this);
            }
            Code.AppendLine(");");
        }

        public void Visit(VIPStringResDefinition node)
        {
            var bc = BuildConstructor; BuildConstructor = true;
            var initcode = /*BuildConstructor || InObjectDefinition ?*/ ConstructorCode /*: Code*/;

            Code.Append($"public {VIPRuntimeClass}.StringRes __{node.Handle}");

            //if (InObjectDefinition)
            //{
            Code.AppendLine(";");
            initcode.Append($"__{node.Handle}");
            //}

            initcode.Append($"= new {VIPRuntimeClass}.StringRes(");
            node.BaseList.Accept(this); initcode.Append(',');
            node.ScaleX.Accept(this); initcode.Append(',');
            node.ScaleY.Accept(this); initcode.Append(',');
            node.SpaceX.Accept(this);
            if (node.SpaceY != null)
            {
                initcode.Append(',');
                node.SpaceY.Accept(this);
            }
            initcode.AppendLine(");");
            BuildConstructor = bc;

            AddStringResSymbol("__" + node.Handle);
        }

        public void Visit(VIPReferenceLiteralNode vIPReferenceLiteralNode)
        {
            throw new NotImplementedException();
        }

        public void Visit(VIPReferenceIdentifier vIPReferenceIdentifier)
        {
            throw new NotImplementedException();
        }
    }
}
