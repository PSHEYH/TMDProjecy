using System;
using System.Collections.Generic;
using System.Text;
using TMDProject.Entities;

namespace TMDProject
{
    public class Context
    {
        public List<Student> Students { get; }
        public List<Teacher> Teachers { get; }
        public List<string> Groups { get; }

        public Context(List<Student> students,List<Teacher> teachers,List<string> groups)
        {
            Students = students;
            Teachers = teachers;
            Groups = groups;
        }

    }
}
