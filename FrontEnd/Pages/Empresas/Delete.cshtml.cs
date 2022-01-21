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
     public class DeleteModel : PageModel
    {
        private readonly RepositorioEmpresa _repoEmpresa;
        public Empresa Empresa {get; set;}

        public DeleteModel(RepositorioEmpresa _repoEmpresa)
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

        public IActionResult OnPost(int empresaId)
        {
            _repoEmpresa.EliminarEmpresa(empresaId);
            return RedirectToPage("./List");
        }
        public Empresa GetEmpresa(int id){
            return _repoEmpresa.ObtenerEmpresa(id);
        }
    }
}