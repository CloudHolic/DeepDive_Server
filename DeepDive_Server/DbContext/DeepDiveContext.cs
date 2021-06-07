using DeepDive_Server.Models.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace DeepDive_Server.DbContext
{
    public class DeepDiveContext : Microsoft.EntityFrameworkCore.DbContext
    {
        private readonly IConfiguration _configuration;

        public DeepDiveContext()
        {
            _configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        }

        public DeepDiveContext(DbContextOptions<DeepDiveContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Boss> Bosses { get; set; }
        public virtual DbSet<BossSkill> BossSkills { get; set; }
        public virtual DbSet<Character> Characters { get; set; }
        public virtual DbSet<CharacterSkill> CharacterSkills { get; set; }
        public virtual DbSet<Skill> Skills { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseMySql(_configuration.GetConnectionString("DeepDiveDb"), ServerVersion.Parse("10.6.0-mariadb"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8").UseCollation("utf8_general_ci");

            modelBuilder.Entity<Boss>(entity =>
            {
                entity.ToTable("boss");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.CreateAt)
                    .HasMaxLength(6)
                    .HasColumnName("createAt")
                    .HasDefaultValueSql("current_timestamp(6)");

                entity.Property(e => e.Hp)
                    .HasColumnType("int(3)")
                    .HasColumnName("hp")
                    .HasDefaultValueSql("'100'");

                entity.Property(e => e.IconImageLink)
                    .HasColumnType("text")
                    .HasColumnName("iconImageLink");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.StandingImageLink)
                    .HasColumnType("text")
                    .HasColumnName("standingImageLink");

                entity.Property(e => e.Str)
                    .HasColumnType("int(1)")
                    .HasColumnName("str")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.UpdateAt)
                    .HasMaxLength(6)
                    .ValueGeneratedOnAddOrUpdate()
                    .HasColumnName("updateAt")
                    .HasDefaultValueSql("current_timestamp(6)");
            });

            modelBuilder.Entity<BossSkill>(entity =>
            {
                entity.ToTable("boss_skills");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.BossId, "bossId");

                entity.HasIndex(e => e.SkillId, "skillId");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.BossId)
                    .HasColumnType("int(11)")
                    .HasColumnName("bossId");

                entity.Property(e => e.CreatedAt)
                    .HasMaxLength(6)
                    .HasColumnName("createdAt")
                    .HasDefaultValueSql("current_timestamp(6)");

                entity.Property(e => e.SkillId)
                    .HasColumnType("int(11)")
                    .HasColumnName("skillId");

                entity.Property(e => e.UpdatedAt)
                    .HasMaxLength(6)
                    .ValueGeneratedOnAddOrUpdate()
                    .HasColumnName("updatedAt")
                    .HasDefaultValueSql("current_timestamp(6)");

                entity.HasOne(d => d.Boss)
                    .WithMany(p => p.BossSkills)
                    .HasForeignKey(d => d.BossId)
                    .HasConstraintName("boss_skills_ibfk_1");

                entity.HasOne(d => d.Skill)
                    .WithMany(p => p.BossSkills)
                    .HasForeignKey(d => d.SkillId)
                    .HasConstraintName("boss_skills_ibfk_2");
            });

            modelBuilder.Entity<Character>(entity =>
            {
                entity.ToTable("character");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Class)
                    .HasMaxLength(15)
                    .HasColumnName("class");

                entity.Property(e => e.CreatedAt)
                    .HasMaxLength(6)
                    .HasColumnName("createdAt")
                    .HasDefaultValueSql("current_timestamp(6)");

                entity.Property(e => e.Dex)
                    .HasColumnType("int(1)")
                    .HasColumnName("dex")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Hp)
                    .HasColumnType("int(2)")
                    .HasColumnName("hp")
                    .HasDefaultValueSql("'10'");

                entity.Property(e => e.IconImageLink)
                    .HasColumnType("text")
                    .HasColumnName("iconImageLink");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Sp)
                    .HasColumnType("int(2)")
                    .HasColumnName("sp")
                    .HasDefaultValueSql("'10'");

                entity.Property(e => e.StandingImageLink)
                    .HasColumnType("text")
                    .HasColumnName("standingImageLink");

                entity.Property(e => e.UpdatedAt)
                    .HasMaxLength(6)
                    .ValueGeneratedOnAddOrUpdate()
                    .HasColumnName("updatedAt")
                    .HasDefaultValueSql("current_timestamp(6)");
            });

            modelBuilder.Entity<CharacterSkill>(entity =>
            {
                entity.ToTable("character_skills");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.CharacterId, "characterId");

                entity.HasIndex(e => e.SkillId, "skillId");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.CharacterId)
                    .HasColumnType("int(11)")
                    .HasColumnName("characterId");

                entity.Property(e => e.CreatedAt)
                    .HasMaxLength(6)
                    .HasColumnName("createdAt")
                    .HasDefaultValueSql("current_timestamp(6)");

                entity.Property(e => e.SkillId)
                    .HasColumnType("int(11)")
                    .HasColumnName("skillId");

                entity.Property(e => e.UpdatedAt)
                    .HasMaxLength(6)
                    .ValueGeneratedOnAddOrUpdate()
                    .HasColumnName("updatedAt")
                    .HasDefaultValueSql("current_timestamp(6)");

                entity.HasOne(d => d.Character)
                    .WithMany(p => p.CharacterSkills)
                    .HasForeignKey(d => d.CharacterId)
                    .HasConstraintName("character_skills_ibfk_1");

                entity.HasOne(d => d.Skill)
                    .WithMany(p => p.CharacterSkills)
                    .HasForeignKey(d => d.SkillId)
                    .HasConstraintName("character_skills_ibfk_2");
            });

            modelBuilder.Entity<Skill>(entity =>
            {
                entity.ToTable("skill");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.AdditionalEffect)
                    .HasMaxLength(50)
                    .HasColumnName("additionalEffect");

                entity.Property(e => e.CastingRange)
                    .HasColumnType("text")
                    .HasColumnName("castingRange");

                entity.Property(e => e.Class)
                    .HasMaxLength(15)
                    .HasColumnName("class");

                entity.Property(e => e.Cost)
                    .HasMaxLength(100)
                    .HasColumnName("cost");

                entity.Property(e => e.CreatedAt)
                    .HasMaxLength(6)
                    .HasColumnName("createdAt")
                    .HasDefaultValueSql("current_timestamp(6)");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.EffectRange)
                    .HasColumnType("text")
                    .HasColumnName("effectRange");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .HasColumnName("name");

                entity.Property(e => e.Range)
                    .HasMaxLength(25)
                    .HasColumnName("range");

                entity.Property(e => e.Target)
                    .HasMaxLength(100)
                    .HasColumnName("target");

                entity.Property(e => e.Turn)
                    .HasMaxLength(100)
                    .HasColumnName("turn");

                entity.Property(e => e.Type).HasColumnName("type");

                entity.Property(e => e.UpdatedAt)
                    .HasMaxLength(6)
                    .ValueGeneratedOnAddOrUpdate()
                    .HasColumnName("updatedAt")
                    .HasDefaultValueSql("current_timestamp(6)");
            });
        }
    }
}
