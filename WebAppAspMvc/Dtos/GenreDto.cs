using System.ComponentModel.DataAnnotations;

namespace WebAppAspMvc.Dtos
{
    public class GenreDto
    {
        public byte Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

    }
}
