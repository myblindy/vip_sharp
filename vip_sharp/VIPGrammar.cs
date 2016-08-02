using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Irony.Ast;
using Irony.Interpreter.Ast;
using Irony.Parsing;

namespace vip_sharp
{
    public class VIPGrammar : Grammar
    {
        public VIPGrammar() : base(false)
        {
            // grammar
            var program = new NonTerminal("program", typeof(VIPProgramNode));

            var main = new NonTerminal("main", typeof(VIPMainNode));
            var typedefs = new NonTerminal("typedefs", typeof(VIPTypedefsNode));
            var typedef = new NonTerminal("typedef", typeof(VIPTypedefNode));

            var commands = new NonTerminal("commands", typeof(VIPCommandsNode));
            var command = new NonTerminal("command", typeof(VIPCommandNode));
            var translatecommand = new NonTerminal("translatecommand", typeof(VIPTranslateCommandNode));
            var scalecommand = new NonTerminal("scalecommand", typeof(VIPScaleCommandNode));
            var fnvariabledefinition = new NonTerminal("fnvariabledefinition", typeof(VIPFnVariableDefinitionNode));
            var polygoncommand = new NonTerminal("polygoncommand", typeof(VIPPolygonCommandNode));

            var variabledefinitions = new NonTerminal("variabledefinitions", typeof(VIPVariableDefinitionsNode));
            var variabledefinition = new NonTerminal("variabledefinition", typeof(VIPVariableDefinitionNode));

            var numberlist = new NonTerminal("numberlist", typeof(VIPNumberListNode));

            var number = new NumberLiteral("number", NumberOptions.AllowSign | NumberOptions.AllowStartEndDot);
            number.AstConfig.NodeType = typeof(VIPNumberNode);
            var identifier = new IdentifierTerminal("identifier");
            identifier.AstConfig.NodeType = typeof(VIPIdentifierNode);

            program.Rule = typedefs + main;
            main.Rule = ToTerm("main") + "{" + commands + "}";
            typedefs.Rule = MakeStarRule(typedefs, null, typedef);
            typedef.Rule = ToTerm("typedef") + identifier + "{" + variabledefinitions + "}";

            commands.Rule = MakePlusRule(commands, null, command);
            command.Rule = translatecommand | scalecommand | fnvariabledefinition | polygoncommand;
            translatecommand.Rule = ToTerm("translate") + "(" + number + "," + number + ")" + ";";
            scalecommand.Rule = ToTerm("scale") + "(" + number + ")" + ";";
            fnvariabledefinition.Rule =
                (identifier + identifier + "[" + number + "]" + "=" + "{" + numberlist + "}" + ";")
                | (identifier + identifier + "[" + number + "]" + ";")
                | (identifier + identifier + "=" + number + ";")
                | (identifier + identifier + ";");
            polygoncommand.Rule = ToTerm("polygon") + "{" + identifier + "," + identifier + "}" + ";";

            variabledefinitions.Rule = MakePlusRule(variabledefinitions, null, variabledefinition);
            variabledefinition.Rule = (ToTerm("double")) + identifier + ";";

            numberlist.Rule = MakePlusRule(numberlist, ToTerm(","), number);

            // grammar setup
            Root = program;
            MarkPunctuation("{", "}", "(", ")", ",", ";");
            //MarkTransient();
            LanguageFlags |= LanguageFlags.CreateAst;
        }
    }

    public interface IVIPNodeVisitor
    {
        void Visit(VIPProgramNode node);
        void Visit(VIPCommandsNode node);
        void Visit(VIPCommandNode node);
        void Visit(VIPStringNode node);
        void Visit(VIPTranslateCommandNode node);
        void Visit(VIPScaleCommandNode node);
        void Visit(VIPNumberNode node);
        void Visit(VIPMainNode node);
        void Visit(VIPTypedefsNode node);
        void Visit(VIPTypedefNode node);
        void Visit(VIPVariableDefinitionNode node);
        void Visit(VIPVariableDefinitionsNode node);
        void Visit(VIPIdentifierNode node);
        void Visit(VIPFnVariableDefinitionNode node);
        void Visit(VIPNumberListNode node);
        void Visit(VIPPolygonCommandNode vIPPolygonCommandNode);
    }

    public abstract class VIPNode : AstNode
    {
        public abstract void Accept(IVIPNodeVisitor visitor);

        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);

            var nodes = treeNode.GetMappedChildNodes();
            InitChildren(nodes);
        }

        public virtual void InitChildren(ParseTreeNodeList nodes) { }

        protected void AddChild(IEnumerable<ParseTreeNode> nodes)
        {
            foreach (var node in nodes)
                if (node.AstNode != null)
                    AddChild("", node);
        }
    }

    public class VIPProgramNode : VIPNode
    {
        public override void Accept(IVIPNodeVisitor visitor) => visitor.Visit(this);

        public override void InitChildren(ParseTreeNodeList nodes) => AddChild(nodes);
    }

    public class VIPTypedefsNode : VIPNode
    {
        public override void Accept(IVIPNodeVisitor visitor) => visitor.Visit(this);

        public override void InitChildren(ParseTreeNodeList nodes) => AddChild(nodes);
    }

    public class VIPTypedefNode : VIPNode
    {
        public override void Accept(IVIPNodeVisitor visitor) => visitor.Visit(this);

        public override void InitChildren(ParseTreeNodeList nodes)
        {
            Name = nodes[1].Token.ValueString;
            AddChild(nodes[2].ChildNodes);
        }

        public string Name;
    }

    public class VIPFnVariableDefinitionNode : VIPNode
    {
        public override void Accept(IVIPNodeVisitor visitor) => visitor.Visit(this);

        public override void InitChildren(ParseTreeNodeList nodes)
        {
            Type = nodes[0].Token.ValueString;
            Name = nodes[1].Token.ValueString;
            if (nodes[2].Token.ValueString == "[")
            {
                ArraySize = Convert.ToInt32(nodes[3].Token.Value);

                if (nodes[5].Token.ValueString == "=")
                    InitValues = nodes[6].ChildNodes;
            }
            else if (nodes[2].Token.ValueString == "=")
                InitValue = nodes[4];
        }

        public string Type;
        public string Name;
        public int? ArraySize;
        public ParseTreeNode InitValue;
        public ParseTreeNodeList InitValues;
    }

    public class VIPVariableDefinitionsNode : VIPNode
    {
        public override void Accept(IVIPNodeVisitor visitor) => visitor.Visit(this);

        public override void InitChildren(ParseTreeNodeList nodes) => AddChild(nodes);
    }

    public class VIPNumberListNode : VIPNode
    {
        public override void Accept(IVIPNodeVisitor visitor) => visitor.Visit(this);

        public override void InitChildren(ParseTreeNodeList nodes) => AddChild(nodes);
    }

    public class VIPVariableDefinitionNode : VIPNode
    {
        public override void Accept(IVIPNodeVisitor visitor) => visitor.Visit(this);

        public override void InitChildren(ParseTreeNodeList nodes)
        {
            Type = nodes[0].Token.ValueString;
            Identifier = nodes[1].Token.ValueString;
        }

        public string Type;
        public string Identifier;
    }

    public class VIPCommandsNode : VIPNode
    {
        public override void Accept(IVIPNodeVisitor visitor) => visitor.Visit(this);
    }

    public class VIPMainNode : VIPNode
    {
        public override void Accept(IVIPNodeVisitor visitor) => visitor.Visit(this);

        public override void InitChildren(ParseTreeNodeList nodes) => AddChild(nodes[1].ChildNodes.Select(n => n.ChildNodes[0]));
    }

    public class VIPCommandNode : VIPNode
    {
        public override void Accept(IVIPNodeVisitor visitor) => visitor.Visit(this);
    }

    public class VIPStringNode : VIPNode
    {
        public override void Accept(IVIPNodeVisitor visitor) => visitor.Visit(this);

        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            AsString = Value = treeNode.Token.ValueString;
        }

        public string Value { get; set; }
    }

    public class VIPNumberNode : VIPNode
    {
        public override void Accept(IVIPNodeVisitor visitor) => visitor.Visit(this);

        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            Value = Convert.ToDouble(treeNode.Token.ValueString);
        }

        public double Value { get; set; }
    }

    public class VIPIdentifierNode : VIPNode
    {
        public override void Accept(IVIPNodeVisitor visitor) => visitor.Visit(this);

        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            Name = treeNode.Token.ValueString;
        }

        public string Name { get; set; }
    }

    public class VIPTranslateCommandNode : VIPNode
    {
        public override void Accept(IVIPNodeVisitor visitor) => visitor.Visit(this);

        public override void InitChildren(ParseTreeNodeList nodes)
        {
            AddChild("", nodes[1]);
            AddChild("", nodes[2]);
        }
    }

    public class VIPScaleCommandNode : VIPNode
    {
        public override void Accept(IVIPNodeVisitor visitor) => visitor.Visit(this);

        public override void InitChildren(ParseTreeNodeList nodes)
        {
            AddChild("", nodes[1]);
        }
    }

    public enum VIPPolygonType { WithArrays };

    public class VIPPolygonCommandNode : VIPNode
    {
        public override void Accept(IVIPNodeVisitor visitor) => visitor.Visit(this);

        public override void InitChildren(ParseTreeNodeList nodes)
        {
            if (nodes[2].AstNode is VIPIdentifierNode && nodes[1].AstNode is VIPIdentifierNode)
            {
                Type = VIPPolygonType.WithArrays;
                VerticesIdentifier = nodes[1].Token.ValueString;
                ColorsIdentifier = nodes[2].Token.ValueString;
            }
        }

        public VIPPolygonType Type;
        public string VerticesIdentifier, ColorsIdentifier;
    }
}
