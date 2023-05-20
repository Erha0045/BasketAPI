using AutoMapper;
using BasketAPI.Data;
using BasketAPI.Models.Dto;
using BasketAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BasketAPI.Repo
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
            var basketHeaderFromDb = await _repository.BasketHeaders.FirstOrDefaultAsync(b => b.UserId == userId);
            if (basketHeaderFromDb != null)
            {
                _repository.BasketDetails.RemoveRange(_repository.BasketDetails.Where(b => b.BasketHeaderId == basketHeaderFromDb.BasketHeaderId));
                _repository.BasketHeaders.Remove(basketHeaderFromDb);
                await _repository.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<BasketDto> CreateUpdateBasket(BasketDto basketDto)
        {
            Models.Basket basket = _mapper.Map<Models.Basket>(basketDto);
            // check if wine exists in db
            var wineInDb = await _repository.WineProducts
                .FirstOrDefaultAsync(p => p.Id == basketDto.BasketDetails.FirstOrDefault()
                .WineId);
            if (wineInDb == null)
            {
                _repository.WineProducts.Add(basket.BasketDetails.FirstOrDefault().Wine);
                await _repository.SaveChangesAsync();
            }

            // check if header is null
            var basketHeaderFromDb = await _repository.BasketHeaders.AsNoTracking()
                .FirstOrDefaultAsync(b => b.UserId == basket.BasketHeader.UserId);

            if (basketHeaderFromDb == null)
            {
                // create header and details
                _repository.BasketHeaders.Add(basket.BasketHeader);
                await _repository.SaveChangesAsync();
                basket.BasketDetails.FirstOrDefault().BasketHeaderId = basket.BasketHeader.BasketHeaderId;
                basket.BasketDetails.FirstOrDefault().Wine = null;
                _repository.BasketDetails.Add(basket.BasketDetails.FirstOrDefault());
                await _repository.SaveChangesAsync();
            }
            else
            {
                // if header is not null
                // check if details has same wine
                var basketdetailsFromDb = await _repository.BasketDetails.AsNoTracking()
                    .FirstOrDefaultAsync(b => b.WineId == basket.BasketDetails.FirstOrDefault().WineId &&
                                        b.BasketHeaderId == basketHeaderFromDb.BasketHeaderId);
                if (basketdetailsFromDb == null)
                {
                    // create details
                    basket.BasketDetails.FirstOrDefault().BasketHeaderId = basketHeaderFromDb.BasketHeaderId;
                    basket.BasketDetails.FirstOrDefault().Wine = null;
                    _repository.BasketDetails.Add(basket.BasketDetails.FirstOrDefault());
                    await _repository.SaveChangesAsync();
                }
                else
                {
                    // update amount
                    basket.BasketDetails.FirstOrDefault().Wine = null;
                    basket.BasketDetails.FirstOrDefault().Amount += basketdetailsFromDb.Amount;
                    _repository.BasketDetails.Update(basket.BasketDetails.FirstOrDefault());
                    await _repository.SaveChangesAsync();
                }
            }

            return _mapper.Map<BasketDto>(basket);

        }

        public async Task<BasketDto> GetBasketByUserId(string userId)
        {
            Models.Basket basket = new()
            {
                BasketHeader = await _repository.BasketHeaders.FirstOrDefaultAsync(b => b.UserId == userId)
            };
            basket.BasketDetails = _repository.BasketDetails
                .Where(b => b.BasketHeaderId == basket.BasketHeader.BasketHeaderId).Include(p => p.Wine);

            return _mapper.Map<BasketDto>(basket);
        }

        public async Task<bool> RemoveFromBasket(int basketDetailsId)
        {
            try
            {
                BasketDetails basketDetails = await _repository.BasketDetails
                    .FirstOrDefaultAsync(b => b.BasketDetailsId == basketDetailsId);

                int totalcountOfBasketItems = _repository.BasketDetails
                    .Where(b => b.BasketHeaderId == basketDetails.BasketHeaderId).Count();

                _repository.BasketDetails.Remove(basketDetails);
                if (totalcountOfBasketItems == 1)
                {
                    var basketHeaderToRemove = await _repository.BasketHeaders
                        .FirstOrDefaultAsync(b => b.BasketHeaderId == basketDetails.BasketHeaderId);

                    _repository.BasketHeaders.Remove(basketHeaderToRemove);

                }
                await _repository.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

    }
}