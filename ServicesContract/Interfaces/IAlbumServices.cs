using ServicesContract.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServicesContract.Interfaces
{
    public interface IAlbumServices
    {
        Task<IEnumerable<Album>> AlbumsAsyn(Func<Album, bool> predicate);
        Task<IEnumerable<Album>> AlbumsAsyn();
    }
}