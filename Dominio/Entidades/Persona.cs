using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades
{
    public class Persona
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es necesario")]
        [StringLength(30, ErrorMessage = "No puede tener mas de 30 caracteres")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El primer apellido es necesario")]
        [StringLength(30, ErrorMessage = "No puede tener mas de 30 caracteres")]
        public string PrimerApellido { get; set; }
        [StringLength(30, ErrorMessage = "No puede tener mas de 30 caracteres")]
        public string SegundoApellido { get; set; }
        [Required(ErrorMessage = "La fecha de nacimiento es necesaria")]
        public DateTime FechaNacimiento { get; set; }
        [Required(ErrorMessage = "El documento es necesario")]
        [StringLength(30, ErrorMessage = "No puede tener mas de 30 caracteres")]
        public string Documento { get; set; }
        public int EmpresaId { get; set; }
        public virtual Empresa Empresa {get; set;}
    }
}