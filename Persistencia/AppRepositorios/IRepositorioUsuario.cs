using System.Collections.Generic;
using Dominio.Entidades;

namespace Persistencia.AppRepositorios
{
    public interface IRepositorioUsuario
    {
        Usuario AgregarUsuario(Usuario usuario);
        Usuario ActualizarUsuario(Usuario usuario);
        void EliminarUsuario(int idUsuario);
        Usuario ObtenerUsuario(int idUsuario);
        IEnumerable<Usuario> ObtenerTodosLosUsuarios();
        IEnumerable<Usuario> ObtenerUsuarioNombre(string nombre);
        IEnumerable<Usuario> ObtenerUsuarioCorreo(string correo);
        IEnumerable<Usuario> ObtenerUsuarioRol(string rol);
        IEnumerable<Usuario> ObtenerUsuarioTipoAdmin();
        IEnumerable<Usuario> ObtenerUsuarioTipoAdminSistema();
    }
}