using Microsoft.EntityFrameworkCore;
using TestTask.Context;
using TestTask.Models;

namespace TestTask.Repositories
{
    public class RectangleRepository : IRectangleRepository
    {

        private readonly DBContext _context;

        public RectangleRepository(DBContext context)
        {
            _context = context;
        }

        public async Task<List<Rectangle>> GetIntersectingRectanglesAsync(double startX, double startY, double endX, double endY)
        {
            return await _context.Rectangles
                .Where(r =>
                    (r.X <= startX && r.X + r.Width >= startX && r.Y <= startY && r.Y + r.Height >= startY) ||
                    (r.X <= endX && r.X + r.Width >= endX && r.Y <= endY && r.Y + r.Height >= endY)
                )
                .ToListAsync();
        }



        public async Task GenerateMockRectangles()
        {

            var data = await _context.Rectangles.FirstOrDefaultAsync();
            if (data != null) return;
            var rectangles = new List<Rectangle>
            {
                new Rectangle { X = 0, Y = 0, Width = 5, Height = 5 },
                new Rectangle { X = 2, Y = 2, Width = 6, Height = 6 },
            };
            await _context.Rectangles.AddRangeAsync(rectangles);
            await _context.SaveChangesAsync();
        }
    }
}