using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServicesContract.Interfaces;
using PhotoAlbumService;

namespace PhotoAlbumApi.IoCSettings
{
    public static class ServiceCollectionExtentions
    {
        public static IServiceCollection ConfigurePhotoAlbumService(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddHttpClient("externalservice", c =>
            {
                c.BaseAddress = new Uri(configuration.GetSection("AppSettings").GetValue<string>("PhotoAlbumUrlApi"));
            });

            serviceCollection.AddScoped<IAlbumRepository, AlbumRepositoryForIoC>();
            serviceCollection.AddScoped<IPhotoRepository, PhotoRepositoryForIoC>();
            serviceCollection.AddScoped<IAlbumServices, PhotoAlbumServices>();

            return serviceCollection;
        }
    }
}
