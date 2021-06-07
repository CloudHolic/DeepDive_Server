using System;
using System.Collections.Generic;

#nullable disable

namespace DeepDive_Server.Models
{
    public sealed class Character
    {
        public Character()
        {
            CharacterSkills = new HashSet<CharacterSkill>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
        public int Dex { get; set; }
        public int Hp { get; set; }
        public int Sp { get; set; }
        public string StandingImageLink { get; set; }
        public string IconImageLink { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public ICollection<CharacterSkill> CharacterSkills { get; set; }
    }
}
