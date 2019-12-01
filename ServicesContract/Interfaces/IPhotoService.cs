using ServicesContract.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServicesContract.Interfaces
{
    public interface IPhotoService
    {
        Task<IEnumerable<Photo>> AlbumsAsyn();
        Task<IEnumerable<Photo>> AlbumAsyn(Func<Photo, bool> predicate);
    }
}
