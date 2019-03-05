using System.Collections.Generic;
using System.Net.Http;

namespace BnpTest.ContentReaders
{
    public interface IOutputContentWriter<in TOutputModel> where TOutputModel : class, new()
    {
        bool WriteToContent(IEnumerable<TOutputModel> data, string fileName);
    }
}
