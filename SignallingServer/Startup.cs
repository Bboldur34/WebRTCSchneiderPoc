using Microsoft.AspNetCore.Http.Connections;
using SignallingServer.Hubs;
using SignallingServer.TurnServerProxies;

namespace SignallingServer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
            {
                builder
                    .SetIsOriginAllowed(_ => true)
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
            }));

            services.AddSignalR((options) =>
            {
                options.EnableDetailedErrors = true;
                options.ClientTimeoutInterval = TimeSpan.FromSeconds(10);
                options.KeepAliveInterval = TimeSpan.FromSeconds(3);
                options.HandshakeTimeout = TimeSpan.FromSeconds(10);
            }).AddMessagePackProtocol();

            services.AddSingleton<TurnServerProxyFactory>();
            services.AddSingleton<StunOnlyProxy>()
                .AddSingleton<ITurnServerProxy, StunOnlyProxy>(service => service.GetService<StunOnlyProxy>());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseStaticFiles();

            app.UseRouting();
            
            app.UseCors("CorsPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<RoomHub>("/roomhub", options =>
                {
                    options.AllowStatefulReconnects = true;
                    options.Transports = HttpTransportType.WebSockets | HttpTransportType.LongPolling;
                    options.TransportSendTimeout = TimeSpan.FromSeconds(10);
                    options.ApplicationMaxBufferSize = 1024 * 1024 * 10;

                });
            });
        }
    }
}
