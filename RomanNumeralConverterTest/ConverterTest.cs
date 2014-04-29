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
        [Test]
        [TestCase("III", 3)]
        [TestCase("VII", 7)]
        [TestCase("CLX", 160)]
        [TestCase("MMCCII", 2202)]
        [TestCase("LXIII", 63)]
        [TestCase("IM", 0)]
        [TestCase("IIX", 0)]
        [TestCase("XCIX", 99)]
        [TestCase("IC", 0)]
        [TestCase("IM", 0)]
        [TestCase("MIM", 0)]
        public void Converter_Successfully_Converts(string romanNumeral, int expectedConversion)
        {
            //Arrange
            //Act
            int conversion = Converter.Convert(romanNumeral);

            //Assert
            Assert.AreEqual(expectedConversion, conversion);
        }
    }
}
