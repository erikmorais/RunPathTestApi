using ServicesContract.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using PhotoAlbumApi.Extentions;

namespace PhotoAlbumApi
{
    public static class Mapper
    {
        public static Task<IEnumerable<Model.Album>> LoadAlbumAsync(IEnumerable<Album> albums)
        {
            return Task<IEnumerable<Model.Album>>.Factory.StartNew(() => AlbumsDto(albums));
        }

        private static IEnumerable<Model.Album> AlbumsDto(IEnumerable<Album> albums)
        {
            foreach (var item in albums)
            {
                var a = item.Dto();
                a.Photos = PhotoDto(item.Photos);
                yield return a;
            }
        }

        private static IEnumerable<Model.Photo> PhotoDto(IEnumerable<Photo> photos)
        {
            if (photos == null)
            {
                yield return null;
            }
            else
            {
                foreach (var item in photos)
                {
                    yield return item.Dto();
                }
            }
        }
    }
}
