using System;

#nullable disable

namespace DeepDive_Server.Models.Db
{
    public class BossSkill
    {
        public int Id { get; set; }
        public int? BossId { get; set; }
        public int? SkillId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual Boss Boss { get; set; }
        public virtual Skill Skill { get; set; }
    }
}
