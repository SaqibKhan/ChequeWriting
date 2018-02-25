using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Cheque.Writing.App.Models;
using Cheque.Writing.App.ServiceCaller;
using Cheque.Writing.Entities;
using Newtonsoft.Json;

namespace Cheque.Writing.App.Controllers
{
    public class ChecqueController : Controller
    {
        IServiceClient _client;
        /// <summary>
        /// Constructor containing dependency injunction 
        /// </summary>
        /// <param name="client"></param>
        public ChecqueController(IServiceClient client)
        {
            _client = client;
        }

        
        public ActionResult Index(ChequeRequestViewModel vm)
        {
          return View(vm);
        }

        /// <summary>
        /// Post Method to Create result
        /// </summary>
        /// <param name="cheque">ChequeRequestViewModel vm</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult TranslateCheck(ChequeRequestViewModel vm)
        {
            string requestURL = $"api/Translate/{vm.Name}/{vm.Amount}/";
            var response = _client.CallApi(requestURL);

            if (response.IsSuccessStatusCode)
            {
               var checqueResult = JsonConvert.DeserializeObject<ChecqueResult>(response.Content.ReadAsStringAsync().Result);
               var checkResultvm = new ChecqueResultViewModel() { AmountInWords = checqueResult.AmountInWords, Name = checqueResult.Name };
              return View("CheckResult", checkResultvm);
            }
            return RedirectToAction("Index",vm);
        }


    }
}
