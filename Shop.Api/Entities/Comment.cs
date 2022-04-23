using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Shop.Api.Entities
{
    [Table("Comment")]
    public partial class Comment
    {
        [Key]
        [StringLength(200)]
        public string CommentId { get; set; }
        [Required]
        [StringLength(200)]
        public string ProductId { get; set; }
        [Required]
        public string CommentText { get; set; }
        public int Note { get; set; }

        [ForeignKey("ProductId")]
        [InverseProperty("Comments")]
        public virtual Product Product { get; set; }
    }
}
