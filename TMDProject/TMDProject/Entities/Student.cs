using System;
using System.Collections.Generic;
using System.Text;
using TMDProject.Entities;

namespace TMDProject
{

    public class Student:Person
    {
        public string Group { get; set; }
        public float Grade { get; set; }

        public int Test1Attempt = 1;
        public int Test2Attempt = 1;
        public int Test3Attempt = 1;
        public int Test4Attempt = 1;
        public int Test5Attempt = 2;
        public int Test6Attempt = 2;
        public int Test7Attempt = 2;
        public int Test8Attempt = 2;
    }

}
