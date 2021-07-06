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
    public class CoreServiceEqualsTest : ApiServiceBase
    {
        [TestMethod]
        public void Test_Equals_1()
        {
            Assert.IsTrue(Equals("TestForTheWiningBug", "TestForTheWiningBug", typeof(string)));
            Assert.IsFalse(Equals("TestForTheWiningBug", "Bugs", typeof(string)));
        }

    }
}
