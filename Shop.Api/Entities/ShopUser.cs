using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Shop.Api.Entities
{
    [Table("ShopUser")]
    public partial class ShopUser
    {
        public ShopUser()
        {
            Products = new HashSet<Product>();
        }

        [Key]
        [StringLength(200)]
        public string UserId { get; set; }
        [Required]
        [StringLength(200)]
        public string UserFirstName { get; set; }
        [Required]
        [StringLength(200)]
        public string UserLastName { get; set; }
        [Required]
        [StringLength(200)]
        public string UserName { get; set; }
        [Required]
        public string UserPasswordSalt { get; set; }
        [Required]
        public string UserPasswordHash { get; set; }

        [InverseProperty("ShopUser")]
        public virtual ICollection<Product> Products { get; set; }
    }
}
