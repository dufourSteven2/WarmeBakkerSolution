using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WarmeBakkerLib
{
    public class Product
    {
        public long Id { get; set; }

        public string Name { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal Price { get; set; }
        public string Description { get; set; }

        //Foreign Key
        public long CategoryId { get; set; }

        //Navigation Property
        public virtual Category Category { get; set; }
    }
}
