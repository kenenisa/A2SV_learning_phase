using System;
using System.Text.Json;
class Student
{
    public string Name { get; set; }
    public int Age { get; set; }
    public readonly int RollNumber;
    public float Grade { get; set; }
    public override string ToString()
    {
        return RollNumber + ". " + Name + ", " + Age + " - " + Grade;
    }
    public Student(string N, int A, int R, float G)
    {
        Name = N;
        Age = A;
        RollNumber = R;
        Grade = G;
    }
}
interface StudentInterface
{
    string Name { get; }
    int Age { get; }
}
class StudentList<T> where T : Student
{
    List<T> students = new();
    string filePath = "save.json";
    public void AddStudent(T student)
    {
        students.Add(student);
    }
    public void DisplayStudents()
    {
        Console.WriteLine("Students: ");
        foreach (T s in students)
        {
            Console.WriteLine(s.ToString());
        }
    }
    public void SearchStudents(string query)
    {
        List<T> list = students.Where(x => x.Name == query || x.RollNumber.ToString() == query).ToList();
        if (list.Count > 0)
        {
            Console.WriteLine("Students search result: ");
        }
        else
        {
            Console.WriteLine("No results fund for query: " + query);
        }
        foreach (T t in list)
        {
            Console.WriteLine(t.ToString());
        }
    }
    public List<T> ConvertList<T>(List<Student> students)
    {
        List<T> convertedList = students.Cast<T>().ToList();
        return convertedList;
    }
    public async void ToJSON()
    {
        try
        {

            //Serialize
            var jsonString = JsonSerializer.Serialize(students);
            await File.WriteAllTextAsync(filePath, jsonString);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);

        }
    }
    public async void FromJson()
    {
        try
        {

            string json = await File.ReadAllTextAsync(filePath);
            students = JsonSerializer.Deserialize<List<T>>(json);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}
public class Program
{
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
    public static int ReadNumber(string prompt)
    {
        int result = 0;
        ReadLine(prompt, (read) =>
                {
                    return !int.TryParse(read, out result) || result < 0;
                });
        return result;
    }
    public static float ReadFloat(string prompt)
    {
        float result = 0;
        ReadLine(prompt, (read) =>
                {
                    return !float.TryParse(read, out result) || result < 0;
                });
        return result;
    }
    public static void Main()
    {
        StudentList<Student> studentList = new();
        Console.WriteLine("Menu");
        Console.WriteLine("1. Add student");
        Console.WriteLine("2. Display students");
        Console.WriteLine("3. Write to json");
        Console.WriteLine("4. Read to json");
        Console.WriteLine("5. Search");
        Console.WriteLine("0. Exit");
        int choice = -1;
        while (choice != 0)
        {
            choice = ReadNumber("Enter choice: ");
            if (choice == 1)
            {
                studentList.AddStudent(new Student(
                    ReadLine("Name: ", (read) => { return read.Equals(""); }),
                    ReadNumber("Age: "),
                    ReadNumber("RollNumber: "),
                    ReadFloat("Grade: ")
                ));
            }
            else if (choice == 2)
            {
                studentList.DisplayStudents();
            }
            else if (choice == 3)
            {
                studentList.ToJSON();
            }
            else if (choice == 4)
            {
                studentList.FromJson();
            }
            else if (choice == 5)
            {
                studentList.SearchStudents(ReadLine("Search query: ", (read) => { return read.Equals(""); }));
            }
        }

    }
}
