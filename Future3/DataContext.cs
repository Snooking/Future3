using Future3.Models;
using System.Collections.Generic;

namespace Future3
{
    public class DataContext
    {
        //Lista naszych postaci
        public List<Character> Characters { get; set; }

        public DataContext()
        {
            //Seedowanie naszej listy (wypełnianie jej przykładowymi danymi)
            Characters = new List<Character>
            {
                new Character
                {
                    Id = 1,
                    Name = "Snooking",
                    Level = 1,
                    Rpg = Rpg.NotAssigned
                },
                new Character
                {
                    Id = 2,
                    Name = "Geralt",
                    Level = 16,
                    Rpg = Rpg.Warhammer
                }
            };
        }
    }
}
