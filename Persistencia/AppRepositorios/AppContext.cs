using Microsoft.EntityFrameworkCore;
using Dominio.Entidades;

namespace Persistencia.AppRepositorios
{
    public class AppContext : DbContext
    {
        public DbSet<Persona> Personas {get;set;}
        public DbSet<Rol> Roles {get;set;}
        public DbSet<Usuario> Usuarios {get;set;}
        public DbSet<Empleado> Empleados {get;set;}
        public DbSet<Cliente> Clientes {get;set;}
        public DbSet<Empresa> Empresas {get;set;}
        public DbSet<Directivo> Directivos {get;set;}
        private const string connectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog = BDEmpresaTeamDDesarroladores;Integrated Security = True";
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            if(!optionsBuilder.IsConfigured){
                optionsBuilder
                .UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Usuario>().HasIndex(u => u.NombreUsuario).IsUnique();
            builder.Entity<Usuario>().HasIndex(u => u.Correo).IsUnique();
            builder.Entity<Persona>().HasIndex(p => p.Documento).IsUnique();
            builder.Entity<Empresa>().HasIndex(e => e.Nit).IsUnique();
        }
    }
}
/**
    __________________________________________________________________
    PARA GENERAR LA BASE DE DATOS:
    1. Abrir SQL Server Managment Studio y conectarse

    2. En el terminal de VS Code, pararse en la carpeta Persistencia

    cd Persistencia

    3. En el terminal ejecutar el siguiente comando
    
    dotnet ef database update --startup-project ..\Aplicacion\
    
    Y Listo.....
    __________________________________________________________________

    Si no funciona y toca generar la migracion completa de nuevo (OJO solo si no funciona):
    1. Borrar toda la carpeta Migrations que esta dentro de Persistencia
    2. En el terminal de VS Code, pararse en la carpeta Persistencia
    3. En el terminal ejecutar el siguiente comando

    dotnet ef migrations add Entidades --startup-project ..\Aplicacion\

    4. En la clase que termina en Designer.cs dentro de la carpeta Migrations cambiar donde dice AppContext por
       Persistencia.AppRepositorios.AppContext

    5. En la clase que termina en Snapshot.cs dentro de la carpeta Migrations cambiar donde dice AppContext por
       Persistencia.AppRepositorios.AppContext

    6. En el terminal ejecutar el siguiente comando
    
    dotnet ef database update --startup-project ..\Aplicacion\
**/