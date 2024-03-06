using Student;

namespace Execution {
    //Viết chương trình quản lý sinh viên có các chức năng sau:
    //Hiện danh sách sinh viên
    //Thêm sinh viên
    //Xóa sinh viên
    //Sửa thông tin sinh viên
    //Thông tin sinh viên bao gồm, mã sinh viên, tên, ngày sinh, lớp học

    class Program
    {
        public static void Main(string[] args)
        {
            UserInterface.MainMenu();
            StudentManager studentManager = new StudentManager();
            StudentData studentData = new StudentData();

            while (true)
            {
                int inputOption = Convert.ToInt32(Console.ReadLine());
                if (inputOption == 1)
                {
                    UserInterface.listStudent(studentManager.getListStudent());
                }
                else

                if (inputOption == 2)
                {
                    studentData = new StudentData();
                    UserInterface.addStudent(studentData);
                    studentManager.InsertStudent(studentData);
                    Console.WriteLine("Them thanh cong");

                    Thread.Sleep(2000);
                    UserInterface.MainMenu();
                }
                else 
                
                if (inputOption == 3)
                {
                    Console.WriteLine("Danh sach sinh vien:");
                    UserInterface.listStudent(studentManager.getListStudent());

                    Console.WriteLine("Nhap ma sinh vien can sua:");
                    string codeToEdit = Console.ReadLine();

                    int studentIndex = studentManager.getListStudent().FindIndex(student => student.code == codeToEdit);

                    if (studentIndex != -1)
                    {
                        Console.WriteLine("Thong tin sinh vien can sua: ");
                        DisplayStudent(studentManager.getListStudent()[studentIndex]);

                        Console.WriteLine("Nhap thong tin moi: ");

                        Console.WriteLine("Ten moi: ");
                        studentData.name = Console.ReadLine();
                        Console.WriteLine("Ngay sinh moi: ");
                        studentData.dob = Console.ReadLine();
                        Console.WriteLine("Lop moi: ");
                        studentData.currentClass = Console.ReadLine();
                    }

                    studentData = new StudentData();
                    studentManager.InsertStudent(studentData);

                    Console.WriteLine("Thong tin sinh vien sau khi thay doi: ");
                    DisplayStudent(studentManager.getListStudent()[studentIndex]);

                    Thread.Sleep(2000);
                    UserInterface.MainMenu();

                }
                else 
                
                if (inputOption == 4)
                {
                    Console.WriteLine("Danh sach sinh vien:");
                    UserInterface.listStudent(studentManager.getListStudent());

                    Console.WriteLine("Nhap ma sinh vien can xoa:");
                    string codeToDelete = Console.ReadLine();

                    int studentIndex = studentManager.getListStudent().FindIndex(student => student.code == codeToDelete);

                    studentData = new StudentData();
                    studentManager.RemoveStudentByIndex(studentIndex);
                    studentManager.InsertStudent(studentData);
                    Console.WriteLine("Xoa thanh cong");

                    Thread.Sleep(2000);
                    UserInterface.MainMenu();
                }
                else 
                
                if (inputOption == 5)
                {
                    break;
                }
            }
        }
        static void DisplayStudent(StudentData student)
        {
            Console.WriteLine($"Ma so: {student.code}\t| Ten: {student.name}\t| Ngay sinh: {student.dob}\t\t| Lop: {student.currentClass}");
        }
        static void DisplayStudents(System.Collections.Generic.List<StudentData> students)
        {
            foreach (var student in students)
            {
                DisplayStudent(student);
            }
        }
    }

    class UserInterface
    {
        public static void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Chuong trinh quan ly sinh vien");
            Console.WriteLine("1.Hien danh sach sinh vien");
            Console.WriteLine("2.Them danh sach sinh vien");
            Console.WriteLine("3.Sua danh sach sinh vien");
            Console.WriteLine("4.Xoa danh sach sinh vien");
            Console.WriteLine("5.Thoat danh sach sinh vien");
        }

        public static void listStudent(List<StudentData> students)
        {
            Console.WriteLine("MSSV\t|\tTen\t|\tDoB\t\t|\tClass");
            for (int i = 0; i < students.Count; i++)
            {
                Console.Write(students[i].code);
                Console.Write("\t|\t");
                Console.Write(students[i].name);
                Console.Write("\t|\t");
                Console.Write(students[i].dob);
                Console.Write("\t|\t");
                Console.Write(students[i].currentClass);
                Console.WriteLine();
            }
        }
        public static void addStudent(StudentData studentData)
        {
            Console.WriteLine("Nhap ma sinh vien: ");
            studentData.code = Console.ReadLine();

            Console.WriteLine("Nhap ten sinh vien: ");
            studentData.name = Console.ReadLine();

            Console.WriteLine("Nhap ngay sinh: ");
            studentData.dob = Console.ReadLine();

            Console.WriteLine("Nhap lop hoc: ");
            studentData.currentClass = Console.ReadLine();
        }
    }
}
