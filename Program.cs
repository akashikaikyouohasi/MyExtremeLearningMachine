using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MyExtremeLearningMachine
{
    public class Program
    {
        static void Main(string[] args)
        {
            Program buf = new Program();
            buf.SampleEigen();
            return;
            //テストコメント
        }

        public int MyAdd(int a, int b)
        {
            return a + b;
        }

        private void SampleEigen()
        {
            

            /* EigenFunc.dll Sample */
            EigenFuncs eigen = new EigenFuncs();
            float[,] bufMat = new float[3, 3] { { 1f, 2f, 5f }, { 1f, -1f, 1f }, { 0f, 1f, 2f } };
            float[,] AnsMat = new float[3, 3];

            AnsMat = eigen.InverseMatrix(bufMat);

            for (int i = 0; i < 3; i++)
            {
                for(int j=0; j<3; j++)
                {
                    Console.Write("{0}, ", bufMat[i, j]);
                }
                Console.Write("\n");
            }

            /*答え
             * 3/2 -1/2 -7/2
             * 1 -1 -2
             * -1/2 1/2 3/2
             */

            //answer
            Console.WriteLine("====ANSWER====");
            float[,] AnswerMat = new float[3, 3] { { 1.5f, -0.5f, -3.5f }, { 1f, -1f, -2f }, { -0.5f, 0.5f, 1.5f } };
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write("{0}, ", AnswerMat[i, j]);
                }
                Console.Write("\n");
            }

            //result
            Console.WriteLine("====RESULT====");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write("{0}, ", AnsMat[i, j]);
                }
                Console.Write("\n");
            }


            Console.ReadLine();
        }
    }
}
