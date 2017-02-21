using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyOwnSite_0._01.Models
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }
        [Required]
        [ForeignKey("User")]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        [Required]
        [StringLength(50)]
        public string Message { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }



        public virtual ICollection<Comment> Comments { get; set; }
        public virtual User User { get; set; }

    }

    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        [Required]
        [ForeignKey("Post")]
        public int PostId { get; set; }
        [Required]
        [ForeignKey("User")]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Message { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }


        
        public virtual Post Post { get; set; }
        public virtual User User { get; set; }
    }
}