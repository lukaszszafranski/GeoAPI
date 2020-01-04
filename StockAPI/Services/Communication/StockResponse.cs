using StockAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockAPI.Services.Communication
{
    public class StockResponse : BaseResponse 
    {
        public StockData StockData { get; private set; }

        private StockResponse(bool success, string message, StockData stockData) : base(success, message)
        {
            StockData = stockData;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="stockData">Saved category.</param>
        /// <returns>Response.</returns>
        public StockResponse(StockData stockData) : this(true, string.Empty, stockData)
        {

        }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public StockResponse(string message) : this(false, message, null)
        {

        }
    }
}
