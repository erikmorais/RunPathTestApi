using ServicesContract.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoAlbumApi.Extentions
{
    public static class MapperExtentions
    {
        public static Model.Album Dto(this Album album)
        {
            return new Model.Album
            {
                Id = album.Id,
                Title = album.Title,
                UserId = album.UserId
            };
        }

        public static Album Dto(this Model.Album album)
        {
            return new Album
            {
                Id = album.Id,
                Title = album.Title,
                UserId = album.UserId
            };
        }

        public static Model.Photo Dto(this Photo photo)
        {
            return new Model.Photo
            {
                Id = photo.Id,
                Title = photo.Title,
                ThumbnailUrl = photo.ThumbnailUrl.ToString(),
                Url = photo.Url.ToString(),
                AlbumId = photo.AlbumId,
            };
        }

        public static Photo Dto(this Model.Photo photo)
        {
            return new Photo
            {
                Id = photo.Id,
                Title = photo.Title,
                ThumbnailUrl = photo.ThumbnailUrl,
                Url = photo.Url,
                AlbumId = photo.AlbumId,
            };
        }
    }
}
