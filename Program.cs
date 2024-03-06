

namespace Execution {
    //Viết chương trình quản lý sinh viên có các chức năng sau:
    //Hiện danh sách sinh viên
    //Thêm sinh viên
    //Xóa sinh viên
    //Sửa thông tin sinh viên
    //Thông tin sinh viên bao gồm, mã sinh viên, tên, ngày sinh, lớp học

    public class Program
    {
        static void Main(string[] args)
        {
            /*         Console.WriteLine("Hello, World!");

                     Animal animal = new Cat();
                     animal.Speak();*/


            /*Bai tap buoi 4*/
            StudentManager studentManager = new StudentManager();

            studentManager.InsertStudent(new Student("01", "ABC", "12-12-1994", "A1"));
            studentManager.InsertStudent(new Student("02", "DEF", "10-9-1995", "A2"));
            Session session = new Session();

            UserManager userManager = new UserManager();
            userManager.InsertUser(new User("ABC", "123456"));
            userManager.InsertUser(new User("DEF", "123456"));

            /*Bai 1*/
            /*            UserInterface.Bai1(studentManager);*/


            /* Bai 2*/
            UserInterface.Bai2(studentManager, userManager, session);





        }


    }

    public class UserInterface
    {
        public static void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("Moi ban nhap");
            Console.WriteLine("1 Hien thi sinh vien");
            Console.WriteLine("2 Them Sinh vien");
            Console.WriteLine("3 Sua Sinh vien");
            Console.WriteLine("4 Xoa Sinh vien");
            Console.WriteLine("Any else: Thoat chuong trinh");
        }

        public static void ShowMenuUser()
        {
            Console.Clear();
            Console.WriteLine("Moi ban nhap");
            Console.WriteLine("1 Dang ky");
            Console.WriteLine("2 Dang nhap ");
            Console.WriteLine("3 Dang xuat");
            Console.WriteLine("Any else: Thoat chuong trinh");
        }

        public static void PrintStudent(List<Student> students)
        {
            Console.WriteLine("MSSV\t|\tTen\t|\tDoB\t\t|\tClass");
            for (int i = 0; i < students.Count; i++)
            {
                Console.Write(students[i].code);
                Console.Write("\t|\t");
                Console.Write(students[i].name);
                Console.Write("\t|\t");
                Console.Write(students[i].birthday);
                Console.Write("\t|\t");
                Console.Write(students[i].classname);
                Console.WriteLine();
            }
        }

        public static void addStudent(Student studentData)
        {
            Console.WriteLine("Vui long nhap ma sinh vien");
            studentData.code = Console.ReadLine();
            Console.WriteLine("Vui long nhap ten sinh vien");
            studentData.name = Console.ReadLine();
            Console.WriteLine("Vui long nhap ngay sinh sinh vien");
            studentData.birthday = Console.ReadLine();
            Console.WriteLine("Vui long nhap lop dang hoc");
            studentData.classname = Console.ReadLine();
        }

        public static void addUser(User userData)
        {
            Console.WriteLine("Vui long nhap username");
            userData.username = Console.ReadLine();
            Console.WriteLine("Vui long nhap password");
            userData.password = Console.ReadLine();

        }



        public static void Bai1(StudentManager studentManager)
        {
            while (true)
            {
                UserInterface.ShowMenu();
                int inputOption = Convert.ToInt32(Console.ReadLine());

                switch (inputOption)
                {
                    case 1:
                        UserInterface.PrintStudent(studentManager.getListStudents());
                        break;

                    case 2:
                        Student student = new Student();
                        UserInterface.addStudent(student);
                        studentManager.InsertStudent(student);
                        Console.WriteLine("Them thanh cong");

                        Thread.Sleep(2000);

                        break;

                    case 3:
                        Console.WriteLine("Nhap thu tu sinh vien can sua:");
                        int index = Convert.ToInt32(Console.ReadLine());
                        if (index > studentManager.getListStudents().Count() | index < 1)
                        {
                            Console.WriteLine("Khong ton tai sinh vien");
                        }
                        else
                        {
                            Student student2 = new Student();
                            UserInterface.addStudent(student2);
                            studentManager.getListStudents()[index - 1] = student2;
                            Console.WriteLine("Sua thanh cong");

                            Thread.Sleep(2000);
                        }

                        break;

                    case 4:
                        Console.WriteLine("Nhap thu tu sinh vien can xoa:");
                        index = Convert.ToInt32(Console.ReadLine());
                        if (index > studentManager.getListStudents().Count() | index < 1)
                        {
                            Console.WriteLine("Khong ton tai sinh vien");
                        }
                        else
                        {
                            studentManager.getListStudents().RemoveAt(index - 1);
                            Console.WriteLine("Xoa thanh cong");

                            Thread.Sleep(2000);
                        }

                        break;
                    default:
                        return;

                }


                Console.WriteLine("ban co muon tiep tuc? nhan Y de tiep tuc");
                string y = Console.ReadLine();
                if (y != "Y" & y != "y")
                {
                    break;
                }
            }
        }

        public static void Bai2(StudentManager studentManager, UserManager userManager, Session session)
        {
            while (true)
            {
                int inputOption = 0;

                if (session.login == false)
                {
                    UserInterface.ShowMenuUser();
                    inputOption = Convert.ToInt32(Console.ReadLine());
                }
                else
                {
                    Console.WriteLine("Ban dang dang nhap, ban co muon dang xuat khong Y/N?");
                    string dangxuat = Console.ReadLine();
                    if (dangxuat == "Y" | dangxuat == "y")
                    {
                        session.login = false;
                    }
                    else
                    {
                        UserInterface.Bai1(studentManager);
                    }

                }

                if (inputOption != 0 & session.login == false)
                {
                    switch (inputOption)
                    {
                        case 1:
                            User user = new User();
                            UserInterface.addUser(user);
                            userManager.InsertUser(user);
                            Console.WriteLine("Dang ky thanh cong");

                            Thread.Sleep(2000);
                            break;

                        case 2:
                            User user2 = new User();
                            UserInterface.addUser(user2);
                            bool login = userManager.Login(user2.username, user2.password, session);
                            if (login == true)
                            {
                                UserInterface.Bai1(studentManager);
                            }
                            break;
                        case 3:
                            userManager.Logout(session);
                            break;
                        default:
                            return;
                    }
                }


                Console.WriteLine("ban co muon tiep tuc user? nhan Y de tiep tuc");
                string y = Console.ReadLine();
                if (y != "Y" & y != "y")
                {
                    break;
                }
            }
        }
    }
}
