using System.ComponentModel.DataAnnotations;

namespace AvatarTLAB.Backend.Models
{
    public class Episode
    {
        [Key]
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public int EpisodeNumber { get; set; }
        public int SeasonNumber { get; set; }
        public DateOnly ReleaseDate { get; set; }
    }
}
