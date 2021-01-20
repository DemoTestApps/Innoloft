using Innoloft.Demo.Core;
using Innoloft.Demo.Core.Entity.Common;
using Innoloft.Demo.Core.Entity.Lookup;
using Innoloft.Demo.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Innoloft.Demo.Service.Seed
{
    public class SeedService : ISeedService
    {
        private InnoloftDBContext _context;
        private IRepository<ProductType> _productTypeRepository;
        private IRepository<Contact> _contactRepository;

        public SeedService(InnoloftDBContext context)
        {
            _context = context;
            _productTypeRepository = new EFRepository<ProductType>(context);
            _contactRepository = new EFRepository<Contact>(context);
        }

        private void InstallProductType()
        {
            _context.ExecuteSqlRaw("DELETE FROM [Product]");
            _context.ExecuteSqlRaw("DELETE FROM [ProductType]");

            using (var transaction = _context.Database.BeginTransaction())
            {
                var ProducTypes = new List<ProductType>()
                {
                    new ProductType()
                    {
                        Type="Hardware"
                    },
                    new ProductType()
                    {
                        Type="Software"
                    }
                };
                _productTypeRepository.Insert(ProducTypes);
                transaction.Commit();
            }
        }

        private void InstallContact()
        {
            _context.ExecuteSqlRaw("DELETE FROM [Product]");
            _context.ExecuteSqlRaw("DELETE FROM [Contact]");

            using (var transaction = _context.Database.BeginTransaction())
            {
                var contacts = new List<Contact>()
                {
                    new Contact()
                    {
                        FirstName="Aksh",
                        LastName="Sharma",
                        PhoneNumber="9087445443",
                        FaxNumber="099123",
                        CreatedDate=DateTime.Now
                    },
                    new Contact()
                    {
                        FirstName="Rakesh",
                        LastName="Verma",
                        PhoneNumber="9087423143",
                        FaxNumber="077123",
                        CreatedDate=DateTime.Now
                    }
                };
                _contactRepository.Insert(contacts);
                transaction.Commit();
            }
        }
        public void Install()
        {
            InstallProductType();
            InstallContact();
        }
    }
}
