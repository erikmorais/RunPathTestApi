using Newtonsoft.Json;
using ServicesContract.Interfaces;
using ServicesContract.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Repositories.AlbumRepository
{
    public class PhotoRepository : IPhotoRepository, IDisposable
    {
        private HttpClient httpClient;

        public PhotoRepository(HttpClient httpClient)
        {
            this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(PhotoRepository));
        }

        public async Task<IEnumerable<Photo>> PhotosAsync()
        {
            var response = await httpClient.GetStringAsync("photos");
            var photos = JsonConvert.DeserializeObject<IReadOnlyCollection<Photo>>(response);
            return photos;
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

