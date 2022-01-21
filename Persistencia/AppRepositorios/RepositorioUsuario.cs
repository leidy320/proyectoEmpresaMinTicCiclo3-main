using System;
using System.Linq;
using System.Collections.Generic;
using Dominio.Entidades;

namespace Persistencia.AppRepositorios
{
    public class RepositorioUsuario : IRepositorioUsuario
    {
        private readonly AppContext appContext;
        public RepositorioUsuario(AppContext appContext)
        {
            this.appContext = appContext;
        }

        public Usuario ActualizarUsuario(Usuario usuario)
        {
            var usuario_encontrado = appContext.Usuarios.FirstOrDefault(u => u.Id == usuario.Id);
            if (usuario_encontrado != null)
            {
                usuario_encontrado.NombreUsuario = usuario.NombreUsuario;
                usuario_encontrado.Clave = usuario.Clave;
                usuario_encontrado.Correo = usuario.Correo;
                usuario_encontrado.Rol = usuario.Rol;
                appContext.SaveChanges();
            }
            return usuario_encontrado;
        }

        public Usuario AgregarUsuario(Usuario usuario)
        {
            var usuario_agregar = appContext.Usuarios.Add(usuario);
            appContext.SaveChanges();
            return usuario_agregar.Entity;
        }

        public void EliminarUsuario(int idUsuario)
        {
            var usuario_encontrado = appContext.Usuarios.FirstOrDefault(u => u.Id == idUsuario);
            if (usuario_encontrado == null)
                return;
            appContext.Usuarios.Remove(usuario_encontrado);

            appContext.SaveChanges();
        }

        public Usuario ObtenerUsuario(int idUsuario)
        {
            return appContext.Usuarios.FirstOrDefault(u => u.Id == idUsuario);
        }

        public IEnumerable<Usuario> ObtenerTodosLosUsuarios()
        {
            return appContext.Usuarios;
        }

        public IEnumerable<Usuario> ObtenerUsuarioNombre(string nombre)
        {
            return appContext.Usuarios.Where(u => u.NombreUsuario.Contains(nombre)).ToList();
        }

        public IEnumerable<Usuario> ObtenerUsuarioCorreo(string correo)
        {
            return appContext.Usuarios.Where(u => u.Correo.Contains(correo)).ToList();
        }

        public IEnumerable<Usuario> ObtenerUsuarioRol(string rol)
        {
            return appContext.Usuarios.Where(u => u.Rol.Nombre.Contains(rol)).ToList();
        }

        public IEnumerable<Usuario> ObtenerUsuarioTipoAdmin()
        {
            return appContext.Usuarios.Where(u => u.Rol.EsSuperAdmin == false).ToList();
        }

        public IEnumerable<Usuario> ObtenerUsuarioTipoAdminSistema()
        {
            return appContext.Usuarios.Where(u => u.Rol.EsSuperAdmin == true).ToList();
        }
    }
}