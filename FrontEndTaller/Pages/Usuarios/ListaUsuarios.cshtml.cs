using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio.Entidades;
using Persistencia.AppRepositorios;

namespace MyApp.Namespace
{
    public class ListaUsuariosModel : PageModel
    {
        private readonly RepositorioUsuario _repoUsuario;
        public IEnumerable<Usuario> Usuarios {get; set;}

        public ListaUsuariosModel(RepositorioUsuario _repoUsuario)
        {
            this._repoUsuario = _repoUsuario;
        }
        public void OnGet()
        {
            Usuarios = _repoUsuario.ObtenerTodosLosUsuarios();
        }
    }
}
