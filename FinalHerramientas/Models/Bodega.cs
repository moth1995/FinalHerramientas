﻿namespace FinalHerramientas.Models
{
    public class Bodega
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Pais { get; set; }
        public string Region { get; set; }

        public List<Vino>? Vinos { get; set; }
    }

}
