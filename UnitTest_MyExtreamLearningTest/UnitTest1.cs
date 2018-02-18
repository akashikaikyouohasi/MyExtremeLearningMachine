using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyExtremeLearningMachine;

namespace UnitTest_MyExtremLearningTest
{
    [TestClass]
    public class MyAddUnitTest1
    {
        [TestMethod]
        public void MyAddTestMethod1()
        {
            var frm = new Program();
            int result = frm.MyAdd(1, 2);
            Assert.AreEqual(3, result);
        }
    }
}
