using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Cheque.Writing.Entities
{
    [DataContract]
    public class ChequeRequest
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public decimal? Amount { get; set; }
    }
}
