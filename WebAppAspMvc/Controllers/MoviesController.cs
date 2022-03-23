using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebAppAspMvc.Client;
using WebAppAspMvc.Dtos;
using WebAppAspMvc.ViewModels;

namespace WebAppAspMvc.Controllers
{
    public class MoviesController : Controller
    {
        //private IHttpClientFactory _clientFactory;

        public MoviesController(IHttpClientFactory clientFactory)
        {
            ConfiguredClient.ClientFactory = clientFactory;
        }

        public async Task<IActionResult> Index()
        {
            IList<MovieDto>? movies = null;

            HttpClient client = ConfiguredClient.CreateClient();

            using (var response = await client.GetAsync("Movies"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var jsonData = await response.Content.ReadAsStringAsync();
                    movies = JsonConvert.DeserializeObject<List<MovieDto>>(jsonData);
                }
            }

            var viewModel = new MoviesViewModel(movies);

            return View(viewModel);
        }

        public async Task<IActionResult> Details(int id)
        {
            MovieDto? movie = null;

            HttpClient client = ConfiguredClient.CreateClient();

            using (var response = await client.GetAsync("Movies/" + id))
            {
                if (response.IsSuccessStatusCode)
                {
                    var jsonData = await response.Content.ReadAsStringAsync();
                    movie = JsonConvert.DeserializeObject<MovieDto>(jsonData);
                }
                else
                {
                    return NotFound();
                }
            }

            var viewModel = new MovieDetailsViewModel(movie);

            return View(viewModel);
        }

    }
}
