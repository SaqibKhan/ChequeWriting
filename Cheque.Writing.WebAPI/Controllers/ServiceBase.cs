using Cheque.Writing.Common.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Cheque.Writing.WebAPI.Controllers
{
    /// <summary>
    /// Service base class used to implement log and HttpResponseMessage
    /// </summary>
    public class ServiceBase : ApiController
    {
        ILogger _logger;
        public ServiceBase(ILogger logger)
        {
            _logger = logger;
        }
        #region private Methods

        /// <summary>
        /// Service Action Method 
        /// </summary>
        /// <typeparam name="T">Function delegate</typeparam>
        /// <param name="action">Delegate value</param>
        /// <param name="message">message  used by log</param>
        /// <param name="statuscode">HTTP status code </param>
        /// <returns></returns>
        protected internal HttpResponseMessage ServiceAction<T>(Func<T> action, string message, HttpStatusCode statuscode = HttpStatusCode.OK)
        {
            try
            {
                _logger.Information(message);
                var result = action();
                return Request.CreateResponse(statuscode, result);
            }
            catch (Exception ex)
            {
               return  CaptureHttpResponseException(ex, HttpStatusCode.InternalServerError);
            }
        }
        /// <summary>
        /// Exception logger
        /// </summary>
        /// <param name="ex">Exception</param>
        /// <param name="statuscode">HttpStatus Code</param>
        /// <returns></returns>
        protected internal HttpResponseMessage CaptureHttpResponseException(Exception ex, HttpStatusCode statuscode = HttpStatusCode.InternalServerError)
        {
            _logger.Error($"Exception:{ex.Message}");
           return Request.CreateResponse(statuscode,ex);
        }

        #endregion
    }
}
