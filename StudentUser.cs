using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
 class UserStudent
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string NameStudent { get; set; }
        public string DOB {  get; set; }
        public string Score { get; set; }
    }
    class UserManager
    {
        
        private List<UserStudent> users;
        private UserStudent currentUser;

        public UserManager()
        {
            users = new List<UserStudent>();
            currentUser = null;
        }

        public void DangKy(string username, string password)
        {
            UserStudent newUser = new UserStudent { Username = username, Password = password };
            users.Add(newUser);

            Console.WriteLine("Dang ky thanh cong");
        }

        public bool DangNhap(string username, string password)
        {
            UserStudent user = users.Find(u => u.Username == username && u.Password == password);
            if (user != null)
            {
                currentUser = user;

                Console.WriteLine("Dang nhap thanh cong");
               


                return true;
            }
            else
            {

                Console.WriteLine("Dang nhap that bai, vui long kiem tra");
                return false;
            }

        }
        public void AddInfo(string nameStudent, string DOB, string Score)
        {
            if (currentUser != null)
            {
                currentUser.NameStudent = nameStudent;
                currentUser.DOB = DOB;
                currentUser.Score = Score;
                SeeInfo();

                Console.WriteLine("Them thong tin thanh cong");

            }
        }
        public void SeeInfo() 
        {
            Console.WriteLine("Thong tin sinh vien la: \nUsername: " + currentUser.NameStudent + "\nDOB" + currentUser.DOB + "\nScore: "+ currentUser.Score);
        }
     
        public void Dangxuat()
        {
            currentUser = null;
           

        }




    }
    }
