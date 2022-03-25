using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyBlog.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        public string Author { get; set; }

        [Required]
        public string PostCategory { get; set; }
        [Required]
        [StringLength(30)]
        public string Title { get; set; }
        [DisplayName("Description")]
        [StringLength(100)]
        [Required]
        public string Description { get; set; }
        [Required]
        public string Text { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
