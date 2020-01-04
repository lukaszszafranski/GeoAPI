using StockAPI.Models;
using StockAPI.Services;
using StockAPI.Services.Communication;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace WebApiTests.Fakers
{
    public class StockServiceFake : IStockService
    {
        private readonly List<StockData> _stockDatas;

        public StockServiceFake()
        {
            _stockDatas = new List<StockData>()
            {
                new StockData()
                {
                    Quote = new Quote
                    {
                        CompanyName = "Apple",
                        Symbol = "AAPL",
                    },
                },

                new StockData()
                {
                    Quote = new Quote
                    {
                        CompanyName = "Facebook",
                        Symbol = "FB",
                    },
                },

                new StockData()
                {
                   Quote = new Quote
                   {
                       CompanyName = "Microsoft",
                       Symbol = "MSFT",
                   },
                },
            };
        }

        public async Task<StockResponse> DeleteAsync(string Symbol)
        {
            var existingStockData = _stockDatas.First(g => g.Quote.Symbol == Symbol || g.Quote.CompanyName.Contains(Symbol));
            _stockDatas.Remove(existingStockData);

            return await Task.Run(() => new StockResponse(existingStockData));
        }

        public async Task<StockData> FindBySymbolOrCompanyNameAsync(string Symbol)
        {
            return await Task.Run(() => _stockDatas.Where(g => g.Quote.Symbol == Symbol || g.Quote.CompanyName.Contains(Symbol)).FirstOrDefault());
        }

        public bool IsDbEmpty()
        {
            return !_stockDatas.Any();
        }

        public async Task<IEnumerable<StockData>> ListAsync()
        {
            return await Task.Run(() => _stockDatas);
        }

        public async Task<StockResponse> SaveAsync(StockData stockData)
        {
            return await Task.Run(() => new StockResponse(stockData));
        }

        public bool SpecificStockDataExists(string Symbol)
        {
            return _stockDatas.Any(g => g.Quote.Symbol == Symbol || g.Quote.CompanyName.Contains(Symbol));
        }
    }
}
