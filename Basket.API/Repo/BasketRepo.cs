using AutoMapper;
using Basket.API.Data;
using Basket.API.Models.Dto;
using Basket.API.Models;

namespace Basket.API.Repo
{
    public class BasketRepo : IBasketRepo
    {
        private readonly ProductContext _repository;
        private IMapper _mapper;
        //private readonly RabbitMQProducer _rabbitMQProducer;

        public BasketRepo(ProductContext repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> ClearBasket(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<BasketDto> CreateUpdateBasket(BasketDto basketDto)
        {
            // Basket basket = _mapper.Map<Basket>(basketDto);
            // check if wine exists in db

            throw new NotImplementedException();
        }

        public async Task<BasketDto> GetBasketByUserId(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemoveFromBasket(int basketDetailsId)
        {
            throw new NotImplementedException();
        }
    }
}