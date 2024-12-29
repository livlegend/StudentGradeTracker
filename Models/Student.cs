using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentGradeTracker.Models
{
    internal class Student
    {
        public int NextId { get; set; } = 0;
        public int StudentId { get; set; }
        public string Name { get; set; }

        public List <Grade> grades { get; private set; } = new List <Grade> ();

        public Student(string name)
        {
            StudentId=NextId++;
            Name = name;
        }
    }
}
