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
    public class CoreServiceEndsWithTest : ApiServiceBase
    {
        [TestMethod]
        public void Test_Endswith_1()
        {
            Assert.IsTrue(Endswith("TestForTheWiningBug", "Bug", typeof(string)));
            Assert.IsFalse(Endswith("TestForTheWiningBug", "Bugs", typeof(string)));
        }

    }
}
