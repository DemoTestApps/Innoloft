using AutoMapper;
using Innoloft.Demo.Api.Controllers;
using Innoloft.Demo.Api.Mapper;
using Innoloft.Demo.Api.Models.Products;
using Innoloft.Demo.Data;
using Innoloft.Demo.Service.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace Innoloft.Demo.Test
{
    public class UnitTestProduct
    {
        public class TestProduct
        {
            InnoloftDBContext context()
            {
                var options = new DbContextOptionsBuilder<InnoloftDBContext>()
                        .UseLazyLoadingProxies()
                        .UseSqlServer("Data Source=localhost\\SQLEXPRESS;Initial Catalog=InnoloftDB;Trusted_Connection=True;");
                var context = new InnoloftDBContext(options.Options);
                return context ;
            }

            private static IMapper _mapper;

            public IMapper AutomapperASPNETCoreTests()
            {
                if (_mapper == null)
                {
                    var mappingConfig = new MapperConfiguration(mc =>
                    {
                        mc.AddProfile(new AssemblyMapping());
                    });
                    IMapper mapper = mappingConfig.CreateMapper();
                    _mapper = mapper;
                }
                return _mapper;

            }

            [Fact]
            public void Get_WhenCalled_ReturnsAllProducts()
            {
                IMapper _mapper = AutomapperASPNETCoreTests();
                var contextval = context();
                var controller = new ProductController(_mapper, contextval);
                var okResult = controller.GetProducts();
                // Assert
                var products = Assert.IsType<List<ProductResponseModel>>(okResult);
                Assert.Equal(3, products.Count);
            }

            [Fact]
            public void GetById_ReturnsOkResult()
            {
                var testProductId = 1;
                IMapper _mapper = AutomapperASPNETCoreTests();
                var contextval = context();
                var controller = new ProductController(_mapper, contextval);
                // Act
                var okResult = controller.GetProductById(testProductId);
                // Assert
                Assert.IsType<ProductResponseModel>(okResult);
            }

            [Fact]
            public void Remove_NotExistingProductIDPassed_ReturnsNotFoundResponse()
            {

                var notExistingId = 9;
                var contextval = context();
                IMapper _mapper = AutomapperASPNETCoreTests();
                var _controller = new ProductController(_mapper, contextval);
                // Act
                var badResponse = _controller.DeleteProduct(notExistingId);
                // Assert
                Assert.IsType<NotFoundResult>(badResponse);
            }

            [Fact]
            public void Remove_ExistingProductIDPassed_ReturnsOkResult()
            {
                // Arrange
                var existingId = 3;
                var contextval = context();
                IMapper _mapper = AutomapperASPNETCoreTests();
                var _controller = new ProductController(_mapper, contextval);
                // Act
                var okResponse = _controller.DeleteProduct(existingId);
                // Assert
                DeleteResult value = ((DeleteResult)((ObjectResult)okResponse).Value);
                Assert.True(value.Success);
            }

        }
    }
}
