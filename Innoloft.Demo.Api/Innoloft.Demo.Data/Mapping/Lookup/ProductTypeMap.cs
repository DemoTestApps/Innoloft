using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Innoloft.Demo.Core.Entity.Lookup;
using System;
using System.Collections.Generic;
using System.Text;

namespace Innoloft.Demo.Data.Mapping.Lookup
{
    public class ProductTypeMap : IEntityTypeConfiguration<ProductType>
    {
        public void Configure(EntityTypeBuilder<ProductType> builder)
        {
            builder.ToTable("ProductType");
        }
    }
}
