namespace DNDCharacter.Models
{
    public class CampaignCharacter
    {
        public int CampaignCharacterId { get; set; }
        public int CharacterId { get; set; }
        public int CampaignId { get; set; }
        public int StatId { get; set; }
        public bool CharacterDeath { get; set; }
        public virtual Character Character { get; set; }
        public virtual Campaign Campaign { get; set; }
    }
}