using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SariSariStore.Core.Model
{
    public class OrderResponseDto
    {
        public int OrderID { get; set; }
        public string CustomerName { get; set; }
        public string Notes { get; set; }
        public string Remarks { get; set; }
        public DateTime OrderDate { get; set; }
        public bool IsPaid { get; set; }
        public decimal TotalAmount { get; set; }
        public List<OrderItemResponseDto> Items { get; set; }
    }
}
