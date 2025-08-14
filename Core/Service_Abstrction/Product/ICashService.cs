using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Abstrction.Product
{
    public interface ICashService
    {
        //Get
        Task<string?> GetAsync(string key);
        //Set
        Task SetAsync(string key, object value , TimeSpan TimeToLive);
    }
}
