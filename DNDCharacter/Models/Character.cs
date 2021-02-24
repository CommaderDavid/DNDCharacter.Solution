using System.Collections.Generic;

namespace DNDCharacter.Models
{
    public class Character
    {
        public int CharacterId { get; set; }
        public string CharacterName { get; set; }
        public string Description { get; set; }
        public string RPClass { get; set; }
        public string Player { get; set; }
        public virtual ICollection<CampaignCharacter> Campaigns { get; }
        public virtual Stat CharacterStat { get; }

        public Character()
        {
            this.Campaigns = new HashSet<CampaignCharacter>();
        }
    }
}