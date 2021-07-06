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
    public class CoreServiceOperationTests : ApiServiceBase
    {
        [TestMethod]
        public void Test_Greather_Than_1()
        {
            Assert.IsTrue(GreaterThan((object)true, "false", typeof(bool)));
        }

        [TestMethod]
        public void Test_Greather_Than_2()
        {
            Assert.ThrowsException<Exception>(() => GreaterThan((object)true, "false", typeof(decimal)));
        }

        [TestMethod]
        public void Test_Greather_Than_True_1()
        {
            Assert.IsTrue(GreaterThan(true, false));
        }

        [TestMethod]
        public void Test_Greather_Than_True_2()
        {
            Assert.IsFalse(GreaterThan(false, true));
        }

        [TestMethod]
        public void Test_Greather_Than_True_3()
        {
            Assert.IsFalse(GreaterThan(true, true));
        }

        [TestMethod]
        public void Test_Greather_Than_Int_1()
        {
            Assert.IsTrue(GreaterThan(3, 2));
        }

        [TestMethod]
        public void Test_Greather_Than_Int_2()
        {
            Assert.IsFalse(GreaterThan(3, 6));
        }

        [TestMethod]
        public void Test_Greather_Than_Int_3()
        {
            Assert.IsFalse(GreaterThan(3, 3));
        }

        [TestMethod]
        public void Test_Greather_Than_Double_1()
        {
            Assert.IsTrue(GreaterThan(4.1, 3.1));
        }

        [TestMethod]
        public void Test_Greather_Than_Double_2()
        {
            Assert.IsFalse(GreaterThan(4.1, 5.1));
        }

        [TestMethod]
        public void Test_Greather_Than_Double_3()
        {
            Assert.IsFalse(GreaterThan(4.1, 4.1));
        }

        [TestMethod]
        public void Test_Greather_Than_Float_1()
        {
            Assert.IsTrue(GreaterThan(4.1f, 3.1f));
        }

        [TestMethod]
        public void Test_Greather_Than_Float_2()
        {
            Assert.IsFalse(GreaterThan(4.1f, 5.1f));
        }

        [TestMethod]
        public void Test_Greather_Than_Float_3()
        {
            Assert.IsFalse(GreaterThan(4.1f, 4.1f));
        }

        [TestMethod]
        public void Test_Greather_Than_String_1()
        {
            Assert.IsTrue(GreaterThan("Test", "Int"));
        }

        [TestMethod]
        public void Test_Greather_Than_String_2()
        {
            Assert.IsFalse(GreaterThan("Int", "Test"));
        }

        [TestMethod]
        public void Test_Greather_Than_String_3()
        {
            Assert.IsFalse(GreaterThan("Test", "Test"));
        }
    }
}
