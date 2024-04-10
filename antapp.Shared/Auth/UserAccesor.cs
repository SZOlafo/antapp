namespace antapp.Shared.Auth;

public interface IUserAccesor
{
    bool IsAuthenticated { get; set; }
    int UserId { get; }
    string Login { get; }
    string Password { get; }

    bool LoginUser(int userId, string login);
    bool LogoutUser();
}

public class DummyUser : IUserAccesor
{
    public bool IsAuthenticated { get; set; }
    public int UserId { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }

    public DummyUser()
    {
        IsAuthenticated = true;
        UserId = 1;
        Login = "AntMaster";
        Password = "Mruwa";
    }

    public bool LoginUser(int userId, string login)
    {
        IsAuthenticated = true;
        Login = login;
        return IsAuthenticated;
    }

    public bool LogoutUser()
    {
        IsAuthenticated = false;
        return IsAuthenticated;
    }
}