using System;

namespace PhotoAlbumApi.Model
{
    public class Photo
    {
        public int? Id { get; set; }
        public int? AlbumId { get; set; }
        public String Title { get; set; }
        public String Url { get; set; }
        public String ThumbnailUrl { get; set; }
    }
}

