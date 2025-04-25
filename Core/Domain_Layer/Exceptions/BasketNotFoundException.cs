using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Layer.Exceptions
{
    public sealed class BasketNotFoundException(string id) : NotFoundExceptions($"Basket With Id :{id} Is Not Found")
    {
    }
}
