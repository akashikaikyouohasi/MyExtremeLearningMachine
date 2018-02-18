using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExtremeLearningMachine
{
    public class Culculation
    {
        public void CulcMatrix_H_inv()
        {
            //List<List<double>> a = new List<List<double>>;


            /*
	        matrix1を逆行列にしてmatrix2に代入する
	        matrix1の行と列数L　正則行列！
	        */


            /*
            double buf; //一時的なデータを蓄える
            int n = L;  //配列の次数

            //単位行列を作る
            //#pragma omp parallel num_threads(procs)
            //{
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix2[i][j] = (i == j) ? 1.0 : 0.0;
                }
            }
            //}

            //掃き出し法
            for (int i = 0; i < n; i++)
            {
                buf = 1 / matrix1[i][i];
                for (int j = 0; j < n; j++)
                {
                    matrix1[i][j] *= buf;
                    matrix2[i][j] *= buf;
                }
                for (int j = 0; j < n; j++)
                {
                    if (i != j)
                    {
                        buf = matrix1[j][i];
                        for (int k = 0; k < n; k++)
                        {
                            matrix1[j][k] -= matrix1[i][k] * buf;
                            matrix2[j][k] -= matrix2[i][k] * buf;
                        }
                    }
                }
            }
            */

            /*
            //逆行列を出力
            for(int i=0;i<n;i++){
                for(int j=0;j<n;j++){
                    cout << matrix2[i][j] << " ";
                }
                cout << endl;
            }
            */

        }

    }
}
