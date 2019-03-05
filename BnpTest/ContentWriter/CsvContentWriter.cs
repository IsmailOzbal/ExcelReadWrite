using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using BnpTest.ContentReaders;
using BnpTest.Models;

namespace BnpTest.ContentWriter
{


    public class CsvContentWriter<TOutputModel> : IOutputContentWriter<TOutputModel>
        where TOutputModel : class, new()
    {
      
        public bool WriteToContent(IEnumerable<TOutputModel> data, string fileName)
        {
            string docPath = ConfigurationSettings.AppSettings["fileLocationUrl"] + fileName + ".txt";

            using (StreamWriter writer = new StreamWriter(docPath, false))
            {
                writer.WriteLine("Tenor, PortfolioID,  Value");
                foreach (var row in data.Cast<TenorClass>() )
                {
                    writer.WriteLine(row.Tenor +" , "+ row.Portfolioid+" ,"+ row.Value);
                }
            }

            return true;
        }

    }
}

