using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Layer.Exceptions
{
    public class UserNotFoundException(string Email) : NotFoundExceptions($"User With Email :{Email} Is Not Found")
    {
    }
}
