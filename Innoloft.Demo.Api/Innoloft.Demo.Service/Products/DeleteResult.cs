using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Innoloft.Demo.Service.Products
{
    public class DeleteResult
    {
        public DeleteResult()
        {
            Errors = new List<string>();
        }
        public IList<string> Errors { get; set; }
        public bool Success => !Errors.Any();

        public string Message { get; set; }
        public void AddError(Exception e, string error)
        {
            Errors.Add(string.Concat(e.Message, " - ", e.InnerException, " - ", error));
        }
    }
}

