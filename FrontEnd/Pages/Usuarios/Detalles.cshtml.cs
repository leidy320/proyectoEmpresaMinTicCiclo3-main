using System;
using System.Collections.Generic;
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
    public class DetallesModel : PageModel
    {
        private readonly RepositorioUsuario _repoUsuario;
        private readonly RepositorioRol _repoRol;
        public Usuario Usuario {get; set;}
        public Rol Rol {get; set;}
        public bool UsuarioEncontrado {get; set;}
        public DetallesModel(RepositorioUsuario _repoUsuario, RepositorioRol _repoRol)
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
            UsuarioEncontrado = true;
            return Page();
        }
    }
}
