using AutoMapper;
using StockAPI.Controllers;
using StockAPI.Models;
using StockAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using WebApiTests.Fakers;
using System.Linq;
using Xunit;

namespace WebApiTests.Tests
{
    public class StockControllerTests
    {
        StocksController _controller;
        IStockService _service;
        IMapper _mapper;

        public StockControllerTests()
        {
            _service = new StockServiceFake();
            _controller = new StocksController(_service, _mapper);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            // Act
            var result = _service.ListAsync().Result;

            // Assert
            var items = Assert.IsType<List<StockData>>(result);
            Assert.Equal(3, items.Count);
        }

        [Fact]
        public void FindByCompanySymbol_WrongCompanyNamePassed_ReturnsNotFoundResult()
        {
            // Arrange
            var CompanySymbol = new PostData { Symbols = "FB_1" };
            // Act
            var notFoundResult = _controller.GetStockData(CompanySymbol);

            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult.Result);
        }

        [Fact]
        public void FindByCompanySymbol_ExistingSymbolPassed_ReturnsOkResult()
        {
            // Arrange
            var CompanySymbol = new PostData { Symbols = "FB" };

            // Act
            var okResult = _controller.GetStockData(CompanySymbol);

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void FindByCompanySymbol_ExistingCompanySymbolPassed_ReturnsRightItem()
        {
            // Arrange
            var CompanySymbol = new PostData { Symbols = "FB" };

            // Act
            var okResult = _controller.GetStockData(CompanySymbol).Result as OkObjectResult;

            // Assert
            Assert.IsType<StockData>(okResult.Value);
            Assert.Equal(CompanySymbol.Symbols, (okResult.Value as StockData).Quote.Symbol);
        }

        [Fact]
        public void Post_InvalidCompanySymbolPassed_ReturnsBadRequest()
        {
            // Arrange
            var CompanySymbol = new PostData { Symbols = "ELO" };

            // Act
            var badResponse = _controller.PostStockData(CompanySymbol);

            // Assert
            Assert.IsType<BadRequestObjectResult>(badResponse);
        }


        [Fact]
        public void Post_ValidObjectPassed_ReturnsCreatedResponse()
        {
            // Arrange
            var CompanySymbol = new PostData { Symbols = "FB" };

            // Act
            var createdResponse = _controller.PostStockData(CompanySymbol).Result;

            // Assert
            Assert.IsType<OkResult>(createdResponse);
        }

        [Fact]
        public void Delete_NotCompanyNamePassed_ReturnsNotFoundResponse()
        {
            // Arrange
            var CompanySymbol = new PostData { Symbols = "FB" };

            // Act
            var badResponse = _controller.DeleteStockData(CompanySymbol);

            // Assert
            Assert.IsType<System.InvalidOperationException>(badResponse.Exception.InnerExceptions.ElementAt(0));
        }

        [Fact]
        public void Delete_ExistingCompanyNamePassed_RemovesOneItem()
        {
            // Arrange
            var CompanyName = new PostData { Symbols = "FB" };

            // Act
            var okResponse = _controller.DeleteStockData(CompanyName);
            var List = _service.ListAsync().Result;

            // Assert
            Assert.Equal(2, List.Count());
        }
    }
}
