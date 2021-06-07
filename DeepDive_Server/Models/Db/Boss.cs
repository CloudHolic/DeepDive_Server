using System;
using System.Collections.Generic;

#nullable disable

namespace DeepDive_Server.Models.Db
{
    public sealed class Boss
    {
        public Boss()
        {
            BossSkills = new HashSet<BossSkill>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Str { get; set; }
        public int Hp { get; set; }
        public string StandingImageLink { get; set; }
        public string IconImageLink { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }

        public ICollection<BossSkill> BossSkills { get; set; }
    }
}
