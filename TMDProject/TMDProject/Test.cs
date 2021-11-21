using System;
using System.Collections.Generic;
using System.Text;

namespace TMDProject
{
    public static class Test
    {
        public static void Test1(Student student)
        {
            if(student.Test1Attempt==0)
            {
                Console.WriteLine("       У вас закончились попытки на этом тесте  ");
                return;
            }
            student.Test1Attempt--;


            Console.WriteLine("   -- Тест № 1 -- ");
            Console.WriteLine("    Рассмотрим пример 1: \n" +
                "   Студент собирается на улицу или куда то ещё подальше в город. Ему необходимо принять решение по поводу своей одежды и екипировки \n" +
                "   Будем считать что у него есть выбор из трёх альтернатив :\n" +
                "   1. Одеться как обычно\n" +
                "   2. Взять зонт \n" +
                "   3. Взять зонт и одеться полностью по погоде \n");
            Console.WriteLine("  С другой стороны и природа можешь находиться в состояниях \n" +
                "   1. Хорошая погода \n" +
                "   2. Плохая погода \n");
            Console.Write("\n  Сколько строк будет у матрицы полезности даного примера?: ");
            int expectedRows = Convert.ToInt32(Console.ReadLine());

            Console.Write("\n  Сколько колонок будет у матрицы полезности даного примера?: ");
            int expectedColumns = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("   Фактическая размерность матрицы полезности 3x2");
            Console.WriteLine($"   Ожидаемая размерность матрицы полезности {expectedRows}x{expectedColumns}");

            if (expectedRows == 3 && expectedColumns == 2)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("   Ответ верный ! +1");
                Console.ForegroundColor = ConsoleColor.White;
                student.Grade++;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("   Ответ неверный ! -");
                Console.WriteLine("   Матрица полезности строиться следующим образом : " +
                    "   По строкам идут выбора особы принимающей решщение, а по столбцам идут состояния природы");
                Console.ForegroundColor = ConsoleColor.White;

            }

            Console.WriteLine("   -- Тест № 1 -- ");
            Console.WriteLine("    Рассмотрим пример 2: \n" +
                "   Менеджер спешит на встречу и думает на чём бы на неё добраться. Менеджер может вызвать такси и добраться быстро на встречу\n" +
                "   Однако он может попасть в пробку. Или же может быть плохая погода из за которой также скорость перемещния замедлиться.\n" +
                "   Менеджер может ещё быстрее добраться на вертолёте. Ему никак не будет мешать пробка, однако плохая погода максимально ужастно\n скажеться" +
                "   на скорости перемещения. И также менеджер может пойти просто пешком. Ситуация также может быть такой что ни пробок ни плохой\n " +
                "   погоды не будет. Будем считать что ситуация при которой одновременно и плохая погода и пробка невозможна\n");

            Console.Write("\n  Сколько строк будет у матрицы полезности даного примера?: ");
            expectedRows = Convert.ToInt32(Console.ReadLine());

            Console.Write("\n  Сколько колонок будет у матрицы полезности даного примера?: ");
            expectedColumns = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("   Фактическая размерность матрицы полезности 3x3");
            Console.WriteLine($"   Ожидаемая размерность матрицы полезности {expectedRows}x{expectedColumns}");

            if (expectedRows == 3 && expectedColumns == 3)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("   Ответ верный ! +1");
                Console.ForegroundColor = ConsoleColor.White;
                student.Grade++;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("   Ответ неверный ! -");
                Console.WriteLine("   Матрица полезности строиться следующим образом : " +
                    "   По строкам идут выборы лица принимающего решение, а по столбцам идут состояния природы");
                Console.ForegroundColor = ConsoleColor.White;
            }


        }

        public static void Test2(Student student)
        {
            if (student.Test2Attempt == 0)
            {
                Console.WriteLine("       У вас закончились попытки на этом тесте  ");
                return;
            }
            student.Test2Attempt--;


            Console.WriteLine("   -- Тест № 2 -- ");
            Console.WriteLine("   Сейчас состоит задача в том чтобы самостоятельно  ввести матрицу полезности ,\n" +
                " а затем вы должны ввести правильно расчитанную матрицу потерь");
            Console.Write("   Задайте количество выборов : ");
            int alpha = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\n   Колчество состояний природы  2 ");
            double[,] matrix = new double[alpha, 2];
            double[,] L = new double[alpha, 2];
            double[,] actualL = new double[alpha, 2];

            
            matrix = WriteMatrixWin(alpha,2);
            DisplayMatrix(matrix);

            Console.WriteLine("    Теперь задайте матрицу потерь  ");
            for (int i = 0; i < alpha; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Console.Write($"   Введите значение елемента {i + 1},{j + 1}: ");
                    L[i, j] = Convert.ToDouble(Console.ReadLine());
                }
            }
            double max = Max(matrix);
            for (int i = 0; i < alpha; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    actualL[i, j] = Math.Round(max - matrix[i, j], 3);
                }
            }
            Console.WriteLine("   -- Ожидаемая матрица потерь -- ");
            DisplayMatrix(L);
            Console.WriteLine("   -- Фактическая матрица потерь -- ");
            DisplayMatrix(actualL);
            if (Equal(L, actualL))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("   Ответ верный ! +");
                student.Grade++;
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("   Ответ неверный ! -");
                Console.WriteLine("   Матрица потерь находиться следующим образом : ");
                Console.WriteLine("   Нужно заменить каждый эллемент матрица полезности на разность максимума среди всех \n" +
                    "  эллементов и текущего эллента матрицы");
                Console.ForegroundColor = ConsoleColor.White;

            }


        }
        private static double Max(double[,] matrix)
        {
            int rows = matrix.GetUpperBound(0) + 1;
            int columns = matrix.Length / rows;
            int max1 = 0;
            int max2 = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (matrix[max1, max2] < matrix[i, j])
                    {
                        max2 = j;
                        max1 = i;
                    }
                }
            }

            return matrix[max1, max2];
        }
        private static bool Equal(double[,] matrix1, double[,] matrix2)
        {
            int rows = matrix1.GetUpperBound(0) + 1;
            int columns = matrix1.Length / rows;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (matrix1[i, j] != matrix2[i, j])
                        return false;
                }
            }
            return true;
        }
        private static bool Equal(double[] matrix1,double[] matrix2)
        {
            if (matrix1.Length != matrix2.Length)
                return false;
            for (int i = 0; i < matrix1.Length; i++)
            {
                if (matrix1[i] != matrix2[i])
                    return false;
            }

            return true;
        }


        public static void Test3(Student student)
        {
            if (student.Test3Attempt == 0)
            {
                Console.WriteLine("       У вас закончились попытки на этом тесте  ");
                return;
            }
            student.Test3Attempt--;


            Console.WriteLine("   -- Тест № 3 -- ");
            Console.WriteLine("       ---- МиниМаксный Критерий ----     ");
            Console.WriteLine("    Сейчас состоит задача в том чтобы самостоятельно  ввести матрицу потерь ,\n" +
            "  принять решение какой выбор сделать использую минимаксный критерий");
            double[,] matrix = WriteMatrixLose();
            DisplayMatrix(matrix);

            Console.WriteLine("      --- Расчеты по минимаксному критерий ---     ");


            if (MiniMax.Method(matrix))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("     Ваши ответ верный ! +");
                student.Grade++;
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("     Ваши ответ неверный ! -");
                Console.WriteLine("     Возможные варианты ошибок :");
                Console.WriteLine("     1) Неправильно найдены максимумы по строке ");
                Console.WriteLine("     2) Неправильно найден миниум по столбцу максимумов ");
                Console.WriteLine("     3) Операции нахождения максимума и минимума были выполнены в неправильном порядке ");
                Console.ForegroundColor = ConsoleColor.White;
            }




        }

        public static void Test4(Student student)
        {
            if (student.Test4Attempt == 0)
            {
                Console.WriteLine("       У вас закончились попытки на этом тесте  ");
                return;
            }
            student.Test4Attempt--;


            Console.WriteLine("   -- Тест № 4 -- ");
            Console.WriteLine("    Сейчас состоит задача в том чтобы самостоятельно  ввести матрицу потерь ,\n" +
           "  принять решение какой выбор сделать использую критерий Неймана-Пирсона");

            double[,] matrix = WriteMatrixLose();
            Console.WriteLine("   -- Матрица Потерь --");
            DisplayMatrix(matrix);

            int rows = matrix.GetUpperBound(0) + 1;
            int columns = matrix.Length / rows;

            while(columns > 2)
            {
                student.Grade = student.Grade - 0.2f;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("     Заметили несостыковку !?");
                Console.WriteLine("    Критерий Неймана-Пирсона можна использовать только когда природа находиться в двух состояниях");
                Console.WriteLine("    Вы же ввели состояних природы больше двух .");
                Console.WriteLine("    Введите заново матрицу потерь ");
                Console.ForegroundColor = ConsoleColor.White;
                matrix = WriteMatrixLose();
                rows = matrix.GetUpperBound(0) + 1;
                columns = matrix.Length / rows;
                DisplayMatrix(matrix);
            }


            Console.WriteLine("      -- Метод Неймана Пирсона --   ");
            Console.Write("   Задайте номер неконтролирумего процеса природы : ");
            int control = Convert.ToInt32(Console.ReadLine());
            while(control<=0 || control>2)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("   !Вы ввели некоректный номер столбца !! ");
                Console.Write("   Задайте номер неконтролирумего процеса природы : ");
                Console.ForegroundColor = ConsoleColor.White;
                control = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine();
            Console.Write("   Задайте L_порог. : ");
            double threshold = Convert.ToDouble(Console.ReadLine());

            Console.Write("   Введите ответ найденый методом Неймана Пирсона: ");
            double alphaResolve = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("    ---- Расчет метода Неймана Пирсона ----   ");

            if (NeymanPirson.Method(control, threshold, matrix, alphaResolve))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("    Ваши ответ верный ! +");
                student.Grade++;
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("     Ваши ответ неверный ! -");
                Console.WriteLine("     Возможные варианты ошибок :");
                Console.WriteLine("     1) Неправильное понимание какое из состояний природы исключается из расссмотрения ");
                Console.WriteLine("     2) Неправильно найден миниум по столбцу ");
                Console.WriteLine("     3) Неправильно исключены строки из рассмотрения ");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public static void Test5(Student student)
        {
            if (student.Test5Attempt == 0)
            {
                Console.WriteLine("       У вас закончились попытки на этом тесте  ");
                return;
            }
            student.Test5Attempt--;


            Console.WriteLine("   -- Тест № 5 -- ");
            Console.WriteLine("       Метод Неймана Пирсона    ");
            Console.WriteLine("    Может ли мы не найти решения задачи принятия решения используя критерий Неймана-Пирсона ?");
            Console.WriteLine("   Ответ : (y / n)");
            string answer = Console.ReadLine();
            if (answer == "Y" || answer == "y")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("   Верно  +");
                Console.ForegroundColor = ConsoleColor.White;
                student.Grade++;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("    Неверно . Может потому, что если мы выберем такое пороговое L такое что ни единая строка" +
                    "   не будет удовлетворять L у задачи не будет решения \n");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public static void Test6(Student student)
        {
            if (student.Test6Attempt == 0)
            {
                Console.WriteLine("       У вас закончились попытки на этом тесте  ");
                return;
            }
            student.Test6Attempt--;


            Console.WriteLine("   -- Тест № 6 -- ");
            Console.WriteLine("       Метод Неймана Пирсона    ");
            Console.WriteLine("    Ввести для заданой задачи матрицу полезности. Затем найти для неё матрицу потерь.\n" +
                "     И последнее это найти решение задачи принятия решений с помощью Минимаксного критерия и критерия Неймана-Пирсона \n");
            Console.WriteLine("    Максим пришел на иподром. Он может поставить деньги на фаворита гонок, может поставить на другого коня\n" +
                "     а может вообще не ставить. При этом в гонках может победить как фаворит так и другой конь .Если Максим поставит на фаворита \n" +
                "     то ничего не потеряет но и в принципе ничего не выйграет. Но в случае проигрыша фаворита потеряет много. Если поставит на \n" +
                "     другого и другой выйграет, то выйграш будет большой однако если проиграет то и потеряет много.");

            int actualRows = 3, actualColumns = 2;

            Console.Write("\n  Сколько строк будет у матрицы полезности даного примера?: ");
            int expectedRows = Convert.ToInt32(Console.ReadLine());

            Console.Write("\n  Сколько колонок будет у матрицы полезности даного примера?: ");
            int expectedColumns = Convert.ToInt32(Console.ReadLine());

            double[,] matrix = WriteMatrixWin(expectedRows,expectedColumns);
            double[,] actualL = new double[expectedRows, expectedColumns];
            double[,] expectedL = new double[expectedRows, expectedColumns];


            Console.WriteLine("     -- Матрица полезности --   ");
            DisplayMatrix(matrix);

            Console.WriteLine("   Введите теперь матрицу потерь");
            expectedL = WriteMatrixLose();

            Console.WriteLine("     -- Матрица потерь(ожидаемая) --   ");
            double max = Max(matrix);

            for (int i = 0; i < expectedRows; i++)
            {
                for (int j = 0; j < expectedColumns; j++)
                {
                    actualL[i, j] = Math.Round(max - matrix[i, j], 3);
                }
            }

            DisplayMatrix(expectedL);

            Console.WriteLine("     -- Матрица потерь(фактическая) --   ");
            if(Equal(expectedL,actualL))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("    + Матрица потерь была найдена верно +");
                Console.ForegroundColor = ConsoleColor.White;
                student.Grade++;
            }    
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("    - Матрица потерь была найдена верно - ");
                Console.ForegroundColor = ConsoleColor.White;
            }

            bool result = MiniMax.Method(expectedL); 

            if(result && actualColumns == expectedColumns && expectedRows == actualRows)
            {
                Console.WriteLine("   + Ответ верный +");
                student.Grade=student.Grade+2;
            }
            else if(result && (actualColumns!=expectedColumns || actualRows!=expectedRows))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("   - Ответ неверный -");
                Console.WriteLine("    Количество выборов и количество состояний природы было задано НЕПРАВИЛЬНО ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("    Но решение с помощью критерия найдено правильно ");
                Console.ForegroundColor = ConsoleColor.White;
                student.Grade++;

            }
            else if (actualRows==expectedRows && actualColumns==expectedColumns && result==false)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("   - Ответ неверный -");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("    Количество выборов и количество состояний природы было задано ПРАВИЛЬНО ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("    Однако решение с помощью критерия найдено НЕправильно ");
                Console.ForegroundColor = ConsoleColor.White;
                student.Grade = student.Grade + 0.5f;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("   - Ответ неверный -");
                Console.WriteLine("    Количество выборов и количество состояний природы было задано НЕПРАВИЛЬНО ");
                Console.WriteLine("    Решение с помощью критерия найдено НЕправильно ");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public static void Test7(Student student)
        {
            if (student.Test7Attempt == 0)
            {
                Console.WriteLine("       У вас закончились попытки на этом тесте  ");
                return;
            }
            student.Test7Attempt--;


            Console.WriteLine("   -- Тест № 7 -- ");
            Console.WriteLine("       Минимаксный критерий. Рандомизированое решение     ");
            Console.WriteLine("   Найдите рандомизированое решение с помощью Минимаксного критерия \n" +
                              "   ===== Матрица потерь =====\n" +
                              "          2    5  \n" +
                              "          4    2  \n" +
                              "          3    6  \n" +
                              "          7    0  \n" +
                              "          1    3  \n");

            double[] expectedResult = new double[5];
            double[] actualResult = new double[] { 0,0,0,0.222,0.777};


            Console.Write("  Введите какой длинны будет результирующий вектор значений Х : ");
            int expectedLenght = Convert.ToInt32(Console.ReadLine());

            if(expectedLenght==5)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("     Ваши ответ верный ! +1");
                Console.ForegroundColor = ConsoleColor.White;
                student.Grade++;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("     Ваши ответ неверный ! ");
                Console.ForegroundColor = ConsoleColor.White;
            }

            Console.Write("  Введите Х1(округлите до 3 числа после знака включно): ");
            expectedResult[0] = Convert.ToDouble(Console.ReadLine());
            Console.Write("  Введите Х2(округлите до 3 числа после знака включно): ");
            expectedResult[1] = Convert.ToDouble(Console.ReadLine());
            Console.Write("  Введите Х3(округлите до 3 числа после знака включно): ");
            expectedResult[2] = Convert.ToDouble(Console.ReadLine());
            Console.Write("  Введите Х4(округлите до 3 числа после знака включно): ");
            expectedResult[3] = Convert.ToDouble(Console.ReadLine());
            Console.Write("  Введите Х5(округлите до 3 числа после знака включно): ");
            expectedResult[4] = Convert.ToDouble(Console.ReadLine());



            if (Equal(expectedResult,actualResult))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("     Ваши ответ верный ! +1");
                Console.ForegroundColor = ConsoleColor.White;
                student.Grade++;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("     Ваши ответ неверный ! -");
                Console.WriteLine("     Возможные варианты ошибок :");
                Console.WriteLine("     1) Неправильно записаны координаты вершин платёжного множества ");
                Console.WriteLine("     2) Неправильно найдена точка прикосновения клина и платёжного множества ");
                Console.WriteLine("     3) Неправильно найдены корни уравнения ");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public static void Test8(Student student)
        {
            if (student.Test8Attempt == 0)
            {
                Console.WriteLine("       У вас закончились попытки на этом тесте  ");
                return;
            }
            student.Test8Attempt--;


            Console.WriteLine("   -- Тест № 8 -- ");
            Console.WriteLine("       Критерий Неймана Пирсона. Рандомизированое решение     ");
            Console.WriteLine("   Найдите рандомизированое решение с помощью критерия Неймана-Пирсона \n" +
                              "   ===== Матрица потерь =====\n" +
                              "          2    5  \n" +
                              "          4    2  \n" +
                              "          3    6  \n" +
                              "          7    0  \n" +
                              "          1    3  \n\n" +
                              "   Пороговое L = 3");



            double[] expectedResult = new double[5];
            double[] actualResult;

            Console.Write("   Введите номер контроллированого состояния : ");
            string  controlState = Console.ReadLine();

            if (controlState == "1")
            {
                actualResult = new double[] { 0, 0, 0, 0.333, 0.666 };

                Console.Write("  Введите Х1(округлите до 3 числа после знака включно): ");
                expectedResult[0] = Convert.ToDouble(Console.ReadLine());
                Console.Write("  Введите Х2(округлите до 3 числа после знака включно): ");
                expectedResult[1] = Convert.ToDouble(Console.ReadLine());
                Console.Write("  Введите Х3(округлите до 3 числа после знака включно): ");
                expectedResult[2] = Convert.ToDouble(Console.ReadLine());
                Console.Write("  Введите Х4(округлите до 3 числа после знака включно): ");
                expectedResult[3] = Convert.ToDouble(Console.ReadLine());
                Console.Write("  Введите Х5(округлите до 3 числа после знака включно): ");
                expectedResult[4] = Convert.ToDouble(Console.ReadLine());

                double actualValue = 3;

                Console.Write("  Введите значение результирующих потерь  L : ");
                string expectedValue = Console.ReadLine();


                if (Equal(expectedResult, actualResult) && Convert.ToDouble(expectedValue)==actualValue )
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("     Ваши ответ верный ! +2");
                    student.Grade = student.Grade + 2;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if(Equal(expectedResult, actualResult) && Convert.ToDouble(expectedValue) != actualValue)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("     Ваши ответ верный, но не полностью! +1\n" +
                                      "     неправильно найдено результирующее значение ");
                    student.Grade++;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("     Ваши ответ неверный ! -");
                    Console.WriteLine("     Возможные варианты ошибок :");
                    Console.WriteLine("     1) Неправильно записаны координаты вершин платёжного множества ");
                    Console.WriteLine("     2) Неправильно найдены корни уравнения ");
                    Console.ForegroundColor = ConsoleColor.White;
                }

            }
            else
            {
                actualResult = new double[] { 0, 0, 0, 0, 1};

                Console.Write("  Введите Х1(округлите до 3 числа после знака включно): ");
                expectedResult[0] = Convert.ToDouble(Console.ReadLine());
                Console.Write("  Введите Х2(округлите до 3 числа после знака включно): ");
                expectedResult[1] = Convert.ToDouble(Console.ReadLine());
                Console.Write("  Введите Х3(округлите до 3 числа после знака включно): ");
                expectedResult[2] = Convert.ToDouble(Console.ReadLine());
                Console.Write("  Введите Х4(округлите до 3 числа после знака включно): ");
                expectedResult[3] = Convert.ToDouble(Console.ReadLine());
                Console.Write("  Введите Х5(округлите до 3 числа после знака включно): ");
                expectedResult[4] = Convert.ToDouble(Console.ReadLine());


                Console.Write("  Введите значение результирующих потерь  L : ");
                string expectedValue = Console.ReadLine();

                double actualValue = 1;

                if (Equal(expectedResult, actualResult) && Convert.ToDouble(expectedValue) == actualValue)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("     Ваши ответ верный ! +2");
                    Console.ForegroundColor = ConsoleColor.White;
                    student.Grade = student.Grade + 2;
                }
                else if (Equal(expectedResult, actualResult) && Convert.ToDouble(expectedValue) != actualValue)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("     Ваши ответ верный, но не полностью! +1\n" +
                                      "     неправильно найдено результирующее значение ");
                    Console.ForegroundColor = ConsoleColor.White;
                    student.Grade++;

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("     Ваши ответ неверный ! -");
                    Console.WriteLine("     Возможные варианты ошибок :");
                    Console.WriteLine("     1) Неправильно записаны координаты вершин платёжного множества ");
                    Console.WriteLine("     2) Неправильно найдены корни уравнения ");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

        }

        public static void DisplayMatrix(double[,] matrix)
        {
            int rows = matrix.GetUpperBound(0) + 1;
            int columns = matrix.Length / rows;
            for (int i = 0; i < rows; i++)
            {
                Console.Write("   ");
                for (int j = 0; j < columns; j++)
                {
                    Console.Write($"   {matrix[i, j]}   ");
                }
                Console.WriteLine();
            }


        }

        public static bool ContainsZero(double[,] matrix)
        {
            int rows = matrix.GetUpperBound(0) + 1;
            int columns = matrix.Length / rows;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (matrix[i, j] == 0)
                        return true;
                }
            }
            return false;
        }
        private static double[,] WriteMatrixWin(int alpha, int beta)
        {
            double[,] matrix = new double[alpha, beta];

            Console.WriteLine("     Задайте матрицу полезности   ");
            for (int i = 0; i < alpha; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Console.Write($"   Введите значение елемента {i + 1},{j + 1}: ");
                    matrix[i, j] = Convert.ToDouble(Console.ReadLine());
                }
            }

            return matrix;
        }

        public static double[,] WriteMatrixLose()
        {
            Console.Write("  Задайте количество выборов : ");
            int alpha = Convert.ToInt32(Console.ReadLine());
            Console.Write("\n  Задайте количество состояний природы  : ");
            int beta = Convert.ToInt32(Console.ReadLine());
            double[,] matrix = new double[alpha, beta];


            Console.WriteLine("    Задайте матрицу потерь   \n");

            for (int i = 0; i < alpha; i++)
            {
                for (int j = 0; j < beta; j++)
                {
                    Console.Write($"  Введите значение елемента {i + 1},{j + 1}: ");
                    matrix[i, j] = Convert.ToDouble(Console.ReadLine());
                }
            }

            while (!ContainsZero(matrix))
            {
                Console.WriteLine("  Задайте заново матрицу потерь. Матрица потерь обязательно должна содержать 0");
                for (int i = 0; i < alpha; i++)
                {
                    for (int j = 0; j < beta; j++)
                    {
                        Console.Write($"  Введите значение елемента {i + 1},{j + 1}: ");
                        matrix[i, j] = Convert.ToDouble(Console.ReadLine());
                    }
                }

            }

            return matrix;
        }

    }
}
