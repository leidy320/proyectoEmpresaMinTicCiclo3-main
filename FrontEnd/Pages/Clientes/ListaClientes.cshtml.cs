using System.Net.Cache;
using System.Net;
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
    public class ListaClientesModel : PageModel
    {
        private readonly RepositorioCliente _repoCliente;
        private readonly RepositorioPersona _repoPersona;
        private readonly RepositorioEmpresa _repoEmpresa;
        public IEnumerable<Cliente> Clientes {get; set;}
        [BindProperty]
        public Persona Persona {get; set;}
        public string CriterioFiltro { get; set; }
        [BindProperty]
        public string TextoFiltro { get; set; }        

        public ListaClientesModel(RepositorioCliente _repoCliente, RepositorioPersona _repoPersona, RepositorioEmpresa _repoEmpresa)
        {
            this._repoCliente = _repoCliente;
            this._repoPersona = _repoPersona;
            this._repoEmpresa = _repoEmpresa;
        }
        //public void OnPost(){
        //}
        public string GetNombreEmpresa(int id){
            var empresa = _repoEmpresa.ObtenerEmpresa(id);
            return empresa.RazonSocial;
        }
        public Persona GetPersona(int id){
            return _repoPersona.ObtenerPersona(id);
        }
        public int CalcularEdad(DateTime fecha){
            return DateTime.Today.AddTicks(-fecha.Ticks).Year - 1;
        }

        public void OnGet(string CriterioFiltro, string TextoFiltro){
            if(String.IsNullOrEmpty(CriterioFiltro)||String.IsNullOrEmpty(TextoFiltro)){
                Clientes = _repoCliente.ObtenerTodosLosClientes();
                return;
            }
            else{
                switch (CriterioFiltro){
                    case "Todos los registros":
                        Clientes = _repoCliente.ObtenerTodosLosClientes();
                        break;
                    case "Por documento":
                        Clientes = _repoCliente.ObtenerClienteDocumento(TextoFiltro);
                        break;
                    case "Por nombres":
                        Clientes = _repoCliente.ObtenerClienteNombre(TextoFiltro);
                        break;
                    case "Por apellidos":
                        Clientes = _repoCliente.ObtenerClienteApellidos(TextoFiltro);
                        break;
                }
            }
        }        
    }
}