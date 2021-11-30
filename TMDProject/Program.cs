using System;
using System.Collections.Generic;
using TMDProject.Entities;

namespace TMDProject
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Student> students = new List<Student>() 
            {
                new Student{ Surname ="Sheychenko" , Name = "Pavel" , Group="PA 18 1",Password="Password"},
                new Student{ Surname ="Solovyov" , Name = "Pavel" , Group="PA 18 1",Password="Password"},
                new Student{ Surname ="RIPna" , Name = "Olena" , Group="PA 18 1",Password="Password"},
                new Student{ Surname ="SCherbak" , Name = "Roman" , Group="PA 18 1", Password = "Password"},
                new Student{Surname="Mostovoi", Name="Aristarh",Group="PA 18 1",Password="Password"}

            };

            List<Teacher> teachers = new List<Teacher>(){
                new Teacher{Surname = "Turchina",Name ="Valentina",SecondName="Andriivna",LectorPassword="LCPass4444"}
            };

            List<string> groups = new List<string>() { "PA 18 1", "PA 18 2", "PA 18 3" };

            Context context = new Context(students, teachers, groups);

            BaseUser user = new GuestUser(context);

            while (true)
            {
                user = user.Menu();
            }
           
        }

        public static void Continue(ref string choice)
        {
            string prev = choice;
            Console.WriteLine(" 0| Продолжить                    2| Повторить");
            choice = Console.ReadLine();
            if (choice == "2")
                choice = prev;


        }

      
    }
}
