using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Innoloft.Demo.Api.Mapper;
using Innoloft.Demo.Data;
using Microsoft.EntityFrameworkCore;

namespace Innoloft.Demo.Test
{
    public class BaseTest
    {
        internal InnoloftDBContext context()
        {
            var options = new DbContextOptionsBuilder<InnoloftDBContext>()
                    .UseLazyLoadingProxies()
                    .UseSqlite("Data Source=Innoloft.db;");
            var context = new InnoloftDBContext(options.Options);
            return context;
        }

        internal static IMapper _mapper;
    }
}
