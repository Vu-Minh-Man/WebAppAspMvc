using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppAspMvc.Models
{
    public class Genre
    {
        public byte Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

    }
}
