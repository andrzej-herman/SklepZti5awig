using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Shop.Api.Entities
{
    [Table("Product")]
    public partial class Product
    {
        public Product()
        {
            Comments = new HashSet<Comment>();
            DeliveryOptions = new HashSet<DeliveryOption>();
        }

        [Key]
        [StringLength(200)]
        public string ProductId { get; set; }
        [Required]
        [StringLength(200)]
        public string ShopUserId { get; set; }
        [Required]
        [StringLength(200)]
        public string CategoryId { get; set; }
        [Required]
        [StringLength(100)]
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int ProductQuantity { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal ProductPrice { get; set; }
        public DateTime ProductDateCreated { get; set; }
        public bool ProductIsPromoted { get; set; }

        [ForeignKey("CategoryId")]
        [InverseProperty("Products")]
        public virtual Category Category { get; set; }
        [ForeignKey("ShopUserId")]
        [InverseProperty("Products")]
        public virtual ShopUser ShopUser { get; set; }
        [InverseProperty("Product")]
        public virtual ICollection<Comment> Comments { get; set; }

        [ForeignKey("ProductId")]
        [InverseProperty("Products")]
        public virtual ICollection<DeliveryOption> DeliveryOptions { get; set; }
    }
}
