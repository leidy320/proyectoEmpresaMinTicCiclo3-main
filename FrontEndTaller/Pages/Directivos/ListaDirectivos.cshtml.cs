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
    public class ListaDirectivosModel : PageModel
    {
        private readonly RepositorioDirectivo _repoDirectivo;
        public IEnumerable<Directivo> Directivos {get; set;}

        public ListaDirectivosModel(RepositorioDirectivo _repoDirectivo)
        {
            this._repoDirectivo = _repoDirectivo;
        }

        public void OnGet()
        {
            Directivos = _repoDirectivo.ObtenerTodosLosDirectivos();
        }
    }
}
