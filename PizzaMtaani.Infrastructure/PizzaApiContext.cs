using Microsoft.EntityFrameworkCore;
using PizzaMtaani.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMtaani.Infrastructure
{
    public class PizzaApiContext:DbContext
    {
        public PizzaApiContext(DbContextOptions<PizzaApiContext> options):base(options)
        {
        }
        public DbSet<PizzaOrder> PizzaOrders { get; set; }
    }
}
