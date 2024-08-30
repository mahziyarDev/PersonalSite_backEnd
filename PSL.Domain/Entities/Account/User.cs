namespace PSL.Domain.Entities.Account;

public class User : BaseEntity<int>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string BirthDay { get; set; }
    public int Age { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Address { get; set; }
    
}