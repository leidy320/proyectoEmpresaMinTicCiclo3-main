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

namespace FrontEnd.Pages.Clientes
{
    [Authorize]
    public class AgregarModelCliente : PageModel
    {
         private readonly RepositorioCliente _repoCliente;
        private readonly RepositorioPersona _repoPersona;
        private readonly RepositorioEmpresa _repoEmpresa;
        [BindProperty]
        public Persona Persona {get; set;}
        [BindProperty]
        public Cliente Cliente {get; set;}
        public IEnumerable<Empresa> Empresas {get; set;}
        public Empresa Empresa {get; set;}
        [Required(ErrorMessage = "La razon social es necesaria")]
        [StringLength(50, ErrorMessage = "No puede tener mas de 50 caracteres")]
        [BindProperty]
        public string RazonSocial {get; set;}
        public AgregarModelCliente(RepositorioCliente _repoCliente, RepositorioPersona _repoPersona, RepositorioEmpresa _repoEmpresa)
        {
            this._repoCliente = _repoCliente;
            this._repoPersona = _repoPersona;
            this._repoEmpresa = _repoEmpresa;
        }
        public IActionResult OnGet()
        {
            Persona = new Persona();
            Cliente = new Cliente();
            Empresa = new Empresa();
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
                Cliente.PersonaId = Persona.Id;
                Cliente = _repoCliente.AgregarCliente(Cliente);
                return RedirectToPage("./ListaClientes");
            }
            return OnGet();
        }
    }
}
