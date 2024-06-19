//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;
//using WoS_Server.Data;
using WoS_Server.Services;

public class Startup
{/*
    public void ConfigureServices(IServiceCollection services)
    {
        // Konfigurace DbContext pro použití InMemory databáze
        // services.AddDbContext<WoS_Db_Context>(options =>
        //    options.UseInMemoryDatabase("WoSDatabase"));

        services.AddGrpc();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if(env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapGrpcService<WoSServiceImpl>();
        });
    }*/
}
