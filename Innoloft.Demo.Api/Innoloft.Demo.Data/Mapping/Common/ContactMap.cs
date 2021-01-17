using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Innoloft.Demo.Core.Entity.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Innoloft.Demo.Data.Mapping.Common
{
    public class ContactMap : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.ToTable("Contact");
        }
    }
}
