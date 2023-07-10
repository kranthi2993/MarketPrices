using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPrices.Application.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string name) : base($"{name} was not found")
        {

        }
    }
}
