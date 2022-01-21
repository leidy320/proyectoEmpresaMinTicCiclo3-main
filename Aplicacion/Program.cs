using System;
using Dominio;
using Persistencia;
using Persistencia.AppRepositorios;
using Dominio.Entidades;

namespace Aplicacion
{
    internal static class Program
    {
        private static readonly IRepositorioEmpresa _repoEmpresa =  new RepositorioEmpresa(new Persistencia.AppRepositorios.AppContext());
        private static readonly IRepositorioPersona _repoPersona =  new RepositorioPersona(new Persistencia.AppRepositorios.AppContext());
        private static readonly IRepositorioCliente _repoCliente =  new RepositorioCliente(new Persistencia.AppRepositorios.AppContext());
        private static readonly IRepositorioEmpleado _repoEmpleado =  new RepositorioEmpleado(new Persistencia.AppRepositorios.AppContext());
        private static readonly IRepositorioDirectivo _repoDirectivo =  new RepositorioDirectivo(new Persistencia.AppRepositorios.AppContext());
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello Team D Desarroladores!");
            Console.WriteLine("PRUEBAS DE CRUD");
            /**
                Descomentar el metodo segun la prueba que se quiera hacer
            **/
            //pruebaCrudAgregar();
            PruebaCrudConsultar();
            //pruebaCrudActualizar();
            //pruebaCrudEliminar();

        }

        public static void PruebaCrudEliminar(){
            Console.WriteLine("eliminar cliente id 2");
            _repoCliente.EliminarCliente(2);
            Console.WriteLine("eliminar persona id 2");
            _repoPersona.EliminarPersona(2);
        }

        public static void PruebaCrudConsultar(){
            Console.WriteLine("Consultar Empleados, datos:");
            Console.WriteLine("__________________________________");
            var empleados = _repoEmpleado.ObtenerTodosLosEmpleados();
            foreach(var empl in empleados){
                Console.WriteLine("ID: " + empl.Id);
                Console.WriteLine("Sueldo: " + empl.SueldoBruto);
                var persona = _repoPersona.ObtenerPersona(empl.PersonaId);
                Console.WriteLine("Nombre: " + persona.Nombre);
                Console.WriteLine("Primer Apellido: " + persona.PrimerApellido);
                Console.WriteLine("Segundo Apellido: " + persona.SegundoApellido);
                Console.WriteLine("Documento: " + persona.Documento);
                var empresa = _repoEmpresa.ObtenerEmpresa(persona.EmpresaId);
                Console.WriteLine("Trabaja en la empresa: " + empresa.RazonSocial + "   NIT: " + empresa.Nit);
                Console.WriteLine("__________________________________");
            }
        }
        private static void PruebaCrudAgregar()
        {
            // crear la empresa
            var empresa = new Empresa{
                RazonSocial = "Empresa ESTA SI",
                Nit = "90909090",
                Direccion = "CL 99 99 99"
            };
            Console.WriteLine("Agregar empresa");
            var emp = _repoEmpresa.AgregarEmpresa(empresa);

            var persona1 = new Persona{
                Nombre = "JUAN",
                PrimerApellido = "AAAA",
                SegundoApellido = "BBBB",
                FechaNacimiento = new DateTime(1999, 09, 09),
                Documento = "12121212",
                EmpresaId = emp.Id
            };
            Console.WriteLine("Agregar persona1 para cliente");
            var per1 = _repoPersona.AgregarPersona(persona1);

            var cliente = new Cliente{
                Telefono = "96369636",
                PersonaId = per1.Id
            };
            Console.WriteLine("Agregar cliente");
            _repoCliente.AgregarCliente(cliente);

            var persona2 = new Persona{
                Nombre = "ARTURO",
                PrimerApellido = "CCCCC",
                SegundoApellido = "VVVVV",
                FechaNacimiento = new DateTime(2000, 07, 07),
                Documento = "45454545",
                EmpresaId = empresa.Id
            };
            Console.WriteLine("Agregar persona 2 para empleado directivo");
            var per2 = _repoPersona.AgregarPersona(persona2);

            var empleado1 = new Empleado{
                SueldoBruto = 2500000,
                PersonaId = per2.Id
            };
            Console.WriteLine("Agregar empleado para directivo");
            var emp1 = _repoEmpleado.AdicionarEmpleado(empleado1);

            var directivo = new Directivo{
                Categoria = "DIRECTOR",
                EmpleadoId = emp1.Id
            };
            Console.WriteLine("Agregar directivo");
            _repoDirectivo.AgregarDirectivo(directivo);

            var persona3 = new Persona{
                Nombre = "LAURA",
                PrimerApellido = "SSSSSS",
                SegundoApellido = "DDDDDDDDD",
                FechaNacimiento = new DateTime(2002, 05, 08),
                Documento = "6666667777",
                EmpresaId = empresa.Id
            };
            Console.WriteLine("Agregar persona 3 para empleado");
            var per3 = _repoPersona.AgregarPersona(persona3);

            var empleado2 = new Empleado{
                SueldoBruto = 1600000,
                PersonaId = per3.Id
            };
            Console.WriteLine("Agregar empleado");
            _repoEmpleado.AdicionarEmpleado(empleado2);
        }
    }
}
