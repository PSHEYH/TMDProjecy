using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMDProject.Entities;

namespace TMDProject
{
    public class GuestUser : BaseUser
    {
        public GuestUser(Context context) : base(context)
        {}

        private string _menu = "                -- -- Обучающая программа -- --    \n" +
                               "     Предмет: Теория принятия решений          \n" +
                               "                       --- Меню ---   \n" +
                               "     1. Войти как студент              2. Войти как преподаватель \n" +
                               "     3. Зарегистрироваться \n";

        enum Operation
        {
            SignIn = 1,
            SignInAsTeacher = 2,
            Registration =3
        }


        public bool Registration()
        {
            Console.WriteLine("         -- Регистрация --     ");
            
            Console.Write("  Введите фамилию: ");
            string surname = Console.ReadLine();

            Console.Write("  Введите имя : ");
            string name = Console.ReadLine();



            Console.Write("  Введите группу : ");
            string group = Console.ReadLine();

            while(!_context.Groups.Contains(group))
            {
                Console.Write("  Введите существующую группу: ");
                group = Console.ReadLine();
            }

            while (_context.Students.Find(x => x.Surname == surname && x.Name == name && x.Group == group)!=null)
            {
                Console.WriteLine("  Студент с такими данными уже зарегистрирован  ");
                Console.Write("  Введите фамилию: ");
                surname = Console.ReadLine();

                Console.Write("  Введите имя : ");
                name = Console.ReadLine();

                Console.Write("  Введите группу : ");
                group = Console.ReadLine();
            }

            Student addedStudent = new Student
            {
                Surname = surname,
                Name = name,
                Group = group
            };
            _context.Students.Add(addedStudent);

            if (_context.Students.Contains(addedStudent))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("  - Регистрация прошла успешно ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("  - Нажмите Enter чтобы продолжить  ");
                Console.ReadLine();
                Console.Clear();

                return true; 
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("  - Регистрация прошла НЕуспешно. Что то пошло не так -");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("  - Нажмите Enter чтобы продолжить  ");
            Console.ReadLine();
            Console.Clear();

            return false;
        }
        public Teacher SignInAsTeacher()
        {
            Console.Write("  Введите фамилию: ");
            string surname = Console.ReadLine();

            Console.Write("  Введите имя : ");
            string name = Console.ReadLine();

            while(GetTeacherByNameSurname(surname,name)==null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" - Вы ввели имя и фамилию не существующего преподавателя в данной программе -");
                Console.ForegroundColor = ConsoleColor.White;

                Console.Write("  Введите фамилию: ");
                surname = Console.ReadLine();

                Console.Write("  Введите имя : ");
                name = Console.ReadLine();

            }

            Console.WriteLine("  Введите пароль : ");
            string password = Console.ReadLine();

            while (GetTeacherByNameSurname(surname,name).LectorPassword!=password)
            {
                Console.Write(" Вы ввели неправильный пароль. Введите пароль заново: ");
                password = Console.ReadLine();
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("  - Авторизация прошла успешно ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("  - Нажмите Enter чтобы продолжить  ");
            Console.ReadLine();
            Console.Clear();


            Teacher result = GetTeacherByNameSurname(surname, name);

            return result;
        }

        public Student SignIn()
        {
            Console.Write("  Введите фамилию: ");
            string surname = Console.ReadLine();

            Console.Write("  Введите имя : ");
            string name = Console.ReadLine();

            Console.Write("  Введите вашу группу: ");
            string group = Console.ReadLine();

            while (GetStudentByNameSurname(surname, name,group) == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" - Вы ввели неправильное имя или фамилию или группу -");
                Console.ForegroundColor = ConsoleColor.White;

                Console.Write("  Введите фамилию: ");
                surname = Console.ReadLine();

                Console.Write("  Введите имя : ");
                name = Console.ReadLine();

                Console.Write("  Введите группу : ");
                group = Console.ReadLine();

            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("  - Авторизация прошла успешно ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("  - Нажмите Enter чтобы продолжить  ");
            Console.ReadLine();
            Console.Clear();

            Student result = GetStudentByNameSurname(surname, name, group);

            return result;
        }

        private Student GetStudentByNameSurname(string surname,string name,string group)
        {
            Student searchableStudent = _context.Students.FirstOrDefault(x => x.Name == name && x.Surname == surname && x.Group==group);
            return searchableStudent;
        }

        private Teacher GetTeacherByNameSurname(string surname,string name)
        {
            Teacher searchableStudent = _context.Teachers.FirstOrDefault(x => x.Name == name && x.Surname == surname);
            return searchableStudent;
        }

        public override BaseUser Menu()
        {

            while (true)
            {
                Console.WriteLine(_menu);
                string input = Console.ReadLine();

                switch (Convert.ToInt32(input))
                {
                    case (int)Operation.SignIn:
                        return new StudentUser(_context,SignIn());
                    case (int)Operation.SignInAsTeacher:
                        return new TeacherUser(_context,SignInAsTeacher());
                    case (int)Operation.Registration:
                        Registration();
                        break;
                    default:
                        break;
                }
            }


        }
    }
}
