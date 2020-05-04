using AudioSwitcher.AudioApi.CoreAudio;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Speaker.Control.Interface;
using Speaker.Control.Services;

namespace Speaker.Http.Api
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
            services.AddMvc((options) =>
            {
                options.EnableEndpointRouting = false;
            })
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddSingleton(new CoreAudioController());
            services.AddTransient<ISpeakerService, SpeakerService>();
            services.AddTransient<IMachineService, MachineService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseMvc();
        }
    }
}