using Cheque.Writing.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Cheque.Writing.App.Models
{
   
    public class ChequeRequestViewModel
    {

        [Display(Name = "Name:")]
        [Required(ErrorMessage = "*")]
        public string Name { get; set; }

        [Display(Name = "Amount:")]
        [Required(ErrorMessage = "*")]
        [Range(0, 99999999999.99)]
        public decimal? Amount { get; set; }
    }
}