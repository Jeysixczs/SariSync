using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SariSariStore.Core.Model
{
    public class CreateOrderDto
    {
        public string CustomerName { get; set; }
        public string Notes { get; set; }
        public string Remarks { get; set; }
        public bool IsPaid { get; set; }
        public List<OrderItemDto> Items { get; set; }
    }
}
