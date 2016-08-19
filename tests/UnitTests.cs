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
            Step(vip);
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
            Step(vip);

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
            Step(vip);

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
            Step(vip);

            Assert.IsTrue(vip.__x == 20.556);
            Assert.IsTrue(vip.__val == "  20.56");
        }

        [TestMethod]
        public void Hotspots()
        {
            var vip = PrepareSource(@"
bool swstate;
double cnt;
double cnt2;

Main { 
	bool up;    hotspot(9,9,5,5,CL, up,   SELECTED, MOMENTARY, true, false, NEVER); if(up)   { swstate = true; }
	bool down;  hotspot(9,9,5,5,CU, down, SELECTED, MOMENTARY, true, false, NEVER); if(down) { swstate = false; }

	bool b;
	hotspot(0, -3, 3, 3, CC, b, SELECT_EDGE, MOMENTARY, true, false, ALWAYS);
	if(b) { cnt = cnt + 0.15; }

    hotspot(0, -6, 3, 3, CC, b, SELECTED, MOMENTARY, true, false, ALWAYS);
	if(b) { cnt2 = cnt2 + 0.15; }
}");

            vip_sharp.VIPRuntime.Instance.VIPSystemClass.MouseX = 9;
            vip_sharp.VIPRuntime.Instance.VIPSystemClass.MouseY = 10;
            vip_sharp.VIPRuntime.Instance.VIPSystemClass.LeftButtonDown = true;
            Step(vip);
            Assert.IsTrue(vip.__swstate);

            vip_sharp.VIPRuntime.Instance.VIPSystemClass.MouseX = 9;
            vip_sharp.VIPRuntime.Instance.VIPSystemClass.MouseY = 8;
            vip_sharp.VIPRuntime.Instance.VIPSystemClass.LeftButtonDown = true;
            Step(vip);
            Assert.IsFalse(vip.__swstate);

            vip_sharp.VIPRuntime.Instance.VIPSystemClass.MouseX = 0;
            vip_sharp.VIPRuntime.Instance.VIPSystemClass.MouseY = -3;
            vip_sharp.VIPRuntime.Instance.VIPSystemClass.LeftButtonDown = false;
            Step(vip);
            Assert.IsTrue(VIPTestFramework.Equals(vip.__cnt, 0));
            vip_sharp.VIPRuntime.Instance.VIPSystemClass.LeftButtonDown = true;
            Step(vip);
            Assert.IsTrue(VIPTestFramework.Equals(vip.__cnt, 0.15));
            Step(vip);
            Assert.IsTrue(VIPTestFramework.Equals(vip.__cnt, 0.15));
            Step(vip);
            Assert.IsTrue(VIPTestFramework.Equals(vip.__cnt, 0.15));
            vip_sharp.VIPRuntime.Instance.VIPSystemClass.LeftButtonDown = false;
            Step(vip);
            Assert.IsTrue(VIPTestFramework.Equals(vip.__cnt, 0.15));
            vip_sharp.VIPRuntime.Instance.VIPSystemClass.LeftButtonDown = true;
            Step(vip);
            Assert.IsTrue(VIPTestFramework.Equals(vip.__cnt, 0.3));
            Step(vip);
            Assert.IsTrue(VIPTestFramework.Equals(vip.__cnt, 0.3));
            vip_sharp.VIPRuntime.Instance.VIPSystemClass.MouseX = 10;
            vip_sharp.VIPRuntime.Instance.VIPSystemClass.MouseY = -3;
            Step(vip);
            Assert.IsTrue(VIPTestFramework.Equals(vip.__cnt, 0.3));
            vip_sharp.VIPRuntime.Instance.VIPSystemClass.MouseX = 0;
            vip_sharp.VIPRuntime.Instance.VIPSystemClass.MouseY = -3;
            Step(vip);
            Assert.IsTrue(VIPTestFramework.Equals(vip.__cnt, 0.45));
            Step(vip);
            Assert.IsTrue(VIPTestFramework.Equals(vip.__cnt, 0.45));

            vip_sharp.VIPRuntime.Instance.VIPSystemClass.MouseX = 0;
            vip_sharp.VIPRuntime.Instance.VIPSystemClass.MouseY = -6;
            vip_sharp.VIPRuntime.Instance.VIPSystemClass.LeftButtonDown = false;
            Step(vip);
            Assert.IsTrue(VIPTestFramework.Equals(vip.__cnt2, 0));
            vip_sharp.VIPRuntime.Instance.VIPSystemClass.LeftButtonDown = true;
            Step(vip);
            Assert.IsTrue(VIPTestFramework.Equals(vip.__cnt2, 0.15));
            Step(vip);
            Assert.IsTrue(VIPTestFramework.Equals(vip.__cnt2, 0.3));
            Step(vip);
            Assert.IsTrue(VIPTestFramework.Equals(vip.__cnt2, 0.45));
            vip_sharp.VIPRuntime.Instance.VIPSystemClass.LeftButtonDown = false;
            Step(vip);
            Assert.IsTrue(VIPTestFramework.Equals(vip.__cnt2, 0.45));
        }
    }
}
