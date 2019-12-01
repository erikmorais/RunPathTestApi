using Repositories.AlbumRepository;
using System.Net.Http;

namespace PhotoAlbumApi.IoCSettings
{
    public class AlbumRepositoryForIoC : AlbumRepository
    {
        public AlbumRepositoryForIoC(IHttpClientFactory httpClientFactory) : base(httpClientFactory.CreateClient("externalservice"))
        { }
    }

    public class PhotoRepositoryForIoC : PhotoRepository
    {
        public PhotoRepositoryForIoC(IHttpClientFactory httpClientFactory) : base(httpClientFactory.CreateClient("externalservice"))
        { }
    }
}
