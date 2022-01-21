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

namespace FrontEnd.Pages.Clientes
{   
    [Authorize]
    public class ModificarModelCliente : PageModel
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
        public bool ClienteEncontrado {get; set;}
        [Required(ErrorMessage = "La razon social es necesaria")]
        [StringLength(50, ErrorMessage = "No puede tener mas de 50 caracteres")]
        [BindProperty]
        public string RazonSocial {get; set;}
        public ModificarModelCliente(RepositorioCliente _repoCliente, RepositorioPersona _repoPersona, RepositorioEmpresa _repoEmpresa)
        {
            this._repoCliente = _repoCliente;
            this._repoPersona = _repoPersona;
            this._repoEmpresa = _repoEmpresa;
            ClienteEncontrado = true;
        }
        public IActionResult OnGet(int idCliente)
        {
            Cliente = _repoCliente.ObtenerCliente(idCliente);
            if(Cliente==null){
                ClienteEncontrado = false;
                //Console.WriteLine("Cliente no encontrado");
                return Page();
            }
            Persona = _repoPersona.ObtenerPersona(Cliente.PersonaId);
            if(Persona==null){
                ClienteEncontrado = false;
                //Console.WriteLine("Persona no encontrado");
                return Page();
            }
            Empresa = _repoEmpresa.ObtenerEmpresa(Persona.EmpresaId);
            if(Empresa==null){
                ClienteEncontrado = false;
                //Console.WriteLine("Empresa no encontrado");
                return Page();
            }
            Empresas = _repoEmpresa.ObtenerEmpresas();
            ClienteEncontrado = true;
            return Page();
        }

        public IActionResult OnPost(int idCliente)
        {
            if(ModelState.IsValid)
            {
                Empresa = _repoEmpresa.ObtenerEmpresaPorRazonSocial(RazonSocial);
                Persona.Empresa = Empresa;
                Persona = _repoPersona.ActualizarPersona(Persona);
                Cliente.Persona = Persona;
                Cliente = _repoCliente.ActualizarCliente(Cliente);
                return RedirectToPage("./ListaClientes");
            }
            return OnGet(idCliente);
        }
    }
}
