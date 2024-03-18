using System.ComponentModel.DataAnnotations;

namespace PeliculasAPi.DTOs
{
    public class GeneroDto
    {

        public int id { get; set; }

        [Required]
        public string nombre { get; set; }
    }
}
