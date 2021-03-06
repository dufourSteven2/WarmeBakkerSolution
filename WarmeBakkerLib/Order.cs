﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WarmeBakkerLib
{
    public class Order
    {
        public long Id { get; set; }

        //Foreign Key
        public int CustomerId { get; set; }

        //Navigation Property
        public virtual ICollection<OrderLine> OrderLines { get; set; }
    }
}
