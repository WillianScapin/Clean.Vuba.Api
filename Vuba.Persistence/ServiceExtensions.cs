using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Vuba.Domain.Entities;
using Vuba.Domain.Validators;
using Vuba.Domain.Interfaces;
using Vuba.Persistence.Context;
using Vuba.Persistence.Repositories;
using Amazon.S3;
using Amazon.Runtime;

namespace Vuba.Persistence
{
    public static class ServiceExtensions
    {
        public static void ConfigurePersistenceApp(this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = Environment.GetEnvironmentVariable("POSTGRESQLCONNSTR_DefaultConnection"); //configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<AppDbContext>(opt => opt.UseNpgsql(connectionString));
            services.AddScoped<IUnitOfWork, UnitiOfWork>();

            services.AddScoped<IJwtAuthenticationService, JwtAuthenticationService>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IEpisodeRepository, EpisodeRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<ILevelRepository, LevelRepository>();
            services.AddScoped<ILoginRepository, LoginRepository>();
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IMediaRepository, MediaRepository>();
            services.AddScoped<IProfileRepository, ProfileRepository>();
            services.AddScoped<IRatingRepository, RatingRepository>();
            services.AddScoped<ISeasonRepository, SeasonRepository>();
            services.AddScoped<ISeriesRepository, SerieRepository>();
            services.AddScoped<IAwsUploadReposotory, AwsUploadReposotory>();

            //Padrão é "Scoped"
            //services.AddValidatorsFromAssemblyContaining<AccountValidator>();
            //services.AddValidatorsFromAssemblyContaining<AccountValidator>(ServiceLifetime.Transient);

            //Recomendado é adicionar como Transient, é a meneira mais simples e segura
            services.AddTransient<IValidator<Account>, AccountValidator>();
            services.AddTransient<IValidator<Episode>, EpisodeValidator>();
            services.AddTransient<IValidator<Genre>, GenreValidator>();
            services.AddTransient<IValidator<Level>, LevelValidator>();
            services.AddTransient<IValidator<Movie>, MovieValidator>();
            services.AddTransient<IValidator<Profile>, ProfileValidator>();
            services.AddTransient<IValidator<Rating>, RatingValidator>();
            services.AddTransient<IValidator<Season>, SeasonValidator>();
            services.AddTransient<IValidator<Serie>, SerieValidator>();

            var awsOptions = configuration.GetAWSOptions("AWS");
            awsOptions.Credentials = new BasicAWSCredentials(
            //configuration.GetSection("AWS-AccessKey").Value,
            //configuration.GetSection("AWS-SecretKey").Value
            Environment.GetEnvironmentVariable("AWS-AccessKey"),
            Environment.GetEnvironmentVariable("AWS-SecretKey")
            );
            awsOptions.Region = Amazon.RegionEndpoint.USEast1;
            services.AddAWSService<IAmazonS3>(awsOptions);


            services.AddTransient<IAwsUploadReposotory>(provider =>
            {
                var s3Client = provider.GetRequiredService<IAmazonS3>();
                return new AwsUploadReposotory(s3Client);
            });

        }
    }
}
