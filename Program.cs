using Student;
using User;

namespace Execution {
    //Viết chương trình quản lý sinh viên có các chức năng sau:
    //Hiện danh sách sinh viên
    //Thêm sinh viên
    //Xóa sinh viên
    //Sửa thông tin sinh viên
    //Thông tin sinh viên bao gồm, mã sinh viên, tên, ngày sinh, lớp học

    class Program
    {
        static StudentManager studentManager = new StudentManager();
        static StudentData studentData = new StudentData();

        static UserManager userManager = new UserManager();

        static void Main(string[] args)
        {
            UserInterface.mainMenu();
            
            studentData.code = "SV1";
            studentData.name = "test";
            studentData.dob = "01/01/2011";
            studentData.currentClass = "GU";

            studentManager.InsertStudent(studentData);

            while (true)
            {
                int inputOption = Convert.ToInt32(Console.ReadLine());
                authentication(inputOption);
            }
        }

        public static void authentication(int inputOption)
        {
            if (inputOption == 1)
            {
                UserData userData = new UserData();
                UserInterface.inputUserData(userData);
                int result = userManager.Login(userData);

                if (result == 1)
                {
                    Console.WriteLine("Dang nhap thanh cong");
                    Thread.Sleep(1000);
                    Console.Clear();
                    onboarding(-1);
                } else
                {
                    Console.WriteLine("Dang nhap that bai");
                    Thread.Sleep(1000);
                    Console.Clear();

                    UserInterface.mainMenu();
                }
            } else if (inputOption == 2)
            {
                UserData userData = new UserData();
                UserInterface.inputUserData(userData);


                userManager.Register(userData);
                Console.WriteLine("Dang ky thanh cong");
            }
        }

        public static void onboarding(int inputOption)
        {
            Console.WriteLine("debug" + inputOption);
            if (inputOption == 1)
            {
                UserInterface.listStudent(studentManager.getListStudent());
            }
            else if (inputOption == 2)
            {
                studentData = new StudentData();
                UserInterface.addStudent(studentData);
                studentManager.InsertStudent(studentData);
                Console.WriteLine("Them thanh cong");

                Thread.Sleep(2000);
                UserInterface.mainMenu();
            }
            if (inputOption == 3)
            {
                string studentCode = UserInterface.findStudent(true);
                int index = studentManager.FindStudent(studentCode);

                if (index == -1)
                {
                    Console.WriteLine("Khong co sinh vien nao co ma sinh vien la " + studentCode);
                }
                else
                {
                    studentData = new StudentData();
                    UserInterface.addStudent(studentData);
                    studentManager.EditStudent(studentData, index);
                    Console.WriteLine("Sua thanh cong");
                }

            }
            else if (inputOption == 4)
            {
                string studentCode = UserInterface.findStudent(false);
                int index = studentManager.FindStudent(studentCode);

                if (index == -1)
                {
                    Console.WriteLine("Khong co sinh vien nao co ma sinh vien la " + studentCode);
                }
                else
                {
                    studentManager.RemoveStudentByIndex(index);
                    Console.WriteLine("Xoa thanh cong");
                }
            }
            else if (inputOption == -1)
            {
                UserInterface.onboarding();
            }
            else if (inputOption == 5)
            {
                return;
            } else
            {
                Console.WriteLine("Khong co chuc nang nay");
            }
        }
    }

    class UserInterface
    {
        public static void mainMenu()
        {
            Console.WriteLine("Chuong trinh quan ly sinh vien");
            Console.WriteLine("1. Dang nhap");
            Console.WriteLine("2. Dang ky");
            Console.WriteLine("3. Thoat");
        }

        public static void inputUserData(UserData user)
        {
            Console.WriteLine("Nhap username: ");
            user.username = Console.ReadLine();
            Console.WriteLine("Nhap password: ");
            user.password = Console.ReadLine();
        }

        public static void onboarding()
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

        public static string findStudent(bool isEdit)
        {
            Console.WriteLine("Vui long nhap ma sinh vien can " + (isEdit ? "sua:" : "xoa:"));

            return Console.ReadLine();
        }
    }
}
