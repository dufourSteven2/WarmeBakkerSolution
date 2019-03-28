using System;
using System.Collections.Generic;
using System.Text;

namespace WarmeBakkerLib
{
    public class Category
    {
        public long Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public bool Publication { get; set; }

        //Navigation property
        public virtual ICollection<Product> Products { get; set; }
    }
}
