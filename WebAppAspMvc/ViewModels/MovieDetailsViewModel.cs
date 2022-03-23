using WebAppAspMvc.Dtos;

namespace WebAppAspMvc.ViewModels
{
    public class MovieDetailsViewModel
    {
        public readonly MovieDto Movie;

        public MovieDetailsViewModel(MovieDto movie)
        {
            Movie = movie;
        }
    }
}
