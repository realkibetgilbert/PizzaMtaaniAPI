using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMtaani.Domain
{
    public class PizzaOrder
    {
        [Required(ErrorMessage = "Pizza size required.")]
        public string? Size { get; set; }
        public List<string>? Toppings { get; set; }

    }
}
