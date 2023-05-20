using BasketAPI.Models.Dto;
using BasketAPI.Repo;
using Microsoft.AspNetCore.Mvc;

namespace BasketAPI.Controllers
{
    [ApiController]
    [Route("api/basket")]
    public class BasketController : Controller
    {
        private readonly IBasketRepo _basketRepo;
        protected ResponseDto _response;

        public BasketController(IBasketRepo basketRepo)
        {
            _basketRepo = basketRepo;
            this._response = new ResponseDto();
        }

        [HttpGet("GetBasket/{userId}")]
        public async Task<object> GetBasket(string userId)
        {
            try
            {
                BasketDto basketDto = await _basketRepo.GetBasketByUserId(userId);
                _response.Result = basketDto;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _response;
        }

        [HttpPost("AddBasket")]
        public async Task<object> AddBasket(BasketDto basketDto)
        {
            try
            {
                BasketDto basketDt = await _basketRepo.CreateUpdateBasket(basketDto);
                _response.Result = basketDt;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _response;
        }

        [HttpPost("UpdateBasket")]
        public async Task<object> UpdateBasket(BasketDto basketDto)
        {
            try
            {
                BasketDto basketDt = await _basketRepo.CreateUpdateBasket(basketDto);
                _response.Result = basketDt;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _response;
        }

        [HttpPost("RemoveBasket")]
        public async Task<object> RemoveBasket([FromBody] int basketId)
        {
            try
            {
                bool isSuccess = await _basketRepo.RemoveFromBasket(basketId);
                _response.Result = isSuccess;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _response;
        }

    }

}