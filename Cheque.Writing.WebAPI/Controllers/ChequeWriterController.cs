using Cheque.Writing.App.Business.Interfaces;
using Cheque.Writing.Common;
using Cheque.Writing.Common.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Cheque.Writing.WebAPI.Controllers
{
    public class ChequeWriterController : ServiceBase
    {
        private readonly ICheckqueTranslator _iNumbersToWordsCompoent;
        public ChequeWriterController(ICheckqueTranslator iNumbersToWords, ILogger logger) : base(logger)
        {
            _iNumbersToWordsCompoent = iNumbersToWords;
        }

        /// <summary>
        ///  Check Translator : get name and decimal number and translate the number into words
        /// </summary>
        /// <param name="name">Account holder name</param>
        /// <param name="number">check amount</param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Translate/{name}/{number:decimal}")]
        public HttpResponseMessage Translate(string name,decimal? number) => ServiceAction(() =>
        {
           return _iNumbersToWordsCompoent.TranslateChequeToWords(name, number.Value);
        }, $"Translate {number} into Words");


    }
}
