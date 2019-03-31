﻿using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WarmeBakkerLib
{
    public class Category
    {
        public long Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public bool Publication { get; set; }

        //Foreign Key
        //public int ProductId { get; set; }
        //public int SubCategoryId { get; set; }

        //Navigation property
        public virtual ICollection<SubCategory> SubCategories { get; set; }
    }
}
