using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades
{
    public class Directivo
    {
        public int Id {set; get;}
        [Required(ErrorMessage = "La categoria es necesaria")]
        [StringLength(30, ErrorMessage = "No puede tener mas de 30 caracteres")]
        public string Categoria{get;set;}
        public int EmpleadoId { get; set; }
        public virtual Empleado Empleado {get; set;}
    }
}