using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BnpTest.ContentReaders
{
    public interface IInputContentReader<TInputModel> where TInputModel : class, new()
    {
        InputContent<TInputModel> ReadContent(string inputStream);
    }
}
