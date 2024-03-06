using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Execution
{
    public class Student
    {
        public Student() { }
        public Student(string code, string name, string birthday, string classname)
        {
            this.code = code;
            this.name = name;
            this.birthday = birthday;
            this.classname = classname;
        }

        public string code { set; get; }
        public string name { set; get; }
        public string birthday { set; get; }
        public string classname { set; get; }

        public override string? ToString()
        {
            return code + " " + name + " " + birthday + " " + classname;
        }
    }

    public class StudentManager
    {
        List<Student> students = new List<Student>();

        public List<Student> getListStudents()
        {
            return students;
        }

        public void InsertStudent(Student student)
        {
            students.Add(student);
        }

        public void UpdateStudent(Student student, int id)
        {
            students[id] = student;
        }

        public void DeleteStudent(int id)
        {
            if (students[id] != null)
            {
                students.RemoveAt(id);
            }

        }

        /*        public void PrintStudent()
                {
                    students.ForEach(student =>
                    {
                        Console.WriteLine(student);
                    });


                }*/
    }
}
