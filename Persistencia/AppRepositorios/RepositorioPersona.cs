using System;
using System.Linq;
using System.Collections.Generic;
using Dominio.Entidades;

namespace Persistencia.AppRepositorios
{
    public class RepositorioPersona : IRepositorioPersona
    {
        private readonly AppContext appContext;
        public RepositorioPersona(AppContext appContext)
        {
            this.appContext = appContext;
        }

        public Persona AgregarPersona(Persona persona)
        {
            var persona_agregar = appContext.Personas.Add(persona);
            appContext.SaveChanges();
            return persona_agregar.Entity;
        }

        public Persona ActualizarPersona(Persona persona)
        {
            var persona_encontrada = appContext.Personas.FirstOrDefault(p => p.Id == persona.Id);
            if (persona_encontrada != null)
            {
                persona_encontrada.Nombre = persona.Nombre;
                persona_encontrada.PrimerApellido = persona.PrimerApellido;
                persona_encontrada.SegundoApellido = persona.SegundoApellido;
                persona_encontrada.FechaNacimiento = persona.FechaNacimiento;
                persona_encontrada.Documento = persona.Documento;
                persona_encontrada.Empresa = persona.Empresa;

                appContext.SaveChanges();
            }

            return persona_encontrada;
        }

        public void EliminarPersona(int idPersona)
        {
            var persona_encontrada = appContext.Personas.FirstOrDefault(p => p.Id == idPersona);
            if(persona_encontrada == null)
                return;
            appContext.Personas.Remove(persona_encontrada);

            appContext.SaveChanges();
        }

        public Persona ObtenerPersona(int idPersona)
        {
            return appContext.Personas.FirstOrDefault(p => p.Id == idPersona);
        }

        public IEnumerable<Persona> ObtenerTodasLasPersonas()
        {
            return appContext.Personas;
        }
    }
}