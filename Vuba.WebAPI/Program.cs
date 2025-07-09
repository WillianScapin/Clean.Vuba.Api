using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Vuba.Domain.Exceptions;
using Vuba.Persistence.Context;
using Vuba.WebAPI.Extensions;
using Vuba.Persistence;
using Vuba.Application.Services;
using System.Text.Json.Serialization;
using Vuba.WebAPI.Middleware;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Vuba.WebAPI
{
    public class Program
    {
        public static string _jwtSecret = "rbs38-8343fhye-64193-ndr27utrangplecy";

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            ConfigureBuilder(builder);

            var app = builder.Build();
            CreateDatabase(app);
            ConfigureApp(app);

            app.Run();
        }


        static void ConfigureBuilder(WebApplicationBuilder builder)
        {
            builder.Services.ConfigurePersistenceApp(builder.Configuration);
            builder.Services.ConfigureApplicationApp();
            //Configurando meu Cors
            builder.Services.ConfigureCorsPolicy();

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddMvc(options =>
            {
                options.Filters.Add(new ApiExceptionFilter());
            });


            ConfigSwagger(builder);
            //ConfigureCookie(builder);
            ConfigureJWT(builder);
        }


        //static void ConfigureCookie(WebApplicationBuilder builder)
        //{
        //    builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        //    .AddCookie(options =>
        //    {
        //        options.Cookie.Name = "JwtToken";
        //        options.LoginPath = "*";
        //        options.LogoutPath = "*";
        //    });

        //    builder.Services.AddControllers();
        //}

        static void ConfigureApp(WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            // Configuração do CORS deve vir antes do roteamento e autenticação
            app.UseCors();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseJwtCookieMiddleware();

            app.MapControllers();

            //======================= Configurações de Headers =======================//
            ConfigureHeaders(app);
        }


        static void ConfigureHeaders(WebApplication app)
        {
            app.Use(async (context, next) =>
            {
                context.Response.Headers.Add("Content-Security-Policy", "default-src 'self';");
                context.Response.Headers.Add("Permissions-Policy", "accelerometer=(), camera=(), geolocation=(), gyroscope=(), magnetometer=(), microphone=(), payment=(), usb=()");
                context.Response.Headers.Add("Referrer-Policy", "no-referrer");
                context.Response.Headers.Add("X-Content-Type-Options", "nosniff");
                context.Response.Headers.Add("X-Frame-Options", "DENY");

                if (app.Environment.IsProduction())
                {
                    context.Response.Headers.Add("Strict-Transport-Security", "max-age=31536000; includeSubDomains");
                }

                var allowedOrigins = new[] { "http://192.168.0.75:3000", "https://localhost:3000", "https://vuba.netlify.app/" };
                var origin = context.Request.Headers["Origin"].ToString();

                if (allowedOrigins.Contains(origin))
                {
                    context.Response.Headers.Add("Access-Control-Allow-Origin", origin);
                }
                // Substitua pelo seu domínio de frontend
                context.Response.Headers.Add("Access-Control-Allow-Credentials", "true");

                await next();

                await next();

            });
        }

        static void CreateDatabase(WebApplication app)
        {
            var serviceScope = app.Services.CreateScope();
            var dataContext = serviceScope.ServiceProvider.GetService<AppDbContext>();
            dataContext?.Database.EnsureCreated();
        }

        static void ConfigSwagger(WebApplicationBuilder builder)
        {
            builder.Services.AddSwaggerGen(c =>
            {
                c.IncludeXmlComments(Path.GetFullPath("CleanArchiteture.xml"));

                //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                //c.IncludeXmlComments(xmlPath);

                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Clean Vuba",
                    Version = "v1"
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                {
                    new OpenApiSecurityScheme {
                        Reference = new OpenApiReference {
                            Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                        }
                    },
                    new string[] {}
                }
                });
            });
        }


        static void ConfigureJWT(WebApplicationBuilder builder)
        {
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    //Defino minha cháve de criptografia
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSecret)),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = true
                };

                o.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        context.Token = context.Request.Cookies["JwtToken"];
                        return Task.CompletedTask;
                    }
                };

            });
        }


    }
}
