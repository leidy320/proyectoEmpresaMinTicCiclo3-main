using System;
using Dominio;
using System.Linq;
using System.Collections.Generic;
using Dominio.Entidades;

namespace Persistencia.AppRepositorios
{
    public class RepositorioEmpresa : IRepositorioEmpresa
    {
        private readonly AppContext _appContext;

        public RepositorioEmpresa(AppContext appContext)
        {
            this._appContext = appContext;
        }

        public Empresa ActualizarEmpresa(Empresa empresa)
        {
            var empresaEncontrada = _appContext.Empresas.FirstOrDefault(
                e => e.Id == empresa.Id
            );
            if(empresaEncontrada != null)
            {
                empresaEncontrada.RazonSocial = empresa.RazonSocial;
                empresaEncontrada.Nit = empresa.Nit;
                empresaEncontrada.Direccion = empresa.Direccion;
                _appContext.SaveChanges();
            }
            return empresaEncontrada;
        }

        public Empresa AgregarEmpresa(Empresa empresa)
        {
            var newEmpresa = _appContext.Empresas.Add(empresa);
            _appContext.SaveChanges();
            return newEmpresa.Entity;
        }

        public void EliminarEmpresa(int idEmpresa)
        {
            var empresaEncontrada = _appContext.Empresas.FirstOrDefault(
                e => e.Id == idEmpresa
            );
            if (empresaEncontrada == null)
                return;
            _appContext.Remove(empresaEncontrada);
            _appContext.SaveChanges();
        }

        public Empresa ObtenerEmpresa(int idEmpresa)
        {
            return _appContext.Empresas.FirstOrDefault(
                e => e.Id == idEmpresa
            );
        }
        public Empresa ObtenerEmpresaPorRazonSocial(string razon)
        {
            return _appContext.Empresas.FirstOrDefault(
                e => e.RazonSocial == razon
            );
        }
        public IEnumerable<Empresa> ObtenerEmpresas()
        {
            return _appContext.Empresas;
        }
        public IEnumerable<Empresa> ObtenerEmpresasPorNit(string nit)
        {
            return _appContext.Empresas.Where(e => e.Nit.Contains(nit)).ToList();
        }
        public IEnumerable<Empresa> ObtenerEmpresasPorRazonSocial(string razonSocial)
        {
            return _appContext.Empresas.Where(e => e.RazonSocial.Contains(razonSocial)).ToList();
        }
    }
}