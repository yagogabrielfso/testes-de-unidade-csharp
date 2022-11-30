using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoFacec.Dominio.nsExceptions
{
   public class BusinessRuleExceptions : Exception
    {
        public BusinessRuleExceptions() { }

        public BusinessRuleExceptions(string message) : base(message) { }
    }
}
