using System;
using System.Collections.Generic;

#nullable disable

namespace DeepDive_Server.Models
{
    public sealed class Skill
    {
        public Skill()
        {
            BossSkills = new HashSet<BossSkill>();
            CharacterSkills = new HashSet<CharacterSkill>();
        }

        public int Id { get; set; }
        public bool Type { get; set; }
        public string Class { get; set; }
        public string Name { get; set; }
        public string Range { get; set; }
        public string Cost { get; set; }
        public string Turn { get; set; }
        public string Target { get; set; }
        public string Description { get; set; }
        public string AdditionalEffect { get; set; }
        public string CastingRange { get; set; }
        public string EffectRange { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public ICollection<BossSkill> BossSkills { get; set; }
        public ICollection<CharacterSkill> CharacterSkills { get; set; }
    }
}
