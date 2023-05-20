using BasketAPI.Models.Dto;

namespace BasketAPI.Repo
{
    public interface IBasketRepo
    {
        Task<BasketDto> GetBasketByUserId(string userId);
        Task<BasketDto> CreateUpdateBasket(BasketDto basketDto);
        Task<bool> RemoveFromBasket(int basketDetailsId);
        Task<bool> ClearBasket(string userId);
    }
}