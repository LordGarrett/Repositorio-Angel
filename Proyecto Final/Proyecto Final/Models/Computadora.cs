using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Proyecto_Final.Models
{
    public class Computadora
    {
        public int ComputadoraID { get; set; }
        [Display(Name = "Computadora")]
        [MaxLength(35, ErrorMessage = "Maximo 35 valores")]
        [Column(TypeName = "varchar")]
        [Required(ErrorMessage = "Capture una Computadora")]
        public string Nombre { get; set; }
        [Display(Name = "Componentes ID")]
        [Required(ErrorMessage="Capture un componente")]
        public int ComponentesID { get; set; }
        [Display(Name = "Precio")]
        
        [Required(ErrorMessage = "Capture un Precio")]
        public decimal Precio { get; set; }
        //public int ProvedorID { get; set; }
        
    }
}