using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Stock;
using api.Helper;
using api.Interface;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class StockRepository : IStockRepository
    {
        public readonly ApplicationDbContext _context;

        public StockRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Stock> CreateAsync(Stock stock)
        {
            await _context.Stocks.AddAsync(stock);
            await _context.SaveChangesAsync();
            return stock;
        }

        public async Task<Stock?> DeleteAsync(int id)
        {
            var stock = await _context.Stocks.FindAsync(id);
            if (stock == null)
            {
                return null;
            }
            _context.Stocks.Remove(stock);
            await _context.SaveChangesAsync();
            return stock;
        }

        public Task<List<Stock>> GetAllAsync()
        {
            return _context.Stocks.Include(s => s.Comments).ToListAsync();
        }

        

        public async Task<Stock?> GetByIdAsync(int id)
        {
            return await _context.Stocks.Include(s => s.Comments).FirstOrDefaultAsync(s => s.Id == id);
        }

        public Task<List<Stock>> GetFilteredStocksAsync(QueryObjects queryObjects)
        {   
            // Start with all stocks
            var stocks = _context.Stocks.AsQueryable();
            // Apply filters based on QueryObjects
            if (!string.IsNullOrEmpty(queryObjects.Symbol))
            {
                stocks = stocks.Where(s => s.Symbol.Contains(queryObjects.Symbol));
            }
            // Example filter for CompanyName
            if (!string.IsNullOrEmpty(queryObjects.CompanyName))
            {
                stocks = stocks.Where(s => s.CompanyName.Contains(queryObjects.CompanyName));
            }
            // Add more filters as needed
            // Return the filtered list
            return stocks.ToListAsync();
        }

        public Task<bool> StockExists(int id)
        {
            return _context.Stocks.AnyAsync(e => e.Id == id);
        }

        public async Task<Stock?> UpdateAsync(int id, UpdateStockDto stockDto)
        {
            var stock = await _context.Stocks.FirstAsync(x => x.Id == id);
            if (stock == null)
            {
                return null;
            }
            stock.Symbol = stockDto.Symbol;
            stock.CompanyName = stockDto.CompanyName;
            stock.Purchase = stockDto.Purchase;

            stock.LastDiv = stockDto.LastDiv;
            stock.Industry = stockDto.Industry;
            stock.MarketCap = stockDto.MarketCap;
            await _context.SaveChangesAsync();
            return stock;
        }
    }
}
