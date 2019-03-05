using System;
using System.Linq;
using BnpTest.ContentReaders;
using BnpTest.CsvClassMaps;
using BnpTest.Models;
using NUnit.Framework;


namespace BNPTestUnit
{
    [TestFixture]
    class ContentReaderTest
    {

        private IInputContentReader<TenorClass> _contentReader;
        private string testDataFilePath = @"C:\Users\Desktop\BNPTestUnit\testdata.txt";
        [SetUp]
        public void SetUp()
        {
          
            _contentReader = new ContentReader<TenorClass, TenorCsvMap>();
        }

        [Test]
        public void ShouldRetrieveAllTenorRecord()
        {

            var inputContent = _contentReader.ReadContent(testDataFilePath);
            Assert.AreEqual(inputContent.Items.Count, 5);

        }

        [Test]
        public void ShouldRetrieveFirstTenorRecord()
        {
            TenorClass testClass = new TenorClass();
            testClass.Portfolioid = "10";
            testClass.Tenor = "9m";
            testClass.Value = 30;

            var inputContent = _contentReader.ReadContent(testDataFilePath);

            Assert.AreEqual(inputContent.Items.First().Portfolioid.Trim(),testClass.Portfolioid);
            Assert.AreEqual(inputContent.Items.First().Value, testClass.Value);

        }

        [Test]
        public void ShouldRetrieveLastTenorRecord()
        {
            TenorClass testClass = new TenorClass();
            testClass.Portfolioid = "11";
            testClass.Tenor = "2y";
            testClass.Value = 155;

            var inputContent = _contentReader.ReadContent(testDataFilePath);

            Assert.AreEqual(inputContent.Items.Last().Portfolioid.Trim(), testClass.Portfolioid);
            Assert.AreEqual(inputContent.Items.Last().Value, testClass.Value);

        }


    }
}
