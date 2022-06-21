using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCoreProject.Models.Entities
{
    public class ProductDiscount
    {
        public int ProductId { get; set; }
        public decimal Discount { get; set; }
    }
}
