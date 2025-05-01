using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Layer.Contract
{
    public interface IDataSeeding
    {
        Task DataSeedAsync();
        Task IdentityDataSeedingAsync();
    }
}
