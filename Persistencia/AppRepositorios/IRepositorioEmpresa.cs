using System;
using Dominio;
using Dominio.Entidades;
using System.Collections.Generic;

namespace Persistencia.AppRepositorios
{
    public interface IRepositorioEmpresa
    {
        Empresa AgregarEmpresa(Empresa empresa);
        Empresa ActualizarEmpresa(Empresa empresa);
        void EliminarEmpresa(int idEmpresa);
        Empresa ObtenerEmpresa(int idEmpresa);
        IEnumerable<Empresa> ObtenerEmpresas();
        IEnumerable<Empresa> ObtenerEmpresasPorNit(string nit);
        IEnumerable<Empresa> ObtenerEmpresasPorRazonSocial(string razonSocial);
    }
}
