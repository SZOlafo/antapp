namespace antapp.Shared.Auth;

public interface IUserAccesor
{
    int UserId { get; }
    string Login { get; }
    string Password { get; }
}

internal class DummyUser : IUserAccesor
{
    public int UserId => 1;

    public string Login => "AntMaster";
    public string Password => "mruwa";
}