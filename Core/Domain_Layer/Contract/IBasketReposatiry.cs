using Domain_Layer.Models.Basket;

namespace Domain_Layer.Contract
{
    public interface IBasketReposatiry
    {
        //Get User Basket
        Task<CustomerBasket?> GetUserBasketAsync(string key);

        //Update User Basket 
        Task<CustomerBasket?> CreateUpdateUserBasketAsync(CustomerBasket basket, TimeSpan? LiveTime = null);

        //Delete User Basket
        Task<bool> DeleteUserBasketAsync(string key);
    }
}
