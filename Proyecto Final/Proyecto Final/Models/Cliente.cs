using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_Final.Models
{
    public class Cliente
    {
        public int ClienteID { get; set; }
        [Display(Name = "Cliente")]
        [MaxLength(20, ErrorMessage = "Maximo 20 valores")]
        [Column(TypeName= "varchar")]
        [Required(ErrorMessage ="Capture un nombre")]
        public string Nombre { get; set; }
        [Display(Name ="Apellidos")]
        [MaxLength(20)]
        [Required(ErrorMessage ="Capture los Apellidos")]
        public string Apellidos { get; set; }
        [Phone]
        [MaxLength(30)]
        [Required(ErrorMessage ="Capture el telefono")]
        public string Telefono { get; set; }
        [MaxLength(250)]
        [Required(ErrorMessage ="Capture una direccion")]
        public string Direccion { get; set; }
        [MaxLength(50)]
        [EmailAddress]
        [Required(ErrorMessage ="Capture su correo")]
        public string Email { get; set; }
       
        //public int FacturaID { get; set; }
    } 
}