using System.Collections.Generic;
using Dominio.Entidades;

namespace Persistencia.AppRepositorios
{
    public interface IRepositorioRol
    {
        Rol AgregarRol(Rol rol);
        Rol ActualizarRol(Rol rol);
        void EliminarRol(int idRol);
        Rol ObtenerRol(int idRol);
        Rol ObtenerRolPorNombre(string nombreRol);
        IEnumerable<Rol> ObtenerTodosLosRoles();
        IEnumerable<Rol> ObtenerRolNombre(string nombre);
        IEnumerable<Rol> ObtenerRolTipoAdminSistema();
        IEnumerable<Rol> ObtenerRolTipoAdmin();
    }
}