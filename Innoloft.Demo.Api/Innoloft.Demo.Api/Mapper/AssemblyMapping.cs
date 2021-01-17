using AutoMapper;
using Innoloft.Demo.Api.Models.Contact;
using Innoloft.Demo.Api.Models.Products;
using Innoloft.Demo.Api.Models.User;
using Innoloft.Demo.Core.Entity.Common;
using Innoloft.Demo.Core.Entity.Identity;
using Innoloft.Demo.Core.Entity.Lookup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Innoloft.Demo.Api.Mapper
{
    public class AssemblyMapping : Profile
    {
        public AssemblyMapping()
        {
            CreateMap<Product, ProductUpdateResponseModel>()
               .ForMember(dest => dest.ProductId,
               opts => opts.MapFrom(src => src.Id));

            CreateMap<ProductType, ProductTypeModel>()
               .ForMember(dest => dest.ProductTypeId,
               opts => opts.MapFrom(src => src.Id))
               .ForMember(dest => dest.ProductType,
               opts => opts.MapFrom(src => src.Type));

            CreateMap<User, UserModel>();

            CreateMap<Contact, ContactModel>()
                .ForMember(dest => dest.ContactPersonId,
                opts => opts.MapFrom(src => src.Id));

            CreateMap<Product, ProductResponseModel>()
                .ForMember(dest => dest.ProductId,
                opts => opts.MapFrom(src => src.Id));
        }
    }
}
