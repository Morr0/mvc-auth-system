using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginOut.Data
{
    public class Users : IUsers
    {
        Dictionary<string, string> users;
        HashSet<string> activeUsers;

        private Users()
        {
            users = new Dictionary<string, string>();
            activeUsers = new HashSet<string>();

            users.Add("Rami", "1234");
        }

        public static Users I = new Users();

        public bool Login(string username, string password)
        {
            if (!users.TryGetValue(username, out var _password))
                return false;

            if (password == _password && !activeUsers.Contains(username))
            {
                activeUsers.Add(username);
                return true;
            }

            return false;
        }

        public bool Logout(string username)
        {
            if (!users.TryGetValue(username, out var _password))
                return false;

            if (activeUsers.Contains(username))
            {
                return activeUsers.Remove(username);
            }

            return false;
        }

        public bool Register(string username, string password)
        {
            if (users.TryGetValue(username, out var _password))
                return false;

            users.Add(username, password);
            return true;
        }
    }
}
