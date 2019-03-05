using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BnpTest.ContentReaders;
using BnpTest.Models;
using BnpTest.Validation.Exceptions;

namespace BnpTest.RequestHandlers
{
    public abstract class TransformRequestHandler<TInputModel, TOutputModel> : ITransformRequestHandler
     where TInputModel : class, new() where TOutputModel : class, new()
    {
        private readonly IInputContentReader<TInputModel> _inputReader;
        private readonly IOutputContentWriter<TOutputModel> _outputWriter;

        protected TransformRequestHandler(IInputContentReader<TInputModel> inputReader,
            IOutputContentWriter<TOutputModel> outputWriter)
        {
            _inputReader = inputReader;
            _outputWriter = outputWriter;

        }

        public async virtual Task<bool> HandleRequest(string content, string fileName)
        {

            var inputContent = await ReadInputContent(content);

            var result = _outputWriter.WriteToContent(Map(inputContent.Items), fileName);

            return result;
        }



        protected virtual IEnumerable<TOutputModel> Map(IEnumerable<TInputModel> inputItems)
        {
            return inputItems.Cast<TOutputModel>();
        }

        private async Task<InputContent<TInputModel>> ReadInputContent(string Content)
        {
            InputContent<TInputModel> inputContent;

            if (Content == null || Content.Length <= 0)
            {
                throw new BadRequestException("400", "An input file must be supplied");
            }

            inputContent = _inputReader.ReadContent(Content);

            return inputContent;
        }



    }
}
