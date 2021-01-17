using System;
using System.Collections.Generic;
using System.Text;

namespace Innoloft.Demo.Service.Users
{
    public class UserRegistrationRequest
    {
        public UserRegistrationRequest(string firstName, string lastName, string phoneNumber, string email, DateTime? birthDate, string password, string role)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
            BirthDate = birthDate;
            Password = password;
            Role = role;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
