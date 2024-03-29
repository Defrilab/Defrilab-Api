using AspNetCoreRateLimit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ReaiotBackend.Data;
using ReaiotBackend.Dtos;
using ReaiotBackend.Hubs;
using ReaiotBackend.IRepositories;
using ReaiotBackend.Models;
using ReaiotBackend.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace ReaiotBackend
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<ReaiotDbContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<AppUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 5;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;

            })
              .AddEntityFrameworkStores<ReaiotDbContext>()
              .AddDefaultTokenProviders();

            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Key);
           
            services.AddAuthentication(au =>
            {
                au.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                au.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                au.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(jwt =>
            {
                jwt.RequireHttpsMetadata = false;
                jwt.SaveToken = true;
                jwt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidIssuer = "Reaiot.com",
                    ClockSkew = TimeSpan.Zero
                };
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Defrisoft",
                        Version = "v1",
                        Contact = new OpenApiContact()
                        {
                            Email = "defrisoft@infor.com",
                            Name = "infor defrisoft support",
                            Url = new Uri("http://defrisoft.com/contact"),
                            
                        },

                        //change this to valid uri
                        TermsOfService = new Uri("http://defrisoft.com/legal/terms_conditions"),

                        // change this to better license
                        License = new OpenApiLicense()
                        {
                            Name = "MIT Licence",
                            Url = new Uri("http://defrisoft.com/legal/licence")
                        },
                        Description = "This Swagger  UI is for documentation for all Defrisoft " +
                                      "services that need backend, either data storage like Mobile apps, " +
                                      "email services for communication with our customers and partners, " +
                                      "messaging services and solutions that require analysis like computer " +
                                      "vision or Natural Language Processing. To use the API, create an account " +
                                      "in the User section at ' /api/User/register'. Copy the response string and click on the 'Authorize' " +
                                      "button just below this documentation. If you already have an account created, " +
                                      "go to '/api/User/authenticateUser' part of the User section. Click on 'Try it out', insert your " +
                                      "email and password without changing anything else. Click on Authorize " +
                                      "button below this documentation. In the box(entry) provided insert the token " +
                                      "in the format 'Bearer tokenitself', click on Authorize, then close and start using the service. " +
                                      "Cheers with Defrisoft!"
                    }) ;
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                         new OpenApiSecurityScheme
                         {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,

                         },
                         new List<string>()
                    }
                });
            });

            services.AddOptions();
            services.AddMemoryCache();
            services.Configure<IpRateLimitOptions>(Configuration.GetSection("IPRateLimit"));
            services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
            services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
            services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
            services.AddHttpContextAccessor();

            services.AddTransient<IHelpRepository, HelpRepository>();
            services.AddTransient<IMessagesRepository, MessagesRepository>();
            services.AddTransient<ISubscriberRepository, SubscriberRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IAppointmentRepository, AppointmentRepository>();
            services.AddTransient<IRtgsmsRepository, RtgsmsRepository>();
           
            services.AddControllers();         
            services.AddSignalR();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, 
                 UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            IdentityDbInitializer.SeedData(userManager, roleManager).Wait();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Defrisoft");
                c.RoutePrefix = string.Empty;
            });
            app.UseIpRateLimiting();
            app.UseRouting();
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<AnnouncementsHub>("/announcementsHub");
                endpoints.MapHub<ChatHub>("/chatHub");
                endpoints.MapHub<NotificationsHub>("/notificationsHub");
            });
            app.Run(async (context) => await Task.Run(() => context.Response.Redirect("/swagger")));
        }
    }
}
