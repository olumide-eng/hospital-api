using Microsoft.AspNetCore.Identity;

namespace Hospital_Api.Reopsitories
{
    public interface ITokenRepository
    {
       string CreateJWTToken(IdentityUser user, List<string> roles);


    }
}

