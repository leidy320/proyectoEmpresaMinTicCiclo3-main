using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades
{
    public class Rol
    {
        public int Id {get; set;}
        [Required(ErrorMessage = "El nombre del rol es necesario")]
        [StringLength(30, ErrorMessage = "Debe tener minimo 3 caracteres y maximo de 30", MinimumLength = 5)]
        public string Nombre {get; set;}
        [Required]
        public bool Ingresar {get; set;}
        [Required]
        public bool Modificar {get; set;}
        [Required]
        public bool Consultar {get; set;}
        [Required]
        public bool Eliminar {get; set;}
        [Required]
        public bool EsSuperAdmin {get; set;}
    }
}