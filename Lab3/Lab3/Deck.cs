using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    class Deck
    {
        private Card[] deck;

        public Deck()
        {
            deck = new Card[10];
        }

        public Card this[int index]
        {
            get => deck[index];
            set => deck[index] = value;
        }

        public int length()
        {
            return deck.Length;
        }

        public void fillDeck()
        {
            CardMinion _temp;
            _temp = new CardMinion("Ragnaros", 8, 8, 8, "None", "All", "Legendary", true, false, " ");
            deck[0] = _temp;
            _temp = new CardMinion("Lich King", 8, 8, 8, "None", "All", "Legendary", true, false, " ");
            deck[1] = _temp;
            _temp = new CardMinion("Deathwing", 10, 12, 12, "None", "All", "Legendary", true, false, " ");
            deck[2] = _temp;
            _temp = new CardMinion("Baron Rivendare", 4, 1, 7, "None", "All", "Legendary", true, false, " ");
            deck[3] = _temp;
            _temp = new CardMinion("Baron Geddon", 7, 7, 7, "None", "All", "Legendary", true, false, " ");
            deck[4] = _temp;
            _temp = new CardMinion("C'Thun", 10, 6, 6, "None", "All", "Legendary", true, false, " ");
            deck[5] = _temp;
            _temp = new CardMinion("N'Zoth", 10, 5, 7, "None", "All", "Legendary", true, false, " ");
            deck[6] = _temp;
            _temp = new CardMinion("Y'Shaarj", 10, 10, 10, "None", "All", "Legendary", true, false, " ");
            deck[7] = _temp;
            _temp = new CardMinion("Bloodmage Thalnos", 2, 1, 1, "None", "All", "Legendary", true, false, " ");
            deck[8] = _temp;
            _temp = new CardMinion("High Inquistor Whitemane", 6, 5, 7, "None", "All", "Legendary", true, false, " ");
            deck[9] = _temp;
        }
    }
}
