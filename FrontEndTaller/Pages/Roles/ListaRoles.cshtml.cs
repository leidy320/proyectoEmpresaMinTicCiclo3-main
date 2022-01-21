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
    public class ListaRolesModel : PageModel
    {
        private readonly RepositorioRol _repoRol;
        public IEnumerable<Rol> Roles {get; set;}

        public ListaRolesModel(RepositorioRol _repoRol)
        {
            this._repoRol = _repoRol;
        }

        public void OnGet()
        {
            Roles = _repoRol.ObtenerTodosLosRoles();
        }
    }
}
