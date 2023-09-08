using System;
using System.Collections.Generic;
public class Input
{

    public static string getGradeLetter(float GradeNumber)
    {
        if (GradeNumber >= 90)
        {
            return "A";
        }
        else if (GradeNumber >= 80)
        {
            return "B";
        }
        else if (GradeNumber >= 70)
        {
            return "C";
        }
        else if (GradeNumber >= 60)
        {
            return "D";
        }
        return "F";
    }
    public class Subject
    {
        public string Name { get; set; } = "";
        public float grade { get; set; }

    }
    public class Student
    {
        public string Name { get; set; } = "";
        public int NumOfSubjects { get; set; } = 0;
        public List<Subject> subjects = new List<Subject>();
    }
    public static string ReadLine(string ask, Func<string, bool> condition)
    {
        Console.Write(ask);
        string read = Console.ReadLine();
        while (condition(read))
        {
            Console.WriteLine("Please enter a valid input");
            Console.Write(ask);
            read = Console.ReadLine();
        }
        return read;
    }
    public static void Main()
    {
        Student student = new Student();
        student.Name = ReadLine("Enter your name: ", (read) =>
        {
            return read.Equals("");
        });
        int readSubs = 0;
        ReadLine("Enter number of subjects: ", (read) =>
        {
            return !int.TryParse(read, out readSubs) || readSubs < 1;
        });
        student.NumOfSubjects = readSubs;
        int x = 1;
        while (x <= readSubs)
        {
            Subject sub = new Subject();
            sub.Name = ReadLine($"Enter subject {x} name: ", (read) =>
            {
                return read.Equals("");
            });
            float grade = 0;
            ReadLine($"Enter subject {x} grade(100%): ", (read) =>
            {
                return read.Equals("") || !float.TryParse(read, out grade) || grade < 0 || grade > 100;
            });
            sub.grade = grade;
            student.subjects.Add(sub);
            x++;
        }
        Console.WriteLine("");
        Console.WriteLine("");

        Console.WriteLine("Here is your result " + student.Name);
        Dictionary<string, float> grades = new Dictionary<string, float>();
        grades.Add("A", 4.0f);
        grades.Add("B", 3.0f);
        grades.Add("C", 2.0f);
        grades.Add("D", 1.0f);
        grades.Add("F", 0.0f);
        int y = 1;
        float gradeSum = 0;
        foreach (Subject sub in student.subjects)
        {
            string g = getGradeLetter(sub.grade);
            Console.WriteLine(y + ". " + sub.Name + " - " + g);
            gradeSum += grades[g];
            y++;
        }
        Console.WriteLine("CGPA - " + (gradeSum / readSubs));

    }
}