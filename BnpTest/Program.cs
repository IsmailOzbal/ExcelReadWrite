using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BnpTest.ContentReaders;
using BnpTest.ContentWriter;
using BnpTest.CsvClassMaps;
using BnpTest.Models;
using BnpTest.RequestHandlers;

namespace BnpTest
{
    class Program
    {
        static  void Main(string[] args)
        {
            //Get File 
            var   fileUrl = ConfigurationSettings.AppSettings["inputFileUrl"];
            var transformResult =
                    new TenorRequestHandler(new CsvContentWriter<TenorClass>(),new ContentReader<TenorClass,TenorCsvMap>()).HandleRequest(fileUrl,"");
           
            
        }
      
    }
}
