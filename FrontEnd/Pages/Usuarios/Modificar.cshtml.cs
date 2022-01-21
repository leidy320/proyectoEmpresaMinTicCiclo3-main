using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Persistencia.AppRepositorios;
using Microsoft.AspNetCore.Authorization;

namespace MyApp.Namespace
{
    [Authorize]
     public class ModificarModel : PageModel
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
        public bool UsuarioEncontrado {get; set;}
        public ModificarModel(RepositorioUsuario _repoUsuario, RepositorioRol _repoRol)
        {
            this._repoUsuario = _repoUsuario;
            this._repoRol = _repoRol;
            UsuarioEncontrado = true;
        }
        public IActionResult OnGet(int idUsuario)
        {
            Usuario = _repoUsuario.ObtenerUsuario(idUsuario);
            if(Usuario==null){
                UsuarioEncontrado = false;
                return Page();
            }
            Rol = _repoRol.ObtenerRol(Usuario.RolId);
            if(Rol==null){
                UsuarioEncontrado = false;
                return Page();
            }
            Roles = _repoRol.ObtenerTodosLosRoles();
            UsuarioEncontrado = true;
            return Page();
        }

        public IActionResult OnPost(int idUsuario)
        {
            if(ModelState.IsValid)
            {
                Rol = _repoRol.ObtenerRolPorNombre(NombreRol);
                Usuario.Rol = Rol;
                Usuario = _repoUsuario.ActualizarUsuario(Usuario);
                return RedirectToPage("./ListaUsuarios");
            }
            return OnGet(idUsuario);
        }
    }
}
