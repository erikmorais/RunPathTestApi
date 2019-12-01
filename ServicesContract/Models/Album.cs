using System.Collections.Generic;

namespace ServicesContract.Models
{
    public struct Album
    {
        public int? Id { get; set; }
        public int? UserId { get; set; }
        public string Title { get; set; }
        public IEnumerable<Photo> Photos { get; set; }
    }
}
