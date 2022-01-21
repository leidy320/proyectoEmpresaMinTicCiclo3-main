using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades
{
    public class Empresa
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "La razon social es necesaria.")]
        [StringLength(50, ErrorMessage = "No puede tener mas de 50 caracteres")]
        public string RazonSocial { get; set; }
        [Required(ErrorMessage = "El NIT es necesario.")]
        [StringLength(30, ErrorMessage = "No puede tener mas de 30 caracteres")]
        public string Nit { get; set; }
        [Required(ErrorMessage = "La direccion es necesaria.")]
        [StringLength(50, ErrorMessage = "No puede tener mas de 50 caracteres")]
        public string Direccion { get; set; }
    }
}