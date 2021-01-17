using Innoloft.Demo.Core.Entity.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Innoloft.Demo.Service.Products
{
    public class ProductsResult : BaseHttpResult
    {
        public ProductsResult()
        {
            Errors = new List<string>();
        }
        public List<Product> Products { get; set; }
    }
}
