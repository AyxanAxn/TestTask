using Microsoft.AspNetCore.Mvc;
using TestTask.Controllers;
using TestTask.Repositories;
using Xunit;

namespace TestTask.Tests.RectangleControllerTests
{
    public class RectangleRepositoryTests
    {
        private readonly RectangleController _controller;
        private readonly IRectangleRepository _repository;

        public RectangleRepositoryTests()
        {
            _repository = new RectangleRepositoryFake();
            _controller = new RectangleController(_repository);
        }

        [Fact]
        public async void TestNotFound()
        {
            var response = await _controller.GetIntersectingRectangles(20, 20, 20, 20);
            Assert.IsType<NotFoundResult>(response.Result);
        }
        [Fact]
        public async void TestFound()
        {
            var response = await _controller.GetIntersectingRectangles(0, 0, 0, 0);
            Assert.IsType<OkObjectResult>(response.Result);
        }
    }
}