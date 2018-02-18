using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;   //Dll用



namespace MyExtremeLearningMachine
{
    class EigenFuncs
    {

        //C++DLLでは、void InverseMat_FullPivLU(int dim, float a[], float ans[]) と定義している。
        //DllImport属性の引数に、参照したいネイティブ ライブラリの名前を書く
        //C# 側の型とネイティブ側の型には対応関係があるので、適切に置き換えて戻り値や引数を並べる
        //externは実装が外にあることを示すための修飾子で、P/Invoke 用の機能です。
        /*
         *[] は属性を表す。クラスやメンバにユーザが指定した追加情報を与える。 
         * 以下、定義。
         * [属性名(属性パラメータ)]
         * メンバーの定義
         * 
         * dllはexeと同じディレクトリに配置する。
         */
        [DllImport("DllEigen", EntryPoint = "InverseMat_FullPivLU", CallingConvention = CallingConvention.Cdecl)]
        private static extern void InverseMat_FullPivLU(int dim, float[] a, float[] ans);

        private void Matrix2Array(float[,] Mat, ref float[] Arr)
        {
            int count = 0;
            int dim = (int)Math.Sqrt(Mat.Length);
            for (int c = 0; c < dim; c++)
            {
                for (int r = 0; r < dim; r++)
                {
                    Arr[count] = Mat[c, r];
                    count++;
                }
            }
        }

        private void Array2Matrix(float[] Arr, float[,] Mat)
        {
            int count = 0;
            int dim = (int)Math.Sqrt(Mat.Length);
            for (int c = 0; c < dim; c++)
            {
                for (int r = 0; r < dim; r++)
                {
                    Mat[c, r] = Arr[count];
                    count++;
                }
            }
        }

        public float[,] InverseMatrix(float[,] Mat)
        {
            float[] arr = new float[Mat.Length];
            int dim = (int)Math.Sqrt(Mat.Length);
            float[,] AnsMat = new float[dim, dim];

            Matrix2Array(Mat, ref arr);
            float[] ansArr = new float[Mat.Length];
            InverseMat_FullPivLU(dim, arr, ansArr);
            Array2Matrix(ansArr, AnsMat);

            return (float[,])AnsMat.Clone();
        }

    }
}
