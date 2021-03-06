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
    public class CoreServiceContainsTest : ApiServiceBase
    {
        [TestMethod]
        public void Test_Contains_1()
        {
            Assert.IsTrue(Contains("TestForTheWiningBug", "For", typeof(string)));
            Assert.IsFalse(Contains("TestForTheWiningBug", "Bugs", typeof(string)));
        }

    }
}
