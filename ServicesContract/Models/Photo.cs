using System;

namespace ServicesContract.Models
{
    public struct Photo
    {
        public int? Id { get; set; }
        public int? AlbumId { get; set; }
        public String Title { get; set; }
        public String Url { get; set; }
        public String ThumbnailUrl { get; set; }
    }
}

