namespace LoginOut.Data
{
    public interface IUsers
    {
        bool Login(string username, string password);
        bool Logout(string username);
        bool Register(string username, string password);
    }
}
