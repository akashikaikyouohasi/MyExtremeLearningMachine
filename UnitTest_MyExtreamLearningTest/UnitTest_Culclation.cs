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
            /*以下の内積を行う
             * | 2  -1| | 1|
             * |-3   4| | 2|
             */
            float[,] mat1 = new float[2, 2] { { 2f, -1f }, { -3f, 4f } };//初期化は、{ {0行目の内容}, {１行目の内容} }　　となっていることに注意　
            float[,] mat2 = new float[2, 1] { { 1f }, { 2f } };
            float[,] result = new float[2,1];
            float[,] answer = new float[2,1] { { 0f }, { 5f } };

            result = frm.CulcInnerProduct(mat1, mat2);
            CollectionAssert.AreEqual(answer, result);

            //テストパターン２
            /*以下の内積を行う
             *         | 8 4  2|
             * |1 5 9| | 1 3 -6|
             *         |-7 0  5| 
             */
            mat1 = new float[1, 3] { { 1f, 5f, 9f }};
            mat2 = new float[3, 3] { { 8f, 4f, 2f }, { 1f, 3f, -6f } , { -7f, 0f, 5f } };
            result = new float[1, 3];
            answer = new float[1, 3] { { -50f, 19f, 17f } };

            result = frm.CulcInnerProduct(mat1, mat2);
            CollectionAssert.AreEqual(answer, result);


        }

    }
}