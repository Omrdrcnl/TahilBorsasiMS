using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using TahilBorsaJqeryAjax.Code.Filters;

namespace TahilBorsaJqeryAjax
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews()
                .AddFluentValidation();

            services.AddScoped<AuthActionFilter>();
        }

        
    }
}
