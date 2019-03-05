using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BnpTest.ContentReaders
{
    public class InputContent<TInputModel> where TInputModel : class, new()
    {
        public InputContent()
        {
            Items = new List<TInputModel>();
        }
        public List<TInputModel> Items { get; set; }
    }
}
