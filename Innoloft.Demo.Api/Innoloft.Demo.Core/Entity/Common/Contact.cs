using System;
using System.Collections.Generic;
using System.Text;

namespace Innoloft.Demo.Core.Entity.Common
{
    public class Contact : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? LastVisitDate { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
