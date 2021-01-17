using Innoloft.Demo.Core.Entity.Identity;
using Innoloft.Demo.Core.Entity.Lookup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Innoloft.Demo.Core.Entity.Common
{
    public class Product : BaseEntity
    {
        [ForeignKey("ProductType")]
        public int ProductTypeId { get; set; }

        [ForeignKey("User")]
        public long OwnerId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        [ForeignKey("Contact")]
        public int ContactPersonId { get; set; }

        public virtual ProductType ProductType { get; set; }
        public virtual User User { get; set; }
        public virtual Contact Contact { get; set; }

    }
}
