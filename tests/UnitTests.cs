using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static tests.VIPTestFramework;

namespace tests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod, ExpectedException(typeof(NullReferenceException))]
        public void EmptySource()
        {
            PrepareSource("");
        }

        [TestMethod]
        public void EmptyMain()
        {
            var vip = PrepareSource("Main { }");
            vip.Run();
        }

        [TestMethod]
        public void BasicMath()
        {
            var vip = PrepareSource(@"
double x;
double y;
double res;

Main { 
    x = 25;
    y = 39;
    y = y + 24;
    res = y - x;
}");
            vip.Run();

            Assert.IsTrue(vip.__x == 25);
            Assert.IsTrue(vip.__y == 39 + 24);
            Assert.IsTrue(vip.__res == 39 + 24 - 25);
        }

        [TestMethod]
        public void Ifs()
        {
            var vip = PrepareSource(@"
double a;
double b;

Main { 
    a = 20; b = 30;
    a = a - b;
    if(a<b) { a = a + 5; } else { b = b + 5; } 
    if(a) { b = b - a; }
}");
            vip.Run();

            Assert.IsTrue(vip.__a == -5);
            Assert.IsTrue(vip.__b == 35);
        }

        [TestMethod]
        public void Format()
        {
            var vip = PrepareSource(@"
char val[8];
double x;

Main { 
    x = 20.556;
	Format(val, "" % .2f"", x);
}");
            vip.Run();

            Assert.IsTrue(vip.__x == 20.556);
            Assert.IsTrue(vip.__val == "  20.56");
        }
    }
}
