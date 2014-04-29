using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Rhino.Mocks;
using RomanNumeralConverter;

namespace RomanNumeralConverterTest
{
    [TestFixture]
    public class ConverterTest
    {
        private Converter converter;

        [SetUp]
        public void Setup()
        {
            converter = new Converter();
        }

        [Test]
        public void Converter_Instantiates()
        {
            converter.Convert();
        }

        [TearDown]
        public void TearDown()
        { 
            //TODO: Teardown
        }
    }
}
