﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SHOP2017.Model
{
    public class ProductCategoryViewModel
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Alias { set; get; }
        public string Description { set; get; }
        public int? ParentID { set; get; }
        public int? DisplayOrder { set; get; }
        public string Image { set; get; }
        public bool? HomeFlag { set; get; }
        //public virtual IEnumerable<ProductViewModel> Products { set; get; }

    }
}
