using System.Globalization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio.Entidades;
using Persistencia.AppRepositorios;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;

namespace FrontEnd.Pages.Directivos
{       
    [Authorize]
    public class AddModel : PageModel
    {
        private readonly RepositorioEmpleado _repoEmpleado;
        private readonly RepositorioPersona _repoPersona;
        private readonly RepositorioEmpresa _repoEmpresa;
        private readonly RepositorioDirectivo _repoDirectivo;
        [BindProperty]
        public Persona Persona {get; set;}
        [BindProperty]
        public Directivo Directivo {get; set;}
        [BindProperty]
        public Empleado Empleado{get; set;}
        public IEnumerable<Empresa> Empresas {get; set;}
        public Empresa Empresa {get; set;}
        [Required(ErrorMessage = "La razon social es necesaria.")]
        [StringLength(50, ErrorMessage = "No puede tener mas de 50 caracteres")]
        [BindProperty]
        public string RazonSocial {get; set;}
        public AddModel(RepositorioEmpleado _repoEmpleado, RepositorioPersona _repoPersona, RepositorioEmpresa _repoEmpresa, RepositorioDirectivo _repoDirectivo)
        {
            this._repoEmpleado = _repoEmpleado;
            this._repoPersona = _repoPersona;
            this._repoEmpresa = _repoEmpresa;
            this._repoDirectivo =_repoDirectivo;
        }
        public IActionResult OnGet()
        {
            Persona = new Persona();
            Empleado = new Empleado();
            Empresa = new Empresa();
            Directivo = new Directivo();
            Empresas = _repoEmpresa.ObtenerEmpresas();
            return Page();
        }

        public IActionResult OnPost()
        {
            if(ModelState.IsValid)
            {
                Empresa = _repoEmpresa.ObtenerEmpresaPorRazonSocial(RazonSocial);
                Persona.EmpresaId = Empresa.Id;
                Persona = _repoPersona.AgregarPersona(Persona);
                Empleado.PersonaId = Persona.Id;
                Empleado = _repoEmpleado.AdicionarEmpleado(Empleado);
                Directivo.EmpleadoId = Empleado.Id;
                Directivo = _repoDirectivo.AgregarDirectivo(Directivo);
                return RedirectToPage("./ListaDirectivos");
            }
            return OnGet();
        }
    }
}
