using ServicesContract.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServicesContract.Interfaces
{
    public interface IAlbumRepository
    {
        Task<IEnumerable<Album>> AlbumsAsync();
    }
}
