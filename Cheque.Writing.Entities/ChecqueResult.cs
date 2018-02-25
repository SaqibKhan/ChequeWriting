using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Cheque.Writing.Entities
{
    [DataContract]
    public class ChecqueResult
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string AmountInWords { get; set; }
    }
}
