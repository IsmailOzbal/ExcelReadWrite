using System.Linq;
using BnpTest.ContentReaders;
using BnpTest.ContentWriter;
using BnpTest.CsvClassMaps;
using BnpTest.Models;
using System.Threading.Tasks;
using BnpTest.Validation.Exceptions;

namespace BnpTest.RequestHandlers
{

    public class TenorRequestHandler : TransformRequestHandler<TenorClass, TenorClass>
    {
        private readonly IInputContentReader<TenorClass> _inputReader;
        private readonly IOutputContentWriter<TenorClass> _outputWriter;
       
        public TenorRequestHandler(IOutputContentWriter<TenorClass> outputWriter, IInputContentReader<TenorClass> inputReader)
            : base(new ContentReader<TenorClass, TenorCsvMap>(),
                new CsvContentWriter<TenorClass>()
               )
        {
            _outputWriter = outputWriter;
            _inputReader = inputReader;
        }

        public TenorRequestHandler() : base(new ContentReader<TenorClass, TenorCsvMap>(),
        new CsvContentWriter<TenorClass>())
        {
            
        }
        public async override Task<bool> HandleRequest(string content, string fileName)
        {
            bool result = false;

            var inputContent = await ReadInputContent(content);


            //Output the data sorted by Tenor and PortfolioID.
            var orderPortfolioIDandTenorInputContent = inputContent.Items.OrderBy(a => a.Tenor).ThenBy(a => a.Portfolioid).ToList();

            result = _outputWriter.WriteToContent(orderPortfolioIDandTenorInputContent, "3.txt");

            //Output the data sorted by PortfolioID and Tenor
            var orderTenorandPortfolioIdInputContent = inputContent.Items.OrderBy(a => a.Portfolioid).ThenBy(a => a.Tenor).ToList();

            result = _outputWriter.WriteToContent(orderTenorandPortfolioIdInputContent, "4.txt");

            return result;
        }

        private async Task<InputContent<TenorClass>> ReadInputContent(string Content)
        {
            InputContent<TenorClass> inputContent;

            if (Content == null || Content.Length <= 0)
            {
                throw new BadRequestException("400", "An input file must be supplied");
            }

            inputContent = _inputReader.ReadContent(Content);

            return inputContent;
        }
    }
}
