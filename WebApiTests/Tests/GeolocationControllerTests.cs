using AutoMapper;
using GeolocationAPI.Controllers;
using GeolocationAPI.Models;
using GeolocationAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using WebApiTests.Fakers;
using System.Linq;
using Xunit;

namespace WebApiTests.Tests
{
    public class GeolocationControllerTests
    {
        GeolocationController _controller;
        IGeolocationService _service;
        IMapper _mapper;

        public GeolocationControllerTests()
        {
            _service = new GeolocationServiceFake();
            _controller = new GeolocationController(_service, _mapper);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            // Act
            var result = _service.ListAsync().Result;

            // Assert
            var items = Assert.IsType<List<GeolocationData>>(result);
            Assert.Equal(3, items.Count);
        }

        [Fact]
        public void FindByIP_WrongIPPassed_ReturnsNotFoundResult()
        {
            // Arrange
            var IP = new PostData { IP = "123.456.890.00" };
            // Act
            var notFoundResult = _controller.GetGeolocationData(IP);

            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult.Result);
        }

        [Fact]
        public void FindByIP_ExistingIPPassed_ReturnsOkResult()
        {
            // Arrange
            var IP = new PostData { IP = "109.131.249.58" };

            // Act
            var okResult = _controller.GetGeolocationData(IP);

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void FindByIP_ExistingIPPassed_ReturnsRightItem()
        {
            // Arrange
            var IP = new PostData { IP = "109.131.249.58" };

            // Act
            var okResult = _controller.GetGeolocationData(IP).Result as OkObjectResult;

            // Assert
            Assert.IsType<GeolocationData>(okResult.Value);
            Assert.Equal(IP.IP, (okResult.Value as GeolocationData).IP);
        }

        [Fact]
        public void Post_InvalidIPPassed_ReturnsBadRequest()
        {
            // Arrange
            var IP = new PostData { IP = "123" };

            // Act
            var badResponse = _controller.PostGeolocationData(IP);

            // Assert
            Assert.IsType<BadRequestObjectResult>(badResponse);
        }


        [Fact]
        public void Post_ValidObjectPassed_ReturnsCreatedResponse()
        {
            // Arrange
            var IP = new PostData { IP = "142.83.211.45" };

            // Act
            var createdResponse = _controller.PostGeolocationData(IP).Result;

            // Assert
            Assert.IsType<OkResult>(createdResponse);
        }

        [Fact]
        public void Delete_NotExistingIPPassed_ReturnsNotFoundResponse()
        {
            // Arrange
            var IP = new PostData { IP = "123.456.789.00" };

            // Act
            var badResponse = _controller.DeleteGeolocationData(IP);

            // Assert
            Assert.IsType<System.InvalidOperationException>(badResponse.Exception.InnerExceptions.ElementAt(0));
        }

        [Fact]
        public void Delete_ExistingIPPassed_RemovesOneItem()
        {
            // Arrange
            var IP = new PostData { IP = "109.131.249.59" };

            // Act
            var okResponse = _controller.DeleteGeolocationData(IP);
            var List = _service.ListAsync().Result;

            // Assert
            Assert.Equal(2, List.Count());
        }
    }
}
