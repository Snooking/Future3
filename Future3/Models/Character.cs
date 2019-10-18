namespace Future3.Models
{
    //Model naszej postaci
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public Rpg Rpg { get; set; }
    }
}
