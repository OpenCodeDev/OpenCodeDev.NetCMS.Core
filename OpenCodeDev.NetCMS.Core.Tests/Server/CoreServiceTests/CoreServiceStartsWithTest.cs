using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenCodeDev.NetCMS.Core.Server.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCodeDev.NetCMS.Core.Tests.Server
{
    [TestCategory("Comparison")]
    [TestClass]
    public class CoreServiceStartsWithTest : ApiServiceBase
    {
        [TestMethod]
        public void Test_StartsWith_1()
        {
            Assert.IsTrue(StartsWith("TestForTheWiningBug", "Test", typeof(string)));
            Assert.IsFalse(StartsWith("TestForTheWiningBug", "Bugs", typeof(string)));
        }

    }
}
