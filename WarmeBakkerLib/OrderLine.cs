using System;
using System.Collections.Generic;
using System.Text;

namespace WarmeBakkerLib
{
    public class OrderLine
    {
        public long Id { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        ////Foreign Key
        public long ProductId { get; set; }
        public long OrderId { get; set; }

        //Navigation Property
        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }
    }
}
