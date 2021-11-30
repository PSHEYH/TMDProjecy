using System;
using System.Collections.Generic;
using System.Text;

namespace TMDProject
{
    public static class NeymanPirson
    {
        public static bool Method(int controlState, double threshold,double[,] matrix,double expected)
        {
            Test.DisplayMatrix(matrix);
            int rows = matrix.GetUpperBound(0) + 1;
            int columns = matrix.Length / rows;

            if (controlState==1)
            {
                Console.WriteLine("     | ");
                Console.WriteLine("     b1");
            }
            else
            {
                Console.WriteLine("            | ");
                Console.WriteLine("            b2");
            }
            List<int> exlusive = new List<int>();

            for (int i = 0; i < rows; i++)
            {
                if (matrix[i, controlState - 1] > threshold)
                    exlusive.Add(i + 1);
            }

            double alpha;
            int min = 0;
            if (controlState == 1)
            {
                for (int i = 1; i < rows; i++)
                {
                    if (!exlusive.Contains(i + 1))
                    {
                        if (matrix[min,1] > matrix[i,1])
                            min = i;
                    }
                }

                alpha = matrix[min,1];
            }
            else
            {
                for (int i = 0; i < rows; i++)
                {
                    if (!exlusive.Contains(i + 1))
                    {
                        if (matrix[min,0] > matrix[i,0])
                            min = i;
                    }
                }
                alpha = matrix[min,0];
            }
           
            Console.WriteLine($"\n    L_пор.={threshold}\n");
            for (int i = 0; i < rows; i++)
            {
                Console.Write("    ");
                for (int j = 0; j < columns; j++)
                {
                    if (!exlusive.Contains(i + 1))
                        Console.Write($"   {matrix[i, j]}  ");
                    else
                        Console.Write("  ----- ");
                }
                Console.WriteLine();
            }
            Console.WriteLine($"  Неконтр. состояние b{controlState}");
            
            Console.WriteLine($"  Ожидаемый результат : {expected}");
            Console.WriteLine($"  Фактический : {alpha}");
            if (alpha == expected)
                return true;
            return false;
        }
    }
}
