﻿using System.ComponentModel.DataAnnotations;

namespace AvatarTLAB.Backend.Models
{
    public class Alias
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
