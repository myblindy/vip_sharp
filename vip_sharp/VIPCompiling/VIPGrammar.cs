using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Irony.Ast;
using Irony.Interpreter.Ast;
using Irony.Parsing;
using static vip_sharp.VIPRuntime;
using vip_sharp.Utils;

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
            var nakedcommand = new NonTerminal("nakedcommand", typeof(VIPNakedCommandNode));
            var translatecommand = new NonTerminal("translatecommand", typeof(VIPTranslateCommandNode));
            var scalecommand = new NonTerminal("scalecommand", typeof(VIPScaleCommandNode));
            var lightcommand = new NonTerminal("lightcommand", typeof(VIPLightCommandNode));
            var fullvariabledefinitioncommand = new NonTerminal("fullvariabledefinitioncommand", typeof(VIPFullVariableDefinitionCommandNode));
            var shapecommand = new NonTerminal("shapecommand", typeof(VIPShapeCommandNode));
            var boxcommand = new NonTerminal("boxcommand", typeof(VIPBoxCommandNode));
            var rotatecommand = new NonTerminal("rotatecommand", typeof(VIPRotateCommandNode));
            var assignmentcommand = new NonTerminal("assignmentcommand", typeof(VIPAssignmentCommandNode));
            var returncommand = new NonTerminal("returncommand", typeof(VIPReturnCommandNode));
            var bitmapcommand = new NonTerminal("bitmapcommand", typeof(VIPBitmapCommandNode));
            var ifcommand = new NonTerminal("ifcommand", typeof(VIPIfCommandNode));
            var drawcommand = new NonTerminal("drawcommand", typeof(VIPDrawCommandNode));
            var functioncallcommand = new NonTerminal("functioncallcommand", typeof(VIPFunctionCallCommandNode));
            var colorcommand = new NonTerminal("colorcommand", typeof(VIPColorCommandNode));
            var linewidthcommand = new NonTerminal("linewidthcommand", typeof(VIPLineWidthCommandNode));
            var lightcolorcommand = new NonTerminal("lightcolorcommand", typeof(VIPLightColorCommandNode));
            var circlecommand = new NonTerminal("circlecommand", typeof(VIPCircleCommandNode));
            var matrixcommand = new NonTerminal("matrixcommand", typeof(VIPMatrixCommandNode));
            var stringcommand = new NonTerminal("stringcommand", typeof(VIPStringCommandNode));
            var hotspotcommand = new NonTerminal("hotspotcommand", typeof(VIPHotSpotCommandNode));
            var formatcommand = new NonTerminal("formatcommand", typeof(VIPFormatCommandNode));
            var rotaryknobcommand = new NonTerminal("rotaryknobcommand", typeof(VIPRotaryKnobCommandNode));
            var slidercommand = new NonTerminal("slidercommand", typeof(VIPSliderCommandNode));
            var forcommand = new NonTerminal("forcommand", typeof(VIPForCommandNode));
            var unaryassignmentcommand = new NonTerminal("unaryassignmentcommand", typeof(VIPUnaryAssignmentCommandNode));
            var loopcommand = new NonTerminal("loopcommand", typeof(VIPLoopCommandNode));
            var displaycommand = new NonTerminal("displaycommand", typeof(VIPDisplayCommandNode));
            var clipcommand = new NonTerminal("clipcommand", typeof(VIPClipCommandNode));
            var calcommand = new NonTerminal("calcommand", typeof(VIPCalCommandNode));
            var arccommand = new NonTerminal("arccommand", typeof(VIPArcCommandNode));

            var variabledefinitions = new NonTerminal("variabledefinitions", typeof(VIPVariableDefinitionsNode));
            var variabledefinition = new NonTerminal("variabledefinition", typeof(VIPVariableDefinitionNode));
            var typedefinition = new NonTerminal("typedefinition", typeof(VIPTypeDefinitionNode));
            var functiondefinition = new NonTerminal("functiondefinition", typeof(VIPFunctionDefinitionNode));
            var bitmapresdefinition = new NonTerminal("bitmapresdefinition", typeof(VIPBitmapResDefinitionNode));
            var calresdefinition = new NonTerminal("calresdefinition", typeof(VIPCalResDefinitionNode));
            var objectdefinition = new NonTerminal("objectdefinition", typeof(VIPObjectDefinitionNode));
            var instancedefinition = new NonTerminal("instancedefinition", typeof(VIPInstanceDefinitionNode));
            var macrodefinition = new NonTerminal("macrodefinition", typeof(VIPMacroDefinitionNode));
            var structdefinition = new NonTerminal("structdefinition", typeof(VIPStructDefinitionNode));
            var objectinitdefinition = new NonTerminal("objectinitdefinition", typeof(VIPObjectInitDefinition));
            var objectentrydefinition = new NonTerminal("objectentrydefinition", typeof(VIPObjectEntryDefinition));
            var listdefinition = new NonTerminal("listdefinition", typeof(VIPListDefinition));
            var stringresdefinition = new NonTerminal("stringresdefinition", typeof(VIPStringResDefinition));
            var fullvariabledefinition = new NonTerminal("fullvariabledefinition", typeof(VIPFullVariableDefinitionNode));
            var assignmentcommandasdefinition = new NonTerminal("assignmentcommandasdefinition", typeof(VIPAssignmentCommandAsDefinitionNode));

            var expressionlist = new NonTerminal("expressionlist", typeof(VIPExpressionListNode));
            var functiondefinitionargumentlist = new NonTerminal("functiondefinitionargumentlist", typeof(VIPFunctionDefinitionArgumentListNode));
            var namedargumentlist = new NonTerminal("namedargumentlist", typeof(VIPNamedArgumentListNode));
            var plainidentifierlist = new NonTerminal("plainidentifierlist", typeof(VIPPlainIdentifierListNode));

            var functiondefinitionargument = new NonTerminal("functiondefinitionargument", typeof(VIPFunctionDefinitionArgument));
            var namedargument = new NonTerminal("namedargument", typeof(VIPNamedArgumentNode));
            var referenceidentifier = new NonTerminal("referenceidentifier", typeof(VIPReferenceIdentifier));

            var arrlist = new NonTerminal("arrlist", typeof(VIPArrListNode));
            var arr = new NonTerminal("arr", typeof(VIPArrNode));

            var identifier = new NonTerminal("identifier", typeof(VIPIdentifierNode));
            var qualifiedidentifier = new NonTerminal("qualifiedidentifier", typeof(VIPQualifiedIdentifierNode));
            var typeidentifier = new NonTerminal("typeidentifier", typeof(VIPTypeIdentifierNode));

            var expr = new NonTerminal("Expr", typeof(VIPExpressionNode));
            var binop = new NonTerminal("BinOp", typeof(VIPOperatorNode));
            var unop = new NonTerminal("UnOp", typeof(VIPOperatorNode));

            var incrementops = new NonTerminal("incrementops", typeof(VIPIncrementOpsNode));

            var numberliteral = GrammarUtils.CreateNumberLiteral("numberliteral"); numberliteral.AstConfig.NodeType = typeof(VIPNumberNode);
            var plainidentifier = new IdentifierTerminal("plainidentifier"); plainidentifier.AstConfig.NodeType = typeof(VIPPlainIdentifierNode);
            var pathidentifier = new IdentifierTerminal("pathidentifier", @" /\."); pathidentifier.AstConfig.NodeType = typeof(VIPPathIdentifierNode);
            var stringliteral = new QuotedValueLiteral("stringliteral", "\"", TypeCode.String); stringliteral.AstConfig.NodeType = typeof(VIPStringLiteralNode);
            var charliteral = new QuotedValueLiteral("charliteral", "'", TypeCode.String); charliteral.AstConfig.NodeType = typeof(VIPCharLiteralNode);
            var referenceliteral = ToTerm("&"); referenceliteral.AstConfig.NodeType = typeof(VIPReferenceLiteralNode);

            program.Rule = defs + main;
            main.Rule = (ToTerm("main") + "{" + commands + "}") | ("main" + commands + "go");

            defs.Rule = MakeStarRule(defs, null, def);
            def.Rule = listdefinition | macrodefinition | stringresdefinition | bitmapresdefinition | typedefinition | fullvariabledefinition
                | functiondefinition | objectdefinition | instancedefinition
                | assignmentcommandasdefinition | calresdefinition;

            objectdefs.Rule = MakeStarRule(objectdefs, null, objectdef);
            objectdef.Rule = objectinitdefinition | objectentrydefinition | listdefinition | macrodefinition | structdefinition | bitmapresdefinition
                | typedefinition | fullvariabledefinition | functiondefinition | objectdefinition | stringresdefinition | instancedefinition
                | assignmentcommandasdefinition | calresdefinition;

            commands.Rule = MakeStarRule(commands, null, command);
            nakedcommand.Rule = rotaryknobcommand | formatcommand | hotspotcommand | stringcommand | shapecommand | circlecommand | matrixcommand
                | drawcommand | colorcommand | translatecommand | scalecommand | assignmentcommand | fullvariabledefinitioncommand | lightcommand
                | rotatecommand | returncommand | bitmapcommand | functioncallcommand | slidercommand | unaryassignmentcommand | boxcommand | displaycommand
                | linewidthcommand | clipcommand | calcommand | arccommand;
            command.Rule = nakedcommand + ";" | ToTerm("{") + commands + "}" | ifcommand | forcommand | calresdefinition | loopcommand | bitmapresdefinition;
            translatecommand.Rule = ToTerm("translate") + "(" + expr + "," + expr + ")";
            scalecommand.Rule = ToTerm("scale") + "(" + expr + ")" | ToTerm("scale") + "(" + expr + "," + expr + ")";
            fullvariabledefinitioncommand.Rule =
                typeidentifier + plainidentifier + "[" + expr + "]" + "=" + "{" + expressionlist + "}"
                | typeidentifier + plainidentifier + "[" + expr + "]" + "=" + stringliteral
                | typeidentifier + plainidentifier + "[" + expr + "]"
                | typeidentifier + plainidentifier + "[" + "]" + "=" + "{" + expressionlist + "}"
                | typeidentifier + plainidentifier + "[" + "]" + "=" + stringliteral
                | typeidentifier + plainidentifier + "=" + expr
                | typeidentifier + plainidentifier + "=" + "{" + expressionlist + "}"
                | typeidentifier + plainidentifier;
            shapecommand.Rule = ToTerm("rotate") + "{" + expressionlist + "}"
                | ToTerm("line") + "{" + expressionlist + "}"
                | ToTerm("quad") + "{" + expressionlist + "}"
                | ToTerm("line_strip") + "{" + expressionlist + "}"
                | ToTerm("closed_line") + "{" + expressionlist + "}"
                | ToTerm("polygon") + "{" + expressionlist + "}"
                | ToTerm("triangle") + "{" + expressionlist + "}";
            rotatecommand.Rule = ToTerm("rotate") + "(" + expr + ")";
            boxcommand.Rule =
                ToTerm("box") + "(" + expr + "," + expr + "," + expr + "," + expr + "," + plainidentifier + ")"
                | ToTerm("box") + "(" + expr + "," + expr + "," + expr + "," + expr + "," + plainidentifier + "," + "fill" + ")";
            arccommand.Rule =
                ToTerm("arc") + "(" + expr + "," + expr + "," + expr + "," + expr + "," + expr + "," + expr + "," + expr + ")"
                | ToTerm("arc") + "(" + expr + "," + expr + "," + expr + "," + expr + "," + expr + "," + expr + "," + expr + "," + "fill" + ")";
            assignmentcommand.Rule = qualifiedidentifier + "=" + expr;
            functiondefinition.Rule =
                ToTerm("function") + typeidentifier + plainidentifier + "(" + functiondefinitionargumentlist + ")" + "{" + commands + "}"
                | ToTerm("function") + plainidentifier + "(" + functiondefinitionargumentlist + ")" + "{" + commands + "}";
            returncommand.Rule = "return" + expr;
            bitmapcommand.Rule = ToTerm("bitmap") + "(" + expressionlist + ")";           // expression list to handle all the different ways of calling this. disambiguate in the Ast handler
            ifcommand.Rule = ToTerm("if") + expr + command
                | ToTerm("if") + expr + command + "else" + command;
            drawcommand.Rule = ToTerm("draw") + "(" + qualifiedidentifier + ")";
            functioncallcommand.Rule = qualifiedidentifier + "(" + expressionlist + ")";
            colorcommand.Rule = ToTerm("color") + "(" + qualifiedidentifier + ")"
                | ToTerm("color") + "(" + expr + "," + expr + "," + expr + "," + expr + ")"
                | ToTerm("color") + "(" + expr + "," + expr + "," + expr + ")"
                | ToTerm("color") + "(" + expr + "," + expr + ")"
                | ToTerm("color") + "(" + expr + ")";
            circlecommand.Rule = ToTerm("circle") + "(" + expr + "," + expr + "," + expr + "," + expr + "," + "fill" + ")"
                | ToTerm("circle") + "(" + expr + "," + expr + "," + expr + "," + expr + ")";
            matrixcommand.Rule = ToTerm("matrix") + "(" + "save" + ")"
                | ToTerm("matrix") + "(" + "restore" + ")"
                | ToTerm("matrix") + "(" + "identity" + ")";
            stringcommand.Rule =
                ToTerm("string") + "(" + expr + "," + expr + "," + plainidentifier + "," + expr + "," + qualifiedidentifier + ","           // array, no spacey
                    + expr + "," + qualifiedidentifier + "," + expr + "," + expr + "," + expr + ")"
                | ToTerm("string") + "(" + expr + "," + expr + "," + plainidentifier + "," + expr + "," + qualifiedidentifier + ","         // array, spacey
                    + expr + "," + qualifiedidentifier + "," + expr + "," + expr + "," + expr + "," + expr + ")"
                | ToTerm("string") + "(" + expr + "," + expr + "," + plainidentifier + "," + expr + "," + stringliteral + ","               // string, no spacey
                    + expr + "," + qualifiedidentifier + "," + expr + "," + expr + "," + expr + ")"
                | ToTerm("string") + "(" + expr + "," + expr + "," + plainidentifier + "," + expr + "," + stringliteral + ","               // string, spacey
                    + expr + "," + qualifiedidentifier + "," + expr + "," + expr + "," + expr + "," + expr + ")"
                | ToTerm("string") + "(" + expr + "," + expr + "," + plainidentifier + "," + expr + ","                                     // array, stringres
                    + qualifiedidentifier + "," + expr + ")"
                | ToTerm("string") + "(" + expr + "," + expr + "," + plainidentifier + "," + stringliteral + ","                            // string, stringres
                    + qualifiedidentifier + "," + expr + ")";
            hotspotcommand.Rule = ToTerm("hotspot") + "(" + expr + "," + expr + "," + expr + "," + expr + "," + plainidentifier + "," + qualifiedidentifier + ","
                    + plainidentifier + "," + plainidentifier + "," + expr + "," + expr + "," + plainidentifier + ")"                                                   // no last argument
                | ToTerm("hotspot") + "(" + expr + "," + expr + "," + expr + "," + expr + "," + plainidentifier + "," + qualifiedidentifier + ","
                    + plainidentifier + "," + plainidentifier + "," + expr + "," + expr + "," + plainidentifier + "," + qualifiedidentifier + ")";                       // last argument quoted identifier (bitmap or list)
            formatcommand.Rule = ToTerm("format") + "(" + qualifiedidentifier + "," + expr + "," + qualifiedidentifier + ")";
            rotaryknobcommand.Rule = ToTerm("rotary_knob") + "(" + expr + "," + expr + "," + expr + "," + qualifiedidentifier + "," + expr + "," + expr + ","
                    + expr + "," + expr + "," + plainidentifier + "," + expr + ")"
                | ToTerm("rotary_knob") + "(" + expr + "," + expr + "," + expr + "," + qualifiedidentifier + "," + expr + "," + expr + ","
                    + expr + "," + expr + "," + plainidentifier + "," + expr + "," + qualifiedidentifier + ")";
            lightcommand.Rule = ToTerm("light") + "(" + expr + ")";
            slidercommand.Rule = ToTerm("slider") + "(" + expr + "," + expr + "," + expr + "," + expr + "," + plainidentifier + "," + expr + "," + qualifiedidentifier + "," +
                    expr + "," + expr + "," + plainidentifier + "," + expr + ")"
                | ToTerm("slider") + "(" + expr + "," + expr + "," + expr + "," + expr + "," + plainidentifier + "," + expr + "," + qualifiedidentifier + "," +
                    expr + "," + expr + "," + plainidentifier + "," + expr + "," + qualifiedidentifier + ")";
            forcommand.Rule = ToTerm("for") + "(" + nakedcommand + ";" + expr + ";" + nakedcommand + ")" + command;
            unaryassignmentcommand.Rule = incrementops + qualifiedidentifier | qualifiedidentifier + incrementops;
            loopcommand.Rule = ToTerm("loop") + "(" + expr + ")" + command;
            displaycommand.Rule = ToTerm("display") + "(" + expr + "," + expr + "," + qualifiedidentifier + ")";
            linewidthcommand.Rule =
                ToTerm("line_width") + "(" + "save" + ")"
                | ToTerm("line_width") + "(" + "restore" + ")"
                | ToTerm("line_width") + "(" + expr + ")";
            clipcommand.Rule =
                ToTerm("clip") + "(" + expr + ")"                // off is defined as 0
                | ToTerm("clip") + "(" + expr + "," + expr + "," + qualifiedidentifier + ")";
            calcommand.Rule = ToTerm("cal") + "(" + qualifiedidentifier + "," + expr + "," + qualifiedidentifier + ")";


            variabledefinitions.Rule = MakeStarRule(variabledefinitions, null, variabledefinition);
            variabledefinition.Rule = typeidentifier + plainidentifier + arrlist + ";";
            typedefinition.Rule = ToTerm("typedef") + plainidentifier + "{" + variabledefinitions + "}";
            bitmapresdefinition.Rule =
                ToTerm("bitmap_res") + "("
                    + plainidentifier + ","                           // name
                    + plainidentifier + ","                           // bitmap type
                    + plainidentifier + ","                           // filter
                    + plainidentifier + ","                           // clamp
                    + pathidentifier + ")" + ";"                      // path
                | ToTerm("bitmap_res") + "("
                    + plainidentifier + ","                           // name
                    + plainidentifier + ","                           // bitmap type
                    + plainidentifier + ","                           // filter
                    + plainidentifier + ","                           // clamp
                    + expr + ")" + ";";                               // path
            stringresdefinition.Rule = ToTerm("string_res") + "(" + plainidentifier + "," + qualifiedidentifier + "," + expr + "," + expr + "," + expr + ")" + ";"
                | ToTerm("string_res") + "(" + plainidentifier + "," + qualifiedidentifier + "," + expr + "," + expr + "," + expr + "," + expr + ")" + ";";
            objectdefinition.Rule = "object" + plainidentifier + "{" + objectdefs + "}";
            instancedefinition.Rule =
                "instance" + qualifiedidentifier + plainidentifier + "{" + namedargumentlist + "}" + ";"
                | "instance" + qualifiedidentifier + plainidentifier + "{" + namedargumentlist + "}" + ":" + "{" + expressionlist + "}" + ";";
            macrodefinition.Rule = ToTerm("macro") + plainidentifier + "(" + plainidentifierlist + ")" + "{" + commands + "}";
            structdefinition.Rule = "struct" + plainidentifier + "{" + variabledefinitions + "}";
            objectentrydefinition.Rule = ToTerm("entry") + "{" + commands + "}";
            objectinitdefinition.Rule = ToTerm("init") + "(" + functiondefinitionargumentlist + ")" + "{" + commands + "}";
            listdefinition.Rule = ToTerm("list") + plainidentifier + "{" + commands + "}" | ToTerm("list") + plainidentifier + "{" + commands + "}" + ";";
            fullvariabledefinition.Rule = fullvariabledefinitioncommand + ";";
            assignmentcommandasdefinition.Rule =
                plainidentifier + arrlist + "=" + expr + ";"
                | "w" + plainidentifier + arrlist + expr;
            calresdefinition.Rule = ToTerm("cal_res") + plainidentifier + "{" + expressionlist + "}" + ";";

            expressionlist.Rule = MakeStarRule(expressionlist, ToTerm(","), expr);
            functiondefinitionargumentlist.Rule = MakeStarRule(functiondefinitionargumentlist, ToTerm(","), functiondefinitionargument);
            namedargumentlist.Rule = MakeStarRule(namedargumentlist, ToTerm(","), namedargument);
            plainidentifierlist.Rule = MakeStarRule(plainidentifierlist, ToTerm(","), plainidentifier);

            functiondefinitionargument.Rule = typeidentifier + referenceidentifier + plainidentifier;
            namedargument.Rule = plainidentifier + "=" + expr;
            referenceidentifier.Rule = referenceliteral | Empty;

            arrlist.Rule = MakeStarRule(arrlist, arr);
            arr.Rule = "[" + expr + "]";

            expr.Rule = (qualifiedidentifier + "(" + expressionlist + ")")
                | stringliteral | charliteral | numberliteral | qualifiedidentifier | expr + binop + expr | unop + expr | "(" + expr + ")"
                | "{" + expr + "}" + binop + "{" + expr + "}";
            binop.Rule = ToTerm("-") | "+" | "*" | "/" | "^" | "|" | "&" | "||" | "&&" | ".AND." | ".OR."
                | "<=" | ">=" | "!=" | "==" | "<" | ">" | "mod";
            unop.Rule = ToTerm("-") | "+" | "!" | "~";

            incrementops.Rule = ToTerm("--") | "++";

            identifier.Rule = plainidentifier + arrlist;
            qualifiedidentifier.Rule = MakePlusRule(qualifiedidentifier, ToTerm("."), identifier);
            typeidentifier.Rule = MakePlusRule(typeidentifier, ToTerm("."), plainidentifier);

            // comments
            var SingleLineComment = new CommentTerminal("SingleLineComment", "//", "\r", "\n", "\u2085", "\u2028", "\u2029");
            var DelimitedComment = new CommentTerminal("DelimitedComment", "/*", "*/");
            NonGrammarTerminals.Add(SingleLineComment);
            NonGrammarTerminals.Add(DelimitedComment);

            // grammar setup
            Root = program;
            MarkPunctuation("{", "}", "(", ")", ",", ";", ":");
            //MarkTransient(nakedcommand);
            LanguageFlags |= LanguageFlags.CreateAst;

            // operator precedence
            RegisterOperators(1, "||");
            RegisterOperators(2, "&&");
            RegisterOperators(3, "|");
            RegisterOperators(4, "^");
            RegisterOperators(5, "&");
            RegisterOperators(6, "==", "!=");
            RegisterOperators(7, "<", ">", "<=", ">=");
            RegisterOperators(9, "+", "-");
            RegisterOperators(10, "*", "/", "mod");
            RegisterOperators(11, "^");
            RegisterOperators(-3, "=", "+=", "-=", "*=", "/=", "%=", "&=", "|=", "^=", "<<=", ">>=");

            RegisterBracePair("(", ")");
            MarkMemberSelect(".");
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
        void Visit(VIPFullVariableDefinitionCommandNode node);
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
        void Visit(VIPIdentifierNode node);
        void Visit(VIPTypeIdentifierNode node);
        void Visit(VIPBitmapResDefinitionNode node);
        void Visit(VIPPathIdentifierNode node);
        void Visit(VIPBitmapCommandNode node);
        void Visit(VIPIfCommandNode node);
        void Visit(VIPObjectDefinitionNode node);
        void Visit(VIPInstanceDefinitionNode node);
        void Visit(VIPNamedArgumentListNode node);
        void Visit(VIPNamedArgumentNode node);
        void Visit(VIPDrawCommandNode node);
        void Visit(VIPMacroDefinitionNode node);
        void Visit(VIPPlainIdentifierListNode node);
        void Visit(VIPFunctionCallCommandNode node);
        void Visit(VIPStructDefinitionNode node);
        void Visit(VIPObjectDefsNode node);
        void Visit(VIPObjectDefNode node);
        void Visit(VIPObjectInitDefinition node);
        void Visit(VIPObjectEntryDefinition node);
        void Visit(VIPColorCommandNode node);
        void Visit(VIPCircleCommandNode node);
        void Visit(VIPStringLiteralNode node);
        void Visit(VIPMatrixCommandNode node);
        void Visit(VIPListDefinition node);
        void Visit(VIPShapeCommandNode node);
        void Visit(VIPStringCommandNode vIPStringCommandNode);
        void Visit(VIPHotSpotCommandNode vIPHotSpotCommandNode);
        void Visit(VIPFormatCommandNode vIPFormatCommandNode);
        void Visit(VIPRotaryKnobCommandNode vIPRotaryKnobCommandNode);
        void Visit(VIPLightCommandNode vIPLightCommandNode);
        void Visit(VIPLightColorCommandNode vIPLightColorCommandNode);
        void Visit(VIPSliderCommandNode vIPSliderCommandNode);
        void Visit(VIPStringResDefinition vIPStringResDefinition);
        void Visit(VIPReferenceLiteralNode vIPReferenceLiteralNode);
        void Visit(VIPReferenceIdentifier vIPReferenceIdentifier);
        void Visit(VIPNakedCommandNode vIPNakedCommandNode);
        void Visit(VIPForCommandNode vIPForCommandNode);
        void Visit(VIPFullVariableDefinitionNode vIPFullVariableDefinitionNode);
        void Visit(VIPUnaryAssignmentCommandNode vIPUnaryAssignmentCommandNode);
        void Visit(VIPAssignmentCommandAsDefinitionNode vIPAssignmentCommandAsDefinitionNode);
        void Visit(VIPCharLiteralNode vIPCharLiteralNode);
        void Visit(VIPCalResDefinitionNode vIPCalResDefinitionNode);
        void Visit(VIPArrNode vIPArrNode);
        void Visit(VIPArrListNode vIPArrListNode);
        void Visit(VIPLoopCommandNode vIPLoopCommand);
        void Visit(VIPIncrementOpsNode vIPIncrementOpsNode);
        void Visit(VIPBoxCommandNode vIPBoxCommandNode);
        void Visit(VIPDisplayCommandNode vIPDisplayCommandNode);
        void Visit(VIPLineWidthCommandNode vIPLineWidthCommandNode);
        void Visit(VIPClipCommandNode vIPClipCommandNode);
        void Visit(VIPCalCommandNode vIPCalCommandNode);
        void Visit(VIPArcCommandNode vIPArcCommandNode);
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

        protected static void ExtractIndices(VIPArrListNode arrlist, out VIPExpressionNode index1, out VIPExpressionNode index2)
        {
            var indexes = arrlist.ChildNodes;
            index1 = index2 = null;
            if (indexes.Count >= 1)
                index1 = ((VIPArrNode)indexes[0]).Expression;
            if (indexes.Count >= 2)
                index2 = ((VIPArrNode)indexes[1]).Expression;
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

    public class VIPListDefinition : VIPNode
    {
        public override void Accept(IVIPNodeVisitor visitor) => visitor.Visit(this);

        public override void InitChildren(ParseTreeNodeList nodes)
        {
            Name = nodes[1].Token.ValueString;
            AddChild(nodes[2].ChildNodes.Select(n => n.ChildNodes[0]));
        }

        public string Name;
    }

    public class VIPFullVariableDefinitionNode : VIPNode
    {
        public override void Accept(IVIPNodeVisitor visitor) => visitor.Visit(this);

        public override void InitChildren(ParseTreeNodeList nodes) =>
            FullVariableDefinitionCommandNode = (VIPFullVariableDefinitionCommandNode)nodes[0].AstNode;

        public VIPFullVariableDefinitionCommandNode FullVariableDefinitionCommandNode;
    }

    public class VIPAssignmentCommandAsDefinitionNode : VIPNode
    {
        public override void Accept(IVIPNodeVisitor visitor) => visitor.Visit(this);

        public override void InitChildren(ParseTreeNodeList nodes)
        {
            if (nodes[0].Token?.ValueString == "w")
            {
                Name = ((VIPPlainIdentifierNode)nodes[1].AstNode).Name;
                ExtractIndices((VIPArrListNode)nodes[2].AstNode, out Index1, out Index2);
                Value = (VIPExpressionNode)nodes[3].AstNode;
            }
            else
            {
                Name = ((VIPPlainIdentifierNode)nodes[0].AstNode).Name;
                ExtractIndices((VIPArrListNode)nodes[1].AstNode, out Index1, out Index2);
                Value = (VIPExpressionNode)nodes[3].AstNode;
            }
        }

        public string Name;
        public VIPExpressionNode Index1, Index2, Value;
    }

    public class VIPFullVariableDefinitionCommandNode : VIPNode
    {
        public override void Accept(IVIPNodeVisitor visitor) => visitor.Visit(this);

        public override void InitChildren(ParseTreeNodeList nodes)
        {
            Type = (VIPTypeIdentifierNode)nodes[0].AstNode;
            Name = nodes[1].Token.ValueString;
            if (nodes.Count > 2 && nodes[2].Token.ValueString == "[")
            {
                ArraySize = (VIPExpressionNode)nodes[3].AstNode;
                ArraySizeAuto = ArraySize == null;

                if (nodes.Count >= 6 && nodes[5].Token?.ValueString == "=")
                    if (nodes[6].AstNode is VIPStringLiteralNode)
                        InitValue = (VIPNode)nodes[6].AstNode;
                    else
                        InitValues = nodes[6].ChildNodes.Select(n => (VIPExpressionNode)n.AstNode).ToArray();
                else if (nodes[4].Token.ValueString == "=")
                    if (nodes[5].AstNode is VIPStringLiteralNode)
                        InitValue = (VIPNode)nodes[5].AstNode;
                    else
                        InitValues = nodes[5].ChildNodes.Select(n => (VIPExpressionNode)n.AstNode).ToArray();
            }
            else if (nodes.Count > 2 && nodes[2].Token.ValueString == "=")
                if (nodes[3].AstNode is VIPExpressionNode)
                    InitValue = (VIPExpressionNode)nodes[3].AstNode;
                else
                    InitValues = nodes[3].ChildNodes.Select(n => (VIPExpressionNode)n.AstNode).ToArray();
        }

        public VIPTypeIdentifierNode Type;
        public string Name;
        public VIPExpressionNode ArraySize;
        public bool ArraySizeAuto;
        public VIPNode InitValue;
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
            if (nodes.Count == 5)
            {
                // return type
                Type = (VIPTypeIdentifierNode)nodes[1].AstNode;
                Name = nodes[2].Token.ValueString;
                Arguments = nodes[3].ChildNodes.Select(n => (VIPFunctionDefinitionArgument)n.AstNode).ToArray();
                AddChild(nodes[4].ChildNodes.Select(n => n.ChildNodes[0]));
            }
            else
            {
                // no return type
                Name = nodes[1].Token.ValueString;
                Arguments = nodes[2].ChildNodes.Select(n => (VIPFunctionDefinitionArgument)n.AstNode).ToArray();
                AddChild(nodes[3].ChildNodes.Select(n => n.ChildNodes[0]));
            }
        }

        public VIPTypeIdentifierNode Type;
        public string Name;
        public VIPFunctionDefinitionArgument[] Arguments;
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
            SpecialArguments = nodes[3].ChildNodes;
            if (nodes.Count >= 5)
                ConstructorArguments = nodes[4].ChildNodes;
        }

        public VIPQualifiedIdentifierNode Object;
        public string Name;
        public ParseTreeNodeList SpecialArguments;
        public ParseTreeNodeList ConstructorArguments;
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
            if (nodes[5].AstNode is VIPPathIdentifierNode)
                Path = ((VIPPathIdentifierNode)nodes[5].AstNode).Path;
            else if (((VIPExpressionNode)nodes[5].AstNode).ChildNodes[0] is VIPStringLiteralNode)
                Path = ((VIPStringLiteralNode)((VIPExpressionNode)nodes[5].AstNode).ChildNodes[0]).Value;
            else
                throw new NotImplementedException();
        }

        public string Handle, Type, Filter, ClampMode, Path;
    }

    public class VIPCalResDefinitionNode : VIPNode
    {
        public override void Accept(IVIPNodeVisitor visitor) => visitor.Visit(this);

        public override void InitChildren(ParseTreeNodeList nodes)
        {
            Handle = ((VIPPlainIdentifierNode)nodes[1].AstNode).Name;
            ExpressionList = (VIPExpressionListNode)nodes[2].AstNode;
        }

        public string Handle;
        public VIPExpressionListNode ExpressionList;
    }

    public class VIPStringResDefinition : VIPNode
    {
        public override void Accept(IVIPNodeVisitor visitor) => visitor.Visit(this);

        public override void InitChildren(ParseTreeNodeList nodes)
        {
            Handle = nodes[1].Token.ValueString;
            BaseList = (VIPQualifiedIdentifierNode)nodes[2].AstNode;
            ScaleX = (VIPExpressionNode)nodes[3].AstNode;
            ScaleY = (VIPExpressionNode)nodes[4].AstNode;
            SpaceX = (VIPExpressionNode)nodes[5].AstNode;
            if (nodes.Count >= 7)
                SpaceY = (VIPExpressionNode)nodes[6].AstNode;
        }

        public string Handle;
        public VIPQualifiedIdentifierNode BaseList;
        public VIPExpressionNode ScaleX, ScaleY, SpaceX, SpaceY;
    }

    public class VIPExpressionListNode : VIPNode
    {
        public override void Accept(IVIPNodeVisitor visitor) => visitor.Visit(this);

        public override void InitChildren(ParseTreeNodeList nodes) => AddChild(nodes);
    }

    public class VIPArrListNode : VIPNode
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
            ExtractIndices((VIPArrListNode)nodes[2].AstNode, out Index1, out Index2);
        }

        public VIPTypeIdentifierNode Type;
        public string Identifier;
        public VIPExpressionNode Index1, Index2;
    }

    public class VIPCommandsNode : VIPNode
    {
        public override void Accept(IVIPNodeVisitor visitor) => visitor.Visit(this);

        public override void InitChildren(ParseTreeNodeList nodes) => AddChild(nodes);
    }

    public class VIPMainNode : VIPNode
    {
        public override void Accept(IVIPNodeVisitor visitor) => visitor.Visit(this);

        public override void InitChildren(ParseTreeNodeList nodes) => AddChild(nodes[1].ChildNodes.Select(n => n.ChildNodes[0]));
    }

    public class VIPCommandNode : VIPNode
    {
        public override void Accept(IVIPNodeVisitor visitor) => visitor.Visit(this);

        public override void InitChildren(ParseTreeNodeList nodes) => AddChild(nodes);
    }

    public class VIPNakedCommandNode : VIPNode
    {
        public override void Accept(IVIPNodeVisitor visitor) => visitor.Visit(this);

        public override void InitChildren(ParseTreeNodeList nodes) => AddChild(nodes);
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

    public class VIPReferenceLiteralNode : VIPNode
    {
        public override void Accept(IVIPNodeVisitor visitor) => visitor.Visit(this);

        public override void Init(AstContext context, ParseTreeNode treeNode) => base.Init(context, treeNode);
    }

    public class VIPReferenceIdentifier : VIPNode
    {
        public override void Accept(IVIPNodeVisitor visitor) => visitor.Visit(this);

        public override void Init(AstContext context, ParseTreeNode node)
        {
            base.Init(context, node);
            Available = node.ChildNodes.Count > 0;
        }

        public bool Available;
    }

    public class VIPArrNode : VIPNode
    {
        public override void Accept(IVIPNodeVisitor visitor) => visitor.Visit(this);

        public override void InitChildren(ParseTreeNodeList nodes)
        {
            Expression = (VIPExpressionNode)nodes[1].AstNode;
        }

        public VIPExpressionNode Expression;
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

        public override void InitChildren(ParseTreeNodeList nodes) =>
            Operator = nodes[0].Token.ValueString;

        public string Operator { get; set; }
    }

    public class VIPIncrementOpsNode : VIPNode
    {
        public override void Accept(IVIPNodeVisitor visitor) => visitor.Visit(this);

        public override void InitChildren(ParseTreeNodeList nodes) =>
            Operator = nodes[0].Token.ValueString;

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

    public class VIPStringLiteralNode : VIPNode
    {
        public override void Accept(IVIPNodeVisitor visitor) => visitor.Visit(this);

        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            Value = treeNode.Token.ValueString;
        }

        public string Value;
    }

    public class VIPCharLiteralNode : VIPNode
    {
        public override void Accept(IVIPNodeVisitor visitor) => visitor.Visit(this);

        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            Value = treeNode.Token.ValueString[0];
        }

        public char Value;
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

        public override void InitChildren(ParseTreeNodeList nodes)
        {
            Name = ((VIPPlainIdentifierNode)nodes[0].AstNode).Name;
            ExtractIndices((VIPArrListNode)nodes[1].AstNode, out Index1, out Index2);
        }

        public string Name;
        public VIPExpressionNode Index1, Index2;
    }

    public class VIPQualifiedIdentifierNode : VIPNode
    {
        public override void Accept(IVIPNodeVisitor visitor) => visitor.Visit(this);

        public override void InitChildren(ParseTreeNodeList nodes) =>
            Parts = nodes.Select(n => Tuple.Create(((VIPIdentifierNode)n.AstNode).Name, ((VIPIdentifierNode)n.AstNode).Index1, ((VIPIdentifierNode)n.AstNode).Index2)).ToArray();

        // tuple of name and index
        public Tuple<string, VIPExpressionNode, VIPExpressionNode>[] Parts;
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

        public override void InitChildren(ParseTreeNodeList nodes)
        {
            ScaleX = (VIPExpressionNode)nodes[1].AstNode;
            if (nodes.Count >= 3)
                ScaleX = (VIPExpressionNode)nodes[2].AstNode;
        }
        public VIPExpressionNode ScaleX, ScaleY;
    }

    public class VIPRotateCommandNode : VIPNode
    {
        public override void Accept(IVIPNodeVisitor visitor) => visitor.Visit(this);

        public override void InitChildren(ParseTreeNodeList nodes) =>
            Angle = (VIPExpressionNode)nodes[1].AstNode;

        public VIPExpressionNode Angle;
    }

    public class VIPLightCommandNode : VIPNode
    {
        public override void Accept(IVIPNodeVisitor visitor) => visitor.Visit(this);

        public override void InitChildren(ParseTreeNodeList nodes)
        {
            if (nodes[1].Token != null)
            {
                if (nodes[1].Token.ValueString.EqualsI("on"))
                    On = true;
                else if (nodes[1].Token.ValueString.EqualsI("off"))
                    Off = true;
            }
            else
                Intensity = (VIPExpressionNode)nodes[1].AstNode;
        }

        public bool On, Off;
        public VIPExpressionNode Intensity;
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

    public class VIPMatrixCommandNode : VIPNode
    {
        public override void Accept(IVIPNodeVisitor visitor) => visitor.Visit(this);

        public override void InitChildren(ParseTreeNodeList nodes) =>
            Type = nodes[1].Token.ValueString;

        public string Type;
    }

    public class VIPHotSpotCommandNode : VIPNode
    {
        public override void Accept(IVIPNodeVisitor visitor) => visitor.Visit(this);

        public override void InitChildren(ParseTreeNodeList nodes)
        {
            X = (VIPExpressionNode)nodes[1].AstNode;
            Y = (VIPExpressionNode)nodes[2].AstNode;
            W = (VIPExpressionNode)nodes[3].AstNode;
            H = (VIPExpressionNode)nodes[4].AstNode;
            Ref = nodes[5].Token.ValueString;
            Var = (VIPQualifiedIdentifierNode)nodes[6].AstNode;
            Trigger = nodes[7].Token.ValueString.EqualsI("selected") ? HotSpotTrigger.Selected
                  : nodes[7].Token.ValueString.EqualsI("select_edge") ? HotSpotTrigger.SelectEdge
                  : nodes[7].Token.ValueString.EqualsI("release_edge") ? HotSpotTrigger.ReleaseEdge
                  : nodes[7].Token.ValueString.EqualsI("double_clicked") ? HotSpotTrigger.DoubleClicked
                  : HotSpotTrigger.Hover;
            Type = nodes[8].Token.ValueString.EqualsI("momentary") ? HotSpotType.Momentary : HotSpotType.Alternate;
            TrueValue = (VIPExpressionNode)nodes[9].AstNode;
            FalseValue = (VIPExpressionNode)nodes[10].AstNode;
            HoverBox = nodes[11].Token.ValueString.EqualsI("never") ? HoverBox.Never
                : nodes[11].Token.ValueString.EqualsI("always") ? HoverBox.Always
                : HoverBox.Hover;
            if (nodes.Count >= 13)
                DisplayObject = (VIPQualifiedIdentifierNode)nodes[12].AstNode;
        }

        public VIPExpressionNode X, Y, W, H, TrueValue, FalseValue;
        public string Ref;
        public VIPQualifiedIdentifierNode Var, DisplayObject;
        public HotSpotType Type;
        public HotSpotTrigger Trigger;
        public HoverBox HoverBox;
    }

    public class VIPRotaryKnobCommandNode : VIPNode
    {
        public override void Accept(IVIPNodeVisitor visitor) => visitor.Visit(this);

        public override void InitChildren(ParseTreeNodeList nodes)
        {
            X = (VIPExpressionNode)nodes[1].AstNode;
            Y = (VIPExpressionNode)nodes[2].AstNode;
            R = (VIPExpressionNode)nodes[3].AstNode;
            Var = (VIPQualifiedIdentifierNode)nodes[4].AstNode;
            StartAngle = (VIPExpressionNode)nodes[5].AstNode;
            EndAngle = (VIPExpressionNode)nodes[6].AstNode;
            MinValue = (VIPExpressionNode)nodes[7].AstNode;
            MaxValue = (VIPExpressionNode)nodes[8].AstNode;
            HoverBox = nodes[9].Token.ValueString.EqualsI("never") ? HoverBox.Never
                : nodes[9].Token.ValueString.EqualsI("always") ? HoverBox.Always
                : HoverBox.Hover;
            WheelDelta = (VIPExpressionNode)nodes[10].AstNode;
            if (nodes.Count >= 12)
                DisplayObject = (VIPQualifiedIdentifierNode)nodes[11].AstNode;
        }

        public VIPExpressionNode X, Y, R, StartAngle, EndAngle, MinValue, MaxValue, WheelDelta;
        public VIPQualifiedIdentifierNode Var, DisplayObject;
        public HoverBox HoverBox;
    }

    public class VIPSliderCommandNode : VIPNode
    {
        public override void Accept(IVIPNodeVisitor visitor) => visitor.Visit(this);

        public override void InitChildren(ParseTreeNodeList nodes)
        {
            X = (VIPExpressionNode)nodes[1].AstNode;
            Y = (VIPExpressionNode)nodes[2].AstNode;
            W = (VIPExpressionNode)nodes[3].AstNode;
            H = (VIPExpressionNode)nodes[4].AstNode;
            Ref = nodes[5].Token.ValueString;
            Angle = (VIPExpressionNode)nodes[6].AstNode;
            Var = (VIPQualifiedIdentifierNode)nodes[7].AstNode;
            MinValue = (VIPExpressionNode)nodes[8].AstNode;
            MaxValue = (VIPExpressionNode)nodes[9].AstNode;
            HoverBox = nodes[10].Token.ValueString.EqualsI("never") ? HoverBox.Never
                : nodes[10].Token.ValueString.EqualsI("always") ? HoverBox.Always
                : HoverBox.Hover;
            WheelDelta = (VIPExpressionNode)nodes[11].AstNode;
            if (nodes.Count >= 13)
                DisplayObject = (VIPQualifiedIdentifierNode)nodes[12].AstNode;
        }

        public VIPExpressionNode X, Y, W, H, Angle, MinValue, MaxValue, WheelDelta;
        public VIPQualifiedIdentifierNode Var, DisplayObject;
        public HoverBox HoverBox;
        public string Ref;
    }

    public class VIPStringCommandNode : VIPNode
    {
        public override void Accept(IVIPNodeVisitor visitor) => visitor.Visit(this);

        public override void InitChildren(ParseTreeNodeList nodes)
        {
            X = (VIPExpressionNode)nodes[1].AstNode;
            Y = (VIPExpressionNode)nodes[2].AstNode;
            Ref = nodes[3].Token.ValueString;
            StringData = (VIPNode)nodes[5].AstNode;
            CharCount = (VIPExpressionNode)nodes[6].AstNode;

            if (nodes.Count >= 11)
            {
                // no string res
                BaseList = (VIPQualifiedIdentifierNode)nodes[7].AstNode;
                ScaleX = (VIPExpressionNode)nodes[8].AstNode;
                ScaleY = (VIPExpressionNode)nodes[9].AstNode;
                SpaceX = (VIPExpressionNode)nodes[10].AstNode;
                if (nodes.Count > 11)
                    SpaceY = (VIPExpressionNode)nodes[11].AstNode;
            }
            else
            {
                // string res
                StringRes = (VIPNode)nodes[4].AstNode;
            }
        }

        public VIPExpressionNode X, Y, ScaleX, ScaleY, CharCount, SpaceX, SpaceY;
        public string Ref;
        public VIPNode StringData, BaseList, StringRes;
    }

    public class VIPBitmapCommandNode : VIPNode
    {
        public override void Accept(IVIPNodeVisitor visitor) => visitor.Visit(this);

        public override void InitChildren(ParseTreeNodeList _nodes)
        {
            var nodes = _nodes[1].ChildNodes;

            if (nodes.Count >= 10)
            {
                // no bitmapres
                BitmapType = ((VIPQualifiedIdentifierNode)((VIPExpressionNode)nodes[0].AstNode).ChildNodes[0]).Parts[0].Item1;
                BitmapFilter = ((VIPQualifiedIdentifierNode)((VIPExpressionNode)nodes[1].AstNode).ChildNodes[0]).Parts[0].Item1;
                BitmapRepeat = ((VIPQualifiedIdentifierNode)((VIPExpressionNode)nodes[2].AstNode).ChildNodes[0]).Parts[0].Item1;
                BitmapPath = ((VIPStringLiteralNode)((VIPExpressionNode)nodes[3].AstNode).ChildNodes[0]).Value;
                Blend = ((VIPQualifiedIdentifierNode)((VIPExpressionNode)nodes[4].AstNode).ChildNodes[0]).Parts[0].Item1;
                X = (VIPExpressionNode)nodes[5].AstNode;
                Y = (VIPExpressionNode)nodes[6].AstNode;
                W = (VIPExpressionNode)nodes[7].AstNode;
                H = (VIPExpressionNode)nodes[8].AstNode;
                Ref = ((VIPQualifiedIdentifierNode)((VIPExpressionNode)nodes[9].AstNode).ChildNodes[0]).Parts[0].Item1;
                if (nodes.Count >= 11)
                    UVCoords = (VIPQualifiedIdentifierNode)((VIPExpressionNode)nodes[10].AstNode).ChildNodes[0];
            }
            else
            {
                Handle = (VIPQualifiedIdentifierNode)((VIPExpressionNode)nodes[0].AstNode).ChildNodes[0];
                Blend = ((VIPQualifiedIdentifierNode)((VIPExpressionNode)nodes[1].AstNode).ChildNodes[0]).Parts[0].Item1;
                X = (VIPExpressionNode)nodes[2].AstNode;
                Y = (VIPExpressionNode)nodes[3].AstNode;
                W = (VIPExpressionNode)nodes[4].AstNode;
                H = (VIPExpressionNode)nodes[5].AstNode;
                Ref = ((VIPQualifiedIdentifierNode)((VIPExpressionNode)nodes[6].AstNode).ChildNodes[0]).Parts[0].Item1;
                if (nodes.Count >= 8)
                    UVCoords = (VIPQualifiedIdentifierNode)((VIPExpressionNode)nodes[7].AstNode).ChildNodes[0];
            }
        }

        public VIPQualifiedIdentifierNode Handle;
        public string Blend;
        public VIPExpressionNode X, Y, W, H;
        public string Ref;
        public VIPQualifiedIdentifierNode UVCoords;
        public string BitmapType, BitmapFilter, BitmapRepeat, BitmapPath;
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
            AddChild(nodes[2].ChildNodes);
            if (nodes.Count >= 4 && (nodes[3].Token?.ValueString.EqualsI("else") ?? false))
                ElseCommands = nodes[4].ChildNodes.Select(n => (VIPNode)n.AstNode).ToArray();
        }

        public VIPExpressionNode Test;
        public VIPNode[] ElseCommands;
    }

    public class VIPForCommandNode : VIPNode
    {
        public override void Accept(IVIPNodeVisitor visitor) => visitor.Visit(this);

        public override void InitChildren(ParseTreeNodeList nodes)
        {
            InitCommand = (VIPNakedCommandNode)nodes[1].AstNode;
            Test = (VIPExpressionNode)nodes[2].AstNode;
            StepCommand = (VIPNakedCommandNode)nodes[3].AstNode;
            AddChild(Enumerable.Repeat(nodes[4], 1));
        }

        public VIPNakedCommandNode InitCommand, StepCommand;
        public VIPExpressionNode Test;
    }

    public class VIPUnaryAssignmentCommandNode : VIPNode
    {
        public override void Accept(IVIPNodeVisitor visitor) => visitor.Visit(this);

        public override void InitChildren(ParseTreeNodeList nodes)
        {
            if (nodes[0].AstNode is VIPQualifiedIdentifierNode)
            {
                Prefix = false;
                Identifier = (VIPQualifiedIdentifierNode)nodes[0].AstNode;
                Operation = ((VIPIncrementOpsNode)nodes[1].AstNode).Operator;
            }
            else
            {
                Prefix = true;
                Identifier = (VIPQualifiedIdentifierNode)nodes[1].AstNode;
                Operation = ((VIPIncrementOpsNode)nodes[0].AstNode).Operator;
            }
        }

        public string Operation;
        public bool Prefix;
        public VIPQualifiedIdentifierNode Identifier;
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

    public class VIPFormatCommandNode : VIPNode
    {
        public override void Accept(IVIPNodeVisitor visitor) => visitor.Visit(this);

        public override void InitChildren(ParseTreeNodeList nodes)
        {
            Result = (VIPQualifiedIdentifierNode)nodes[1].AstNode;
            Format = (VIPExpressionNode)nodes[2].AstNode;
            Value = (VIPQualifiedIdentifierNode)nodes[3].AstNode;
        }

        public VIPQualifiedIdentifierNode Result, Value;
        public VIPExpressionNode Format;
    }

    public class VIPColorCommandNode : VIPNode
    {
        public override void Accept(IVIPNodeVisitor visitor) => visitor.Visit(this);

        public override void InitChildren(ParseTreeNodeList nodes)
        {
            if (nodes[1].AstNode is VIPQualifiedIdentifierNode)
            {
                // save/restore?
                var qnode = (VIPQualifiedIdentifierNode)nodes[1].AstNode;
                if (qnode.Parts.Length == 1)
                    if (qnode.Parts[0].Item1.EqualsI("save"))
                    {
                        Save = true;
                        return;
                    }
                    else if (qnode.Parts[0].Item1.EqualsI("restore"))
                    {
                        Restore = true;
                        return;
                    }

                ArrayName = qnode;
            }
            else if (nodes.Count > 3)
            {
                R = (VIPExpressionNode)nodes[1].AstNode;
                G = (VIPExpressionNode)nodes[2].AstNode;
                B = (VIPExpressionNode)nodes[3].AstNode;
                if (nodes.Count > 4)
                    A = (VIPExpressionNode)nodes[4].AstNode;
            }
            else if (nodes.Count > 2)
            {
                C = (VIPExpressionNode)nodes[1].AstNode;
                A = (VIPExpressionNode)nodes[2].AstNode;
            }
            else if (nodes.Count > 1)
            {
                C = (VIPExpressionNode)nodes[1].AstNode;
            }
        }

        public VIPQualifiedIdentifierNode ArrayName;
        public VIPExpressionNode R, G, B, A, C;
        public bool Save, Restore;
    }

    public class VIPLineWidthCommandNode : VIPNode
    {
        public override void Accept(IVIPNodeVisitor visitor) => visitor.Visit(this);

        public override void InitChildren(ParseTreeNodeList nodes)
        {
            if (nodes[1].Token != null)
            {
                // save/restore?
                if (nodes[1].Token.ValueString.EqualsI("save"))
                {
                    Save = true;
                    return;
                }
                else if (nodes[1].Token.ValueString.EqualsI("restore"))
                {
                    Restore = true;
                    return;
                }
            }
            else
                Expression = (VIPExpressionNode)nodes[1].AstNode;
        }

        public VIPExpressionNode Expression;
        public bool Save, Restore;
    }

    public class VIPLightColorCommandNode : VIPNode
    {
        public override void Accept(IVIPNodeVisitor visitor) => visitor.Visit(this);

        public override void InitChildren(ParseTreeNodeList nodes)
        {
            if (nodes[1].AstNode is VIPQualifiedIdentifierNode)
            {
                // save/restore?
                var qnode = (VIPQualifiedIdentifierNode)nodes[1].AstNode;
                if (qnode.Parts.Length == 1)
                    if (qnode.Parts[0].Item1.EqualsI("save"))
                    {
                        Save = true;
                        return;
                    }
                    else if (qnode.Parts[0].Item1.EqualsI("restore"))
                    {
                        Restore = true;
                        return;
                    }

                ArrayName = qnode;
            }
            else if (nodes.Count > 3)
            {
                R = (VIPExpressionNode)nodes[1].AstNode;
                G = (VIPExpressionNode)nodes[2].AstNode;
                B = (VIPExpressionNode)nodes[3].AstNode;
                if (nodes.Count > 4)
                    A = (VIPExpressionNode)nodes[4].AstNode;
            }
            else if (nodes.Count > 2)
            {
                C = (VIPExpressionNode)nodes[1].AstNode;
                A = (VIPExpressionNode)nodes[2].AstNode;
            }
            else if (nodes.Count > 1)
            {
                C = (VIPExpressionNode)nodes[1].AstNode;
            }
        }

        public VIPQualifiedIdentifierNode ArrayName;
        public VIPExpressionNode R, G, B, A, C;
        public bool Save, Restore;
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


    public class VIPPolygonCommandNode : VIPNode
    {
        public override void Accept(IVIPNodeVisitor visitor) => visitor.Visit(this);

        public override void InitChildren(ParseTreeNodeList nodes)
        {
            if (nodes[2].AstNode is VIPQualifiedIdentifierNode && nodes[1].AstNode is VIPQualifiedIdentifierNode)
            {
                VerticesIdentifier = (VIPQualifiedIdentifierNode)nodes[1].AstNode;
                ColorsIdentifier = (VIPQualifiedIdentifierNode)nodes[2].AstNode;
            }
            else
                ExpressionList = (VIPExpressionListNode)nodes[1].AstNode;
        }

        public VIPQualifiedIdentifierNode VerticesIdentifier, ColorsIdentifier;
        public VIPExpressionListNode ExpressionList;
    }

    public class VIPShapeCommandNode : VIPNode
    {
        public override void Accept(IVIPNodeVisitor visitor) => visitor.Visit(this);

        public override void InitChildren(ParseTreeNodeList nodes)
        {
            Command = nodes[0].Token.ValueString;
            ExpressionList = (VIPExpressionListNode)nodes[1].AstNode;
        }

        public string Command;
        public VIPExpressionListNode ExpressionList;
    }

    public class VIPBoxCommandNode : VIPNode
    {
        public override void Accept(IVIPNodeVisitor visitor) => visitor.Visit(this);

        public override void InitChildren(ParseTreeNodeList nodes)
        {
            X = (VIPExpressionNode)nodes[1].AstNode;
            Y = (VIPExpressionNode)nodes[2].AstNode;
            W = (VIPExpressionNode)nodes[3].AstNode;
            H = (VIPExpressionNode)nodes[4].AstNode;
            Ref = ((VIPPlainIdentifierNode)nodes[5].AstNode).Name;
            if (nodes.Count >= 7)
                Filled = true;
        }

        public VIPExpressionNode X, Y, W, H;
        public string Ref;
        public bool Filled;
    }

    public class VIPLoopCommandNode : VIPNode
    {
        public override void Accept(IVIPNodeVisitor visitor) => visitor.Visit(this);

        public override void InitChildren(ParseTreeNodeList nodes)
        {
            Expression = (VIPExpressionNode)nodes[1].AstNode;
            Command = (VIPCommandNode)nodes[2].AstNode;
        }

        public VIPExpressionNode Expression;
        public VIPCommandNode Command;
    }

    public class VIPDisplayCommandNode : VIPNode
    {
        public override void Accept(IVIPNodeVisitor visitor) => visitor.Visit(this);

        public override void InitChildren(ParseTreeNodeList nodes)
        {
            X = (VIPExpressionNode)nodes[1].AstNode;
            Y = (VIPExpressionNode)nodes[2].AstNode;
            List = (VIPQualifiedIdentifierNode)nodes[3].AstNode;
        }

        public VIPExpressionNode X, Y;
        public VIPQualifiedIdentifierNode List;
    }

    public class VIPClipCommandNode : VIPNode
    {
        public override void Accept(IVIPNodeVisitor visitor) => visitor.Visit(this);

        public override void InitChildren(ParseTreeNodeList nodes)
        {
            if (nodes.Count == 2)
                Off = true;
            else
            {
                X = (VIPExpressionNode)nodes[1].AstNode;
                Y = (VIPExpressionNode)nodes[2].AstNode;
                List = (VIPQualifiedIdentifierNode)nodes[3].AstNode;
            }
        }

        public VIPExpressionNode X, Y;
        public VIPQualifiedIdentifierNode List;
        public bool Off;
    }

    public class VIPCalCommandNode : VIPNode
    {
        public override void Accept(IVIPNodeVisitor visitor) => visitor.Visit(this);

        public override void InitChildren(ParseTreeNodeList nodes)
        {
            CalRes = (VIPQualifiedIdentifierNode)nodes[1].AstNode;
            Input = (VIPExpressionNode)nodes[2].AstNode;
            Output = (VIPQualifiedIdentifierNode)nodes[3].AstNode;
        }

        public VIPExpressionNode Input;
        public VIPQualifiedIdentifierNode CalRes, Output;
    }

    public class VIPArcCommandNode : VIPNode
    {
        public override void Accept(IVIPNodeVisitor visitor) => visitor.Visit(this);

        public override void InitChildren(ParseTreeNodeList nodes)
        {
            X = (VIPExpressionNode)nodes[1].AstNode;
            Y = (VIPExpressionNode)nodes[2].AstNode;
            InnerRadius = (VIPExpressionNode)nodes[3].AstNode;
            OuterRadius = (VIPExpressionNode)nodes[4].AstNode;
            StartAngle = (VIPExpressionNode)nodes[5].AstNode;
            EndAngle = (VIPExpressionNode)nodes[6].AstNode;
            Steps = (VIPExpressionNode)nodes[7].AstNode;
            if (nodes.Count >= 9)
                Filled = true;
        }

        public VIPExpressionNode X, Y, InnerRadius, OuterRadius, StartAngle, EndAngle, Steps;
        public bool Filled;
    }
}
