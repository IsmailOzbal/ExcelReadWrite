using CsvHelper.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CsvHelper;

namespace BnpTest.ContentReaders
{
    public class ContentReader<TInputModel, TCsvClassMap> : IInputContentReader<TInputModel>
        where TInputModel : class, new()
        where TCsvClassMap : ClassMap<TInputModel>, new()
    {

        public InputContent<TInputModel> ReadContent(string filepatch)
        {
            List<TInputModel> items;
            using (var reader = new StreamReader(filepatch))
            using (var csv = new CsvReader(reader, CsvConfiguration))
            {
                items = csv.GetRecords<TInputModel>().ToList();
            }
            return new InputContent<TInputModel> { Items = items };
        }

        protected virtual Configuration CsvConfiguration
        {
            get
            {
                var csvConfig = new Configuration { Encoding = Encoding.UTF8 };
                var classMap = new TCsvClassMap();
                csvConfig.RegisterClassMap(classMap);

                return csvConfig;
            }
        }
    }
}
