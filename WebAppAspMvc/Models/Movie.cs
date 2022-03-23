using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppAspMvc.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [StringLength(255)]
        public string Title { get; set; }

        //[ForeignKey("Genre")]
        [Display(Name = "Genre")]
        public byte GenreId { get; set; }
        public virtual Genre Genre { get; set; }

        [StringLength(1023)]
        public string? Description { get; set; }

        [Range(0.0, 5.0, ErrorMessage = "Rating must be between 0.0 and 5.0")]
        public float? Rating { get; set; }

    }
}
