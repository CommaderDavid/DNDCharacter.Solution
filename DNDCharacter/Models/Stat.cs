namespace DNDCharacter.Models
{
    public class Stat
    {
        public int StatId { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }
        public virtual CampaignCharacter Character { get; }
    }
}