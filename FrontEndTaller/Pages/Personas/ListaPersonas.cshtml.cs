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
    public class ListaPersonasModel : PageModel
    {
        private readonly RepositorioPersona _repoPersona;
        public IEnumerable<Persona> Personas {get; set;}

        public ListaPersonasModel(RepositorioPersona _repoPersona)
        {
            this._repoPersona = _repoPersona;
        }
        public void OnGet()
        {
            Personas = _repoPersona.ObtenerTodasLasPersonas();
        }
    }
}