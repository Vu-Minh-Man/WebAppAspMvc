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
    public class MoviesController : ControllerBase
    {
        private readonly WebAppDbContext _context;
        private readonly IMapper _mapper;

        public MoviesController(WebAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET /api/Movies
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IList<MovieDto>))]
        public async Task<IActionResult> GetMovies()
        {
            IList<Movie> movies = await _context.Movies.Include(m => m.Genre).ToListAsync();

            var moviesDto = _mapper.Map<IList<Movie>, IList<MovieDto>>(movies);

            return Ok(moviesDto);
        }

        // GET /api/Movies/:id
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MovieDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetMovie(int id)
        {
            try
            {
                var movie = await _context.Movies.Include(m => m.Genre).SingleOrDefaultAsync(x => x.Id == id);

                if (movie is null)
                    return NotFound();

                var movieDto = _mapper.Map<Movie, MovieDto>(movie);

                return Ok(movieDto);
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

        // POST /api/Movies
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(MovieDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddMovie([FromBody] MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = _mapper.Map<MovieDto, Movie>(movieDto);
            await _context.Movies.AddAsync(movie);
            await _context.SaveChangesAsync();

            movieDto.Id = movie.Id;

            return CreatedAtAction("GetMovie", new { id = movie.Id }, movieDto);
        }

        // PUT /api/Movies/:id
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MovieDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateMovie(int id, [FromBody] MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                var movie = await _context.Movies.SingleOrDefaultAsync(x => x.Id == id);

                if (movie is null)
                    return NotFound();

                _mapper.Map(movieDto, movie);

                await _context.SaveChangesAsync();

                return Ok(movieDto);
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

        // DELETE /api/Movies/:id
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            try
            {
                var movie = await _context.Movies.SingleOrDefaultAsync(x => x.Id == id);

                if (movie is null)
                    return NoContent();

                _context.Movies.Remove(movie);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (ArgumentNullException ex)
            {
                return NoContent();
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
