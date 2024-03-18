﻿using System.ComponentModel.DataAnnotations;

namespace PeliculasAPi.Entidades
{
    public class Genero
    {
        public int id { get; set; }

        [Required]
        public string nombre { get; set; }
    }
}
