using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio.Entidades;
using Persistencia.AppRepositorios;
using Microsoft.AspNetCore.Authorization;

namespace FrontEnd.Pages.Directivos
{ 
    [Authorize]    
    public class InfoModel : PageModel
    {    
    
        private readonly RepositorioEmpleado _repoEmpleado;
        private readonly RepositorioPersona _repoPersona;
        private readonly RepositorioEmpresa _repoEmpresa;
        private readonly RepositorioDirectivo _repoDirectivo;

        public Persona Persona {get; set;}
        public Empleado Empleado {get; set;}
        public Empresa Empresa {get; set;}
        public Directivo Directivo {get; set;}
        public bool DirectivoEncontrado {get; set;}

        public InfoModel(RepositorioEmpleado _repoEmpleado, RepositorioPersona _repoPersona, RepositorioEmpresa _repoEmpresa, RepositorioDirectivo _repoDirectivo)
        {
            this._repoEmpleado = _repoEmpleado;
            this._repoPersona = _repoPersona;
            this._repoEmpresa = _repoEmpresa;
            this._repoDirectivo = _repoDirectivo;
            DirectivoEncontrado = false;
        }
        public IActionResult OnGet(int idDirectivo)
        {
            Directivo = _repoDirectivo.ObtenerDirectivo(idDirectivo);
            if(Directivo==null){
                DirectivoEncontrado = false;
                return Page();
            }
            Empleado = _repoEmpleado.ObtenerEmpleado(Directivo.EmpleadoId);
            if(Empleado==null){
                DirectivoEncontrado = false;
                return Page();
            }
            Persona = _repoPersona.ObtenerPersona(Empleado.PersonaId);
            if(Persona==null){
                DirectivoEncontrado  = false;
                return Page();
            }
            Empresa = _repoEmpresa.ObtenerEmpresa(Persona.EmpresaId);
            if(Empresa==null){
                DirectivoEncontrado = false;
                return Page();
            }
            DirectivoEncontrado  = true;
            return Page();
        }
    }
}
