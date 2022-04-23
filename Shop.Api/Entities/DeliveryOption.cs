using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Shop.Api.Entities
{
    [Table("DeliveryOption")]
    public partial class DeliveryOption
    {
        public DeliveryOption()
        {
            Products = new HashSet<Product>();
        }

        [Key]
        [StringLength(200)]
        public string DeliveryOptionId { get; set; }
        [Required]
        [StringLength(50)]
        public string DeliveryOptionName { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal DeliveryOptionPrice { get; set; }
        public int DeliveryOptionDays { get; set; }

        [ForeignKey("DeliveryOptionId")]
        [InverseProperty("DeliveryOptions")]
        public virtual ICollection<Product> Products { get; set; }
    }
}
