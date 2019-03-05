using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BnpTest.Common;
using BnpTest.Models;
using CsvHelper.Configuration;

namespace BnpTest.CsvClassMaps
{

    public sealed class TenorCsvMap : ClassMap<TenorClass>
    {
        public TenorCsvMap()
        {
            SetupMap(new Converter());
        }

        private void SetupMap(Converter converter)
        {
            Map(m => m.Tenor).ConvertUsing(c => converter.ConvertValueToDividedDateString(c.GetField("Tenor"), "Tenor"));
            Map(m => m.Portfolioid).ConvertUsing(c => converter.ConvertValueString(c.GetField("Portfolioid"), "Portfolioid"));
            Map(m => m.Value).ConvertUsing(c => converter.ConvertValueDouble(c.GetField("Value"), "Value"));
        }


    }
}
