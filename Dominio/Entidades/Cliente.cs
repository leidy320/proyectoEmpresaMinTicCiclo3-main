using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades
{
    public class Cliente
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El telefono es necesario")]
        [StringLength(15, ErrorMessage = "No puede tener mas de 15 caracteres")]
        public string Telefono { get; set; }
        public int PersonaId { get; set; }
        public virtual Persona Persona {get; set;}
    }
}