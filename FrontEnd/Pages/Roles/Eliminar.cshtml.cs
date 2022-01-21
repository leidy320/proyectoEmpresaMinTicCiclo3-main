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
       public class EliminarModel : PageModel
    {
        private readonly RepositorioRol _repoRol;
        public Rol Rol {get; set;}
        public bool RolEncontrado {get; set;}

        public EliminarModel(RepositorioRol _repoRol)
        {
            this._repoRol = _repoRol;
            RolEncontrado = true;
        }
        public IActionResult OnGet(int idRol)
        {
            Rol = _repoRol.ObtenerRol(idRol);
            if(Rol==null){
                RolEncontrado = false;
                return Page();
            }
            RolEncontrado = true;
            return Page();
        }

        public IActionResult OnPost(int idRol)
        {
            _repoRol.EliminarRol(idRol);
            return RedirectToPage("./ListaRoles");
        }
    }
}
