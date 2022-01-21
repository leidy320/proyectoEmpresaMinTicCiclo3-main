using System.Collections.Generic;
using Dominio.Entidades;

namespace Persistencia.AppRepositorios
{
    public interface IRepositorioPersona
    {
        Persona AgregarPersona(Persona persona);
        Persona ActualizarPersona(Persona persona);
        void EliminarPersona(int idPersona);
        Persona ObtenerPersona(int idPersona);
        IEnumerable<Persona> ObtenerTodasLasPersonas();
    }
}