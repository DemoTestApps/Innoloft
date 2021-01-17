using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Innoloft.Demo.Api.Models.Contact
{
    public class ContactModel
    {
        public int ContactPersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
    }
}
