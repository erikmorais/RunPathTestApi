using System.Collections.Generic;

namespace PhotoAlbumApi.Model
{
    public class Album
    {
        public int? Id { get; set; }
        public int? UserId { get; set; }
        public string Title { get; set; }
        public IEnumerable<Photo> Photos { get; set; }
    }
}
