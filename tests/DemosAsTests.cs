using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Reflection;
using vip_sharp;

namespace tests
{
    [TestClass]
    public class DemosAsTests
    {
        [TestMethod]
        public void Demos()
        {
            var folder = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetLocalPath()), @"..\..\..\vip_sharp\demos\");
            var files = Directory.GetFiles(folder, "*.vip");

            foreach (var file in files)
            {
                Directory.SetCurrentDirectory(Path.GetDirectoryName(file));
                var obj = VIPTestFramework.PrepareFile(file);
                VIPTestFramework.Step(obj);
            }
        }
    }
}
