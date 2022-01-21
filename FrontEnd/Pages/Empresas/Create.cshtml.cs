using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio.Entidades;
using Persistencia.AppRepositorios;
using Microsoft.AspNetCore.Authorization;

namespace proyectoEmpresaMinTicCiclo3.FrontEnd.Pages
{
     [Authorize]
     public class CreateModel : PageModel
    {
        private readonly RepositorioEmpresa _repoEmpresa;
        [BindProperty]
        public Empresa Empresa {get; set;}

        public CreateModel(RepositorioEmpresa _repoEmpresa)
        {
            this._repoEmpresa = _repoEmpresa;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _repoEmpresa.AgregarEmpresa(Empresa);
            return RedirectToPage("./List");
        }
    }
}