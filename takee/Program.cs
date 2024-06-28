using Microsoft.EntityFrameworkCore;
using takee.Application.Services;
using takee.Core.Interfaces.Repositories;
using takee.Core.Interfaces.Services;
using takee.DataAccess;
using takee.DataAccess.Mapping;
using takee.DataAccess.Repositories;

namespace takee
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAutoMapper(typeof(DataBaseMappings));

            builder.Services.AddDbContext<TakeeDbContext>(
                options => 
                {
                    options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(TakeeDbContext)));
                });

            builder.Services.AddScoped<IAnimalsService, AnimalsService>();
            builder.Services.AddScoped<IBreedsService, BreedsService>();
            builder.Services.AddScoped<ICuratorsService, CuratorsService>();
            builder.Services.AddScoped<IFavouritesService, FavouritesService>();
            builder.Services.AddScoped<IRecordsForWalkService, RecordsForWalkService>();
            builder.Services.AddScoped<ITypesOfAnimalsService, TypesOfAnimalsService>();
            builder.Services.AddScoped<IUserRolesService, UserRolesService>();
            builder.Services.AddScoped<IUsersService, UsersService>();

            builder.Services.AddScoped<IAnimalsRepository, AnimalsRepository>();
            builder.Services.AddScoped<IBreedsRepository, BreedsRepository>();
            builder.Services.AddScoped<ICuratorsRepository, CuratorsRepository>();
            builder.Services.AddScoped<IFavouritesRepository, FavouritesRepository>();
            builder.Services.AddScoped<IRecordsForWalkRepository, RecordsForWalkRepository>();
            builder.Services.AddScoped<ITypesOfAnimalsRepository, TypesOfAnimalsRepository>();
            builder.Services.AddScoped<IUserRolesRepository, UserRolesRepository>();
            builder.Services.AddScoped<IUsersRepository, UsersRepository>();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.UseCors(x =>
            {
                x.WithHeaders().AllowAnyHeader();
                x.WithOrigins().AllowAnyOrigin();
                x.WithMethods().AllowAnyMethod();
            });

            app.Run();
        }
    }
}