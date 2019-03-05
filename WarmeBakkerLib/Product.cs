using System;
using System.Collections.Generic;
using System.Text;

namespace WarmeBakkerLib
{
    public class Product
    {
        public long Id { get; set; }

        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

        //Foreign Key
        public long CategoryId { get; set; }

        //Navigation Property
        public virtual Category Category { get; set; }
    }
}
