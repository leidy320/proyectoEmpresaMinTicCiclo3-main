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

namespace FrontEnd.Pages.Empleados
{
     [Authorize]
     public class ListaEmpleadosModel : PageModel
    {
        private readonly RepositorioEmpleado _repoEmpleado;
        private readonly RepositorioPersona _repoPersona;
        private readonly RepositorioEmpresa _repoEmpresa;
        private readonly RepositorioDirectivo _repoDirectivo;
        public IEnumerable<Empleado> Empleados { get; set; }
        public IEnumerable<Directivo> Directivos { get; set; }
        [BindProperty]
        public string CriterioFiltro { get; set; }
        [BindProperty]
        public string TextoFiltro { get; set; }

        public ListaEmpleadosModel(RepositorioEmpleado _repoEmpleado, RepositorioPersona _repoPersona, RepositorioEmpresa _repoEmpresa, RepositorioDirectivo _repoDirectivo)
        {
            this._repoEmpleado = _repoEmpleado;
            this._repoPersona = _repoPersona;
            this._repoEmpresa = _repoEmpresa;
            this._repoDirectivo = _repoDirectivo;
        }
        public void OnGet(string CriterioFiltro, string TextoFiltro)
        {
            if(String.IsNullOrEmpty(CriterioFiltro)||String.IsNullOrEmpty(TextoFiltro))
            {
                Empleados = _repoEmpleado.ObtenerTodosLosEmpleados();
                return;
            }
            else
            {
                switch (CriterioFiltro)
                {
                    case "Todos los registros":
                        Empleados = _repoEmpleado.ObtenerTodosLosEmpleados();
                        break;
                    case "Por documento":
                        Empleados = _repoEmpleado.ObtenerEmpleadosDocumento(TextoFiltro);
                        break;
                    case "Por nombre":
                        Empleados = _repoEmpleado.ObtenerEmpleadosNombre(TextoFiltro);
                        break;
                    case "Por apellidos":
                        Empleados = _repoEmpleado.ObtenerEmpleadosApellidos(TextoFiltro);
                        break;
                }
            }
        }
        public string GetNombreEmpresa(int id)
        {
            var empresa = _repoEmpresa.ObtenerEmpresa(id);
            return empresa.RazonSocial;
        }

        public Persona GetPersona(int id)
        {
            return _repoPersona.ObtenerPersona(id);
        }

        public int CalcularEdad(DateTime fecha)
        {
            return DateTime.Today.AddTicks(-fecha.Ticks).Year - 1;
        }
    }
}
