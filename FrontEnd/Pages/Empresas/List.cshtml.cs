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

namespace proyectoEmpresaMinTicCiclo3.FrontEnd.Pages
{
    [Authorize]
     public class ListModel : PageModel
    {
        private readonly RepositorioEmpresa _repoEmpresa;
        public IEnumerable<Empresa> Empresas {get; set;}
        public int Cantidad { get; set; }
        [BindProperty]
        public string CriterioFiltro { get; set; }
        [BindProperty]
        public string TextoFiltro { get; set; }
        public ListModel(RepositorioEmpresa _repoEmpresa)
        {
            this._repoEmpresa = _repoEmpresa;
        }
        public void OnGet(string CriterioFiltro, string TextoFiltro)
        {
            if(String.IsNullOrEmpty(CriterioFiltro)||String.IsNullOrEmpty(TextoFiltro))
            {
                Empresas = _repoEmpresa.ObtenerEmpresas();
                Cantidad = Math.Abs(Empresas.Count());
                return;
            }
            else
            {
                switch (CriterioFiltro)
                {
                    case "1":
                        Empresas = _repoEmpresa.ObtenerEmpresas();
                        Cantidad = Math.Abs(Empresas.Count());
                        break;
                    case "2":
                        Empresas = _repoEmpresa.ObtenerEmpresasPorNit(TextoFiltro);
                        Cantidad = Math.Abs(Empresas.Count());
                        break;
                    case "3":
                        Empresas = _repoEmpresa.ObtenerEmpresasPorRazonSocial(TextoFiltro);
                        Cantidad = Math.Abs(Empresas.Count());
                        break;
                }
            }
        }
    }
}