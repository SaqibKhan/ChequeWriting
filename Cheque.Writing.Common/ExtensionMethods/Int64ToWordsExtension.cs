using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cheque.Writing.Common.ExtensionMethods
{
    public static class Int64ToWordsExtension
    {
        
    /// <summary>
    /// Extension Method used to Convert Int into world
    /// </summary>
    /// <param name="number"></param>
    /// <returns></returns>
        public static string ToWords(this Int64 number)
        {
            var numbertoWords = new NumbersToWords();
            return numbertoWords.IntToWords(number);
        }
    }
}
