using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M5_SALES.Core.Exceptions
{
    public class GeneralException : Exception
    {
        public GeneralException()
        {

        }

        public GeneralException(string message): base(message)
        {

        }
    }
}
