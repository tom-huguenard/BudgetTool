namespace BaseClasses.Interfaces.POCO
{
    public interface IUserAccount
    {
        string Password { get; set; }
        int UserId { get; set; }
        string UserName { get; set; }
    }
}