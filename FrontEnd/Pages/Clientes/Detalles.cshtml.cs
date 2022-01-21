using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio.Entidades;
using Persistencia.AppRepositorios;
using Microsoft.AspNetCore.Authorization;

namespace FrontEnd.Pages.Clientes
{
     [Authorize]
    public class DetallesModelCliente : PageModel
    {
        private readonly RepositorioCliente _repoCliente;
        private readonly RepositorioPersona _repoPersona;
        private readonly RepositorioEmpresa _repoEmpresa;
        public Persona Persona {get; set;}
        public Cliente Cliente {get; set;}
        public Empresa Empresa {get; set;}
        public bool ClienteEncontrado {get; set;}

        public DetallesModelCliente(RepositorioCliente _repoCliente, RepositorioPersona _repoPersona, RepositorioEmpresa _repoEmpresa)
        {
            this._repoCliente = _repoCliente;
            this._repoPersona = _repoPersona;
            this._repoEmpresa = _repoEmpresa;
            ClienteEncontrado = false;
        }
        public IActionResult OnGet(int idCliente)
        {
            Cliente = _repoCliente.ObtenerCliente(idCliente);
            if(Cliente==null){
                ClienteEncontrado = false;
                return Page();
            }
            Persona = _repoPersona.ObtenerPersona(Cliente.PersonaId);
            if(Persona==null){
                ClienteEncontrado = false;
                return Page();
            }
            Empresa = _repoEmpresa.ObtenerEmpresa(Persona.EmpresaId);
            if(Empresa==null){
                ClienteEncontrado = false;
                return Page();
            }
            ClienteEncontrado = true;
            return Page();
        }

        public int CalcularEdad(DateTime fecha)
        {
            return DateTime.Today.AddTicks(-fecha.Ticks).Year - 1;
        }
    }
}
