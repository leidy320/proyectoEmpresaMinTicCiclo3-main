using System.Net.Http;
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
    public class ModificarModel : PageModel
    {
        private readonly RepositorioRol _repoRol;
        [BindProperty]
        public Rol Rol {get; set;}
        public bool RolEncontrado {get; set;}

        public ModificarModel(RepositorioRol _repoRol)
        {
            this._repoRol = _repoRol;
            RolEncontrado = false;
        }
        public IActionResult OnGet(int IdRol)
        {
            Rol = _repoRol.ObtenerRol(IdRol);
            if(Rol == null)
            {
                RolEncontrado = false;
                return Page();
            }
            RolEncontrado = true;
            return Page();
        }

        public IActionResult OnPost(int IdRol)
        {
            if(ModelState.IsValid)
            {
                Rol.EsSuperAdmin = false;
                Rol = _repoRol.ActualizarRol(Rol);
                return RedirectToPage("./ListaRoles");
            }
            return OnGet(IdRol);
        }
    }
}
