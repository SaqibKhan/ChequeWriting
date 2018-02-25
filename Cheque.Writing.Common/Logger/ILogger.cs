using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheque.Writing.Common.Logger
{
    public interface ILogger
    {
        void Information(string message);
        void Warning(string message);
        void Error(string message);

    }
}
