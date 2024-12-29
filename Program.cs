using StudentGradeTracker.Models;
using System;

namespace StudentGradeTracker
{
    class Program
    {
        private static List <Student> students = new List <Student> ();
        private static List <Grade> grades = new List <Grade> ();
        static void Main(string[] args)
        {
            Console.WriteLine("*********Student grade tracker*********");   
            while (true)
            {
                DisplayMenu();
                int choice = GetChoice();
                switch (choice)
                {
                    case 0:
                        Console.WriteLine("Exciting..");
                        Environment.Exit (0);
                        break;
                    case 1: addStudent();
                        break;
                    case 2: showStudents();
                        break;
                    case 3: addGrade();
                        break;
                    case 4: findStudentByName();
                        break;
                    case 5:
                        averageScore();
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }

            }

            
        }

        private static void averageScore()
        {
            if(grades.Count == 0) 
            {
                Console.WriteLine("No grades recorded");
                return;
            }
            var score = grades.Average(grade => grade.Score);
            Console.WriteLine($"La moyenne est {score:F2}");
        }

        private static void findStudentByName()
        {
            Console.WriteLine("Enter the name researched");
            string name=Console.ReadLine();
            var searchStudent= students.Where(student => student.Name.ToLower()==name.ToLower());
            if (searchStudent.Any() ) 
            {
                foreach (var item in searchStudent)
                {
                    Console.WriteLine(item.Name);
                }
            }
            else { Console.WriteLine("No results found"); }
            
        }

        private static void addGrade()
        {
            Console.WriteLine("Enter the grade subject");
            string subject=  Console.ReadLine();
            Console.WriteLine("Enter the grade score");
            string scoreTyped= Console.ReadLine();
            double score;
            while(!double.TryParse(scoreTyped, out score))
            {
                Console.WriteLine("Enter a valid score value");
                scoreTyped = Console.ReadLine();
            }
            grades.Add(new Grade(subject, score));
            Console.WriteLine("Grade added");
            showGrade();
        }

        private static void showGrade()
        {
            Console.WriteLine("**** GRADES*****");
            Console.WriteLine("|SUBJECT|SCORE|");
            foreach (var grade in grades)
            {
                Console.WriteLine($"|{grade.Subject}|{grade.Score}");
            }
        }

        private static void showStudents()
        {
            Console.WriteLine("**** STUDENTS*****");
            Console.WriteLine("|ID|NAME|GRADES|");
            foreach (var student in students)
            {
                string gradeObject = String.Join("-", student.grades.ConvertAll(item => item.Subject));
                Console.WriteLine($"|{student.StudentId}|{student.Name}|{gradeObject}");
            }
        }


        private static void addStudent()
        {
            Console.WriteLine(" Enter student name");
            string name = Console.ReadLine();
            Console.WriteLine("Choose grade by numbers");
            var gradesWithIds= new Dictionary<int, Grade>();
            int i = 0;
            foreach (var grade in grades)
            {
                Console.WriteLine($"{i++}. {grade.Subject}");
                gradesWithIds[i-1] = grade;
                
            }
            string choice = Console.ReadLine();
            int choiceIntVal;
            while(!int.TryParse(choice, out choiceIntVal) || choiceIntVal<1 || choiceIntVal>i)
            {
                Console.WriteLine("Erreur de saisit, saisir un chiffre correct");
                choice = Console.ReadLine();
            }
            Student stud = new Student(name);
            stud.grades.Add(gradesWithIds[choiceIntVal]);

            students.Add(stud);
            
        }

        private static int GetChoice()
        {
            Console.WriteLine("Enter a choice");
            string choice = Console.ReadLine();
            int result;
            while(!int.TryParse(choice, out result))
            {
                Console.WriteLine("Enter a valid integer choice");
                choice = Console.ReadLine();
            }
            return result;
        }

        private static void DisplayMenu()
        {
            Console.WriteLine("**MENU**");
            Console.WriteLine("1. ADD STUDENT");
            Console.WriteLine("2. VIEW STUDENTS");
            Console.WriteLine("3. ADD GRADE");
            Console.WriteLine("4. SEARCH BY NAME");
            Console.WriteLine("3. VIEW SCORE AVERAGE");
            Console.WriteLine("0. EXIT");
        }
    }
}