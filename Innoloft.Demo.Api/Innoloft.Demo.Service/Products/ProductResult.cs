using Innoloft.Demo.Core.Entity.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Innoloft.Demo.Service.Products
{
    public class ProductResult : BaseHttpResult
    {
        public ProductResult()
        {
            Errors = new List<string>();
        }
        public Product Product { get; set; }

       
    }
}
