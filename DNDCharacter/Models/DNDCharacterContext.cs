using Microsoft.EntityFrameworkCore;

namespace DNDCharacter.Models
{
    public class DNDCharacterContext : DbContext
    {
        public virtual DbSet<Campaign> Campaigns { get; set; }
        public virtual DbSet<Character> Characters { get; set; }
        public virtual DbSet<Stat> Stats { get; set; }
        public virtual DbSet<CampaignCharacter> CampaignCharacter { get; set; }

        public DNDCharacterContext(DbContextOptions options) : base(options) { }
    }
}