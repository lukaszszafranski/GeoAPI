using StockAPI.Models;
using StockAPI.Repositories;
using StockAPI.Repositories.Domain;
using StockAPI.Resources;
using StockAPI.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockAPI.Services
{
    public class StockService : IStockService
    {
        private readonly IStockRepository _stockRepository;
        private readonly IUnitOfWork _unitOfWork;

        public StockService(IStockRepository stockRepository, IUnitOfWork unitOfWork)
        {
            _stockRepository = stockRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<StockData>> ListAsync()
        {
            return await _stockRepository.ListAsync();
        }
        public async Task<StockResponse> SaveAsync(StockData stockData)
        {
            try
            {
                await _stockRepository.AddAsync(stockData);
                await _unitOfWork.CompleteAsync();

                return new StockResponse(stockData);
            }
            catch (Exception ex)
            {
                return new StockResponse($"An error occurred when saving the category: {ex.Message}");
            }
        }
        public async Task<StockData> FindBySymbolOrCompanyNameAsync(string Symbol)
        {
            return await _stockRepository.FindBySymbolAsync(Symbol);
        }
        public async Task<StockResponse> DeleteAsync (string Symbol)
        {
            var existingStockData = await _stockRepository.FindBySymbolAsync(Symbol);

            if (existingStockData == null)
            {
                return new StockResponse("Symbol not found");
            }

            try
            {
                _stockRepository.Remove(existingStockData);
                await _unitOfWork.CompleteAsync();

                return new StockResponse(existingStockData);
            }
            catch (Exception ex)
            {
                return new StockResponse($"An error occurred when deleting the category: {ex.Message}");
            }
        }
        public bool IsDbEmpty()
        {
            return _stockRepository.IsDbEmpty();
        }
        public bool SpecificStockDataExists(string Symbol)
        {
            return _stockRepository.SpecificStockDataExists(Symbol);
        }
    }
}
