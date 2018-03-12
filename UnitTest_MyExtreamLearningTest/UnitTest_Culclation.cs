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


        [TestMethod]
        public void CulcInnerProductTest()
        {
            var frm = new EigenFuncs();

            //テストパターン１
            float[,] mat1 = new float[2, 2] { { 2f, -3f }, { -1f, 4f } };
            float[,] mat2 = new float[2, 1] { { 1f }, { 2f } };
            float[,] result = new float[2,1];
            float[,] answer = new float[2,1] { { 0f }, { 5f } };

            result = frm.CulcInnerProduct(mat1, mat2);
            CollectionAssert.AreEqual(answer, result);

            //テストパターン２
            mat1 = new float[1, 3] { { 1f, 5f, 9f }};
            mat2 = new float[3, 3] { { 8f, 1f, -7f }, { 4f, 3f, 0f } , { 2f, -6f, 5f } };
            result = new float[1, 3];
            answer = new float[1, 3] { { -50f, 19f, 17f } };

            result = frm.CulcInnerProduct(mat1, mat2);
            CollectionAssert.AreEqual(answer, result);


        }

    }
}