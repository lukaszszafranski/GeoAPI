using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StockAPI.Models;
using Microsoft.EntityFrameworkCore.Internal;
using StockAPI.Services;
using AutoMapper;
using StockAPI.Resources;
using System.Net;

namespace StockAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StocksController : ControllerBase
    {
        private readonly IStockService _stockService;
        private readonly IMapper _mapper;

        public StocksController(IStockService stockService, IMapper mapper)
        {
            _stockService = stockService;
            _mapper = mapper;
        }

        // GET: api/Geolocation
        [HttpGet]
        public async Task<IEnumerable<StockResource>> GetStockData()
        {
            var stockDatas = await _stockService.ListAsync();
            var resources = _mapper.Map<IEnumerable<StockData>, IEnumerable<StockResource>>(stockDatas);

            return resources;
        }

        // GET: api/Geolocation/5
        [HttpGet("{symbol}")]
        public async Task<IActionResult> GetStockData([FromRoute] PostData postData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.SelectMany(m => m.Errors).Select(m => m.ErrorMessage).ToList());
            }

            var geolocationData = await _stockService.FindBySymbolOrCompanyNameAsync(postData.Symbols);

            if (!_stockService.SpecificStockDataExists(postData.Symbols))
            {
                return NotFound();
            }

            return Ok(geolocationData);
        }

        // POST: api/Geolocation
        [HttpPost]
        public async Task<IActionResult> PostStockData([FromBody] PostData postData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.SelectMany(m => m.Errors).Select(m => m.ErrorMessage).ToList());
            }

            var symbolList = postData.Symbols.Split(new char[] { ',' }).ToList();

            if (symbolList.Count == 1)
            {
                var httpClient = new HttpClient();
                var URL = "https://cloud.iexapis.com/v1/stock/market/batch?symbols=" + postData.Symbols + "&types=" + postData.Types + "&range=" + postData.Range;
                var Token = "?token=pk_8936f153936f4ee3b77122727d80bead";

                var response = await httpClient.GetStringAsync(URL + Token);
                var stockResource = Newtonsoft.Json.JsonConvert.DeserializeObject<SaveStockResource>(response);
                var stockData = _mapper.Map<SaveStockResource, StockData>(stockResource);

                if (!_stockService.SpecificStockDataExists(stockData.Quote.Symbol) || !_stockService.SpecificStockDataExists(stockData.Quote.CompanyName))
                {
                    var result = _stockService.SaveAsync(stockData);

                    if (!result.Result.Success)
                    {
                        return BadRequest(result.Result.Message);
                    }

                    var finalGeolocationResource = _mapper.Map<StockData, StockResource>(result.Result.StockData);

                    return Ok(finalGeolocationResource);
                }
                else
                {
                    return Content("This Stock Data exists in database");
                }
            }
            else if (symbolList.Count > 1)
            {

                var listOfStockData = new List<StockData>();

                foreach (var symbol in symbolList)
                {
                    if (!_stockService.SpecificStockDataExists(symbol))
                    {
                        var httpClient = new HttpClient();
                        var URL = "https://cloud.iexapis.com/v1/stock/market/batch?symbols=" + symbol + "&types=" + postData.Types + "&range=" + postData.Range;
                        var Token = "?token=pk_8936f153936f4ee3b77122727d80bead";

                        var response = await httpClient.GetStringAsync(URL + Token);
                        var stockResource = Newtonsoft.Json.JsonConvert.DeserializeObject<SaveStockResource>(response);
                        var stockData = _mapper.Map<SaveStockResource, StockData>(stockResource);

                        listOfStockData.Add(stockData);
                    }
                    else
                    {
                        return Content("This Stock Data exist in database");
                    }
                }

                foreach (var stockData in listOfStockData)
                {
                    var result = _stockService.SaveAsync(stockData);

                    if (!result.Result.Success)
                    {
                        return BadRequest(result.Result.Message);
                    }

                    var finalStockResource = _mapper.Map<StockData, StockResource>(result.Result.StockData);

                    return Ok(finalStockResource);
                }
            }

            return Ok();
        }

        // DELETE: api/Geolocation/ip
        [HttpDelete("{symbol}")]
        public async Task<IActionResult> DeleteStockData([FromRoute] PostData postData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.SelectMany(m => m.Errors).Select(m => m.ErrorMessage).ToList());
            }

            var result = await _stockService.DeleteAsync(postData.Symbols);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var stockResource = _mapper.Map<StockData, StockResource>(result.StockData);

            return Ok(stockResource);
        }
    }
}