using System;
using System.Collections.Generic;
using System.Text;

namespace TMDProject
{
    public static class MiniMax
    {
        public static bool Method(double[,] matrix)
        {
            int rows = matrix.GetUpperBound(0) + 1;
            int columns = matrix.Length / rows;

            double[] maxActual = new double[rows];


            for (int i = 0; i < rows; i++)
            {
                maxActual[i] = Max(matrix, i, columns);
            }


            Console.Write("  Введите номер выбора alpha*: ");
            int expected = Convert.ToInt32(Console.ReadLine());

            Console.Write($"  Введите ожидаемый L*  ");
            double expectedL = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("  -- Фактические максимумы -- ");
            int min = Min(maxActual);
            DisplayMaximum(maxActual,min);

            
            Console.WriteLine($"  Ожидаемый результат (L*):  {expectedL}");
            Console.WriteLine($"  Фактический результат (L*): {maxActual[min]}");

            Console.WriteLine($"  Ожидаемый номер выбора alpha*  {expected}");
            Console.WriteLine($"  Фактический номер  {min+1}");

            if (expected == min+1 && expectedL == maxActual[min])
            {
                return true;
            }

            return false;

        }
        private static double Max(double[,] matrix,int index,int column)
        {
            int max = 0;
            for (int i = 0; i < column; i++)
            {
                if (matrix[index, max] < matrix[index, i])
                    max = i;
            }
            return matrix[index,max];
        }
        private static int Min(double[] max)
        {
            int min = 0;
            for (int i = 1; i < max.Length; i++)
            {
                if (max[min] > max[i])
                    min = i;
            }
            return min;
        }

        private static void DisplayMaximum(double[] max,int index)
        {
            for (int i = 0; i < max.Length; i++)
            {
                if(i!=index)
                    Console.WriteLine($" Макс {i + 1} строки : {max[i]}");
                else
                    Console.WriteLine($" Макс {i + 1} строки : {max[i]} -- min");
            }
        }
    }
}
