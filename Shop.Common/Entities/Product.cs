using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Common.Entities
{
    public class Product
    {
        public string ProductId { get; set; }
        public string UserId { get; set; }
        public Category Category { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime DateAdd { get; set; }
        public bool IsPromoted { get; set; }
        public string ImageUrl { get; set; }
        public List<Comment> Comments { get; set; }
        public List<DeliveryOption> Deliveries { get; set; }   
        public double AverageNote
        {
            get
            {
                if (Comments != null && Comments.Any())
                {
                    return Comments.Average(c => c.Note);
                }
                else
                    return 0;
            }
        }
    }
}
