using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Test.Data.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string Number { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public User Owner { get; set; }
    }
}
