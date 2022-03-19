using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Common.Entities
{
    public class DeliveryOption
    {
        public string DeliveryOptionId { get; set; }
        public string DeliveryOptionName { get; set; }
        public decimal DeliveryOptionPrice { get; set; }
        public int DeliveryOptionDays { get; set; }
    }
}



// Poczta Polska => 6.99 PLN => 7 dni
// Paczkomat InPost => 10.99 PLN => 3 dni
// Kurier => 17.99 PLN => 1 dzień