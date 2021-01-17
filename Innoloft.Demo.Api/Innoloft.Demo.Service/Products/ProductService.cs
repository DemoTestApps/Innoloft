using Innoloft.Demo.Core;
using Innoloft.Demo.Core.Entity.Common;
using Innoloft.Demo.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Innoloft.Demo.Core.Entity.Lookup;
using System.Threading.Tasks;

namespace Innoloft.Demo.Service.Products
{
    public class ProductService : IProductService
    {
        private IRepository<Product> _productRepository;
        private IRepository<ProductType> _productTypeRepository;

        public ProductService(InnoloftDBContext context)
        {
            _productRepository = new EFRepository<Product>(context);
            _productTypeRepository = new EFRepository<ProductType>(context);

        }

        //public CodeType GetTypeById(int id)
        //{
        //    return _typeRepository.GetById(id);
        //}
        public List<Product> GetProducts()
        {
            return _productRepository.Table.ToList();
        }

        public Product GetProductById(int productId)
        {
            return _productRepository.GetById(productId);
        }

        public List<Product> GetProductsByProductType(int productTypeId)
        {
            List<Product> products = new List<Product>();

            return _productRepository.Table.Where(x => x.ProductTypeId == productTypeId)
                 .ToList();
        }

        public List<ProductType> GetProductTypes()
        {
            return _productTypeRepository.Table.ToList();
        }

        public ProductsResult InsertProducts(List<Product> products)
        {
            var result = new ProductsResult();
            try
            {
                _productRepository.Insert(products);
            }
            catch (Exception ex)
            {
                result.AddError(ex, "Bulk insertion failed");
            }
            result.Products.AddRange(products);

            return result;
        }

        public ProductResult InsertProduct(Product product)
        {
            var result = new ProductResult();
            try
            {
                _productRepository.Insert(product);
            }

            catch (Exception ex)
            {
                result.AddError(ex, "Product insert failed");
            }
            result.Product = product;

            return result;
        }

        public ProductResult UpdateProduct(Product product)
        {
            var result = new ProductResult();
            try
            {
                _productRepository.Update(product);
            }
            catch (Exception ex)
            {
                result.AddError(ex, "Product update failed");
            }
            result.Product = product;

            return result;
        }

        public DeleteResult DeleteProduct(Product product)
        {
            var result = new DeleteResult();
            try
            {
                _productRepository.Delete(product);
                result.Message = $"Product - {product.Title} is deleted successfully";
            }
            catch (Exception ex)
            {
                result.AddError(ex, "Product delete failed");
            }
            return result;
        }
    }
}
