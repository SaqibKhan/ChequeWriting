using Cheque.Writing.App.Business.Interfaces;
using Cheque.Writing.Common.Logger;
using Cheque.Writing.Entities;
using Cheque.Writing.WebAPI.Controllers;
using Newtonsoft.Json;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Hosting;

namespace Cheque.Writing.WebAPI.Tests
{
    [TestFixture]
    public class ChequeWriterController_Test
    {
        private ICheckqueTranslator _checkqueTranslator;
        private ILogger _logger;
        private ChequeWriterController _controller;
        private ChecqueResult _checqueResult = new ChecqueResult() { Name = "Saqib", AmountInWords = "THREE THOUSAND TWENTY FIVE DOLLARS AND THIRTY SIX CENTS" };

        [SetUp]
        public void SetUp()
        {
            _checkqueTranslator = Substitute.For<ICheckqueTranslator>(); //  Mock the checkqueTranslator 
            _logger = Substitute.For<ILogger>(); // we need logger because WebAPI need this logger to log the activity
            _controller = new ChequeWriterController(_checkqueTranslator, _logger)  // WebAPI controller
             {
                Request = new HttpRequestMessage()
                {
                    Properties = { { HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration() } }
                }
            };
        }
        
        [TestCase]
        public void Call_TranslateMethod_ByProviding_NameAndAmount_ShouldCallTranslatorComponent()
        {
            //Arrange
          
            var writer = _checkqueTranslator.TranslateChequeToWords("Saqib", 3025.36m).Returns(_checqueResult);
           
            //ACT
            _controller.Translate("Saqib", 3025.36m);

            // Assert 
            _checkqueTranslator.Received(1); // should be call and only one per request

        }
        [TestCase]
        public void Call_TranslateMethod_ByProviding_NameAndAmount_ShouldReturnOkStatusCode() 
        {
            //Arrange
            var writer = _checkqueTranslator.TranslateChequeToWords("Saqib", 3025.36m).Returns(_checqueResult);
           
            //ACT
            var httpResponse = _controller.Translate("Saqib", 3025.36m);

            // Assert 
            Assert.AreEqual(HttpStatusCode.OK, httpResponse.StatusCode);
        }

        [TestCase]
        public void Call_TranslateMethod_ByProviding_NameAndAmount_ShouldReturnValidReponse()
        {           
            //Arrange
            var writer = _checkqueTranslator.TranslateChequeToWords("Saqib", 3025.36m).Returns(_checqueResult);
           
            //ACT
            var httpResponse = _controller.Translate("Saqib", 3025.36m);
            var translatedcheckItem = JsonConvert.DeserializeObject<ChecqueResult>(httpResponse.Content.ReadAsStringAsync().Result);
           
            // Assert 
            Assert.AreEqual(translatedcheckItem.Name, _checqueResult.Name);
            Assert.AreEqual(translatedcheckItem.AmountInWords, _checqueResult.AmountInWords);

        }

        [TestCase]
        public void Call_TranslateMethod_ByProviding_NameAndAmount_ShouldReturnInValidJsonReponse()
        {
            //Arrange
            var writer = _checkqueTranslator.TranslateChequeToWords("Saqib", 3025.36m).Returns(_checqueResult);
         
            //ACT
            var httpResponse = _controller.Translate("Saqib1", 3025.36m);

            // here when the WebApi return invalid response the translatedChecque item will be null 
            var translatedcheckItem = JsonConvert.DeserializeObject<ChecqueResult>(httpResponse.Content.ReadAsStringAsync().Result);
           
            // Assert 
            Assert.IsNull(translatedcheckItem);            
        }

        [TestCase]
        public void Call_TranslateMethod_ByProviding_NameAndAmount_ShouldReturnNullResult()
        {
            //ACT
            var httpResponse = _controller.Translate("Saqib", 3025.36m);
            var result = JsonConvert.DeserializeObject<ChecqueResult>(httpResponse.Content.ReadAsStringAsync().Result);
       
            // Assert 
            Assert.IsNull(result);
        }

    }
}
