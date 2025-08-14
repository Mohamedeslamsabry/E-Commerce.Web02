using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Layer.Contract
{
    public interface ICashRepo
    {
        //Get
        Task<string?> GetCashedDataAsync(string Key);

        //Set
        Task SetDataAsync(string Key, string CashValue, TimeSpan TimeToLive);
    }
}
