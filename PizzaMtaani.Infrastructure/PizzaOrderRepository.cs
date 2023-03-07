using PizzaMtaani.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMtaani.Infrastructure
{

    public class PizzaOrderRepository:IPizzaOrderRepository
    {
        private readonly PizzaApiContext _pizzaApiContext;

        public PizzaOrderRepository(PizzaApiContext pizzaApiContext)
        {
            _pizzaApiContext = pizzaApiContext;
        }
    }
}
