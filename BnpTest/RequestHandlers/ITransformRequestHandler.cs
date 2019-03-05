using System.Threading.Tasks;

namespace BnpTest.RequestHandlers
{
    public interface ITransformRequestHandler
    {
        Task<bool> HandleRequest(string content,string fileName);
    }
}
