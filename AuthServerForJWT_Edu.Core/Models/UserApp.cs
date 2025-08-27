using Microsoft.AspNet.Identity.EntityFramework;

namespace AuthServerForJWT_Edu.Core.Models;

public class UserApp : IdentityUser
{
    public string City { get; set; }
}
