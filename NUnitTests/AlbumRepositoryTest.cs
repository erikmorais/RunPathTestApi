using NUnit.Framework;
using System;
using System.Net.Http;
using Repositories.AlbumRepository;
using Moq.Protected;
using System.Linq;
using Moq;
using System.Threading.Tasks;
using System.Threading;
using System.Net;

namespace Repository_Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class AlbumRepositoryTest
    {
        HttpClient httpClient;
        String jsonAlbums;
        String jsonPhotos;

        [SetUp]
        public void Setup()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://jsonplaceholder.typicode.com/");
            jsonPhotos = GetJsonPhotos();
            jsonAlbums = GetJsonAlbums();
        }

        [Test]
        [Category("Unit_Test")]
        public void Test_get_photos_from_repository_unit_test_mock_http_client()
        {
            // Arrange
            var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            handlerMock
               .Protected()
               // Setup the PROTECTED method to mock
               .Setup<Task<HttpResponseMessage>>(
                  "SendAsync",
                  ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>()
               )
               // prepare the expected response of the mocked http call
               .ReturnsAsync(new HttpResponseMessage()
               {
                   StatusCode = HttpStatusCode.OK,
                   Content = new StringContent(jsonPhotos),
               })
               .Verifiable();

            var _httpClient = new HttpClient(handlerMock.Object)
            {
                BaseAddress = new Uri("http://Mock.Test"),
            };

            var photoepository = new PhotoRepository(_httpClient);

            // Act
            var res = photoepository.PhotosAsync().Result;

            // Assert
            Assert.True(res.Any());

            Assert.AreEqual(6, res.Count());
        }

        [Test]
        [Category("Unit_Test")]
        public void Test_get_albums_from_repository_unit_test_mock_http_client()
        {
            // Arrange
            var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            handlerMock
               .Protected()
               // Setup the PROTECTED method to mock
               .Setup<Task<HttpResponseMessage>>(
                  "SendAsync",
                  ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>()
               )
               // prepare the expected response of the mocked http call
               .ReturnsAsync(new HttpResponseMessage()
               {
                   StatusCode = HttpStatusCode.OK,
                   Content = new StringContent(jsonAlbums),
               })
               .Verifiable();

            var _httpClient = new HttpClient(handlerMock.Object)
            {
                BaseAddress = new Uri("http://Mock.Test"),
            };

            var albumRepository = new AlbumRepository(_httpClient);

            // Act
            var res = albumRepository.AlbumsAsync().Result;

            // Assert
            Assert.True(res.Any());

            Assert.AreEqual(17, res.Count());
        }

        [Test]
        [Category("Integrated_Test")]
        public void Test_get_albums_from_repository_integrated()
        {
            // Arrange
            var albumRepository = new AlbumRepository(httpClient);

            // Act
            var res = albumRepository.AlbumsAsync().Result;

            // Assert
            Assert.True(res.Any());
        }

        [Test]
        [Category("Integrated_Test")]
        public void Test_get_photos_from_repositorio_integrated()
        {
            // Arrange
            var albumRepository = new PhotoRepository(httpClient);

            // Act
            var res = albumRepository.PhotosAsync().Result;

            // Assert
            Assert.True(res.Any());
        }
        public string GetJsonAlbums()
        {
            return @"[
              {
                ""userId"": 1,
                ""id"": 1,
                ""title"": ""quidem molestiae enim""
              },
              {
                ""userId"": 1,
                ""id"": 2,
                ""title"": ""sunt qui excepturi placeat culpa""
              },
              {
                ""userId"": 1,
                ""id"": 3,
                ""title"": ""omnis laborum odio""
              },
              {
                ""userId"": 1,
                ""id"": 4,
                ""title"": ""non esse culpa molestiae omnis sed optio""
              },
              {
                ""userId"": 1,
                ""id"": 5,
                ""title"": ""eaque aut omnis a""
              },
              {
                ""userId"": 1,
                ""id"": 6,
                ""title"": ""natus impedit quibusdam illo est""
              },
              {
                ""userId"": 1,
                ""id"": 7,
                ""title"": ""quibusdam autem aliquid et et quia""
              },
              {
                ""userId"": 1,
                ""id"": 8,
                ""title"": ""qui fuga est a eum""
              },
              {
                ""userId"": 1,
                ""id"": 9,
                ""title"": ""saepe unde necessitatibus rem""
              },
              {
                ""userId"": 1,
                ""id"": 10,
                ""title"": ""distinctio laborum qui""
              },
              {
                ""userId"": 2,
                ""id"": 11,
                ""title"": ""quam nostrum impedit mollitia quod et dolor""
              },
              {
                ""userId"": 2,
                ""id"": 12,
                ""title"": ""consequatur autem doloribus natus consectetur""
              },
              {
                ""userId"": 2,
                ""id"": 13,
                ""title"": ""ab rerum non rerum consequatur ut ea unde""
              },
              {
                ""userId"": 2,
                ""id"": 14,
                ""title"": ""ducimus molestias eos animi atque nihil""
              },
              {
                ""userId"": 2,
                ""id"": 15,
                ""title"": ""ut pariatur rerum ipsum natus repellendus praesentium""
              },
              {
                ""userId"": 2,
                ""id"": 16,
                ""title"": ""voluptatem aut maxime inventore autem magnam atque repellat""
              },
              {
                ""userId"": 2,
                ""id"": 17,
                ""title"": ""aut minima voluptatem ut velit""
              }
              ]";
        }
        public string GetJsonPhotos()
        {
            return @"[
              {
                ""albumId"": 1,
                ""id"": 1,
                ""title"": ""accusamus beatae ad facilis cum similique qui sunt"",
                ""url"": ""https://via.placeholder.com/600/92c952"",
                ""thumbnailUrl"": ""https://via.placeholder.com/150/92c952""
              },
              {
                ""albumId"": 1,
                ""id"": 2,
                ""title"": ""reprehenderit est deserunt velit ipsam"",
                ""url"": ""https://via.placeholder.com/600/771796"",
                ""thumbnailUrl"": ""https://via.placeholder.com/150/771796""
              },
              {
                ""albumId"": 1,
                ""id"": 3,
                ""title"": ""officia porro iure quia iusto qui ipsa ut modi"",
                ""url"": ""https://via.placeholder.com/600/24f355"",
                ""thumbnailUrl"": ""https://via.placeholder.com/150/24f355""
              },
              {
                ""albumId"": 1,
                ""id"": 4,
                ""title"": ""culpa odio esse rerum omnis laboriosam voluptate repudiandae"",
                ""url"": ""https://via.placeholder.com/600/d32776"",
                ""thumbnailUrl"": ""https://via.placeholder.com/150/d32776""
              },
              {
                ""albumId"": 1,
                ""id"": 5,
                ""title"": ""natus nisi omnis corporis facere molestiae rerum in"",
                ""url"": ""https://via.placeholder.com/600/f66b97"",
                ""thumbnailUrl"": ""https://via.placeholder.com/150/f66b97""
              },
              {
                ""albumId"": 1,
                ""id"": 6,
                ""title"": ""accusamus ea aliquid et amet sequi nemo"",
                ""url"": ""https://via.placeholder.com/600/56a8c2"",
                ""thumbnailUrl"": ""https://via.placeholder.com/150/56a8c2""
              }
            ]";
        }
    }
}