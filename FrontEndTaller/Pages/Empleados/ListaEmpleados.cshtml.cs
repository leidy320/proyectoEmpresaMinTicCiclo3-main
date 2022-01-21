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
    public class ListaEmpleadosModel : PageModel
    {
        private readonly RepositorioEmpleado _repoEmpleado;
        public IEnumerable<Empleado> Empleados {get; set;}

        public ListaEmpleadosModel(RepositorioEmpleado _repoEmpleado)
        {
            this._repoEmpleado = _repoEmpleado;
        }

        public void OnGet()
        {
            Empleados = _repoEmpleado.ObtenerTodosLosEmpleados();
        }
    }
}
