using Microsoft.AspNetCore.Mvc;
using TestTask.Models;
using TestTask.Repositories;

namespace TestTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RectangleController : ControllerBase
    {
        private readonly IRectangleRepository _rectangleRepository;

        public RectangleController(IRectangleRepository rectangleRepository)
        {
            _rectangleRepository = rectangleRepository;
        }

        [HttpGet("Intersections")]
        public async Task<ActionResult<List<Rectangle>>> GetIntersectingRectangles(double startX, double startY, double endX, double endY)
        {
            await _rectangleRepository.GenerateMockRectangles();
            var rectangles = await _rectangleRepository.GetIntersectingRectanglesAsync(startX, startY, endX, endY);
            if (rectangles.Count == 0)
                return NotFound();
            return Ok(rectangles);
        }
    }
}