using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AvatarTLAB.Backend.Models
{
    public class FightingStyle
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int ElementId { get; set; }
        public Element? Element { get; set; }
        public List<CharacterFightingStyle> CharacterFightingStyles { get; set; } = new List<CharacterFightingStyle>();
    }

    public class CharacterFightingStyle
    {
        [Key]
        public int Id { get; set; }
        public int CharacterId { get; set; }
        public int FightingStyleId { get; set; }
        [JsonIgnore]
        public FightingStyle? FightingStyle { get; set; }
    }
}
