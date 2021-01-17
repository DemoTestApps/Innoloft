using Innoloft.Demo.Api.Models.Contact;
using Innoloft.Demo.Api.Models.User;
using Innoloft.Demo.Core.Entity.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Innoloft.Demo.Api.Models.Products
{
    public class ProductResponseModel
    {
        public int ProductId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public UserModel User { get; set; }
        public ContactModel Contact { get; set; }
        public ProductTypeModel ProductType { get; set; }

    }

    public class ProductUpdateResponseModel
    {
        public int ProductId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
