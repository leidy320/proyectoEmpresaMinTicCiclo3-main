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
     public class EditModel : PageModel
    {
        private readonly RepositorioEmpresa _repoEmpresa;
        [BindProperty]
        public Empresa Empresa {get; set;}

        public EditModel(RepositorioEmpresa _repoEmpresa)
        {
            this._repoEmpresa = _repoEmpresa;
        }
        public IActionResult OnGet(int empresaId)
        {
            Empresa = _repoEmpresa.ObtenerEmpresa(empresaId);
            if (Empresa == null)
            {
                return RedirectToPage("./NotFound");
            }
            else
            {
                return Page();
            }
        }
        public Empresa GetEmpresa(int id){
            return _repoEmpresa.ObtenerEmpresa(id);
        }

        public IActionResult OnPost()
        {
            Empresa = _repoEmpresa.ActualizarEmpresa(Empresa);
            return RedirectToPage("./List");
        }
    }
}