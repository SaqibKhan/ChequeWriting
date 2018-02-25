using Castle.Core.Logging;
using Cheque.Writing.Common.Logger;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheque.Writing.WebAPI.Tests
{
    [TestFixture]
    class ServiceFileLogger_Test
    {
        private Common.Logger.ILogger _Logger;
        private string _informationMessage="this is information message";

        [SetUp]
        public void SetUp()
        {
            _Logger = Substitute.For<Common.Logger.ILogger>();
        }

        [TestCase]
        public void Call_InformationMethod_shouldCallInformatoinMessageConcreateClassMehtod()
        {
            //ACT
            _Logger.Information(this._informationMessage);

            // Assert 
            _Logger.Received(1); // should be call and only one per request

        }

        [TestCase]
        public void Call_WarningMethod_shouldCallInformatoinMessageConcreateClassMehtod()
        {

            //ACT
            _Logger.Warning(this._informationMessage);

            // Assert 
            _Logger.Received(1); // should be call and only one per request

        }
    }
}
