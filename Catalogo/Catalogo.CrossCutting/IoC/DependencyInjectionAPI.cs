using Catalogo.Infra.Context;
using Catalogo.Application.Interfaces;
using Catalogo.Application.Mappings;
using Catalogo.Infra.Repositories;
using Catalogo.Application.Services;
using Catalogo.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace Catalogo.CrossCutting.IoC;

public static class DependencyInjectionAPI
{

    public static IServiceCollection AddInfrastructureAPI(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<ICategoriaRepository, CategoriaRepository>();
        services.AddScoped<IProdutoRepository, ProdutoRepository>();
        services.AddScoped<IProdutoService, ProdutoService>();
        services.AddScoped<ICategoriaService, CategoriaService>();

        services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

        return services;
    }
}
