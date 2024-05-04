using TestTask.Models;

namespace TestTask.Repositories
{
    public interface IRectangleRepository
    {
        Task<List<Rectangle>> GetIntersectingRectanglesAsync(double startX, double startY, double endX, double endY);

        Task GenerateMockRectangles();
    }
}