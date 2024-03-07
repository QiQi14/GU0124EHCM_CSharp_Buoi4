using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student {
    public class StudentData {
        public string code { get; set; }
        public string name { get; set; }
        public string dob { get; set; }
        public string currentClass { get; set; }
    }

    //class DongVat
    //function dongVat

    public class StudentManager
    {
        List<StudentData> students = new List<StudentData>();

        public List<StudentData> getListStudent()
        {
            return students;
        }

        public void InsertStudent(StudentData student)
        {
            students.Add(student);
        }

        public void RemoveStudentByIndex(int index)
        {
            students.RemoveAt(index);
        }

        public void EditStudent(StudentData newData, int studentIndex)
        {
            students[studentIndex] = newData;
        }

        public int FindStudent(string studentCode)
        {
            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].code == studentCode)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
