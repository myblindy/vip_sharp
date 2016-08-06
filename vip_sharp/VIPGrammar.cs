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

            var objectdefs = new NonTerminal("objectdefs", typeof(VIPObjectDefsNode));
            var objectdef = new NonTerminal("objectdef", typeof(VIPObjectDefNode));

            var commands = new NonTerminal("commands", typeof(VIPCommandsNode));
            var command = new NonTerminal("command", typeof(VIPCommandNode));
            var translatecommand = new NonTerminal("translatecommand", typeof(VIPTranslateCommandNode));
            var scalecommand = new NonTerminal("scalecommand", typeof(VIPScaleCommandNode));
            var fullvariabledefinition = new NonTerminal("fullvariabledefinition", typeof(VIPFullVariableDefinitionNode));
            var polygoncommand = new NonTerminal("polygoncommand", typeof(VIPPolygonCommandNode));
            var rotatecommand = new NonTerminal("rotatecommand", typeof(VIPRotateCommandNode));
            var assignmentcommand = new NonTerminal("assignmentcommand", typeof(VIPAssignmentCommandNode));
            var returncommand = new NonTerminal("returncommand", typeof(VIPReturnCommandNode));
            var bitmapcommand = new NonTerminal("bitmapcommand", typeof(VIPBitmapCommandNode));
            var ifcommand = new NonTerminal("ifcommand", typeof(VIPIfCommandNode));
            var drawcommand = new NonTerminal("drawcommand", typeof(VIPDrawCommandNode));
            var functioncallcommand = new NonTerminal("functioncallcommand", typeof(VIPFunctionCallCommandNode));
            var colorcommand = new NonTerminal("colorcommand", typeof(VIPColorCommandNode));
            var circlecommand = new NonTerminal("circlecommand", typeof(VIPCircleCommandNode));

            var variabledefinitions = new NonTerminal("variabledefinitions", typeof(VIPVariableDefinitionsNode));
            var variabledefinition = new NonTerminal("variabledefinition", typeof(VIPVariableDefinitionNode));
            var typedefinition = new NonTerminal("typedefinition", typeof(VIPTypeDefinitionNode));
            var functiondefinition = new NonTerminal("functiondefinition", typeof(VIPFunctionDefinitionNode));
            var bitmapresdefinition = new NonTerminal("bitmapresdefinition", typeof(VIPBitmapResDefinitionNode));
            var objectdefinition = new NonTerminal("objectdefinition", typeof(VIPObjectDefinitionNode));
            var instancedefinition = new NonTerminal("instancedefinition", typeof(VIPInstanceDefinitionNode));
            var macrodefinition = new NonTerminal("macrodefinition", typeof(VIPMacroDefinitionNode));
            var structdefinition = new NonTerminal("structdefinition", typeof(VIPStructDefinitionNode));
            var objectinitdefinition = new NonTerminal("objectinitdefinition", typeof(VIPObjectInitDefinition));
            var objectentrydefinition = new NonTerminal("objectentrydefinition", typeof(VIPObjectEntryDefinition));

            var expressionlist = new NonTerminal("expressionlist", typeof(VIPExpressionListNode));
            var functiondefinitionargumentlist = new NonTerminal("functiondefinitionargumentlist", typeof(VIPFunctionDefinitionArgumentListNode));
            var namedargumentlist = new NonTerminal("namedargumentlist", typeof(VIPNamedArgumentListNode));
            var plainidentifierlist = new NonTerminal("plainidentifierlist", typeof(VIPPlainIdentifierListNode));

            var functiondefinitionargument = new NonTerminal("functiondefinitionargument", typeof(VIPFunctionDefinitionArgument));
            var namedargument = new NonTerminal("namedargument", typeof(VIPNamedArgumentNode));

            var identifier = new NonTerminal("identifier", typeof(VIPIdentifierNode));
            var qualifiedidentifier = new NonTerminal("qualifiedidentifier", typeof(VIPQualifiedIdentifierNode));
            var typeidentifier = new NonTerminal("typeidentifier", typeof(VIPTypeIdentifierNode));

            var expr = new NonTerminal("Expr", typeof(VIPExpressionNode));
            var binop = new NonTerminal("BinOp", typeof(VIPOperatorNode));
            var unop = new NonTerminal("UnOp", typeof(VIPOperatorNode));

            var number = new NumberLiteral("number", NumberOptions.AllowSign | NumberOptions.AllowStartEndDot);
            number.AstConfig.NodeType = typeof(VIPNumberNode);
            var plainidentifier = new IdentifierTerminal("plainidentifier");
            plainidentifier.AstConfig.NodeType = typeof(VIPPlainIdentifierNode);
            var pathidentifier = new IdentifierTerminal("pathidentifier", @" /\.");
            pathidentifier.AstConfig.NodeType = typeof(VIPPathIdentifierNode);

            program.Rule = defs + main;
            main.Rule = (ToTerm("main") + "{" + commands + "}") | ("main" + commands + "go");

            defs.Rule = MakeStarRule(defs, null, def);
            def.Rule = macrodefinition | structdefinition | bitmapresdefinition | typedefinition | fullvariabledefinition
                | functiondefinition | objectdefinition | instancedefinition;

            objectdefs.Rule = MakeStarRule(objectdefs, null, objectdef);
            objectdef.Rule = objectinitdefinition | objectentrydefinition | macrodefinition | structdefinition | bitmapresdefinition
                | typedefinition | fullvariabledefinition | functiondefinition | objectdefinition | instancedefinition;

            commands.Rule = MakePlusRule(commands, null, command);
            command.Rule = circlecommand | drawcommand | colorcommand | translatecommand | scalecommand | assignmentcommand
                | fullvariabledefinition | polygoncommand | rotatecommand | returncommand | bitmapcommand | ifcommand | functioncallcommand;
            translatecommand.Rule = ToTerm("translate") + "(" + expr + "," + expr + ")" + ";";
            scalecommand.Rule = ToTerm("scale") + "(" + expr + ")" + ";";
            fullvariabledefinition.Rule =
                (typeidentifier + plainidentifier + "[" + expr + "]" + "=" + "{" + expressionlist + "}" + ";")
                | (typeidentifier + plainidentifier + "[" + expr + "]" + ";")
                | (typeidentifier + plainidentifier + "=" + expr + ";")
                | (typeidentifier + plainidentifier + ";");
            polygoncommand.Rule = ToTerm("polygon") + "{" + qualifiedidentifier + "," + qualifiedidentifier + "}" + ";";
            rotatecommand.Rule = ToTerm("rotate") + "(" + expr + ")" + ";";
            assignmentcommand.Rule = qualifiedidentifier + "=" + expr + ";";
            functiondefinition.Rule = ToTerm("function") + typeidentifier + plainidentifier + "(" + functiondefinitionargumentlist + ")" + "{" + commands + "}";
            returncommand.Rule = "return" + expr + ";";
            bitmapcommand.Rule = ToTerm("bitmap") + "("
                + qualifiedidentifier + ","                                                     // handle
                + plainidentifier + ","                                                         // modulation
                + expr + "," + expr + "," + expr + "," + expr + "," + plainidentifier + ","     // x,y,w,h,ref
                + qualifiedidentifier + ")" + ";";                                              // vertices
            ifcommand.Rule = ToTerm("if") + "(" + expr + ")" + "{" + commands + "}";
            drawcommand.Rule = ToTerm("draw") + "(" + qualifiedidentifier + ")" + ";";
            functioncallcommand.Rule = qualifiedidentifier + "(" + expressionlist + ")" + ";";
            colorcommand.Rule = ToTerm("color") + "(" + qualifiedidentifier + ")" + ";";
            circlecommand.Rule = ToTerm("circle") + "(" + expr + "," + expr + "," + expr + "," + expr + "," + "fill" + ")" + ";"
                | ToTerm("circle") + "(" + expr + "," + expr + "," + expr + "," + expr + ")" + ";";


            variabledefinitions.Rule = MakePlusRule(variabledefinitions, null, variabledefinition);
            variabledefinition.Rule = typeidentifier + plainidentifier + ";";
            typedefinition.Rule = ToTerm("typedef") + plainidentifier + "{" + variabledefinitions + "}";
            bitmapresdefinition.Rule = ToTerm("bitmap_res") + "("
                + plainidentifier + ","                           // name
                + plainidentifier + ","                           // bitmap type
                + plainidentifier + ","                           // filter
                + plainidentifier + ","                           // clamp
                + pathidentifier + ")" + ";";                     // path
            objectdefinition.Rule = "object" + plainidentifier + "{" + objectdefs + "}";
            instancedefinition.Rule = "instance" + qualifiedidentifier + plainidentifier + "{" + namedargumentlist + "}" + ";";
            macrodefinition.Rule = ToTerm("macro") + plainidentifier + "(" + plainidentifierlist + ")" + "{" + commands + "}";
            structdefinition.Rule = "struct" + plainidentifier + "{" + variabledefinitions + "}";
            objectentrydefinition.Rule = ToTerm("entry") + "{" + commands + "}";
            objectinitdefinition.Rule = ToTerm("init") + "(" + functiondefinitionargumentlist + ")" + "{" + commands + "}";

            expressionlist.Rule = MakeStarRule(expressionlist, ToTerm(","), expr);
            functiondefinitionargumentlist.Rule = MakeStarRule(functiondefinitionargumentlist, ToTerm(","), functiondefinitionargument);
            namedargumentlist.Rule = MakeStarRule(namedargumentlist, ToTerm(","), namedargument);
            plainidentifierlist.Rule = MakeStarRule(plainidentifierlist, ToTerm(","), plainidentifier);

            functiondefinitionargument.Rule = typeidentifier + plainidentifier;
            namedargument.Rule = plainidentifier + "=" + expr;

            expr.Rule = (qualifiedidentifier + "(" + expressionlist + ")")
                | number | qualifiedidentifier | expr + binop + expr | unop + expr | "(" + expr + ")";
            binop.Rule = ToTerm("-") | "+" | "*" | "/" | "|" | "&" | "||" | "&&" | ".AND." | ".OR."
                | "<=" | ">=" | "!=" | "=" | "<" | ">";
            unop.Rule = ToTerm("-") | "+" | "!" | "~";

            identifier.Rule = plainidentifier + "[" + expr + "]" | plainidentifier;
            qualifiedidentifier.Rule = MakeStarRule(qualifiedidentifier, ToTerm("."), identifier);
            typeidentifier.Rule = MakePlusRule(typeidentifier, ToTerm("."), plainidentifier);

            // grammar setup
            Root = program;
            MarkPunctuation("{", "}", "(", ")", ",", ";");
            //MarkTransient();
            LanguageFlags |= LanguageFlags.CreateAst;
            NonGrammarTerminals.Add(
                new CommentTerminal("line-comment", "//",
                    "\r", "\n", "\u2085", "\u2028", "\u2029"));

            // operator precedence
            RegisterOperators(1, "!");
            RegisterOperators(2, "~");
            RegisterOperators(3, "|", "&");
            RegisterOperators(4, "+", "-");
            RegisterOperators(5, "*", "/");
            RegisterOperators(6, "<=", ">=", "!=", "=", "<", ">");
            RegisterOperators(7, "||", "&&", ".AND.", ".OR.");
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
        void Visit(VIPPlainIdentifierNode node);
        void Visit(VIPFullVariableDefinitionNode node);
        void Visit(VIPExpressionListNode node);
        void Visit(VIPPolygonCommandNode node);
        void Visit(VIPExpressionNode node);
        void Visit(VIPOperatorNode node);
        void Visit(VIPDefNode node);
        void Visit(VIPRotateCommandNode node);
        void Visit(VIPAssignmentCommandNode node);
        void Visit(VIPFunctionDefinitionNode node);
        void Visit(VIPFunctionDefinitionArgumentListNode node);
        void Visit(VIPFunctionDefinitionArgument node);
        void Visit(VIPReturnCommandNode node);
        void Visit(VIPQualifiedIdentifierNode node);
        void Visit(VIPIdentifierNode vIPIdentifierNode);
        void Visit(VIPTypeIdentifierNode vIPTypeIdentifierNode);
        void Visit(VIPBitmapResDefinitionNode vIPBitmapResDefinitionNode);
        void Visit(VIPPathIdentifierNode vIPPathIdentifierNode);
        void Visit(VIPBitmapCommandNode vIPBitmapCommandNode);
        void Visit(VIPIfCommandNode vIPIfCommandNode);
        void Visit(VIPObjectDefinitionNode vIPObjectDefinitionNode);
        void Visit(VIPInstanceDefinitionNode vIPInstanceDefinitionNode);
        void Visit(VIPNamedArgumentListNode vIPNamedArgumentListNode);
        void Visit(VIPNamedArgumentNode vIPNamedArgumentNode);
        void Visit(VIPDrawCommandNode vIPDrawCommandNode);
        void Visit(VIPMacroDefinitionNode vIPMacroDefinitionNode);
        void Visit(VIPPlainIdentifierListNode vIPPlainIdentifierListNode);
        void Visit(VIPFunctionCallCommandNode vIPFunctionCallCommandNode);
        void Visit(VIPStructDefinitionNode vIPStructDefinitionNode);
        void Visit(VIPObjectDefsNode vIPObjectDefsNode);
        void Visit(VIPObjectDefNode vIPObjectDefNode);
        void Visit(VIPObjectInitDefinition vIPObjectInitDefinition);
        void Visit(VIPObjectEntryDefinition vIPObjectEntryDefinition);
        void Visit(VIPColorCommandNode vIPColorCommandNode);
        void Visit(VIPCircleCommandNode vIPCircleCommandNode);
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

    public class VIPObjectDefsNode : VIPNode
    {
        public override void Accept(IVIPNodeVisitor visitor) => visitor.Visit(this);

        public override void InitChildren(ParseTreeNodeList nodes) => AddChild(nodes.Select(n => n.ChildNodes[0]));
    }

    public class VIPDefNode : VIPNode
    {
        public override void Accept(IVIPNodeVisitor visitor) => visitor.Visit(this);
    }

    public class VIPObjectDefNode : VIPNode
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
            Type = (VIPTypeIdentifierNode)nodes[0].AstNode;
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

        public VIPTypeIdentifierNode Type;
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

    public class VIPNamedArgumentListNode : VIPNode
    {
        public override void Accept(IVIPNodeVisitor visitor) => visitor.Visit(this);

        public override void InitChildren(ParseTreeNodeList nodes) => AddChild(nodes);
    }

    public class VIPPlainIdentifierListNode : VIPNode
    {
        public override void Accept(IVIPNodeVisitor visitor) => visitor.Visit(this);

        public override void InitChildren(ParseTreeNodeList nodes) => AddChild(nodes);
    }

    public class VIPFunctionDefinitionArgument : VIPNode
    {
        public override void Accept(IVIPNodeVisitor visitor) => visitor.Visit(this);

        public override void InitChildren(ParseTreeNodeList nodes) => AddChild(nodes);
    }

    public class VIPNamedArgumentNode : VIPNode
    {
        public override void Accept(IVIPNodeVisitor visitor) => visitor.Visit(this);

        public override void InitChildren(ParseTreeNodeList nodes)
        {
            Name = ((VIPPlainIdentifierNode)nodes[0].AstNode).Name;
            Expression = (VIPExpressionNode)nodes[2].AstNode;
        }

        public string Name;
        public VIPExpressionNode Expression;
    }

    public class VIPFunctionDefinitionNode : VIPNode
    {
        public override void Accept(IVIPNodeVisitor visitor) => visitor.Visit(this);

        public override void InitChildren(ParseTreeNodeList nodes)
        {
            Type = (VIPTypeIdentifierNode)nodes[1].AstNode;
            Name = nodes[2].Token.ValueString;
            Arguments = ((VIPFunctionDefinitionArgumentListNode)nodes[3].AstNode).ChildNodes
                .Select(n => Tuple.Create((VIPTypeIdentifierNode)n.ChildNodes[0], ((VIPPlainIdentifierNode)n.ChildNodes[1]).Name))
                .ToArray();
            AddChild(nodes[4].ChildNodes.Select(n => n.ChildNodes[0]));
        }

        public VIPTypeIdentifierNode Type;
        public string Name;
        public Tuple<VIPTypeIdentifierNode, string>[] Arguments;
    }

    public class VIPObjectDefinitionNode : VIPNode
    {
        public override void Accept(IVIPNodeVisitor visitor) => visitor.Visit(this);

        public override void InitChildren(ParseTreeNodeList nodes)
        {
            Name = nodes[1].Token.ValueString;
            Definitions = nodes[2].ChildNodes;
        }

        public string Name;
        public ParseTreeNodeList Definitions;
    }

    public class VIPInstanceDefinitionNode : VIPNode
    {
        public override void Accept(IVIPNodeVisitor visitor) => visitor.Visit(this);

        public override void InitChildren(ParseTreeNodeList nodes)
        {
            Object = (VIPQualifiedIdentifierNode)nodes[1].AstNode;
            Name = nodes[2].Token.ValueString;
            Arguments = nodes[3].ChildNodes;
        }

        public VIPQualifiedIdentifierNode Object;
        public string Name;
        public ParseTreeNodeList Arguments;
    }

    public class VIPMacroDefinitionNode : VIPNode
    {
        public override void Accept(IVIPNodeVisitor visitor) => visitor.Visit(this);

        public override void InitChildren(ParseTreeNodeList nodes)
        {
            Name = nodes[1].Token.ValueString;
            Arguments = nodes[2].ChildNodes;
            AddChild(nodes[3].ChildNodes.Select(n => n.ChildNodes[0]));
        }

        public string Name;
        public ParseTreeNodeList Arguments;
    }

    public class VIPObjectInitDefinition : VIPNode
    {
        public override void Accept(IVIPNodeVisitor visitor) => visitor.Visit(this);

        public override void InitChildren(ParseTreeNodeList nodes)
        {
            Arguments = nodes[1].ChildNodes;
            AddChild(nodes[2].ChildNodes.Select(n => n.ChildNodes[0]));
        }

        public ParseTreeNodeList Arguments;
    }

    public class VIPObjectEntryDefinition : VIPNode
    {
        public override void Accept(IVIPNodeVisitor visitor) => visitor.Visit(this);

        public override void InitChildren(ParseTreeNodeList nodes)
        {
            AddChild(nodes[1].ChildNodes.Select(n => n.ChildNodes[0]));
        }

        public ParseTreeNodeList Arguments;
    }

    public class VIPStructDefinitionNode : VIPNode
    {
        public override void Accept(IVIPNodeVisitor visitor) => visitor.Visit(this);

        public override void InitChildren(ParseTreeNodeList nodes)
        {
            Name = nodes[1].Token.ValueString;
            AddChild(nodes[2].ChildNodes);
        }

        public string Name;
    }

    public class VIPBitmapResDefinitionNode : VIPNode
    {
        public override void Accept(IVIPNodeVisitor visitor) => visitor.Visit(this);

        public override void InitChildren(ParseTreeNodeList nodes)
        {
            Handle = nodes[1].Token.ValueString;
            Type = nodes[2].Token.ValueString;
            Filter = nodes[3].Token.ValueString;
            ClampMode = nodes[4].Token.ValueString;
            Path = nodes[5].Token.ValueString;
        }

        public string Handle, Type, Filter, ClampMode, Path;
    }

    public class VIPExpressionListNode : VIPNode
    {
        public override void Accept(IVIPNodeVisitor visitor) => visitor.Visit(this);

        public override void InitChildren(ParseTreeNodeList nodes) => AddChild(nodes);
    }

    public class VIPVariableDefinitionNode : VIPNode
    {
        public override void Accept(IVIPNodeVisitor visitor) => visitor.Visit(this);

        public override void InitChildren(ParseTreeNodeList nodes)
        {
            Type = (VIPTypeIdentifierNode)nodes[0].AstNode;
            Identifier = nodes[1].Token.ValueString;
        }

        public VIPTypeIdentifierNode Type;
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

    public class VIPPlainIdentifierNode : VIPNode
    {
        public override void Accept(IVIPNodeVisitor visitor) => visitor.Visit(this);

        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            Name = treeNode.Token.ValueString;
        }

        public string Name;
    }

    public class VIPPathIdentifierNode : VIPNode
    {
        public override void Accept(IVIPNodeVisitor visitor) => visitor.Visit(this);

        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            Path = treeNode.Token.ValueString;
        }

        public string Path;
    }

    public class VIPIdentifierNode : VIPNode
    {
        public override void Accept(IVIPNodeVisitor visitor) => visitor.Visit(this);

        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            Name = ((VIPPlainIdentifierNode)treeNode.ChildNodes[0].AstNode).Name;
            if (treeNode.ChildNodes.Count > 2)
                Index = (VIPExpressionNode)treeNode.ChildNodes[2].AstNode;
        }

        public string Name;
        public VIPExpressionNode Index;
    }

    public class VIPQualifiedIdentifierNode : VIPNode
    {
        public override void Accept(IVIPNodeVisitor visitor) => visitor.Visit(this);

        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            Parts = treeNode.ChildNodes.Select(n => Tuple.Create(((VIPIdentifierNode)n.AstNode).Name, ((VIPIdentifierNode)n.AstNode).Index)).ToArray();
        }

        // tuple of name and index
        public Tuple<string, VIPExpressionNode>[] Parts;
    }

    public class VIPTypeIdentifierNode : VIPNode
    {
        public override void Accept(IVIPNodeVisitor visitor) => visitor.Visit(this);

        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            Parts = treeNode.ChildNodes.Select(n => ((VIPPlainIdentifierNode)n.AstNode).Name).ToArray();
        }

        // tuple of name and index
        public string[] Parts;

        public override bool Equals(object obj)
        {
            var o = obj as VIPTypeIdentifierNode;
            return o == null ? false : o.Parts.SequenceEqual(Parts);
        }

        public override int GetHashCode() => Parts.GetHashCode();
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

        public override void InitChildren(ParseTreeNodeList nodes) =>
            Scale = (VIPExpressionNode)nodes[1].AstNode;

        public VIPExpressionNode Scale;
    }

    public class VIPRotateCommandNode : VIPNode
    {
        public override void Accept(IVIPNodeVisitor visitor) => visitor.Visit(this);

        public override void InitChildren(ParseTreeNodeList nodes) =>
            Angle = (VIPExpressionNode)nodes[1].AstNode;

        public VIPExpressionNode Angle;
    }

    public class VIPCircleCommandNode : VIPNode
    {
        public override void Accept(IVIPNodeVisitor visitor) => visitor.Visit(this);

        public override void InitChildren(ParseTreeNodeList nodes)
        {
            X = (VIPExpressionNode)nodes[1].AstNode;
            Y = (VIPExpressionNode)nodes[2].AstNode;
            Radius = (VIPExpressionNode)nodes[3].AstNode;
            Steps = (VIPExpressionNode)nodes[4].AstNode;
            Filled = nodes.Count >= 6;
        }

        public VIPExpressionNode X, Y, Radius, Steps;
        public bool Filled;
    }

    public class VIPReturnCommandNode : VIPNode
    {
        public override void Accept(IVIPNodeVisitor visitor) => visitor.Visit(this);

        public override void InitChildren(ParseTreeNodeList nodes) =>
            Expression = (VIPExpressionNode)nodes[1].AstNode;

        public VIPExpressionNode Expression;
    }

    public class VIPBitmapCommandNode : VIPNode
    {
        public override void Accept(IVIPNodeVisitor visitor) => visitor.Visit(this);

        public override void InitChildren(ParseTreeNodeList nodes)
        {
            Handle = (VIPQualifiedIdentifierNode)nodes[1].AstNode;
            Blend = ((VIPPlainIdentifierNode)nodes[2].AstNode).Name;
            X = (VIPExpressionNode)nodes[3].AstNode;
            Y = (VIPExpressionNode)nodes[4].AstNode;
            W = (VIPExpressionNode)nodes[5].AstNode;
            H = (VIPExpressionNode)nodes[6].AstNode;
            Ref = ((VIPPlainIdentifierNode)nodes[7].AstNode).Name;
            Vertices = (VIPQualifiedIdentifierNode)nodes[8].AstNode;
        }

        public VIPQualifiedIdentifierNode Handle;
        public string Blend;
        public VIPExpressionNode X, Y, W, H;
        public string Ref;
        public VIPQualifiedIdentifierNode Vertices;
    }

    public class VIPAssignmentCommandNode : VIPNode
    {
        public override void Accept(IVIPNodeVisitor visitor) => visitor.Visit(this);

        public override void InitChildren(ParseTreeNodeList nodes)
        {
            Variable = (VIPQualifiedIdentifierNode)nodes[0].AstNode;
            Expression = (VIPExpressionNode)nodes[2].AstNode;
        }

        public VIPQualifiedIdentifierNode Variable;
        public VIPExpressionNode Expression;
    }

    public class VIPIfCommandNode : VIPNode
    {
        public override void Accept(IVIPNodeVisitor visitor) => visitor.Visit(this);

        public override void InitChildren(ParseTreeNodeList nodes)
        {
            Test = (VIPExpressionNode)nodes[1].AstNode;
            AddChild(nodes[2].ChildNodes.Select(n => n.ChildNodes[0]));
        }

        public VIPExpressionNode Test;
    }

    public class VIPDrawCommandNode : VIPNode
    {
        public override void Accept(IVIPNodeVisitor visitor) => visitor.Visit(this);

        public override void InitChildren(ParseTreeNodeList nodes)
        {
            ObjectName = (VIPQualifiedIdentifierNode)nodes[1].AstNode;
        }

        public VIPQualifiedIdentifierNode ObjectName;
    }

    public class VIPColorCommandNode : VIPNode
    {
        public override void Accept(IVIPNodeVisitor visitor) => visitor.Visit(this);

        public override void InitChildren(ParseTreeNodeList nodes)
        {
            ArrayName = (VIPQualifiedIdentifierNode)nodes[1].AstNode;
        }

        public VIPQualifiedIdentifierNode ArrayName;
    }

    public class VIPFunctionCallCommandNode : VIPNode
    {
        public override void Accept(IVIPNodeVisitor visitor) => visitor.Visit(this);

        public override void InitChildren(ParseTreeNodeList nodes)
        {
            Name = (VIPQualifiedIdentifierNode)nodes[0].AstNode;
            Arguments = nodes[1].ChildNodes;
        }

        public VIPQualifiedIdentifierNode Name;
        public ParseTreeNodeList Arguments;
    }

    public enum VIPPolygonType { WithArrays };

    public class VIPPolygonCommandNode : VIPNode
    {
        public override void Accept(IVIPNodeVisitor visitor) => visitor.Visit(this);

        public override void InitChildren(ParseTreeNodeList nodes)
        {
            if (nodes[2].AstNode is VIPQualifiedIdentifierNode && nodes[1].AstNode is VIPQualifiedIdentifierNode)
            {
                Type = VIPPolygonType.WithArrays;
                VerticesIdentifier = (VIPQualifiedIdentifierNode)nodes[1].AstNode;
                ColorsIdentifier = (VIPQualifiedIdentifierNode)nodes[2].AstNode;
            }
        }

        public VIPPolygonType Type;
        public VIPQualifiedIdentifierNode VerticesIdentifier, ColorsIdentifier;
    }
}
