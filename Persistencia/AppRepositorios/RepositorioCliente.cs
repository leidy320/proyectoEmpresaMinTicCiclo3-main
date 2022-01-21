using System;
using System.Linq;
using System.Collections.Generic;
using Dominio.Entidades;

namespace Persistencia.AppRepositorios
{
    public class RepositorioCliente : IRepositorioCliente
    {
        private readonly AppContext appContext;

        public RepositorioCliente(AppContext appContext){
            this.appContext = appContext;
        }

        public Cliente AgregarCliente(Cliente cliente){
            var clienteAdicionado = appContext.Clientes.Add(cliente);
            appContext.SaveChanges();
            return clienteAdicionado.Entity;
        }
        public Cliente ActualizarCliente(Cliente cliente){
            var clienteEncontrado = appContext.Clientes.FirstOrDefault(c => c.Id == cliente.Id);
            if(clienteEncontrado != null){
                clienteEncontrado.Telefono = cliente.Telefono;
                clienteEncontrado.Persona = cliente.Persona;
                appContext.SaveChanges();
            }
            return clienteEncontrado;
        }
        public void EliminarCliente(int idCliente){
            var clienteEncontrado = appContext.Clientes.FirstOrDefault(c => c.Id == idCliente);
            if(clienteEncontrado == null)
                return;
            appContext.Clientes.Remove(clienteEncontrado);
            appContext.SaveChanges();
        }
        public Cliente ObtenerCliente(int idCliente){
            return appContext.Clientes.FirstOrDefault(c => c.Id == idCliente);
        }
        public IEnumerable<Cliente> ObtenerTodosLosClientes(){
            return appContext.Clientes;
        }
        public IEnumerable<Cliente> ObtenerClienteDocumento(string documento){
            return appContext.Clientes.Where(e => e.Persona.Documento.Contains(documento)).ToList();
        }
        public IEnumerable<Cliente> ObtenerClienteNombre(string nombre){
            return appContext.Clientes.Where(e => e.Persona.Nombre.Contains(nombre)).ToList();
        }
        public IEnumerable<Cliente> ObtenerClienteApellidos(string apellidos){
            return appContext.Clientes.Where(e => e.Persona.PrimerApellido.Contains(apellidos)||e.Persona.SegundoApellido.Contains(apellidos)).ToList();
        }        
    }
}