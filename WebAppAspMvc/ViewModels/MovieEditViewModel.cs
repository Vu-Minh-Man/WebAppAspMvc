using System.ComponentModel.DataAnnotations;
using WebAppAspMvc.Dtos;

namespace WebAppAspMvc.ViewModels
{
    public class MovieEditViewModel
    {
        public IEnumerable<GenreDto>? Genres { get; private set; }

        public int Id { get; set; }

        [StringLength(255)]
        public string Title { get; set; }

        [Display(Name = "Genre")]
        public byte GenreId { get; set; }

        [StringLength(1023)]
        public string? Description { get; set; }

        [Range(0.0, 5.0, ErrorMessage = "Rating must be between 0.0 and 5.0")]
        public float? Rating { get; set; }

        public MovieEditViewModel()
        {
        }

        public MovieEditViewModel(MovieDto movie, IEnumerable<GenreDto> genres)
        {
            Genres = genres;

            Id = movie.Id;
            Title = movie.Title;
            GenreId = movie.GenreDto.Id;
            Description = movie.Description;
            Rating = movie.Rating;
        }
    }
}
