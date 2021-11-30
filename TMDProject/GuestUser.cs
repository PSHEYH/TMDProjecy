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

            Console.Write("  Введите пароль : ");
            string password = Console.ReadLine();

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

                Console.Write("  Введите пароль : ");
                password = Console.ReadLine();
            }

            Student addedStudent = new Student
            {
                Surname = surname,
                Name = name,
                Group = group,
                Password = password
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

            if (GetTeacherByNameSurname(surname,name)==null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" - Вы ввели имя и фамилию не существующего преподавателя в данной программе -");
                Console.WriteLine("  - НЕуспешная авторизация -  ");
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("  - Нажмите Enter чтобы продолжить  ");
                Console.ReadLine();
                Console.Clear();

                return null;

            }

            Console.Write("  Введите пароль : ");
            string password = Console.ReadLine();

            if (GetTeacherByNameSurname(surname,name).LectorPassword!=password)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" - Вы ввели НЕправильный пароль ! !  -");
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("  - Нажмите Enter чтобы продолжить  ");
                Console.ReadLine();
                Console.Clear();

                return null;
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

            Console.Write("  Введите пароль : ");
            string password = Console.ReadLine();

            if (GetStudentByNameSurname(surname, name,group,password) == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" - Вы ввели неправильное имя или фамилию или группу или пароль");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("  - Нажмите Enter чтобы продолжить  ");
                Console.ReadLine();
                Console.Clear();
                return null;
            }
            

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("  - Авторизация прошла успешно ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("  - Нажмите Enter чтобы продолжить  ");
            Console.ReadLine();
            Console.Clear();

            Student result = GetStudentByNameSurname(surname, name, group,password);

            return result;
        }

        private Student GetStudentByNameSurname(string surname,string name,string group,string password)
        {
            Student searchableStudent = _context.Students.FirstOrDefault(x => x.Name == name && x.Surname == surname && x.Group==group && x.Password==password);
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
                        Student student = SignIn();
                        if (student != null)
                        {
                            return new StudentUser(_context, student);
                        }
                        break;
                    case (int)Operation.SignInAsTeacher:
                        Teacher teacher = SignInAsTeacher();
                        if (teacher != null)
                        {
                            return new TeacherUser(_context, teacher);
                        }
                        break;
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
