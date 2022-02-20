using System;
using System.Collections.Generic;
using System.Text;
using ConstructionDiary.Contract;
using ConstructionDiary.Service;
using Lucile.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: Lucile.Extensions.DependencyInjection.ServiceConfiguration(typeof(Startup))]

namespace ConstructionDiary.Service
{
    public class Startup : IServiceConfiguration
    {
        public void Configure(IServiceCollection services)
        {
            services.AddScoped<IAreaService, AreaService>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IIssueService, IssueService>();
            services.AddScoped<IProjectService, ProjectService>();
        }
    }
}