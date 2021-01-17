using AutoMapper;
using Innoloft.Demo.Api.Models.Products;
using Innoloft.Demo.Core.Entity.Common;
using Innoloft.Demo.Core.Entity.Lookup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Innoloft.Demo.Api.Extension
{
    public static class ModelBuildExtension
    {
        public static IEnumerable<ProductResponseModel> BuildProductResponse(this List<Product> products)
        {
            List<ProductResponseModel> responseModels = new List<ProductResponseModel>();
            foreach (var product in products)
            {
                var productModel = new ProductResponseModel()
                {
                    ProductId = product.Id,
                    Title = product.Title,
                    Description = product.Description,
                };

                if (product.User != null)
                {
                    productModel.User = new Models.User.UserModel()
                    {
                        Email = product.User.Email,
                        FirstName = product.User.FirstName,
                        LastName = product.User.LastName,
                        PhoneNumber = product.User.PhoneNumber,
                        BirthDate = product.User.BirthDate
                    };
                }

                if (product.Contact != null)
                {
                    productModel.Contact = new Models.Contact.ContactModel()
                    {
                        ContactPersonId = product.Contact.Id,
                        FirstName = product.Contact.FirstName,
                        LastName = product.Contact.LastName,
                        PhoneNumber = product.Contact.PhoneNumber,
                        FaxNumber = product.Contact.FaxNumber
                    };
                }

                if (product.ProductType != null)
                {
                    productModel.ProductType = new ProductTypeModel()
                    {
                        ProductTypeId = product.ProductType.Id,
                        ProductType = product.ProductType.Type
                    };
                }

                responseModels.Add(productModel);
            }
            return responseModels;
        }

        public static ProductResponseModel BuildProductResponse(this Product product)
        {
            var productModel = new ProductResponseModel()
            {
                ProductId = product.Id,
                Title = product.Title,
                Description = product.Description,
            };

            if (product.User != null)
            {
                productModel.User = new Models.User.UserModel()
                {
                    Email = product.User.Email,
                    FirstName = product.User.FirstName,
                    LastName = product.User.LastName,
                    PhoneNumber = product.User.PhoneNumber,
                    BirthDate = product.User.BirthDate
                };
            }

            if (product.Contact != null)
            {
                productModel.Contact = new Models.Contact.ContactModel()
                {
                    ContactPersonId = product.Contact.Id,
                    FirstName = product.Contact.FirstName,
                    LastName = product.Contact.LastName,
                    PhoneNumber = product.Contact.PhoneNumber,
                    FaxNumber = product.Contact.FaxNumber
                };
            }

            if (product.ProductType != null)
            {
                productModel.ProductType = new ProductTypeModel()
                {
                    ProductTypeId = product.ProductType.Id,
                    ProductType = product.ProductType.Type
                };
            }

            return productModel;
        }

        public static ProductUpdateResponseModel BuildProductUpdateResponse(this Product product)
        {
            var productUpdateModel = new ProductUpdateResponseModel()
            {
                ProductId = product.Id,
                Title = product.Title,
                Description = product.Description,
            };

            return productUpdateModel;
        }

        public static IEnumerable<ProductTypeModel> BuildProductType(this List<ProductType> productTypes)
        {
            List<ProductTypeModel> productTypeModels = new List<ProductTypeModel>();

            foreach (var productType in productTypes)
            {
                var productTypeModel = new ProductTypeModel()
                {
                    ProductTypeId = productType.Id,
                    ProductType = productType.Type
                };
                productTypeModels.Add(productTypeModel);
            }

            return productTypeModels;
        }

        public static ProductTypeModel BuildProductType(this ProductType productType)
        {

            var productTypeModel = new ProductTypeModel()
            {
                ProductTypeId = productType.Id,
                ProductType = productType.Type
            };

            return productTypeModel;
        }

    }
}
