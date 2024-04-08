using Sistema_Turnos.DataAccess.Repository;
using Sistema_Turnos.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sistema_Turnos.BusinessLogic.Services
{
    public class AccesoServices
    {
        private readonly RolesRepository _rolesRepository;
        private readonly PantallaRepository _pantallaRepository;
        private readonly UsuarioRepository _usuarioRepository;
        public AccesoServices(RolesRepository rolesRepository, PantallaRepository pantallaRepository, UsuarioRepository usuarioRepository)
        {
            _rolesRepository = rolesRepository;
            _pantallaRepository = pantallaRepository;
            _usuarioRepository = usuarioRepository;
        }

        #region Roles

        public ServiceResult ListRol()
        {
            var result = new ServiceResult();
            try
            {
                var lost = _rolesRepository.List();
                return result.Ok(lost);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult ListPantalla()
        {
            var result = new ServiceResult();
            try
            {
                var lost = _pantallaRepository.List();
                return result.Ok(lost);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult InsertarRol(tbRoles item)
        {
            var result = new ServiceResult();
            try
            {
                var lost = _rolesRepository.Insert(item);
                if (lost.CodeStatus > 0)
                {
                    return result.Ok(lost);
                }
                else
                {
                    return result.Error(lost);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult ActualizarRol(tbRoles item)
        {
            var result = new ServiceResult();
            try
            {
                var lost = _rolesRepository.Update(item);
                if (lost.CodeStatus > 0)
                {
                    return result.Ok(lost);
                }
                else
                {
                    return result.Error(lost);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult InsertarPantallasPorRol(tbPantallasPorRoles item)
        {
            var result = new ServiceResult();
            try
            {
                var lost = _rolesRepository.InsertPantallasRoles(item);
                if (lost.CodeStatus > 0)
                {
                    return result.Ok(lost);
                }
                else
                {
                    return result.Error(lost);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult ObtenerId(string Rol, int usuario_creacion, DateTime fecha_creacion)
        {
            var result = new ServiceResult();
            try
            {
                var lost = _rolesRepository.findObtenerId(Rol, usuario_creacion, fecha_creacion);
                return result.Ok(lost);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult ObtenerRol(int Rol_Id)
        {
            var result = new ServiceResult();
            try
            {
                var lost = _rolesRepository.ObtenerRol(Rol_Id);
                return result.Ok(lost);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public IEnumerable<tbPantallasPorRoles> ObtenerPantallasPorRol(int id)
        {
            try
            {

                return _rolesRepository.BuscarPantallasPorRol(id);
            }
            catch (Exception ex)
            {

                return Enumerable.Empty<tbPantallasPorRoles>();
            }
        }

        public ServiceResult EliminarPantallaPorRol(int PaRo_Id)
        {
            var result = new ServiceResult();
            try
            {
                var lost = _rolesRepository.EliminarPantallaPorRol(PaRo_Id);
                if (lost.CodeStatus > 0)
                {
                    return result.Ok(lost);
                }
                else
                {
                    return result.Error(lost);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult EliminarRol(int Rol_Id)
        {
            var result = new ServiceResult();
            try
            {
                var lost = _rolesRepository.EliminarRol(Rol_Id);
                if (lost.CodeStatus > 0)
                {
                    return result.Ok(lost);
                }
                else
                {
                    return result.Error(lost);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        #endregion

        #region Usuarios
        public ServiceResult Login(string Usuario, string Contra)
        {
            var result = new ServiceResult();
            try
            {
                var lost = _usuarioRepository.Login(Usuario, Contra);
                return result.Ok(lost);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult ValidarUsuario(string Usuario)
        {
            var result = new ServiceResult();
            try
            {
                var lost = _usuarioRepository.ValidarUsuario(Usuario);
                return result.Ok(lost);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult ValidarClave(string Contra)
        {
            var result = new ServiceResult();
            try
            {
                var lost = _usuarioRepository.ValidarClave(Contra);
                return result.Ok(lost);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        #endregion

    }
}
