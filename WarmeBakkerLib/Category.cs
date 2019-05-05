using System;
using System.Collections.Generic;
using System.Text;

namespace WarmeBakkerLib
{
    public class Category
    {
        public readonly int? id;

        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public bool Publication { get; set; }

        public int? HeadCategoryId { get; set;  }
        public virtual  Category HeadCategory { get; set; }
       

        //Navigation property
        public virtual ICollection<Product> Products { get; set; }

        }
}
