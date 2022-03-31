using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using WebAppAspMvc.Context;
using WebAppAspMvc.Models;
using WebAppAspMvc.Dtos;

namespace WebAppAspMvc.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly WebAppDbContext _context;
        private readonly IMapper _mapper;

        public GenresController(WebAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET /api/Genres
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IList<GenreDto>))]
        public async Task<IActionResult> GetGenres()
        {
            IList<Genre> genres = await _context.Genres.ToListAsync();

            var genresDto = _mapper.Map<IList<Genre>, IList<GenreDto>>(genres);

            return Ok(genresDto);
        }

        // GET /api/Genres/:id
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GenreDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetGenre(int id)
        {
            try
            {
                var genre = await _context.Genres.SingleOrDefaultAsync(x => x.Id == id);

                if (genre is null)
                    return NotFound();

                var genreDto = _mapper.Map<Genre, GenreDto>(genre);

                return Ok(genreDto);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
