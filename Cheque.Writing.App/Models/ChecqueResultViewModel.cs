using Cheque.Writing.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Cheque.Writing.App.Models
{
    [DataContract]
    public class ChecqueResultViewModel
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string AmountInWords { get; set; }
    }
}