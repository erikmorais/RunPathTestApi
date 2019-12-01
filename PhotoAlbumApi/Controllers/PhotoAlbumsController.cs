using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServicesContract.Interfaces;

namespace PhotoAlbumApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoAlbumsController : ControllerBase
    {
        private readonly IAlbumServices albumServices;

        public PhotoAlbumsController(IAlbumServices albumServices)
        {
            this.albumServices = albumServices;
        }

        [HttpGet]
        public async Task<IEnumerable<Model.Album>> Get()
        {
            var result = await albumServices.AlbumsAsyn();
            return await Mapper.LoadAlbumAsync(result);
        }

        [HttpGet("{id}")]
        public async Task<IEnumerable<Model.Album>> Get(int? id)
        {
            var res = await albumServices.AlbumsAsyn(a => a.UserId == id);
            return await Mapper.LoadAlbumAsync(res);
        }
    }
}
