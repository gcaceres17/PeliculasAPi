using System.ComponentModel.DataAnnotations;

namespace PeliculasAPi.DTOs
{
    public class ActorDTo
    {
        public int Id { get; set; }
        [Required]
        public string nombre { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public string foto { get; set; }
    }
}
