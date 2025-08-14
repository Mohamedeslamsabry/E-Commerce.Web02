using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Implment_Repo
{
    public class CashRepositary(IConnectionMultiplexer _connection) : ICashRepo
    {
        private readonly IDatabase _database = _connection.GetDatabase();

        #region GetCashedDataAsync
        public async Task<string?> GetCashedDataAsync(string Key)
        {
            var CashValue = await _database.StringGetAsync(Key);
            return CashValue.IsNullOrEmpty ? null : CashValue.ToString();
        }
        #endregion

        #region SetDataAsync
        public async Task SetDataAsync(string Key, string CashValue, TimeSpan TimeToLive)
        {
            await _database.StringSetAsync(Key, CashValue, TimeToLive);
        }
        #endregion
    }
}
