using Cheque.Writing.App.Business.Interfaces;
using Cheque.Writing.Common;
using Cheque.Writing.Common.ExtensionMethods;
using Cheque.Writing.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cheque.Writing.App.Business.Components
{
    public class ChecqueTranslatorComponent : ICheckqueTranslator
    {
        /// <summary>
        /// Translate the account holder Cheque intoWords
        /// </summary>
        /// <param name="name">Name of account holder</param>
        /// <param name="number">Amount enter in digits (decimal allowed) </param>
        /// <returns></returns>
        public ChecqueResult TranslateChequeToWords(string name, decimal number)
        {
            string[] digits = number.ToString(System.Globalization.CultureInfo.CreateSpecificCulture("en-GB")).Split('.'); // split decimal number 
            var intRightDigits = Convert.ToInt64(digits[0]);
            var dollars = Convert.ToInt64(intRightDigits);
            var intLeftDigits = Math.Abs(Convert.ToInt64((number - dollars) * 100)); // in case of negative value return abs for decimal points

            StringBuilder builder = new StringBuilder();
            if (intRightDigits < 0)
            {
                builder.Append($"MINUS {System.Math.Abs(intRightDigits).ToWords()} DOLLER(S) AND {intLeftDigits.ToWords()} CENTS");
            }
            else
            {
                builder.Append($"{intRightDigits.ToWords()} DOLLER(S) AND {intLeftDigits.ToWords()} CENTS");
            }

            var checkResult = new ChecqueResult()
            {
                Name = name,
                AmountInWords = builder.ToString()
            };
            return checkResult;
        }

    }
}
