using Cheque.Writing.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheque.Writing.App.Business.Interfaces
{
    public interface ICheckqueTranslator
    {
        ChecqueResult TranslateChequeToWords(string name, decimal number);
    }
}
