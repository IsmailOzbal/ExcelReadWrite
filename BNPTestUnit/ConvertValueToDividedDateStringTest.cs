using BnpTest.Common;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BNPTestUnit
{
    [TestFixture]
    class ConvertValueToDividedDateStringTest
    {
        private Converter _converter;

        [SetUp]
        public void SetUp()
        {
            _converter = new Converter();
        }

        [Test]
        public void ShouldReturn_3weeks()
        {
            object value = "3w";
            string retVal = _converter.ConvertValueToDividedDateString(value, "Tenor");
            Assert.AreEqual(retVal, "3 weeks");
        }

        [Test]
        public void ShouldReturn_1day_and_3months()
        {
            object value = "1d3m";
            string retVal = _converter.ConvertValueToDividedDateString(value, "Tenor");
            Assert.AreEqual(retVal, "1 day and 3 months");
        }


        [Test]
        public void ShouldReturn_4years_1day_and_3months()
        {
            object value = "4y1d3m";
            string retVal = _converter.ConvertValueToDividedDateString(value, "Tenor");
            Assert.AreEqual(retVal, "4 years, 1 day and 3 months");
        }
    }
}
