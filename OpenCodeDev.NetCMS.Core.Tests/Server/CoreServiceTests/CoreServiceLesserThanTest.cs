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
    public class CoreServiceLesserThanTest : ApiServiceBase
    {
        [TestMethod]
        public void Test_Lesser_Than_1()
        {
            Assert.IsFalse(LesserThan((object)true, "false", typeof(bool)));
        }

        [TestMethod]
        public void Test_Lesser_Than_2()
        {
            Assert.ThrowsException<Exception>(() => LesserThan((object)true, "false", typeof(decimal)));
        }

        [TestMethod]
        public void Test_Lesser_Than_True_1()
        {
            Assert.IsFalse(LesserThan(true, false));
        }

        [TestMethod]
        public void Test_Lesser_Than_True_2()
        {
            Assert.IsTrue(LesserThan(false, true));
        }

        [TestMethod]
        public void Test_Lesser_Than_True_3()
        {
            Assert.IsFalse(LesserThan(true, true));
        }

        [TestMethod]
        public void Test_Lesser_Than_Int_1()
        {
            Assert.IsFalse(LesserThan(3, 2));
        }

        [TestMethod]
        public void Test_Lesser_Than_Int_2()
        {
            Assert.IsTrue(LesserThan(3, 6));
        }

        [TestMethod]
        public void Test_Lesser_Than_Int_3()
        {
            Assert.IsFalse(LesserThan(3, 3));
        }

        [TestMethod]
        public void Test_Lesser_Than_Double_1()
        {
            Assert.IsFalse(LesserThan(4.1, 3.1));
        }

        [TestMethod]
        public void Test_Lesser_Than_Double_2()
        {
            Assert.IsTrue(LesserThan(4.1, 5.1));
        }

        [TestMethod]
        public void Test_Lesser_Than_Double_3()
        {
            Assert.IsFalse(LesserThan(4.1, 4.1));
        }

        [TestMethod]
        public void Test_Lesser_Than_Float_1()
        {
            Assert.IsFalse(LesserThan(4.1f, 3.1f));
        }

        [TestMethod]
        public void Test_Lesser_Than_Float_2()
        {
            Assert.IsTrue(LesserThan(4.1f, 5.1f));
        }

        [TestMethod]
        public void Test_Lesser_Than_Float_3()
        {
            Assert.IsFalse(LesserThan(4.1f, 4.1f));
        }

        [TestMethod]
        public void Test_Lesser_Than_String_1()
        {
            Assert.IsFalse(LesserThan("Test", "Int"));
        }

        [TestMethod]
        public void Test_Lesser_Than_String_2()
        {
            Assert.IsTrue(LesserThan("Int", "Test"));
        }

        [TestMethod]
        public void Test_Lesser_Than_String_3()
        {
            Assert.IsFalse(LesserThan("Test", "Test"));
        }
    }
}
