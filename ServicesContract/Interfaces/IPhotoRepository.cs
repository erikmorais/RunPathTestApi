using ServicesContract.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServicesContract.Interfaces
{
    public interface IPhotoRepository
    {
        Task<IEnumerable<Photo>> PhotosAsync();
    }
}
