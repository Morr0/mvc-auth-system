using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginOut.Data
{
    public class Users : IUsers
    {
        Dictionary<string, string> users;

        private Users()
        {
            users = new Dictionary<string, string>();
            users.Add("Rami", "1234");
        }

        public static Users I = new Users();

        public bool Login(string username, string password)
        {
            if (!users.TryGetValue(username, out var _password))
                return false;

            return password == _password;
        }

        public bool Logout(string username)
        {
            if (!users.TryGetValue(username, out var _password))
                return false;

            return users.Remove(username);
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
