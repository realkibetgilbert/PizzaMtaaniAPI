using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMtaani.Infrastructure.Exceptions
{
    public class InvalidPizzaSizeException:Exception
    {
        public InvalidPizzaSizeException(string message) : base(message)
        {
        }
    }
}
