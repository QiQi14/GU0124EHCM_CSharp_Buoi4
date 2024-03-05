// See https://aka.ms/new-console-template for more information
using ConsoleApp1;

class Program
{
    static void Main(string[] args)
    {
        UserManager userManager = new UserManager();
        UserInterface menu = new UserInterface(userManager);

        menu.MainMenu();
        while (true)
        {
            int inputButton = Convert.ToInt32(Console.ReadLine());
            if (inputButton == 1)
            {
                Console.WriteLine("Nhap ten dang nhap");
                string username = Console.ReadLine();

                Console.WriteLine("Nhap mat khau");
                string password = Console.ReadLine();
                menu.DangNhap(username, password);

                Console.WriteLine("Chon 1 hoac 2 de ");
                Console.WriteLine("A. Them thong tin ");
                Console.WriteLine("B. Xem thong tin");

                while (true)
                {
                    string subInputButton = Console.ReadLine();

                    if (subInputButton == "A")
                    {
                        menu.AddInfoMenu();
                    }
                    else if (subInputButton == "B")
                    {
                        menu.SeeInfo();
                    }
                    else
                    {
                        break;
                    }
                }


            }
            else if (inputButton == 2)
            {
                Console.WriteLine("Ban da dang xuat");
                menu.DangXuat();

            }
            else if (inputButton == 3)
            {
                Console.WriteLine("Nhap ten dang ky");
                string username = Console.ReadLine();

                Console.WriteLine("Nhap mat khau dang ky:");
                string password = Console.ReadLine();

                menu.DangKy(username, password);
            }
            else if (inputButton == 4)
            {
                Console.WriteLine("Thoat ung dung");
                break;
            }

            else
            {
                Console.WriteLine("Khong hop le vui long chon lai");
            }

        }
    }
}

class UserInterface
{
    private UserManager userManager;
    public string username;
    public string password;

    public UserInterface(UserManager userManager)
    {
        this.userManager = userManager;
    }

    public void MainMenu()
    {
        Console.Clear();
        Console.WriteLine("1. Dang nhap");
        Console.WriteLine("2. Dang xuat");
        Console.WriteLine("3. Dang ky");
        Console.WriteLine("4. Thoat");

    }

    public void DangKy(string username, string password)
    {
        userManager.DangKy(username, password);
    }

    public bool DangNhap(string username, string password)
    {
        return userManager.DangNhap(username, password);
    }

    public void DangXuat()
    {
        userManager.Dangxuat();
    }
    public void AddInfoMenu()
    {
        if (userManager.DangNhap(username, password))
        {
            Console.WriteLine("Nhap ten hoc sinh");
            string studentName = Console.ReadLine();
            Console.WriteLine("Nhap ngay thang nam sinh");
            string dob = Console.ReadLine();
            Console.WriteLine("Nhap diem");
            string score = Console.ReadLine();

            userManager.AddInfo(studentName, dob, score);
        }


    }
    public void SeeInfo()
    {
        userManager.SeeInfo();
    }

}