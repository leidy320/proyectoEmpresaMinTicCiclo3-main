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
       public class DetallesModel : PageModel
    {
        private readonly RepositorioRol _repoRol;
        public Rol Rol {get; set;}
        public bool RolEncontrado {get; set;}

        public DetallesModel(RepositorioRol _repoRol)
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
    }
}
