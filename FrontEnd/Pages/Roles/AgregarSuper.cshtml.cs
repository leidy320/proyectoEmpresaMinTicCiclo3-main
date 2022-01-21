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
       public class AgregarSuperModel : PageModel
    {
        private readonly RepositorioRol _repoRol;
        [BindProperty]
        public Rol Rol {get; set;}

        public AgregarSuperModel(RepositorioRol _repoRol)
        {
            this._repoRol = _repoRol;
        }
        public IActionResult OnGet()
        {
            Rol = new Rol();
            return Page();
        }

        public IActionResult OnPost()
        {
            if(ModelState.IsValid)
            {
                Rol.EsSuperAdmin = true;
                Rol.Ingresar = true;
                Rol.Modificar = true;
                Rol.Eliminar = true;
                Rol.Consultar = true;
                Rol = _repoRol.AgregarRol(Rol);
                return RedirectToPage("./ListaRoles");
            }
            return OnGet();
        }
    }
}
