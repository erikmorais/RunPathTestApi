using Newtonsoft.Json;
using ServicesContract.Interfaces;
using ServicesContract.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Repositories.AlbumRepository
{
    public class AlbumRepository : IAlbumRepository, IDisposable
    {
        private HttpClient httpClient;

        public AlbumRepository(HttpClient httpClient)
        {
            this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(AlbumRepository));
        }

        public async Task<IEnumerable<Album>> AlbumsAsync()
        {
            var response = await httpClient.GetStringAsync("albums");
            var albums = JsonConvert.DeserializeObject<IReadOnlyCollection<Album>>(response);
            return albums;
        }

        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (httpClient != null)
                    {
                        httpClient.Dispose();
                        httpClient = null;
                    }
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
