using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheque.Writing.Common
{
    /// <summary>
    /// Number to Words Calls used to Convert Integer into words
    /// </summary>
    public class NumbersToWords
    {
        private Dictionary<Int64, string> WordsForZeroToHundred;
        private Dictionary<Int64, string> WordsForThousandToBillions;
        private StringBuilder builder;

        public NumbersToWords()
        {
            Initialize();  // Initialize the List for Tens and Thousands
            builder = new StringBuilder();
        }
        private void Initialize()
        {
            WordsForZeroToHundred = new Dictionary<Int64, string>
        {
            { 0, "ZERO" },

            { 1, "ONE" },

            { 2, "TWO" },

            { 3, "THREE" },

            { 4, "FOUR" },

            { 5, "FIVE" },

            { 6, "SIX" },

            { 7, "SEVEN" },

            { 8, "EIGHT" },

            { 9, "NINE" },

            { 10, "TEN" },

            { 11, "ELEVEN" },

            { 12, "TWELVE" },

            { 13, "THIRTEEN" },

            { 14, "FOURTEEN" },

            { 15, "FIFTEEN" },

            { 16, "SIXTEEN" },

            { 17, "SEVENTEEN" },

            { 18, "EIGHTEEN" },

            { 19, "NINETEEN" },

            { 20, "TWENTY" },

            { 30, "THIRTY" },

            { 40, "FORTY" },

            { 50, "FIFTY" },

            { 60, "SIXTY" },

            { 70, "SEVENTY" },

            { 80, "EIGHTY" },

            { 90, "NINETY" },

            { 100, "HUNDRED" }
        };

            WordsForThousandToBillions = new Dictionary<Int64, string>
        {
            { 1000000000, "BILLION" },{ 1000000, "MILLION" },{ 1000, "THOUSAND" }
        };
        }
        
        /// <summary>
        /// Public Method 
        /// </summary>
        /// <param name="value">Int64 based value </param>
        /// <returns> String </returns>
        public string IntToWords(Int64 value)
        {
            builder = new StringBuilder();// reset the builder
            if (value == 0)
            {
                builder.Append(WordsForZeroToHundred[value]);
                return builder.ToString();
            }

            foreach (var item in WordsForThousandToBillions)
            {
                value = AppendHighFigureValues(value, item.Key); // check value in list WordsThousandToBillions
            }

            AppendThreeFigureValues(value); // append the last renaming value

            return builder.ToString().Trim();
        }

        /// <summary>
        /// High Figure Value Translator
        /// </summary>
        /// <param name="number">Number</param>
        /// <param name="scaleValue"> Scale value used to calculate scale value in input number  </param>
        /// <returns></returns>
        private Int64 AppendHighFigureValues(Int64 number, Int64 scaleValue)
        {
            if (number > scaleValue - 1) // if value is greater then Scale value 
            {
                var baseScale = (number / scaleValue); // calculate number of scaleValue in Input Number 
                AppendThreeFigureValues(baseScale); // Create words for three and Above figure number 
                builder.AppendFormat("{0} ", WordsForThousandToBillions[scaleValue]);
                number = number - (baseScale * scaleValue);
            }
            return number;
        }

        /// <summary>
        /// Append Three figure value translate the three figure values and return the string
        /// </summary>
        /// <param name="value">value</param>
        /// <returns></returns>
        private Int64 AppendThreeFigureValues(Int64 value)
        {
            value = GetHundreds(value);
            value = GetTens(value);
            GetUnits(value);
            return value;
        }

        /// <summary>
        /// Translate the single digits value into words
        /// </summary>
        /// <param name="value"></param>
        private void GetUnits(Int64 value)
        {
            if (value > 0)
            {
                builder.AppendFormat("{0} ", WordsForZeroToHundred[value]);
            }
        }

        /// <summary>
        /// Translate the 2 digits values into words
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private Int64 GetTens(Int64 value)
        {
            if (value > 20)
            {
                var tensvalue = (value / 10) * 10;
                builder.AppendFormat("{0} ", WordsForZeroToHundred[tensvalue]);
                value = value - tensvalue;
            }
            return value;
        }

        /// <summary>
        /// Translate the 3 digits values into words
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private Int64 GetHundreds(Int64 value)
        {
            if (value > 99)
            {
                var hundredsValue = (value / 100);
                builder.AppendFormat("{0} HUNDRED ", WordsForZeroToHundred[hundredsValue]);
                value = value - (hundredsValue * 100);
            }
            return value;
        }


    }
}
