using Innoloft.Demo.Core.Entity.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Innoloft.Demo.Core.Entity.Lookup
{
    public class ProductType : BaseEntity
    {
        [StringLength(10)]
        public string Type { get; set; }
               
        public virtual ICollection<Product> Products { get; set; }
    }
}
