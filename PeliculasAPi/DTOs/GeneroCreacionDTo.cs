using System.ComponentModel.DataAnnotations;

namespace PeliculasAPi.DTOs
{
    public class GeneroCreacionDTo
    {
        [Required]
        public string nombre { get; set; }
    }
}
