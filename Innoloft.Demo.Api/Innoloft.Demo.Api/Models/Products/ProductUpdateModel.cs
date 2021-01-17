using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Innoloft.Demo.Api.Models.Products
{
    public class ProductUpdateModel
    {
        public int ProductId { get; set; }
        public int ProductTypeId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ContactPersonId { get; set; }
    }
}
