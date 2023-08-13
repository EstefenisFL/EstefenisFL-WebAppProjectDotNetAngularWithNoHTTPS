using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class OrderItemDTO
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public OrderDTO? Order { get; set; }
        public int ProductId { get; set; }
        public ProductDTO? Product { get; set; }
        public int Quantity { get; set; }
        public decimal Value { get; set; }
        public decimal Discount { get; set; }
    }
}
