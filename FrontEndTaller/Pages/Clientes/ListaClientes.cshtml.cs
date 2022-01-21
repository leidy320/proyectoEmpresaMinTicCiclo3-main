using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio.Entidades;
using Persistencia.AppRepositorios;

namespace MyApp.Namespace
{
    public class ListaClientesModel : PageModel
    {
        private readonly RepositorioCliente _repoCliente;
        public IEnumerable<Cliente> Clientes {get; set;}

        public ListaClientesModel(RepositorioCliente _repoCliente)
        {
            this._repoCliente = _repoCliente;
        }

        public void OnGet()
        {
            Clientes = _repoCliente.ObtenerTodosLosClientes();
        }
    }
}
