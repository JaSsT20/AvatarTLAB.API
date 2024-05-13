using System.ComponentModel.DataAnnotations;

namespace AvatarTLAB.Backend.Models
{
    public class Character
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Surname { get; set; }
        public int Age { get; set; }
        public string? Image { get; set; }
        public int ElementId { get; set; }
        public Element? Element { get; set; }
        public int FirstEpisodeId { get; set; }
        public Episode? FirstEpisode { get; set; }
        public int LastEpisodeId { get; set; }
        public Episode? LastEpisode { get; set; }
        public string Born { get; set; } = string.Empty;
        public int NationId { get; set; }
        public Nation? Nation { get; set; }
        public string? Pronouns { get; set; }
        public string? EyesColor { get; set; }
        public string? HairColor { get; set; }
        public string? SkinColor { get; set; }
        public List<Alias> Aliases { get; set; } = new List<Alias>();
        public List<CharacterFightingStyle> CharacterFightingStyles { get; set; } = new List<CharacterFightingStyle>();
    }
}
