using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;   //Dll用



namespace MyExtremeLearningMachine
{
    public class EigenFuncs
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
        private static extern void InverseMat(int dim_row, int dim_column, float[] a, float[] ans);

        public void Matrix2Array(float[,] Mat, ref float[] Arr)
        {
            /*
             * 2次元配列を１次元配列に変換する関数
             * Eigen.dllでは、１次元配列で行列を渡すため必要な関数
             */

            int count = 0;
            //多次元配列なので、Lengthでは要素数を返す。
            //行と列の次元数を得る。
            int dim_row = Mat.GetLength(0);
            int dim_column = Mat.GetLength(1);

            //２次元配列の中身を１次元配列に順番に格納
            for (int c = 0; c < dim_row; c++)
            {
                for (int r = 0; r < dim_column; r++)
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
            //行と列の次元数を得る。
            int dim_row = Mat.GetLength(0);
            int dim_column = Mat.GetLength(1);

            for (int c = 0; c < dim_row; c++)
            {
                for (int r = 0; r < dim_column; r++)
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
             * ２次元配列に格納された行列 0次元目：行、１次元目：列
             * [出力]
             * 計算した逆行列
             */
            float[] arr = new float[Mat.Length];
            float[,] AnsMat = new float[Mat.GetLength(0), Mat.GetLength(1)];

            //参照渡しで値を格納してもらう。
            Matrix2Array(Mat, ref arr);

            float[] ansArr = new float[Mat.Length];
            InverseMat(Mat.GetLength(0), Mat.GetLength(1), arr, ansArr);

            Array2Matrix(ansArr, AnsMat);

            //配列の実体をコピーして渡す。
            //そのまま返すと参照になる？（ポインタを渡す感じ？）
            return (float[,])AnsMat.Clone();
        }

        public float[,] CulcInnerProduct(float[,] mat1, float[,] mat2)
        {
            /*
             * 内積を計算する関数
             * [入力]
             * ２次元配列に格納された行列 0次元目：行、１次元目：列
             * Mat1 と Mat2の内積
             * [出力]
             * 計算した逆行列
             * 行数：mat1の行数
             * 列数：mat2の列数
             */
            float[] arr1 = new float[mat1.Length];
            float[] arr2 = new float[mat2.Length];

            float[,] ansmat = new float[mat1.GetLength(0), mat2.GetLength(1)];

            ////参照渡しで値を格納してもらう。
            Matrix2Array(mat1, ref arr1);
            Matrix2Array(mat2, ref arr2);

            float[] ansarr = new float[2] { 0f, 5f };
            //float[] ansarr = new float[ansmat.Length] { 0f, 5f };
            //inversemat(mat.getlength(0), mat.getlength(1), arr, ansarr);

            Array2Matrix(ansarr, ansmat);

            //配列の実体をコピーして渡す。
            //そのまま返すと参照になる？（ポインタを渡す感じ？）
            return (float[,])ansmat.Clone();
        }

    }
}
