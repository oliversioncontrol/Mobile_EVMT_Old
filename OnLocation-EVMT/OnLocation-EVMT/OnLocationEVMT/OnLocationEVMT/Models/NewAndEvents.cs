using Xamarin.Forms;

namespace OnLocationEVMT.Models
{
    /// <summary>
    /// Class News and Events
    /// </summary>
    public class NewAndEvents
    {
        public string id { get; set; }
        public string ndate { get; set; }
        public string NewsHeading { get; set; }
        public string NewsDate { get; set; }
        public string Content { get; set; }
    }

    /// <summary>
    /// Class News Announcements
    /// </summary>
    public class NewsAnnouncemetns
    {
        public string title { get; set; }
        public string fulltitle { get; set; }
        public string pubDate { get; set; }
        public string description { get; set; }
        public string fullDesc { get; set; }
        public string datepart { get; set; }
        public Command NewsDetails { get; set; }
        public string URL { get; set; }

    }
}
