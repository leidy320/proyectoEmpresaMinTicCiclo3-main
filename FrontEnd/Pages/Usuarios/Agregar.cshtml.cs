using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio.Entidades;
using Persistencia.AppRepositorios;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;

namespace MyApp.Namespace
{
    [Authorize]
    public class AgregarModel : PageModel
    {
        private readonly RepositorioUsuario _repoUsuario;
        private readonly RepositorioRol _repoRol;

        [BindProperty]
        public Usuario Usuario {get; set;}
        public Rol Rol {get; set;}
        public IEnumerable<Rol> Roles {get; set;}
        [Required(ErrorMessage = "El rol del usuario es necesario")]
        [BindProperty]
        public string NombreRol {get; set;}
        public AgregarModel(RepositorioUsuario _repoUsuario, RepositorioRol _repoRol)
        {
            this._repoUsuario = _repoUsuario;
            this._repoRol = _repoRol;
        }
        public IActionResult OnGet()
        {
            Usuario = new Usuario();
            Rol = new Rol();
            Roles = _repoRol.ObtenerTodosLosRoles();
            return Page();
        }

        public IActionResult OnPost()
        {
            if(ModelState.IsValid)
            {
                Rol = _repoRol.ObtenerRolPorNombre(NombreRol);
                Usuario.RolId = Rol.Id;
                Usuario = _repoUsuario.AgregarUsuario(Usuario);
                return RedirectToPage("./ListaUsuarios");
            }
            return OnGet();
        }
    }
}
