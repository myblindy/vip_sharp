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
            var defs = new NonTerminal("defs", typeof(VIPDefsNode));
            var def = new NonTerminal("def", typeof(VIPDefNode));

            var commands = new NonTerminal("commands", typeof(VIPCommandsNode));
            var command = new NonTerminal("command", typeof(VIPCommandNode));
            var translatecommand = new NonTerminal("translatecommand", typeof(VIPTranslateCommandNode));
            var scalecommand = new NonTerminal("scalecommand", typeof(VIPScaleCommandNode));
            var fullvariabledefinition = new NonTerminal("fullvariabledefinition", typeof(VIPFullVariableDefinitionNode));
            var polygoncommand = new NonTerminal("polygoncommand", typeof(VIPPolygonCommandNode));
            var rotatecommand = new NonTerminal("rotatecommand", typeof(VIPRotateCommandNode));
            var assignmentcommand = new NonTerminal("assignmentcommand", typeof(VIPAssignmentCommandNode));
            var returncommand = new NonTerminal("returncommand", typeof(VIPReturnCommandNode));

            var variabledefinitions = new NonTerminal("variabledefinitions", typeof(VIPVariableDefinitionsNode));
            var variabledefinition = new NonTerminal("variabledefinition", typeof(VIPVariableDefinitionNode));
            var typedefinition = new NonTerminal("typedefinition", typeof(VIPTypeDefinitionNode));
            var functiondefinition = new NonTerminal("functiondefinition", typeof(VIPFunctionDefinitionNode));

            var expressionlist = new NonTerminal("expressionlist", typeof(VIPNumberListNode));
            var functiondefinitionargumentlist = new NonTerminal("functiondefinitionargumentlist", typeof(VIPFunctionDefinitionArgumentListNode));

            var functiondefinitionargument = new NonTerminal("functiondefinitionargument", typeof(VIPFunctionDefinitionArgument));

            var expr = new NonTerminal("Expr", typeof(VIPExpressionNode));
            var binop = new NonTerminal("BinOp", typeof(VIPOperatorNode));
            var unop = new NonTerminal("UnOp", typeof(VIPOperatorNode));

            var number = new NumberLiteral("number", NumberOptions.AllowSign | NumberOptions.AllowStartEndDot);
            number.AstConfig.NodeType = typeof(VIPNumberNode);
            var identifier = new IdentifierTerminal("identifier");
            identifier.AstConfig.NodeType = typeof(VIPIdentifierNode);

            program.Rule = defs + main;
            main.Rule = ToTerm("main") + "{" + commands + "}";
            defs.Rule = MakeStarRule(defs, null, def);
            def.Rule = typedefinition | fullvariabledefinition | functiondefinition;

            commands.Rule = MakePlusRule(commands, null, command);
            command.Rule = translatecommand | scalecommand | fullvariabledefinition | polygoncommand
                | rotatecommand | assignmentcommand | returncommand;
            translatecommand.Rule = ToTerm("translate") + "(" + expr + "," + expr + ")" + ";";
            scalecommand.Rule = ToTerm("scale") + "(" + expr + ")" + ";";
            fullvariabledefinition.Rule =
                (identifier + identifier + "[" + expr + "]" + "=" + "{" + expressionlist + "}" + ";")
                | (identifier + identifier + "[" + expr + "]" + ";")
                | (identifier + identifier + "=" + expr + ";")
                | (identifier + identifier + ";");
            polygoncommand.Rule = ToTerm("polygon") + "{" + identifier + "," + identifier + "}" + ";";
            rotatecommand.Rule = ToTerm("rotate") + "(" + expr + ")" + ";";
            assignmentcommand.Rule = identifier + "=" + expr + ";";
            functiondefinition.Rule = ToTerm("function") + identifier + identifier + "(" + functiondefinitionargumentlist + ")" + "{" + commands + "}";
            returncommand.Rule = "return" + expr + ";";

            variabledefinitions.Rule = MakePlusRule(variabledefinitions, null, variabledefinition);
            variabledefinition.Rule = identifier + identifier + ";";
            typedefinition.Rule = ToTerm("typedef") + identifier + "{" + variabledefinitions + "}";

            expressionlist.Rule = MakeStarRule(expressionlist, ToTerm(","), expr);
            functiondefinitionargumentlist.Rule = MakeStarRule(functiondefinitionargumentlist, ToTerm(","), functiondefinitionargument);

            functiondefinitionargument.Rule = identifier + identifier;

            expr.Rule = identifier + "(" + expressionlist + ")"
                | number | identifier | expr + binop + expr | unop + expr | "(" + expr + ")";
            binop.Rule = ToTerm("-") | "+" | "*" | "/" | "|" | "&" | "||" | "&&" | ".AND." | ".OR.";
            unop.Rule = ToTerm("-") | "+" | "!" | "~";

            // grammar setup
            Root = program;
            MarkPunctuation("{", "}", "(", ")", ",", ";");
            //MarkTransient();
            LanguageFlags |= LanguageFlags.CreateAst;
            NonGrammarTerminals.Add(
                new CommentTerminal("line-comment", "//",
                    "\r", "\n", "\u2085", "\u2028", "\u2029"));

            // operator precedence
            RegisterOperators(1, "+", "-");
            RegisterOperators(2, "*", "/");
            RegisterOperators(3, "|", "&");
            RegisterOperators(4, "||", "&&", ".AND.", ".OR.");
            RegisterOperators(5, "!");
            RegisterOperators(6, "~");
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
        void Visit(VIPDefsNode node);
        void Visit(VIPTypeDefinitionNode node);
        void Visit(VIPVariableDefinitionNode node);
        void Visit(VIPVariableDefinitionsNode node);
        void Visit(VIPIdentifierNode node);
        void Visit(VIPFullVariableDefinitionNode node);
        void Visit(VIPNumberListNode node);
        void Visit(VIPPolygonCommandNode node);
        void Visit(VIPExpressionNode node);
        void Visit(VIPOperatorNode node);
        void Visit(VIPDefNode vIPDefNode);
        void Visit(VIPRotateCommandNode vIPRotateCommandNode);
        void Visit(VIPAssignmentCommandNode vIPAssignmentCommandNode);
        void Visit(VIPFunctionDefinitionNode vIPFunctionDefinitionNode);
        void Visit(VIPFunctionDefinitionArgumentListNode vIPFunctionDefinitionArgumentListNode);
        void Visit(VIPFunctionDefinitionArgument vIPFunctionDefinitionArgument);
        void Visit(VIPReturnCommandNode vIPReturnCommandNode);
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

    public class VIPDefsNode : VIPNode
    {
        public override void Accept(IVIPNodeVisitor visitor) => visitor.Visit(this);

        public override void InitChildren(ParseTreeNodeList nodes) => AddChild(nodes.Select(n => n.ChildNodes[0]));
    }

    public class VIPDefNode : VIPNode
    {
        public override void Accept(IVIPNodeVisitor visitor) => visitor.Visit(this);
    }

    public class VIPTypeDefinitionNode : VIPNode
    {
        public override void Accept(IVIPNodeVisitor visitor) => visitor.Visit(this);

        public override void InitChildren(ParseTreeNodeList nodes)
        {
            Name = nodes[1].Token.ValueString;
            AddChild(nodes[2].ChildNodes);
        }

        public string Name;
    }

    public class VIPFullVariableDefinitionNode : VIPNode
    {
        public override void Accept(IVIPNodeVisitor visitor) => visitor.Visit(this);

        public override void InitChildren(ParseTreeNodeList nodes)
        {
            Type = nodes[0].Token.ValueString;
            Name = nodes[1].Token.ValueString;
            if (nodes.Count > 2 && nodes[2].Token.ValueString == "[")
            {
                ArraySize = (VIPExpressionNode)nodes[3].AstNode;

                if (nodes[5].Token.ValueString == "=")
                    InitValues = nodes[6].ChildNodes.Select(n => (VIPExpressionNode)n.AstNode).ToArray();
            }
            else if (nodes.Count > 2 && nodes[2].Token.ValueString == "=")
                InitValue = (VIPExpressionNode)nodes[3].AstNode;
        }

        public string Type;
        public string Name;
        public VIPExpressionNode ArraySize;
        public VIPExpressionNode InitValue;
        public VIPExpressionNode[] InitValues;
    }

    public class VIPVariableDefinitionsNode : VIPNode
    {
        public override void Accept(IVIPNodeVisitor visitor) => visitor.Visit(this);

        public override void InitChildren(ParseTreeNodeList nodes) => AddChild(nodes);
    }

    public class VIPFunctionDefinitionArgumentListNode : VIPNode
    {
        public override void Accept(IVIPNodeVisitor visitor) => visitor.Visit(this);

        public override void InitChildren(ParseTreeNodeList nodes) => AddChild(nodes);
    }

    public class VIPFunctionDefinitionArgument : VIPNode
    {
        public override void Accept(IVIPNodeVisitor visitor) => visitor.Visit(this);

        public override void InitChildren(ParseTreeNodeList nodes) => AddChild(nodes);
    }

    public class VIPFunctionDefinitionNode : VIPNode
    {
        public override void Accept(IVIPNodeVisitor visitor) => visitor.Visit(this);

        public override void InitChildren(ParseTreeNodeList nodes)
        {
            Type = nodes[1].Token.ValueString;
            Name = nodes[2].Token.ValueString;
            Arguments = ((VIPFunctionDefinitionArgumentListNode)nodes[3].AstNode).ChildNodes
                .Select(n => Tuple.Create(((VIPIdentifierNode)n.ChildNodes[0]).Name, ((VIPIdentifierNode)n.ChildNodes[1]).Name))
                .ToArray();
            AddChild(nodes[4].ChildNodes.Select(n => n.ChildNodes[0]));
        }

        public string Type, Name;
        public Tuple<string, string>[] Arguments;
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

    public class VIPExpressionNode : VIPNode
    {
        public override void Accept(IVIPNodeVisitor visitor) => visitor.Visit(this);

        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            AddChild(treeNode.ChildNodes);
        }
    }

    public class VIPOperatorNode : VIPNode
    {
        public override void Accept(IVIPNodeVisitor visitor) => visitor.Visit(this);

        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            Operator = treeNode.ChildNodes[0].Token.ValueString;
        }

        public string Operator { get; set; }
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
            X = (VIPExpressionNode)nodes[1].AstNode;
            Y = (VIPExpressionNode)nodes[2].AstNode;
        }

        public VIPExpressionNode X, Y;
    }

    public class VIPScaleCommandNode : VIPNode
    {
        public override void Accept(IVIPNodeVisitor visitor) => visitor.Visit(this);

        public override void InitChildren(ParseTreeNodeList nodes)
        {
            Scale = (VIPExpressionNode)nodes[1].AstNode;
        }

        public VIPExpressionNode Scale;
    }

    public class VIPRotateCommandNode : VIPNode
    {
        public override void Accept(IVIPNodeVisitor visitor) => visitor.Visit(this);

        public override void InitChildren(ParseTreeNodeList nodes)
        {
            Angle = (VIPExpressionNode)nodes[1].AstNode;
        }

        public VIPExpressionNode Angle;
    }

    public class VIPReturnCommandNode : VIPNode
    {
        public override void Accept(IVIPNodeVisitor visitor) => visitor.Visit(this);

        public override void InitChildren(ParseTreeNodeList nodes)
        {
            Expression = (VIPExpressionNode)nodes[1].AstNode;
        }

        public VIPExpressionNode Expression;
    }

    public class VIPAssignmentCommandNode : VIPNode
    {
        public override void Accept(IVIPNodeVisitor visitor) => visitor.Visit(this);

        public override void InitChildren(ParseTreeNodeList nodes)
        {
            Variable = (VIPIdentifierNode)nodes[0].AstNode;
            Expression = (VIPExpressionNode)nodes[2].AstNode;
        }

        public VIPIdentifierNode Variable;
        public VIPExpressionNode Expression;
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
