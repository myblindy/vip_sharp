using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vip_sharp.Utils
{
    public static class GrammarUtils
    {
        public static NumberLiteral CreateNumberLiteral(string name)
        {
            NumberLiteral literal = new NumberLiteral(name, NumberOptions.AllowStartEndDot);
            literal.DefaultIntTypes = new TypeCode[] { TypeCode.Int32, TypeCode.UInt32, TypeCode.Int64, TypeCode.UInt64 };
            literal.DefaultFloatType = TypeCode.Double;
            literal.AddPrefix("0x", NumberOptions.Hex);
            TypeCode[] typeCodes = new TypeCode[] { TypeCode.UInt32, TypeCode.UInt64 };
            literal.AddSuffix("u", typeCodes);
            TypeCode[] codeArray3 = new TypeCode[] { TypeCode.Int64, TypeCode.UInt64 };
            literal.AddSuffix("l", codeArray3);
            TypeCode[] codeArray4 = new TypeCode[] { TypeCode.UInt64 };
            literal.AddSuffix("ul", codeArray4);
            TypeCode[] codeArray5 = new TypeCode[] { TypeCode.Single };
            literal.AddSuffix("f", codeArray5);
            TypeCode[] codeArray6 = new TypeCode[] { TypeCode.Double };
            literal.AddSuffix("d", codeArray6);
            TypeCode[] codeArray7 = new TypeCode[] { TypeCode.Decimal };
            literal.AddSuffix("m", codeArray7);
            return literal;
        }
    }
}
