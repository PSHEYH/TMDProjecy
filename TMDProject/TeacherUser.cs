using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMDProject.Entities;

namespace TMDProject
{
    public class TeacherUser : BaseUser
    {
        private Teacher _current;
        private string _teacherMenu = "                  --- Меню ---     \n" +
                                      "     1. Просмотр информации о студентах \n" +
                                      "     2. Изменить бал конкретному студенту \n" +
                                      "     3. Выйти";

        private string _changeStudentMenu = "   1. Изменить имя            2. Изменить фамилию  \n" +
                                           "   3. Изменить группу         4. Изменить бал \n";

        public TeacherUser(Context context) : base(context) { }
        public TeacherUser(Context context,Teacher user) : base(context)
        {
            _current = user;
        }

        enum Operation {
            DisplayInformation = 1,
            ChangeStudentGrade =2,
            Exit =3
        }

        enum ChangeUserOperation
        {
            ChangeName =1 ,
            ChangeSurname =2,
            ChangeGroup =3,
            ChangeGrade =4
        }

        public void GetAllStudents()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("   -- Список всех студентов и их соответственные балы --\n");
            for (int i = 0; i < _context.Students.Count; i++)
            {
                Console.WriteLine($" {i + 1}. {_context.Students[i].Surname}  {_context.Students[i].Name}  Бал : {_context.Students[i].Grade}");
            }

            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("  - Нажмите Enter чтобы продолжить  ");
            Console.ReadLine();
            Console.Clear();
        }

        public void ChangeStudentGrade()
        {
            Console.WriteLine("  --  Изменение студента  -- ");
            Console.Write(" Введите фамилию студента: ");
            string surname = Console.ReadLine();

            Console.Write(" Введите имя студента: ");
            string name = Console.ReadLine();

            Console.Write(" Введите групу студента: ");
            string group = Console.ReadLine();

            bool IsClose = false;

            if (GetStudentByNameSurnameGroup(surname, name, group) == null)
            {
                Console.WriteLine("   Вы ввели направильные данные. ");

                IsClose = true;
            }
            else
            {
                IsClose = false;
            }
            while (!IsClose)
            {
                Console.WriteLine("         -- Меню --           ");
                Console.WriteLine(_changeStudentMenu);
                string input = Console.ReadLine();
                string change;

                switch (Convert.ToInt32(input))
                {

                    case (int)ChangeUserOperation.ChangeGroup:
                        Console.Write("   Введите новую группу : ");
                        change = Console.ReadLine();
                        
                        break;
                    case (int)ChangeUserOperation.ChangeGrade:
                        Console.Write("   Введите новый бал: ");
                        change = Console.ReadLine();

                        break;
                    default:
                        break;
                }
            }


            Console.WriteLine("  - Нажмите Enter чтобы продолжить  ");
            Console.ReadLine();
            Console.Clear();

        }

        public Student GetStudentByNameSurnameGroup(string surname,string name,string group)
        {
            Student student = _context.Students.FirstOrDefault(x=>x.Surname==surname && x.Name==name && x.Group==group);
            return student;
        }

        public override BaseUser Menu()
        {
           

            while (true)
            {
                Console.WriteLine(_teacherMenu);
                string input = Console.ReadLine();

                switch (Convert.ToInt32(input))
                {
                    case (int)Operation.DisplayInformation:
                        GetAllStudents();
                        break;
                    case (int)Operation.ChangeStudentGrade:
                        ChangeStudentGrade();
                        break;
                    case (int)Operation.Exit:
                        Console.Clear();
                        return new GuestUser(_context);
                    default:
                        Console.Clear();
                        return new GuestUser(_context);
                }
            }
        }
    }
}
