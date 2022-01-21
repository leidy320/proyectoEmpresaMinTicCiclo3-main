using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades
{
    public class Usuario
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre de usuario es necesario")]
        [StringLength(15, ErrorMessage = "Debe tener maximo 15 caracteres y minimo 3", MinimumLength = 3)]
        public string NombreUsuario { get; set; }
        [Required(ErrorMessage = "La contraseña es obligatoria")]
        [StringLength(15, ErrorMessage = "Debe tener entre 5 y 15 caracteres", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Clave { get; set; }
        [Required(ErrorMessage = "El correo electronico es necesario")]
        [DataType(DataType.EmailAddress)]
        public string Correo {get; set;}
        public string TokenRecuperacion {get;set;}
        public int RolId { get; set; }
        public virtual Rol Rol {get; set;}
    }
}