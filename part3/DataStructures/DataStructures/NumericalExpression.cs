using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Humanizer;
using System.Net;
using System.Text.RegularExpressions;

namespace DataStructures
{
    public class NumericalExpression
    {
        public long Number { get; set; }
        public string Language { get; set; }

        private readonly string[] _ones = {"", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };
        private readonly string[] _teens = {"Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
        private readonly string[] _tens = {"", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
        private readonly string[] _thousands = {"", "Thousand", "Million", "Billion", "Trillion", "Quadrillion", "Quintillion" };

        public NumericalExpression(long number, string language)
        {
            Number = number;
            Language = language;
        }

        private string TranslateText(string input)
        {
            string url = String.Format($"https://translate.googleapis.com/translate_a/single?client=gtx&sl=en&tl={Language}&dt=t&q={input}&ie=UTF8");

            var webRequest = (HttpWebRequest)HttpWebRequest.Create(url);
            webRequest.UserAgent = "Hej";

            var response = webRequest.GetResponse();
            var content = response.GetResponseStream();

            using (var reader = new StreamReader(content))
            {
                string strContent = reader.ReadToEnd();
                return strContent.Split('"')[1].Replace("?", string.Empty);
            }
        }


        public long GetValue() { return Number; }

        public override string ToString()
        {
            //return ConvertNumberToWords1();
            return TranslateText(ConvertNumberToWords2());
        }

        private string ConvertNumberToWords1() 
        {
            return Number.ToWords(new CultureInfo(Language, false));
        }
        private string ConvertNumberToWords2()
        {
            if (Number == 0)
                return "Zero";

            long num = Number;
            string words = " ";

            for (int i = 0; num > 0; i++)
            {
                if (num % 1000 != 0) 
                {
                    string translatedHundred = ConvertHundreds(num % 1000) + _thousands[i] + " ";
                    words = words.Insert(0, translatedHundred);
                }

                num /= 1000;
            }


            return words.Trim().Replace("  ", " ");
        }

        private string ConvertHundreds(long number)
        {
            string words = "";

            if (number >= 100)
            {
                words += _ones[number / 100] + " Hundred ";
                number %= 100;
                //if (number > 0)
                //    words += " and ";
            }

            if (number >= 10 && number <= 19)
            {
                words += _teens[number % 10] + " ";
            }
            else
            {
                words += _tens[number / 10] + " ";
                words += _ones[number % 10] + " ";
            }

            return words;
        }

        public static int SumLetters(int countNumber, string language)
        {
            int amountLetters = 0;

            NumericalExpression numericalExpression = new NumericalExpression(0, language);

            for (int i = 0; i <= countNumber; i++)
            {
                numericalExpression.Number = i;

                string wordsOfNum = numericalExpression.ToString();

                // הורדת ניקוד של אותיות - נגיד ניקוד של עברית או ספרדית וכו
                char[] arr = wordsOfNum.ToCharArray();
                arr = Array.FindAll<char>(arr, (c => (char.IsLetterOrDigit(c)
                                  || char.IsWhiteSpace(c)
                                  || c == '-')));
                wordsOfNum = new string(arr);

                amountLetters += wordsOfNum.Length;
            }

            return amountLetters;
        }

        // הפונקציה מביאה לידי ביטוי את עקרון הפולימורפיזם -רב צורתיות
        public static int SumLetters(NumericalExpression countNumber)
        {
            int amountLetters = 0;

            NumericalExpression numericalExpression = new NumericalExpression(0, countNumber.Language);

            for (int i = 0; i <= countNumber.Number; i++)
            {
                numericalExpression.Number = i;

                string wordsOfNum = numericalExpression.ToString();

                // הורדת ניקוד של אותיות - נגיד ניקוד של עברית או ספרדית וכו
                char[] arr = wordsOfNum.ToCharArray();
                arr = Array.FindAll<char>(arr, (c => (char.IsLetterOrDigit(c)
                                  || char.IsWhiteSpace(c)
                                  || c == '-')));
                wordsOfNum = new string(arr);

                amountLetters += wordsOfNum.Length;
            }

            return amountLetters;
        }
    }
}
