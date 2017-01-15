namespace BaseClasses.Interfaces.POCO
{
    public interface IMember
    {
        bool CanWrite { get; set; }
        bool IsOwner { get; set; }
        IMasterAccount MasterAccount { get; set; }
        int MasterAccountId { get; set; }
        int MemberId { get; set; }
        IUserAccount UserAccount { get; set; }
        int UserId { get; set; }
    }
}