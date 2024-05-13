using System.ComponentModel.DataAnnotations;

namespace AvatarTLAB.Backend.Models
{
    public class Nation
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Symbol { get; set; } = string.Empty;
        public string Capital { get; set; } = string.Empty;
        public int LeaderId { get; set; }
    }
}
