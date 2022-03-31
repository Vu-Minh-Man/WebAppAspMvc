using System.ComponentModel.DataAnnotations;

namespace WebAppAspMvc.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [StringLength(255)]
        public string Title { get; set; }

        public GenreDto? GenreDto { get; set; }

        [StringLength(1023)]
        public string? Description { get; set; }

        [Range(0.0, 5.0, ErrorMessage = "Rating must be between 0.0 and 5.0")]
        public float? Rating { get; set; }
    }
}
