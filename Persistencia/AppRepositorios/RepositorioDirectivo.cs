using System;
using Dominio;
using Dominio.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace Persistencia.AppRepositorios
{
    public class RepositorioDirectivo : IRepositorioDirectivo
    {
        private readonly AppContext appContext;

        public RepositorioDirectivo(AppContext appContext)
        {
            this.appContext = appContext;
        }

        public Directivo AgregarDirectivo(Directivo directivo)
        {
            var directivoAdicionado = appContext.Directivos.Add(directivo);
            appContext.SaveChanges();
            return directivoAdicionado.Entity;
        }
        public Directivo ActualizarDirectivo(Directivo directivo)
        {
            var directivoEncontrado = appContext.Directivos.FirstOrDefault(d => d.Id == directivo.Id);
            if(directivoEncontrado != null){
                directivoEncontrado.Categoria= directivo.Categoria;
                directivoEncontrado.Empleado = directivo.Empleado;
                appContext.SaveChanges();
            }
            return directivoEncontrado;
        }
        public void EliminarDirectivo(int idDirectivo)
        {
            var directivoEncontrado = appContext.Directivos.FirstOrDefault(d => d.Id == idDirectivo);
            if(directivoEncontrado == null)
                return;
            appContext.Directivos.Remove(directivoEncontrado);
            appContext.SaveChanges();
        }
        public Directivo ObtenerDirectivo(int idDirectivo)
        {
            return appContext.Directivos.FirstOrDefault(d => d.Id == idDirectivo);
        }
        public IEnumerable<Directivo> ObtenerTodosLosDirectivos()
        {
            return appContext.Directivos;
        }
          public IEnumerable<Directivo> ObtenerDirectivoPorCategoria(string Categoria)
        {
            return appContext.Directivos.Where(e => e.Categoria.Contains(Categoria)).ToList();
        }
    }
}