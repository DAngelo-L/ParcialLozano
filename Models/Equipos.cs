//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ExamenParcialLozano.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Equipos
    {
        public Equipos()
        {
            this.Jugadores = new HashSet<Jugadores>();
        }
    
        public int ID_Equipo { get; set; }
        [Display (Name ="Nombre equipo")]
        public string Nombre_Equipo { get; set; }
        [Display(Name = "Ciudad")]
        public string Ciudad { get; set; }
        [Display(Name = "Estadio")]
        public string Estadio { get; set; }
        [Display(Name = "Copas ganadas")]
        public Nullable<int> Copas_Ganadas { get; set; }
        

        public virtual ICollection<Jugadores> Jugadores { get; set; }
    }
}
