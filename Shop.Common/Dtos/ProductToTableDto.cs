using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Common.Dtos
{
    public class ProductToTableDto
    {
        public string ProductId { get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int ProductQuantity { get; set; }
        public decimal ProductPrice { get; set; }
    }
}




// [Key]
// [StringLength(200)]
// public string ProductId { get; set; }
// [Required]
// [StringLength(200)]
// public string ShopUserId { get; set; }
// [Required]
// [StringLength(200)]
// public string CategoryId { get; set; }
// [Required]
// [StringLength(100)]
// public string ProductName { get; set; }
// public string ProductDescription { get; set; }
// public int ProductQuantity { get; set; }
// [Column(TypeName = "decimal(18, 0)")]
// public decimal ProductPrice { get; set; }
// public DateTime ProductDateCreated { get; set; }
// public bool ProductIsPromoted { get; set; }