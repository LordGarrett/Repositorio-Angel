using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Proyecto_Final.Models
{
    public class Componentes
    {
        public int ComponentesID { get; set; }
        public int ComputadoraID { get; set; }
        [Display(Name = "Microprocesador")]
        [MaxLength(50, ErrorMessage = "Maximo 50 valores")]
        [Column(TypeName = "varchar")]
        [Required(ErrorMessage = "Capture un componente")]
        public string Microprocesador { get; set; }
        [Display(Name ="Memoria Ram")]
        [MaxLength(50, ErrorMessage = "Maximo 50 valores")]
        [Column(TypeName = "varchar")]
        [Required(ErrorMessage = "Capture un componente")]
        public string Ram { get; set; }
        [Display(Name = "Placa Madre")]
        [MaxLength(50, ErrorMessage = "Maximo 50 valores")]
        [Column(TypeName = "varchar")]
        [Required(ErrorMessage = "Capture un componente")]
        public string PlacaMadre { get; set; }
        [Display(Name = "Almacenamiento")]
        [MaxLength(50, ErrorMessage = "Maximo 50 valores")]
        [Column(TypeName = "varchar")]
        [Required(ErrorMessage = "Capture un componente")]
        public string Almacenamiento { get; set; }
        [Display(Name = "Tarjeta de video")]
        [MaxLength(50, ErrorMessage = "Maximo 50 valores")]
        [Column(TypeName = "varchar")]
        [Required(ErrorMessage = "Capture un componente")]
        public string TarjetaVideo { get; set; }
        [Display(Name = "Gabinete")]
        [MaxLength(50, ErrorMessage = "Maximo 50 valores")]
        [Column(TypeName = "varchar")]
        [Required(ErrorMessage = "Capture un componente")]
        public string Gabinete { get; set; }
        [Display(Name = "Fuente de poder")]
        [MaxLength(50, ErrorMessage = "Maximo 50 valores")]
        [Column(TypeName = "varchar")]
        [Required(ErrorMessage = "Capture un componente")]
        public string FuenteDePoder { get; set; }
    }
}