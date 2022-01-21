using System.Security.AccessControl;
using System.Collections.Generic;
using Dominio.Entidades;
namespace Persistencia.AppRepositorios
{
    public interface IRepositorioDirectivo
    {
        Directivo AgregarDirectivo(Directivo directivo);
        Directivo ActualizarDirectivo(Directivo directivo);
        void EliminarDirectivo(int idDirectivo);
        Directivo ObtenerDirectivo(int idDirectivo);
        IEnumerable<Directivo> ObtenerTodosLosDirectivos();
        IEnumerable<Directivo> ObtenerDirectivoPorCategoria(string Categoria);
    }
}
