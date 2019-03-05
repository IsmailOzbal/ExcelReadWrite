using System;
using System.Collections.Generic;
using System.Linq;


namespace BnpTest.Common
{
    public class Converter
    {
        private readonly Dictionary<char, string> _singleDatedict = new Dictionary<char, string>()
        {
            {'d',"day" },
            {'y', "year"},
            {'w', "week" },
            {'m', "month" }
        };

        private readonly Dictionary<char, string> _pluralDatedict = new Dictionary<char, string>()
        {
            {'d',"days" },
            {'y', "years"},
            {'w', "weeks" },
            {'m', "months" }
        };

        private readonly char[] _datepart = { 'y', 'd', 'm', 'w' };
        public Converter()
        {

        }

        public string ConvertValueToDividedDateString(object value, string valueName)
        {
            if (string.IsNullOrWhiteSpace(value?.ToString()))
            {
                return null;
            }

            string val = value.ToString().Trim();
            string returnValue = "";
            try
            {
                int order = 1;
                int containsCharacterValue = GetContainsDatePart(val);
                for (int i = 0; i < val.Length; i += 2)
                {
                    //plural date part string or single date part string
                    string partName = Int32.Parse(val[i].ToString()) > 1 ? _pluralDatedict[val[i + 1]] : _singleDatedict[val[i + 1]];

                    returnValue += val[i] + " " + partName + GetSeperateName(order, containsCharacterValue);
                    order++;
                }

                return returnValue.TrimEnd();
            }
            catch (Exception)
            {
                return "";
            }
        }

        public double? ConvertValueDouble(object value, string valueName)
        {
            if (string.IsNullOrWhiteSpace(value?.ToString()))
            {
                return null;
            }

            string val = value.ToString().Trim();
            try
            {
                return double.Parse(val);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string ConvertValueString(object value, string valueName)
        {
            if (string.IsNullOrWhiteSpace(value?.ToString()))
            {
                return null;
            }

            return value.ToString().Trim();

        }


        public int GetContainsDatePart(object value)
        {

            //how many date part of character inside tenor value(year month week day ) 
            int count = 0;

            foreach (var item in _datepart)
            {
                count += value.ToString().Count(x => x == item);
            }
            return count;
        }


        public string GetSeperateName(int order, int sumOrder)
        {
            //I can write seperate string comma or and
            if (sumOrder - order == 1)
            {
                return " and ";
            }
            else if (sumOrder - order > 1)
            {
                return ", ";
            }
            else
            {
                return "";
            }

        }
    }
}
