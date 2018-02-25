using Cheque.Writing.App.Business.Components;
using Cheque.Writing.App.Business.Interfaces;
using Cheque.Writing.Common;
using Cheque.Writing.Common.ExtensionMethods;
using NSubstitute;
using NUnit.Framework;
using System.Net;

namespace Cheque.Writing.WebAPI.Tests
{
   public class ChecqueTranslatorComponent_Test
    {
        private ICheckqueTranslator _checkqueTranslator;

        [SetUp]
        public void SetUp()
        {
            _checkqueTranslator = new ChecqueTranslatorComponent();
        }

        [TestCase]
        public void Call_TranslateChequeToWords_WithDecimalValue_ShouldResutrnCorrentStringValue()
        {

            //ACT
            var result = _checkqueTranslator.TranslateChequeToWords("Saqib",50263.63m);

            // Assert  
            Assert.AreEqual("FIFTY THOUSAND TWO HUNDRED SIXTY THREE DOLLER(S) AND SIXTY THREE CENTS", result.AmountInWords);

        }

        [TestCase]
        public void Call_TranslateChequeToWords_WithNegativeDecimalValue_ShouldResutrnCorrentStringValue()
        {
            //Act
            var result = _checkqueTranslator.TranslateChequeToWords("Saqib", -50263.63m);

            // Assert  
            Assert.AreEqual("MINUS FIFTY THOUSAND TWO HUNDRED SIXTY THREE DOLLER(S) AND SIXTY THREE CENTS", result.AmountInWords);

        }

        [TestCase]
        public void Call_TranslateChequeToWords_WithDecimalValueAndThreeDecimalPrecision_ShouldResutrnRoundOftheDecimal_AndReturnStringTranslation()
        {

            //ACT
            var result = _checkqueTranslator.TranslateChequeToWords("Saqib", 0890100.0900m);

            // Assert  
            Assert.AreEqual("EIGHT HUNDRED NINETY THOUSAND ONE HUNDRED DOLLER(S) AND NINE CENTS", result.AmountInWords);

        }

    }
}
