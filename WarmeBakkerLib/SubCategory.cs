using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace WarmeBakkerLib
{
    public class SubCategory
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Publication { get; set; }

        //Foreign Key
        //public long ProductId { get; set; }
        public long CategoryId { get; set; }

        //Navigation Property
        //public virtual Product Product { get; set; }
        public virtual Category Category { get; set; }

        //Navigation property
        public virtual ICollection<Product> Products { get; set; }
    }
}
