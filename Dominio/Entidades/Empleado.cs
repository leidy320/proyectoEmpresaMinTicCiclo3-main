using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades
{
    public class Empleado
    {
        public int Id {get; set;}
        [Required(ErrorMessage = "El monto del sueldo bruto es necesario")]
        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Valor invalido, maximo 2 decimales.")]
        [Range(0, 9999999999999999.99, ErrorMessage = "Valor invalido de debe ser mayor a 0; y no mas de 16 digitos y 2 decimales")]
        public decimal SueldoBruto { get; set; }
        public int PersonaId { get; set; }
        public virtual Persona Persona {get; set;}
    }
}