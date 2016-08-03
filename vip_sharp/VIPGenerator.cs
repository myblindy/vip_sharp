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

        private const string VIPUtilsClass = "vip_sharp.VIPUtils.Instance";

        class TypedefDataClass
        {
            internal string Name;
            internal string[] Fields;
        }
        Dictionary<string, TypedefDataClass> Typedefs = new Dictionary<string, TypedefDataClass>(StringComparer.OrdinalIgnoreCase);
        HashSet<string> ValueTypes = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { "double" };

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

        public void Visit(VIPTypedefsNode node)
        {
            foreach (VIPNode typedef in node.ChildNodes)
                typedef.Accept(this);
        }

        public void Visit(VIPVariableDefinitionNode node)
        {
            var prefix = ValueTypes.Contains(node.Type) ? "" : "__typedef_";
            Code.AppendLine($"public {prefix}{node.Type} __{node.Identifier};");
        }

        public void Visit(VIPIdentifierNode node)
        {
        }

        public void Visit(VIPNumberListNode node)
        {
        }

        public void Visit(VIPFnVariableDefinitionNode node)
        {
            var valuetype = ValueTypes.Contains(node.Type);
            var prefix = valuetype ? "" : "__typedef_";
            if (node.ArraySize.HasValue)
            {
                Code.AppendLine($"var __{node.Name} = new {prefix}{node.Type}[{node.ArraySize}];");
                if (node.InitValues != null)
                {
                    var fields = Typedefs[node.Type].Fields;
                    var itemsintype = fields.Length;
                    for (int idx = 0; idx < node.InitValues.Count; idx += itemsintype)
                    {
                        var initlist = string.Join(",", fields.Select((f, i) => $"__{f} = " + Convert.ToDouble(node.InitValues[idx + i].Token.Value)));
                        Code.AppendLine($"__{node.Name}[{idx / itemsintype}] = new {prefix}{node.Type} {{ {initlist} }};");
                    }
                }
            }
            else if (!valuetype)
            {
                if (node.InitValues != null)
                {
                    var fields = Typedefs[node.Type].Fields;
                    var init = fields.Select((f, i) => f + " = " + Convert.ToDouble(node.InitValues[i].Token.Value));
                    Code.AppendLine($"var __{node.Name} = new {prefix}{node.Type} {{ {init} }};");
                }
                else
                    Code.AppendLine($"var __{node.Name} = new {prefix}{node.Type};");
            }
            else
            {
                Code.AppendLine($"{prefix}{node.Type} __{node.Name};");
                if (node.InitValue != null)
                    Code.AppendLine($"__{node.Name} = {node.InitValue.Token.Value};");
            }
        }

        public void Visit(VIPVariableDefinitionsNode node)
        {
        }

        public void Visit(VIPTypedefNode node)
        {
            Typedefs.Add(node.Name, new TypedefDataClass
            {
                Name = node.Name,
                Fields = node.ChildNodes.Cast<VIPVariableDefinitionNode>().Select(n => n.Identifier).ToArray()
            });

            Code.AppendLine($"public class __typedef_{node.Name} {{ ");
            foreach (VIPNode defnode in node.ChildNodes)
                defnode.Accept(this);
            Code.AppendLine("}");
        }

        public void Visit(VIPMainNode node)
        {
            Code.AppendLine("public class __MainClass { public void Run() {");
            foreach (VIPNode command in node.ChildNodes)
                command.Accept(this);
            Code.AppendLine("} }");
        }

        public void Visit(VIPTranslateCommandNode node)
        {
            Code.Append($"{VIPUtilsClass}.Translate(");
            ((VIPNode)node.ChildNodes[0]).Accept(this);
            Code.Append(", ");
            ((VIPNode)node.ChildNodes[1]).Accept(this);
            Code.AppendLine(");");
        }

        public void Visit(VIPScaleCommandNode node)
        {
            Code.Append($"{VIPUtilsClass}.Scale(");
            ((VIPNode)node.ChildNodes[0]).Accept(this);
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
            Code.AppendLine("using System; ");
            foreach (VIPNode entry in node.ChildNodes)
                entry.Accept(this);
        }

        public void Visit(VIPPolygonCommandNode node)
        {
            if (node.Type == VIPPolygonType.WithArrays)
                Code.AppendLine($"{VIPUtilsClass}.Polygon(__{node.VerticesIdentifier}, __{node.ColorsIdentifier});");
        }

        public void Visit(VIPExpressionNode node)
        {
            foreach (VIPNode subnode in node.ChildNodes)
                subnode.Accept(this);
        }

        public void Visit(VIPOperatorNode node)
        {
            switch (node.Operator)
            {
                case ".AND.":
                    Code.Append("&&");
                    break;
                case ".OR.":
                    Code.Append("||");
                    break;
                default:
                    Code.Append(node.Operator);
                    break;
            }
        }
    }
}
