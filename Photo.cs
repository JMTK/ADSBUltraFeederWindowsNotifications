using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADSBNotification
{
    public class Photo
    {
        public string id { get; set; }
        public Thumbnail thumbnail { get; set; }
        public ThumbnailLarge thumbnail_large { get; set; }
        public string link { get; set; }
        public string photographer { get; set; }
    }

    public class PhotoResponse
    {
        public List<Photo> photos { get; set; }
    }

    public class Size
    {
        public int width { get; set; }
        public int height { get; set; }
    }

    public class Thumbnail
    {
        public string src { get; set; }
        public Size size { get; set; }
    }

    public class ThumbnailLarge
    {
        public string src { get; set; }
        public Size size { get; set; }
    }


}
