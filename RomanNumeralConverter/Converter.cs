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
        public static int Convert(string numeral)
        {
            int conversion = 0;
            int prevNumeral = 0;
            bool isPrevOpValidSummation = false;

            for (int i = 0; i < numeral.Length; i++)
            {
                char c = numeral[i];
                bool isMatch = false;
                int romanValue = 0;

                foreach(var value in Enum.GetValues(typeof(RomanNumeral)))
                {
                    isMatch = c.ToString() == value.ToString();

                    if (isMatch)
                    {
                        romanValue = (int)value;

                        break;
                    }
                }

                if (isMatch)
                {

                    if (prevNumeral >= romanValue || conversion == 0)
                    {
                        conversion += romanValue;
                        isPrevOpValidSummation = prevNumeral != romanValue;
                    }
                    else
                    {
                        if (!isPrevOpValidSummation || (romanValue / prevNumeral != 2 && romanValue / prevNumeral != 10))
                            return 0;
                        else
                            conversion = conversion + (romanValue - prevNumeral * 2);

                        isPrevOpValidSummation = false;
                    }

                    prevNumeral = romanValue;
                }
            }

            return conversion;
        }

        static void Main(string[] args)
        {
            System.Console.WriteLine("\nEnter a Roman Numeral: ");
            
            string romanNumeral = Console.ReadLine();

            System.Console.WriteLine("Conversion is: " + Convert(romanNumeral));

            Console.Read();
        }
    }
}
