using PizzaMtaani.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMtaani.Application
{
    public interface IPizzaOrderService
    {
        string CalculatePrice(List<PizzaOrder> orders);
    }
}
