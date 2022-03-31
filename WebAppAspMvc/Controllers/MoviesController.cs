using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using AutoMapper;
using WebAppAspMvc.Client;
using WebAppAspMvc.Dtos;
using WebAppAspMvc.ViewModels;

namespace WebAppAspMvc.Controllers
{
    public class MoviesController : Controller
    {
        //private IHttpClientFactory _clientFactory;
        private ConfiguredClient _client;
        private readonly IMapper _mapper;

        public MoviesController(IHttpClientFactory clientFactory, IMapper mapper)
        {
            _client = new ConfiguredClient
            {
                ClientFactory = clientFactory
            };
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            HttpClient client = _client.CreateClient();

            var moviesDto = await GetMovies(client);

            if (moviesDto is null)
                return NotFound();

            var viewModel = new MoviesViewModel(moviesDto);

            return View(viewModel);
        }

        public async Task<IActionResult> Edit(int id)
        {
            HttpClient client = _client.CreateClient();

            MovieDto? movie = await GetMovie(client, id);
            IList<GenreDto>? genres = await GetGenres(client);

            if (movie is null || genres is null)
                return NotFound();

            var viewModel = new MovieEditViewModel(movie, genres);

            return View(viewModel);
        }

        public async Task<IActionResult> Update(MovieEditViewModel movie)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Edit", "Movies", new { id = movie.Id });
            }

            HttpClient client = _client.CreateClient();
            var genreDto = await GetGenre(client, movie.GenreId);

            var movieDto = _mapper.Map<MovieEditViewModel, MovieDto>(movie);
            movieDto.GenreDto = genreDto;

            var retrievedMovieDto = await UpdateMovie(client, movieDto.Id, movieDto);

            if (retrievedMovieDto is null)
                return BadRequest();

            return RedirectToAction("Index", "Movies");
        }

        [HttpGet]
        private async Task<IList<MovieDto>?> GetMovies(HttpClient client)
        {
            using (var response = await client.GetAsync("Movies"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var jsonData = await response.Content.ReadAsStringAsync();
                    var moviesDto = JsonConvert.DeserializeObject<IList<MovieDto>>(jsonData);

                    return moviesDto;
                }
                else
                {
                    return null;
                }
            }
        }

        [HttpGet]
        private async Task<MovieDto?> GetMovie(HttpClient client, int id)
        {
            using (var response = await client.GetAsync("Movies/" + id))
            {
                if (response.IsSuccessStatusCode)
                {
                    var jsonData = await response.Content.ReadAsStringAsync();
                    var movieDto = JsonConvert.DeserializeObject<MovieDto>(jsonData);

                    return movieDto;
                }
                else
                {
                    return null;
                }
            }
        }

        [HttpPut]
        private async Task<MovieDto?> UpdateMovie(HttpClient client, int id, MovieDto movieDto)
        {
            var jsonData = JsonConvert.SerializeObject(movieDto);

            using (HttpContent httpContent = new StringContent(jsonData))
            using (var response = await client.PutAsync("Movies/" + id, httpContent))
            {
                if (response.IsSuccessStatusCode)
                    return movieDto;
                else
                    return null;
            }
        }

        [HttpGet]
        private async Task<IList<GenreDto>?> GetGenres(HttpClient client)
        {
            using (var response = await client.GetAsync("Genres"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var jsonData = await response.Content.ReadAsStringAsync();
                    var genresDto = JsonConvert.DeserializeObject<IList<GenreDto>>(jsonData);

                    return genresDto;
                }
                else
                {
                    return null;
                }
            }
        }

        [HttpGet]
        private async Task<GenreDto?> GetGenre(HttpClient client, int id)
        {
            using (var response = await client.GetAsync("Genres/" + id))
            {
                if (response.IsSuccessStatusCode)
                {
                    var jsonData = await response.Content.ReadAsStringAsync();
                    var genreDto = JsonConvert.DeserializeObject<GenreDto>(jsonData);

                    return genreDto;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
