using Domain_Layer.Contract;
using Service_Abstrction.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Service_Implemention.Cashing
{
    public class CashService(ICashRepo _cashRepo) : ICashService
    {
        public async Task<string?> GetAsync(string key) => await _cashRepo.GetCashedDataAsync(key);

        public async Task SetAsync(string key, object value, TimeSpan TimeToLive)
        {
            var CashValue = JsonSerializer.Serialize(value);
            await _cashRepo.SetDataAsync(key, CashValue, TimeToLive);
        }
    }
}
