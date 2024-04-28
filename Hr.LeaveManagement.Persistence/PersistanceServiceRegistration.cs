using Hr.LeaveManagement.Persistence.DatabseContext;
using Hr.LeaveManagement.Persistence.Repositories;
using HR.LeaveManagement.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hr.LeaveManagement.Persistence
{
    public static class PersistanceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<HRDatabaseContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("HRDatabaseConnectionString"));
            });

            // Adding Generic Repository
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(ILeaveTypeRepository), typeof(LeaveTypeRepository));
            services.AddScoped(typeof(ILeaveRequestRepository), typeof(LeaveRequestRepository));
            services.AddScoped(typeof(ILeaveAllocationRepository), typeof(LeaveAllocationRepository));

            return services;
        }
    }
}
