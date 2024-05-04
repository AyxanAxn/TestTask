using TestTask.Models;
using TestTask.Repositories;

namespace TestTask.Tests.RectangleControllerTests
{
    internal class RectangleRepositoryFake : IRectangleRepository
    {
        private readonly List<Rectangle> _rectangleListMock;

        public RectangleRepositoryFake() =>
            _rectangleListMock = new();

        public async Task GenerateMockRectangles()
        {

            var rectangles = new List<Rectangle>
            {
                new() { X = 0, Y = 0, Width = 5, Height = 5 },
                new() { X = 2, Y = 2, Width = 6, Height = 6 },
            };
            await Task.Yield();
            _rectangleListMock.AddRange(rectangles);
        }
        public Task<List<Rectangle>> GetIntersectingRectanglesAsync(double startX, double startY, double endX, double endY)
        {
            var res = _rectangleListMock.Where(r =>
                    (r.X <= startX && r.X + r.Width >= startX && r.Y <= startY && r.Y + r.Height >= startY) ||
                    (r.X <= endX && r.X + r.Width >= endX && r.Y <= endY && r.Y + r.Height >= endY)
                ).ToList();
            return Task.FromResult(res);
        }
    }
}