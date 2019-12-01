using NUnit.Framework;
using PhotoAlbumService;
using Repositories.AlbumRepository;
using System;
using System.Linq;
using System.Net.Http;

namespace Services_Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class Services
    {
        HttpClient httpClient;

        [SetUp]
        public void Setup()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://jsonplaceholder.typicode.com/");
        }

        [TestCase(15)]
        [Test]
        [Category("Integrated_Test")]
        public void Test_get_albums_fromService_integrated_test(int idAlbum)
        {
            // Arrange
            var albumRepository = new AlbumRepository(httpClient);
            var photoRepository = new PhotoRepository(httpClient);
            var photoService = new PhotoAlbumServices(albumRepository, photoRepository);

            // Act
            var resAll = photoService.AlbumsAsyn().Result;
            var resOne = photoService.AlbumsAsyn(a => a.Id == idAlbum).Result;

            // Assert
            Assert.True(resAll.Any());
            Assert.True(resOne.Count()==1);
        }
    }
}
