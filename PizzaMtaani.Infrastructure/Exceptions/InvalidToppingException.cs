using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMtaani.Infrastructure.Exceptions
{
    public class InvalidToppingException:Exception
    {
        public InvalidToppingException(string message) : base(message)
        {
        }
    }
}
