using Innoloft.Demo.Core.Entity.Common;
using Innoloft.Demo.Core.Entity.Lookup;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Innoloft.Demo.Service.Products
{
    public interface IProductService
    {
        public List<Product> GetProducts();
        public List<Product> GetProductsByProductType(int productTypeId);
        public List<ProductType> GetProductTypes();
        public Product GetProductById(int productId);

        public ProductsResult InsertProducts(List<Product> products);
        public ProductResult InsertProduct(Product product);
        public ProductResult UpdateProduct(Product product);
        public DeleteResult DeleteProduct(Product product);
    }
}
