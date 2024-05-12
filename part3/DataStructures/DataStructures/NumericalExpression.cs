using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Humanizer;

namespace DataStructures
{
    public class NumericalExpression
    {
        private int _number;

        //private string[] _multiplier = [ "", "Thousand", "Million", "Billion"];

        //private string[] _firstTwenty = ["", "One", "Two", "Three",
        //   "Four", "Five", "Six", "Seven",
        //   "Eight", "Nine", "Ten", "Eleven",
        //   "Twelve", "Thirteen", "Fourteen", "Fifteen",
        //   "Sixteen", "Seventeen", "Eighteen", "Nineteen" ];

        //private string[] _tens = [ "", "", "Twenty",  "Thirty", "Forty", "Fifty",
        //    "Sixty", "Seventy", "Eighty", "Ninety" ];

        public NumericalExpression(int number)
        {
            _number = number;
        }

        public override string ToString()
        {
            return _number.ToWords(new CultureInfo("en-GB", false));
        }

        public int GetValue() { return _number; }

        //public int SumLetters(int num) { }



        //public string Translater()
        //{
        //    string translatedNumber = "";
        //    string[] partedNumbers;
        //    if (_number.ToString().Length < 3)
        //        partedNumbers = [_number.ToString()];
        //    else
        //    {
        //        partedNumbers = _number.ToString().Where((x, i) => i % 3 == 0).Select((x, i) => new string(_number.ToString()
        //         .Skip(i * 3)
        //         .Take(3)
        //         .ToArray()))
        //         .ToArray();
        //    }

        //    for (int i = 0; i < partedNumbers.Length; i++)
        //    {
        //        int currentNumber = int.Parse(partedNumbers[i]);
        //        int hundreds = currentNumber / 100;
        //        int tens = (currentNumber / 10) % 10;
        //        int units = currentNumber % 10;

        //        if (hundreds > 0)
        //            translatedNumber += $"{_firstTwenty[hundreds]} Hundred ";

        //        if (tens > 0 && tens < 2)
        //            translatedNumber += $"{_firstTwenty[hundreds]} ";
        //        else if (tens > 0 && tens >= 2)
        //        {
        //            translatedNumber += _tens[tens] + " ";
        //            translatedNumber += $"{_firstTwenty[units]} ";
        //        }
        //        else if (units > 0)
        //            translatedNumber += $"{_firstTwenty[units]} ";

        //    }

        //    return translatedNumber;
        //}
    }
}
