using Domain_Layer.Models.Basket;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Persistence.Implment_Repo
{
    public class BasketReposiatry(IConnectionMultiplexer _connection) : IBasketReposatiry
    {
        private readonly IDatabase _database = _connection.GetDatabase();

        #region DeleteUserBasketAsync
        public async Task<bool> DeleteUserBasketAsync(string key) => await _database.KeyDeleteAsync(key);
        #endregion

        #region GetUserBasketAsync
        public async Task<CustomerBasket?> GetUserBasketAsync(string key)
        {
            var Basket = await _database.StringGetAsync(key);
            if (Basket.IsNullOrEmpty) return null;
            else
            {
                return JsonSerializer.Deserialize<CustomerBasket>(Basket!);
            }
        }
        #endregion

        #region CreateUpdateUserBasketAsync
        public async Task<CustomerBasket?> CreateUpdateUserBasketAsync(CustomerBasket basket, TimeSpan? LiveTime = null)
        {
            var Basket = JsonSerializer.Serialize/*<CustomerBasket>*/(basket);
            var IsCreatedOrUpdates = await _database.StringSetAsync(basket.Id, Basket, LiveTime ?? TimeSpan.FromDays(30));
            if (IsCreatedOrUpdates)
            {
                return await GetUserBasketAsync(basket.Id);
            }
            return null;
        }
        #endregion

    }
}
