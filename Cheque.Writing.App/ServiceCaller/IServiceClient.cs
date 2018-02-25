using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Cheque.Writing.App.ServiceCaller
{
    public interface IServiceClient
    {
        HttpResponseMessage CallApi(string Url);
    }
}
