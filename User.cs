using Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User {
    public class UserData {
        public string username { get; set; }
        public string password { get; set; }
    }

    public class UserManager
    {
        List<UserData> users = new List<UserData>();

        public void Register(UserData user)
        {
            users.Add(user);
        }

        // || hoặc
        // && và
        public int Login(UserData user)
        {
            for (int i = 0; i < users.Count; i++) { 
                if (users[i].username == user.username && users[i].password == user.password)
                {
                    return 1;
                }
            }

            return 0;
        }
    }
}
