using System;

#nullable disable

namespace DeepDive_Server.Models
{
    public class CharacterSkill
    {
        public int Id { get; set; }
        public int? CharacterId { get; set; }
        public int? SkillId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual Character Character { get; set; }
        public virtual Skill Skill { get; set; }
    }
}
