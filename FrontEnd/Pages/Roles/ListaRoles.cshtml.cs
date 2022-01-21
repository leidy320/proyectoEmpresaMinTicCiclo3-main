using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Persistencia.AppRepositorios;
using Microsoft.AspNetCore.Authorization;
namespace FrontEnd.Pages.Roles
{
       [Authorize]
    public class ListaRolesModel : PageModel
    {
        private readonly RepositorioRol _repoRol;
        public IEnumerable<Rol> Roles {get; set;}
        [BindProperty]
        public string CriterioFiltro { get; set; }
        [BindProperty]
        public string TextoFiltro { get; set; }

        public ListaRolesModel(RepositorioRol _repoRol)
        {
            this._repoRol = _repoRol;
        }
        public void OnGet(string CriterioFiltro, string TextoFiltro)
        {
            if(String.IsNullOrEmpty(CriterioFiltro)||String.IsNullOrEmpty(TextoFiltro))
            {
                Roles = _repoRol.ObtenerTodosLosRoles();
            }
            else
            {
                switch (CriterioFiltro)
                {
                    case "Todos los registros":
                        Roles = _repoRol.ObtenerTodosLosRoles();
                    break;
                    case "Por nombre de rol":
                        Roles = _repoRol.ObtenerRolNombre(TextoFiltro);
                    break;
                    case "Admin de sistema":
                        Roles = _repoRol.ObtenerRolTipoAdminSistema();
                    break;
                    case "Admin de operativo":
                        Roles = _repoRol.ObtenerRolTipoAdmin();
                    break;
                }
            }
        }
    }
}
