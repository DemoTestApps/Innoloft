using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Innoloft.Demo.Service.Products
{
    public class BaseHttpResult
    {
        public IList<string> Errors { get; set; }

        public bool Success => !Errors.Any();

        public void AddError(Exception e, string error)
        {
            Errors.Add(string.Concat(e.Message, " - ", e.InnerException, " - ", error));
        }
    }
}
