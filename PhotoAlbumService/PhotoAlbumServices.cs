using ServicesContract.Interfaces;
using ServicesContract.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoAlbumService
{
    public class PhotoAlbumServices : IAlbumServices
    {
        public PhotoAlbumServices(IAlbumRepository albumRepository, IPhotoRepository photoRepository)
        {
            AlbumRepository = albumRepository ?? throw new ArgumentNullException(nameof(PhotoAlbumServices)); ;
            PhotoRepository = photoRepository ?? throw new ArgumentNullException(nameof(PhotoAlbumServices)); ;
        }

        private IAlbumRepository AlbumRepository { get; }
        private IPhotoRepository PhotoRepository { get; }

        public Task<IEnumerable<Album>> AlbumsAsyn(Func<Album, bool> predicate)
        {

            //var albumns = await AlbumRepository.AlbumsAsync();
            //var photos = await PhotoRepository.PhotosAsync();

            var albumsTask = AlbumRepository.AlbumsAsync();
            var photoTask = PhotoRepository.PhotosAsync();


            Task.WaitAll(albumsTask, photoTask);

            var albumns = albumsTask.Result;
            var photos = photoTask.Result;

            var result = from a in albumns
                         where predicate(a)
                         join p in photos
                         on a.Id equals p.AlbumId
                         into photoGroup
                         select new Album
                         {
                             Id = a.Id,
                             Title = a.Title,
                             UserId = a.UserId,
                             Photos = photoGroup,
                         };

            return Task.FromResult(result);
        }

        public async Task<IEnumerable<Album>> AlbumsAsyn()
        {
            return await this.AlbumsAsyn(a => true);
        }
    }
}
