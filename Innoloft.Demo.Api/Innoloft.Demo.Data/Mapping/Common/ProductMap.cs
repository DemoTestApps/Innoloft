using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Innoloft.Demo.Core.Entity.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Innoloft.Demo.Data.Mapping.Common
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");
        }
    }
}
