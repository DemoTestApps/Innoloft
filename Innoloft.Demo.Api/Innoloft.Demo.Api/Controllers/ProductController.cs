using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Innoloft.Demo.Api.Models;
using Innoloft.Demo.Core.Entity.Common;
using Innoloft.Demo.Core.Entity.Lookup;
using Innoloft.Demo.Data;
using Innoloft.Demo.Service;
using Innoloft.Demo.Service.Authentication;
using Microsoft.AspNetCore.Identity;
using Innoloft.Demo.Core.Entity.Identity;
using Innoloft.Demo.Service.Products;
using Innoloft.Demo.Api.Models.Products;
using Innoloft.Demo.Api.Extension;
using AutoMapper;
using Innoloft.Demo.Api.Mapper;

namespace Innoloft.Demo.Api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMapper _mapper;
        private IProductService _productService;
        public ProductController(IMapper mapper, InnoloftDBContext context)
        {
            _mapper = mapper;
            _productService = new ProductService(context);
        }

        [HttpPost]
        [Route("Add")]
        public IActionResult AddProduct(ProductRequestModel model)
        {
            if (ModelState.IsValid)
            {
                long userId;
                try
                {
                    userId = Convert.ToInt64(User.Identities
                        .First().Claims
                        .Where(x => x.Type.ToLower().Equals("id")).First().Value);
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("Error", e.Message);
                    return BadRequest(ModelState);
                }
                var product = new Product()
                {
                    OwnerId = userId,
                    ProductTypeId = model.ProductTypeId,
                    Title = model.Title,
                    Description = model.Description,
                    ContactPersonId = model.ContactPersonId

                };
                var response = _productService.InsertProduct(product);
                if (response.Success)
                {
                    //return Ok(response.Product.BuildProductUpdateResponse());
                    return Ok(_mapper
                        .Map<Product, ProductUpdateResponseModel>(response.Product));
                }

                foreach (var e in response.Errors)
                {
                    ModelState.AddModelError("Error", e);
                }
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        [Route("Edit")]
        public IActionResult EditProduct(ProductUpdateModel model)
        {
            if (ModelState.IsValid)
            {
                long userId;
                try
                {
                    userId = Convert.ToInt64(User.Identities
                        .First().Claims
                        .Where(x => x.Type.ToLower().Equals("id")).First().Value);
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("Error", e.Message);
                    return BadRequest(ModelState);
                }
                var product = new Product()
                {
                    Id = model.ProductId,
                    OwnerId = userId,
                    ProductTypeId = model.ProductTypeId,
                    Title = model.Title,
                    Description = model.Description,
                    ContactPersonId = model.ContactPersonId

                };
                var response = _productService.UpdateProduct(product);
                if (response.Success)
                    //return Ok(response.Product.BuildProductUpdateResponse());
                    return Ok(_mapper
                        .Map<Product, ProductUpdateResponseModel>(response.Product));

                foreach (var e in response.Errors)
                {
                    ModelState.AddModelError(string.Empty, e);
                }
            }
            return BadRequest(ModelState);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null)
            {
                ModelState.AddModelError("Error", "Product not found");
                return BadRequest(ModelState);
            }
            var response = _productService.DeleteProduct(product);
            if (response.Success)
                return Ok(response);

            foreach (var e in response.Errors)
            {
                ModelState.AddModelError("Error", e);
            }

            return BadRequest(ModelState);
        }

        [HttpGet]
        [Route("ProductByType/{typeId}")]
        public List<ProductResponseModel> GetProductByTypeId(int TypeId)
        {
            var response = _productService.GetProductsByProductType(TypeId);

            if (response != null && response.Count > 0)
            {
                //return response.BuildProductResponse().ToList();
                var responseModel = _mapper.Map<List<Product>, List<ProductResponseModel>>(response);
                return responseModel;
            }

            return null;
        }

        [HttpGet]
        [Route("Products")]
        public List<ProductResponseModel> GetProducts()
        {
            var model = new List<ProductResponseModel>();
            var response = _productService.GetProducts();

            if (response != null && response.Count > 0)
            {
                //model = response.BuildProductResponse().ToList();
                //return model;
                var responseModel = _mapper.Map<List<Product>, List<ProductResponseModel>>(response);
                return responseModel;
            }

            return null;
        }

        [HttpGet]
        [Route("{id}")]
        public ProductResponseModel GetProductById(int id)
        {
            var response = _productService.GetProductById(id);

            if (response != null)
            {
                //model = response.BuildProductResponse();
                //return model;
                var responseModel = _mapper.Map<Product, ProductResponseModel>(response);
                return responseModel;
            }
            return null;
        }

        [HttpGet]
        [Route("Types")]
        public List<ProductTypeModel> GetTypes()
        {
            var response = _productService.GetProductTypes();

            List<ProductTypeModel> types = new List<ProductTypeModel>();
            if (response != null && response.Count > 0)
            {
                //types = response.BuildProductType().ToList();
                //return types;
                var responseModel = _mapper.Map<List<ProductType>, List<ProductTypeModel>>(response);
                return responseModel;
            }
            return null;
        }
    }
}
