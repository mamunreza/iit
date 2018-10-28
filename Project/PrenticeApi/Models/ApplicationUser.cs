using Microsoft.AspNetCore.Identity;

namespace PrenticeApi.Models
{
    public class ApplicationUser : IdentityUser
    {
        // public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        // public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}