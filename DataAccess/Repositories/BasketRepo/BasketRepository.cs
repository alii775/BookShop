using DataAccess.Models;
using DataAccess.Models.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.BasketRepo
{
    public class BasketRepository : IBasketRepository
    {
        private readonly BookDbContext _context;
        public BasketRepository(BookDbContext context)
        {
            _context = context;
        }

        public async Task Add(Basket basket)
        {
            _context.Baskets.Add(basket);
            await _context.SaveChangesAsync();
        }

        public async Task AddbasketItems(BasketItems basketItem)
        {
            _context.BasketItems.Add(basketItem);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var basket = await GetById(id);
            _context.Baskets.Remove(basket);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Basket basket)
        {
            _context.Baskets.Remove(basket);
            await _context.SaveChangesAsync();
        }

        public async Task DeletebasketItems(BasketItems basketItem)
        {
             _context.BasketItems.Remove(basketItem);
            await _context.SaveChangesAsync();

        }

        public IQueryable<Basket> GetAll(Expression<Func<Basket, bool>> where = null)
        {
            var baskets = _context.Baskets.AsQueryable();
            if (where != null)
            {
                baskets = baskets.Where(where);
            }

            return baskets;
        }

        public IQueryable<BasketItems> GetAllbasketItems(Expression<Func<BasketItems, bool>> where = null)
        {
            var basketItems= _context.BasketItems.AsQueryable();
            if (where != null) 
            {
                basketItems = basketItems.Where(where);
            }
            return basketItems;
        }

        public async Task<Basket> GetById(int id)
        {
            return await _context.Baskets.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task Update(Basket basket)
        {
            _context.Baskets.Update(basket);
            await _context.SaveChangesAsync();
        }

     
    }
}
