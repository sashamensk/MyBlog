using Microsoft.AspNetCore.Identity;

namespace MyBlog.Areas.Admin.Models
{
    public class User : IdentityUser
    {
        public int Year { get; set; }
    }
}
