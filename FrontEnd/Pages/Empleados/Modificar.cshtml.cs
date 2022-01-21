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

namespace FrontEnd.Pages.Empleados
{
    [Authorize]
     public class ModificarModel : PageModel
    {
        private readonly RepositorioEmpleado _repoEmpleado;
        private readonly RepositorioPersona _repoPersona;
        private readonly RepositorioEmpresa _repoEmpresa;
        [BindProperty]
        public Persona Persona {get; set;}
        [BindProperty]
        public Empleado Empleado {get; set;}
        public IEnumerable<Empresa> Empresas {get; set;}
        public Empresa Empresa {get; set;}
        public bool EmpleadoEncontrado {get; set;}
        [BindProperty]
        public string RazonSocial {get; set;}
        public ModificarModel(RepositorioEmpleado _repoEmpleado, RepositorioPersona _repoPersona, RepositorioEmpresa _repoEmpresa)
        {
            this._repoEmpleado = _repoEmpleado;
            this._repoPersona = _repoPersona;
            this._repoEmpresa = _repoEmpresa;
            EmpleadoEncontrado = true;
        }
        public IActionResult OnGet(int idEmpleado)
        {
            Empleado = _repoEmpleado.ObtenerEmpleado(idEmpleado);
            if(Empleado==null){
                EmpleadoEncontrado = false;
                //Console.WriteLine("Empleado no encontrado");
                return Page();
            }
            Persona = _repoPersona.ObtenerPersona(Empleado.PersonaId);
            if(Persona==null){
                EmpleadoEncontrado = false;
                //Console.WriteLine("Persona no encontrado");
                return Page();
            }
            Empresa = _repoEmpresa.ObtenerEmpresa(Persona.EmpresaId);
            if(Empresa==null){
                EmpleadoEncontrado = false;
                //Console.WriteLine("Empresa no encontrado");
                return Page();
            }
            Empresas = _repoEmpresa.ObtenerEmpresas();
            EmpleadoEncontrado = true;
            return Page();
        }

        public IActionResult OnPost(int idEmpleado)
        {
            if(ModelState.IsValid)
            {
                Empresa = _repoEmpresa.ObtenerEmpresaPorRazonSocial(RazonSocial);
                Persona.Empresa = Empresa;
                Persona = _repoPersona.ActualizarPersona(Persona);
                Empleado.Persona = Persona;
                Empleado = _repoEmpleado.ActualizarEmpleado(Empleado);
                return RedirectToPage("./ListaEmpleados");
            }
            return OnGet(idEmpleado);
        }
    }
}
