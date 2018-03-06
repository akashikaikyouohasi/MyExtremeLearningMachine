using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyExtremeLearningMachine;

namespace UnitTest_MyExtremLearningTest
{
    [TestClass]
    public class UnitTest_EigenFuncs
    {
        [TestMethod]
        public void Matrix2ArrayTest()
        {
            var frm = new EigenFuncs();

            float[,] mat = new float[3, 3] { { 1f, 2f, 5f }, { 1f, -1f, 1f }, { 0f, 1f, 2f } };
            float[] result = new float[9];
            float[] arr = new float[9] { 1f, 2f, 5f ,1f, -1f, 1f,  0f, 1f, 2f  };

            frm.Matrix2Array(mat, ref result);
            CollectionAssert.AreEqual(arr, result);
        }
    }
}