using Microsoft.AspNetCore.Identity;

namespace Hospital_Api.Models.Domain
{
    public class Staff : IdentityUser
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }

        public string Password { get; set; }

    }
}
