using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Execution
{
    public class User
    {
        public User() { }
        public User(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public string username { get; set; }
        public string password { get; set; }
/*        public bool login { get; set; }*/
        
    }

    public class UserManager
    {
        List<User> users = new List<User>();

        public List<User> getListUsers ()
        { return users; }

        public void InsertUser(User user)
        {
            users.Add(user);
        }

        public void DeleteUser(string username)
        {
            bool del = false;
            for (int i = 0; i < users.Count(); i++)
            {
                if (users[i].username == username)
                {
                    users.RemoveAt(i);
                    del = true;
                    return;
                }
            }     
                Console.WriteLine("Username khong ton tai");
        }

        public bool Login(string username,string password,Session session)
        {
            for (int i = 0; i < users.Count(); i++)
            {
                if (users[i].username == username & users[i].password == password)
                {
                    session.username = username;
                    session.password = password;
                    session.login = true;

                    Console.WriteLine("Dang nhap thanh cong");
                    return true;
                }
            }

            Console.WriteLine("Sai tai khoan hoac mat khau");
            return false;
        }


        public void Logout(Session session)
        {
            session = new Session();

            Console.WriteLine("Da dang xuat");

        }

    }
}
