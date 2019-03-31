using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarmeBakkerLib
{
    public class Product
    {
        public long Id { get; set; }

        public string Name { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal Price { get; set; }
        public string Description { get; set; }
        public bool Highlight { get; set; }

        //Foreign Key
        public long SubCategoryId { get; set; }
        //public long CategoryId { get; set; }

        //Navigation Property
        public virtual SubCategory SubCategory { get; set; }
        //public virtual Category Category { get; set; }
    }
}
