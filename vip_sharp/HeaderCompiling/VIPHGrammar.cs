using Irony.Ast;
using Irony.Interpreter.Ast;
using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vip_sharp
{
    public class VIPHGrammar : Grammar
    {
        public VIPHGrammar() : base(true)
        {
            // terminals/nonterminals
            var program = new NonTerminal("program", typeof(VIPHProgramNode));
            var @struct = new NonTerminal("struct", typeof(VIPHStructNode));

            var defs = new NonTerminal("defs", typeof(VIPHDefsNode));
            var def = new NonTerminal("def", typeof(VIPHDefNode));

            var typeidentifier = new NonTerminal("typeidentifier", typeof(VIPHTypeNode));
            var plainidentifier = new IdentifierTerminal("plainidentifier"); plainidentifier.AstConfig.NodeType = typeof(VIPHPlainIdentifierNode);
            var number = new NumberLiteral("number"); number.AstConfig.NodeType = typeof(VIPHNumberNode);
            var optarr = new NonTerminal("optarr", typeof(VIPHOptArrNode));

            // rules
            program.Rule = @struct;
            @struct.Rule = ToTerm("struct") + plainidentifier + "{" + defs + "}" + ";";

            defs.Rule = MakeStarRule(defs, def);
            def.Rule = typeidentifier + plainidentifier + optarr + optarr + ";";

            typeidentifier.Rule = ToTerm("char") | "float" | "short" | "int" | "double";
            optarr.Rule = "[" + number + "]" | Empty;

            // comments
            var SingleLineComment = new CommentTerminal("SingleLineComment", "//", "\r", "\n", "\u2085", "\u2028", "\u2029");
            var DelimitedComment = new CommentTerminal("DelimitedComment", "/*", "*/");
            NonGrammarTerminals.Add(SingleLineComment);
            NonGrammarTerminals.Add(DelimitedComment);

            // language setup
            MarkPunctuation("{", "}", "(", ")", ",", ";", ":");
            Root = program;
            LanguageFlags |= LanguageFlags.CreateAst;
        }
    }

    public interface IVIPHNodeVisitor
    {
        void Visit(VIPHProgramNode node);
        void Visit(VIPHStructNode vIPHStructNode);
        void Visit(VIPHDefsNode vIPHDefsNode);
        void Visit(VIPHDefNode vIPHDefNode);
        void Visit(VIPHTypeNode vIPHTypeNode);
        void Visit(VIPHPlainIdentifierNode vIPHPlainIdentifierNode);
        void Visit(VIPHNumberNode vIPHNumberNode);
        void Visit(VIPHOptArrNode vIPHOptArrNode);
    }

    public abstract class VIPHNode : AstNode
    {
        public abstract void Accept(IVIPHNodeVisitor visitor);

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

    public class VIPHProgramNode : VIPHNode
    {
        public override void Accept(IVIPHNodeVisitor visitor) => visitor.Visit(this);

        public override void InitChildren(ParseTreeNodeList nodes) => AddChild(nodes);
    }

    public class VIPHStructNode : VIPHNode
    {
        public override void Accept(IVIPHNodeVisitor visitor) => visitor.Visit(this);

        public override void InitChildren(ParseTreeNodeList nodes)
        {
            Name = nodes[1].Token.ValueString;
            AddChild(nodes[2].ChildNodes);
        }

        public string Name;
    }

    public class VIPHDefsNode : VIPHNode
    {
        public override void Accept(IVIPHNodeVisitor visitor) => visitor.Visit(this);

        public override void InitChildren(ParseTreeNodeList nodes) => AddChild(nodes.Select(n => n.ChildNodes[0]));
    }

    public class VIPHDefNode : VIPHNode
    {
        public override void Accept(IVIPHNodeVisitor visitor) => visitor.Visit(this);
        public override void InitChildren(ParseTreeNodeList nodes)
        {
            TypeName = ((VIPHTypeNode)nodes[0].AstNode).TypeName;
            VariableName = ((VIPHPlainIdentifierNode)nodes[1].AstNode).Name;
            ArrayIndex1 = ((VIPHOptArrNode)nodes[2].AstNode).Value;
            ArrayIndex2 = ((VIPHOptArrNode)nodes[3].AstNode).Value;
        }

        public string TypeName, VariableName;
        public int? ArrayIndex1, ArrayIndex2;
    }

    public class VIPHTypeNode : VIPHNode
    {
        public override void Accept(IVIPHNodeVisitor visitor) => visitor.Visit(this);

        public override void InitChildren(ParseTreeNodeList nodes) =>
            TypeName = nodes[0].Token.ValueString;

        public string TypeName;
    }

    public class VIPHPlainIdentifierNode : VIPHNode
    {
        public override void Accept(IVIPHNodeVisitor visitor) => visitor.Visit(this);

        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            Name = treeNode.Token.ValueString;
        }

        public string Name;
    }

    public class VIPHNumberNode : VIPHNode
    {
        public override void Accept(IVIPHNodeVisitor visitor) => visitor.Visit(this);

        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            Value = Convert.ToInt32(treeNode.Token.Value);
        }

        public int Value;
    }

    public class VIPHOptArrNode : VIPHNode
    {
        public override void Accept(IVIPHNodeVisitor visitor) => visitor.Visit(this);

        public override void InitChildren(ParseTreeNodeList nodes)
        {
            if (nodes.Count >= 2)
                Value = Convert.ToInt32(nodes[1].Token.ValueString);
        }

        public int? Value;
    }
}
