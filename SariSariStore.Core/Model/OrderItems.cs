using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SariSariStore.Core.Model
{
    [Table("tbl_OrderDetails")]
    public class OrderItems
    {
        [Key]
        public int OrderDetailID { get; set; }
        public int OrderID { get; set; }
        [NotMapped]
        public string? ProductName { get; set; }
        public int ProductID { get; set; }

        private int _quantity;
        public int Quantity
        {
            get => _quantity;
            set
            {
                _quantity = value;
                CalculateTotalPrice();
            }
        }

        private decimal _unitPrice;
        public decimal UnitPrice
        {
            get => _unitPrice;
            set
            {
                _unitPrice = value;
                CalculateTotalPrice();
            }
        }

        private decimal _totalPrice;
        public decimal TotalPrice
        {
            get => _totalPrice;
            set => _totalPrice = value;
        }

        public void CalculateTotalPrice()
        {
            _totalPrice = Quantity * UnitPrice;
        }

        public OrderItems()
        {
            _quantity = 0;
            _unitPrice = 0;
            _totalPrice = 0;
        }

    }


}
