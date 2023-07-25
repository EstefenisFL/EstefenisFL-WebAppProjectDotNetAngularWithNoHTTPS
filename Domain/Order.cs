using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace Domain
{
    public class Order
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public Client? Client { get; set; }
        public DateTime Started {get; set; }
        public DateTime Finished { get; set;}
        public FreightType FreightType { get; set; }
        public OrderStatus Status { get; set; }
        public string? Note { get; set; }
        public ICollection<OrderItem>? Itens { get; set; } 
    }
}
