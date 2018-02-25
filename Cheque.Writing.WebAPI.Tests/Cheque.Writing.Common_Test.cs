using Cheque.Writing.Common;
using NUnit.Framework;
using System.Net;

namespace Cheque.Writing.WebAPI.Tests
{
    [TestFixture]
    public class Cheque
    {
        private NumbersToWords _numbersToWords;

        [SetUp]
        public void SetUp()
        {
            _numbersToWords = new NumbersToWords();
        }

        [TestCase]
        public void Call_NumbersToWords_WithIntergerParamter_ShouldResutrnCorrentStringValue()
        {

            //ACT
            var result = _numbersToWords.IntToWords(50263);

           // Assert  
           Assert.AreEqual("FIFTY THOUSAND TWO HUNDRED SIXTY THREE", result);

        }

        [TestCase]
        public void Call_NumbersToWords_WithZeroValue_ShouldResutrnZeroString()
        {

            //ACT
            var result = _numbersToWords.IntToWords(0);

            // Assert  
            Assert.AreEqual("ZERO", result);

        }
        

    }
}
