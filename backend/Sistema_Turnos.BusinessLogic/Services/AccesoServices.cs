using Sistema_Turnos.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema_Turnos.BusinessLogic.Services
{
    public class AccesoServices
    {
        private readonly DepartamentoRepository _departamentoRepository1;
        //private readonly RolRepository _RolRepository;
        //private readonly PantallaRepository _pantallaRepository;
        public AccesoServices(DepartamentoRepository departamentoRepository/*, RolRepository RolRepository, PantallaRepository pantallaRepository*/)
        {
            _departamentoRepository1 = departamentoRepository;
            ////_RolRepository = RolRepository;
            ////_pantallaRepository = pantallaRepository;
        }
    }
}
