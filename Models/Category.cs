
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MyBlog.Models
{
    [Index(propertyNames: nameof(CategoryName), IsUnique = true)]
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string CategoryName { get; set; }
    }
}
