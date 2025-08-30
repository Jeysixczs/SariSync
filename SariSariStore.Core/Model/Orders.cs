using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SariSariStore.Core.Model
{
    [Table("tbl_Orders")]
    public class Orders
    {
        //send Order to the database
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }

        public List<OrderItems> Items { get; set; } = new List<OrderItems>();

        public bool IsPaid { get; set; }

        public decimal TotalAmount => Items?.Sum(i => i.Quantity * i.Price) ?? 0;

    }
}
