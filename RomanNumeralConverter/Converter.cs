using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumeralConverter
{
    enum RomanNumeral
    {
        I = 1,
        V = 5,
        X = 10,
        L = 50,
        C = 100,
        D = 500,
        M = 1000
    }

    public static class Converter
    {
        public static int ConvertRomanNumeralToInteger(string input)
        {
            int conversionSum = 0;
            int prevValue = 0;
            bool isPrevOpValidSummation = false;
            string romanNumeral = input.ToUpper();

            for (int i = 0; i < romanNumeral.Length; i++)
            {
                string romanChar = romanNumeral[i].ToString();
                bool isMatch = false;
                int romanValue = 0;

                foreach(var value in Enum.GetValues(typeof(RomanNumeral)))
                {
                    isMatch = romanChar == value.ToString();

                    if (isMatch)
                    {
                        romanValue = (int)value;

                        break;
                    }
                }

                if (isMatch)
                {
                    if (prevValue >= romanValue || conversionSum == 0)
                    {
                        conversionSum += romanValue;
                        isPrevOpValidSummation = prevValue != romanValue;
                    }
                    else
                    {
                        if (!isPrevOpValidSummation || (romanValue / prevValue != 2 && romanValue / prevValue != 10))
                            return 0; //Value is not a valid Roman romanNumeral
                        else
                            conversionSum = conversionSum + (romanValue - prevValue * 2);

                        isPrevOpValidSummation = false;
                    }

                    prevValue = romanValue;
                }
                else
                    return 0; //Value is not a valid Roman romanNumeral
            }

            return conversionSum;
        }

        static void Main(string[] args)
        {
            System.Console.WriteLine("\nEnter a Roman Numeral: ");
            
            string romanNumeral = Console.ReadLine();

            System.Console.WriteLine("conversionSum is: " + ConvertRomanNumeralToInteger(romanNumeral.ToUpper()));

            Console.Read();
        }
    }
}
