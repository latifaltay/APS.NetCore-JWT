using Microsoft.AspNetCore.Identity;

namespace AuthServerForJWT_Edu.Core.Models;

public class UserApp : IdentityUser
{
    public string City { get; set; } = string.Empty;
    public DateTime BirthDay { get; set; }
}
