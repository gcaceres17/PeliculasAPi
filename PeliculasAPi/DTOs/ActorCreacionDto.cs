using System.ComponentModel.DataAnnotations;

namespace PeliculasAPi.DTOs
{
    public class ActorCreacionDto
    {
        [Required]
        public string nombre { get; set; }

        public DateTime FechaNacimiento { get; set; }

    }
}
