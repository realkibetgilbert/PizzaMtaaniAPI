using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMtaani.Domain
{
    public class PizzaOrder
    {
        public string Size { get; set; }
        public List<string> Toppings { get; set; }
    }
}
