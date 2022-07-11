using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace FinalTask;

[Serializable]
public class Student
{
    public string Name { get; set; }
    public string Group { get; set; }
    public DateTime DateOfBirth { get; set; }

    public Student(string name, string group, DateTime dateOfBirth)
    {
        Name = name;
        Group = group;
        DateOfBirth = dateOfBirth;
    }
}

public class BinaryLoader
{
    public void LoadBinaryFile(string path)
    {
        BinaryFormatter bf = new BinaryFormatter();
        Student[] students;
        using (var fs = new FileStream(path, FileMode.OpenOrCreate))
        {
            students = (Student[]) bf.Deserialize(fs);
        }

        DirectoryInfo studentFileInfo = new DirectoryInfo(@"C:\Users\Alexey\Desktop\Students");
        studentFileInfo.Create();

        List<string> groups = new List<string>();

        for (int i = 0; i < students.Length; i++)
        {

                using (StreamWriter sw = new StreamWriter(File.Open(@"C:\Users\Alexey\Desktop\Students\" + students[i].Group + ".txt",FileMode.Append)))
                {
                    sw.Write(students[i].Name);
                    sw.Write(" ");
                    sw.Write(students[i].Group);
                    sw.Write(" ");
                    sw.Write(students[i].DateOfBirth);
                    sw.WriteLine();
                }

        }

        for (int i = 0; i < students.Length; i++)
        {
            
        }
    }
}