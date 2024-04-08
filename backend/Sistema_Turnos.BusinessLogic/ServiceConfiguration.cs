using Microsoft.Extensions.DependencyInjection;
using Sistema_Turnos.DataAccess;
using Sistema_Turnos.DataAccess.Repository;
using Sistema_Turnos.BusinessLogic.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema_Turnos.BusinessLogic.Services
{
    public static class ServiceConfiguration
    {
        public static void DataAccess(this IServiceCollection service, string conn)
        {
            service.AddScoped<DepartamentoRepository>();

            Sistemas_TurnosContext.BuildConnectionString(conn);
        }
        public static void BusinessLogic(this IServiceCollection service)
        {
            service.AddScoped<GeneralService>();
        }
    }
}
