using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MatchmakerBotAPI.Core.Services.MatchmakerUsers;
using MatchmakerBotAPI.Core.Connectors.MatchmakerUsers;
using MatchmakerBotAPI.Core.Services.Guilds;
using MatchmakerBotAPI.Core.Connectors.Guilds;
using MatchmakerBotAPI.Core.Connectors.MongoDB;
using MatchmakerBotAPI.Core.Services.Teams;
using MatchmakerBotAPI.Core.Connectors.Teams;

namespace MatchmakerBotAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MatchmakerBotAPI", Version = "v1" , Description = "API for the matchmakerbot with routes for guilds, games and users."});
            });

            //Services
            services.AddScoped<IGuildsService, GuildsService>();
            services.AddScoped<IMatchmakerUsersService, MatchmakerUsersService>();
            services.AddScoped<ITeamsService, TeamsService>();

            //Connectors
            services.AddScoped<IMongoDBConnector, MongoDBConnector>();
            services.AddScoped<IMatchmakerUsersConnector, MatchmakerUsersConnector>();
            services.AddScoped<IGuildsConnector, GuildsCollector>();
            services.AddScoped<ITeamsConnector, TeamsConnector>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MatchmakerBotAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
