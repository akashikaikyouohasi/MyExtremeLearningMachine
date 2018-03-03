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

        //C++DLLでは、void InverseMat(int dim, float a[], float ans[]) と定義している。
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
        [DllImport("DllEigen", EntryPoint = "InverseMat", CallingConvention = CallingConvention.Cdecl)]
        private static extern void InverseMat(int dim, float[] a, float[] ans);

        private void Matrix2Array(float[,] Mat, ref float[] Arr)
        {
            /*
             * 2次元配列を１次元配列に変換する関数
             * Eigen.dllでは、１次元配列で行列を渡すため必要な関数
             */

            int count = 0;
            //多次元配列なので、Lengthでは要素数を返す。
            //要素数の平方根を計算し、行列の次元数を計算している。
            int dim = (int)Math.Sqrt(Mat.Length);

            //２次元配列の中身を１次元配列に順番に格納
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
            /*
             * １次元配列に格納されている２次元行列を、２次元配列に変換する関数。
             * Matrix2Arrayと逆の変換
             */

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
            /*
             * 逆行列を計算する関数
             * [入力]
             * ２次元配列に格納された正方行列
             * [出力]
             * 計算した逆行列
             */
            float[] arr = new float[Mat.Length];
            int dim = (int)Math.Sqrt(Mat.Length);
            float[,] AnsMat = new float[dim, dim];

            Matrix2Array(Mat, ref arr);
            float[] ansArr = new float[Mat.Length];
            InverseMat(dim, arr, ansArr);
            Array2Matrix(ansArr, AnsMat);

            return (float[,])AnsMat.Clone();
        }

    }
}
