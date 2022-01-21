using System;
using Dominio;
using System.Collections.Generic;
using Dominio.Entidades;

namespace Persistencia.AppRepositorios
{
    public interface IRepositorioEmpleado
    {
        IEnumerable<Empleado> ObtenerTodosLosEmpleados();
         Empleado AdicionarEmpleado(Empleado empleado);
         void EliminarEmpleado(int idEmpleado);
         Empleado ActualizarEmpleado(Empleado empleado);
         Empleado BuscarEmpleadoDocumento(string documentoEmpleado);
         Empleado BuscarEmpleadoNombre(string nombreEmpleado);
         Empleado BuscarEmpleadoApellido(string apellidoEmpleado);
        Empleado ObtenerEmpleado(int id);
        IEnumerable<Empleado> ObtenerEmpleadosDocumento(string documento);
        IEnumerable<Empleado> ObtenerEmpleadosNombre(string nombre);
        IEnumerable<Empleado> ObtenerEmpleadosApellidos(string apellidos);
    }
}