using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Proyecto_Final.Models
{
    public class Factura
    {
        public int FacturaID { get; set; }
        [Display(Name = "ID del producto")]
        public int ProductoID { get; set; }
        [Display(Name = "ID del Cliente")]
        public int ClienteID { get; set; }
        
        [MaxLength(150, ErrorMessage = "Maximo 150 valores")]
        [Column(TypeName = "varchar")]
        [Required(ErrorMessage = "Capture una descripcion")]
        public string Descripcion { get; set; }
        
        
        [Required(ErrorMessage = "Capture una cantidad")]
        public int Cantidad { get; set; }
        [Display(Name = "Precio Unitario")]
        [Required(ErrorMessage = "Capture un precio unitario")]
        public decimal PrecioUnitario { get; set; }
        
        [Required(ErrorMessage = "Capture un total")]
        public decimal Total { get; set; }

    }
}