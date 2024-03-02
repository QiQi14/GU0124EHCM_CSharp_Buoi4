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
        static void Main(string[] args)
        {
            UserInterface.mainMenu();
            StudentManager studentManager = new StudentManager();

            StudentData studentData = new StudentData();
            studentData.code = "SV1";
            studentData.name = "test";
            studentData.dob = "01/01/2011";
            studentData.currentClass = "GU";

            studentManager.InsertStudent(studentData);

            while (true)
            {
                int inputOption = Convert.ToInt32(Console.ReadLine());
                if (inputOption == 1)
                {
                    UserInterface.listStudent(studentManager.getListStudent());
                } else if (inputOption == 2)
                {
                    studentData = new StudentData();
                    UserInterface.addStudent(studentData);
                    studentManager.InsertStudent(studentData);
                    Console.WriteLine("Them thanh cong");

                    Thread.Sleep(2000);
                    UserInterface.mainMenu();
                }
            }
        }
    }

    class UserInterface
    {
        public static void mainMenu()
        {
            Console.Clear();
            Console.WriteLine("Chuong trinh quan ly sinh vien");
            Console.WriteLine("1. Hien danh sach sinh vien");
            Console.WriteLine("2. Them sinh vien");
            Console.WriteLine("3. Sua thong tin sinh vien");
            Console.WriteLine("4. Xoa sinh vien");
            Console.WriteLine("5. Thoat chuong trinh");
        }
        // \n xuống dòng
        // \t tương tự với khi ấn tab, tạo 1 khoảng trắng giữa các ký tự
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
            Console.WriteLine("Vui long nhap ma sinh vien");
            studentData.code = Console.ReadLine();
            Console.WriteLine("Vui long nhap ten sinh vien");
            studentData.name = Console.ReadLine();
            Console.WriteLine("Vui long nhap ngay sinh sinh vien");
            studentData.dob = Console.ReadLine();
            Console.WriteLine("Vui long nhap lop dang hoc");
            studentData.currentClass = Console.ReadLine();
        }
    }
}
