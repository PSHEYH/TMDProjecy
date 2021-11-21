using System;
using System.Collections.Generic;
using System.Text;

namespace TMDProject
{
    public class StudentUser : BaseUser
    {
        enum Operation
        {
            PassingTest = 1,
            LearningTheory = 2,
            DisplayCurrentGrade = 3,
            Exit = 4
        }

        

        private string studentMenu = "                     --- Меню ---   \n" +
                                     "     1. Начать выполнение тестов           2. Изучение теории \n" +
                                     "     3. Просмотр текущих балов             4. Выход \n";
        private Student _current;



        public StudentUser(Context context) : base(context) { }
        public StudentUser(Context context,Student student):base(context)
        {
            _current = student;
        }

        public void DisplayMyGrade()
        {
            Console.WriteLine("         -- Информация о студенте --  ");
            Console.WriteLine($"  Фамилия:{_current.Surname} \n" +
                              $"  Имя:    {_current.Name} \n" +
                              $"  Бал: {_current.Grade}/12\n");
            Console.WriteLine("      Нажмите Enter чтобы продолжить ");
            Console.ReadLine();
            Console.Clear();

        }

        public void LearnTheory()
        {
            bool IsClose = false;
            while (!IsClose)
            {
                Console.WriteLine("   Введите номер темы которую хотите рассмотреть  ");
                Console.WriteLine("    1. ПРИНЯТИЕ РЕШЕНИЕ В УСЛОВИЯХ НЕОПРЕДЕЛЛЁННОСТИ\n" +
                                  "    2. ПОНЯТИЕ НЕРАНДОМИЗИРОВАНЫХ РЕШЕНИЙ. Минимаксный критерий\n" +
                                  "    3. КРИТЕРИЙ НЕЙМАНА ПИРСОНА \n" +
                                  "    4. РАНДОМИЗИРОВАННЫЕ РЕШЕНИЯ \n" +
                                  "    5. МИНИМАКСНЫЙ КРИТЕРИЙ (РАНДОМИЗИРОВАНЫХ РЕШЕНИЙ)\n" +
                                  "    6. Алгоритм поиска нерандомизированого решнеия за критерием Нейймана - Пирсона");
                string inputLesson = Console.ReadLine();
                Console.Clear();
                switch (inputLesson)
                {
                    case "1":
                        Theory.Lesson1();
                        break;
                    case "2":
                        Theory.Lesson2();
                        break;
                    case "3":
                        Theory.Lesson3();
                        break;
                    case "4":
                        Theory.Lesson4();
                        break;
                    case "5":
                        Theory.Lesson5();
                        break;
                    case "6":
                        Theory.Lesson6();
                        break;
                    default:
                        IsClose = true;
                        break;
                }
                Console.WriteLine("      Нажмите Enter чтобы продолжить ");
                Console.ReadLine();
                Console.Clear();
            }
        }

        public void PassTest()
        {
            bool isEnd = false;
            while (!isEnd)
            {
                Console.WriteLine("    -- Критерии оптимальности для нерандомизированых решений --   ");
               
                Console.WriteLine("  Здравствуй дорогой студент \n" +
                    "  Для оценки твоих знаний по даной теме мы(я) подготовили для тебя 5 тестов, \n" +
                    "  которые покажут насколько хорошо ты понял данную тему ");
                Console.WriteLine("  Введите номер теста который хотите выполнить ");
                Console.WriteLine("  1.Тест\n" +
                                  "  2.Тест\n" +
                                  "  3.Тест\n" +
                                  "  4.Тест\n" +
                                  "  5.Тест\n" +
                                  "  6.Тест\n" +
                                  "  7.Тест\n" +
                                  "  8.Тест\n" +
                                  "  0.Назад");

                string choice = Console.ReadLine();

                Console.Clear();

                switch (choice)
                {
                    case "1":
                        Test.Test1(_current);
                        Console.WriteLine("    Нажмите Enter чтобы продолжить ");
                        Console.ReadLine();
                        break;
                    case "2":
                        Test.Test2(_current);
                        Console.WriteLine("    Нажмите Enter чтобы продолжить ");
                        Console.ReadLine();
                        break;
                    case "3":
                        Test.Test3(_current);
                        Console.WriteLine("    Нажмите Enter чтобы продолжить ");
                        Console.ReadLine();
                        break;
                    case "4":
                        Test.Test4(_current);
                        Console.WriteLine("    Нажмите Enter чтобы продолжить ");
                        Console.ReadLine();
                        break;
                    case "5":
                        Test.Test5(_current);
                        Console.WriteLine("    Нажмите Enter чтобы продолжить ");
                        Console.ReadLine();
                        break;
                    case "6":
                        Test.Test6(_current);
                        Console.WriteLine("    Нажмите Enter чтобы продолжить ");
                        Console.ReadLine();
                        break;
                    case "7":
                        Test.Test7(_current);
                        Console.WriteLine("    Нажмите Enter чтобы продолжить ");
                        Console.ReadLine();
                        break;
                    case "8":
                        Test.Test8(_current);
                        Console.WriteLine("    Нажмите Enter чтобы продолжить ");
                        Console.ReadLine();
                        break;
                    case "0":
                        isEnd = true;
                        break;
                }

                Console.Clear();
            }
        }
        public override BaseUser Menu()
        {
            while (true)
            {
                Console.WriteLine(studentMenu);
                Console.Write("  введите номер операции :");
                string input = Console.ReadLine();
                switch (Convert.ToInt32(input))
                {
                    case (int)Operation.PassingTest:
                        PassTest();
                        Console.Clear();
                        break;
                    case (int)Operation.LearningTheory:
                        LearnTheory();
                        Console.Clear();
                        break;
                    case (int)Operation.DisplayCurrentGrade:
                        DisplayMyGrade();
                        Console.Clear();
                        break;
                    case (int)Operation.Exit:
                        Console.Clear();
                        return new GuestUser(_context);
                }
            }
            
        }
    }
}
