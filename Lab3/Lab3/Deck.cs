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
            _temp = new CardMinion("Ragnaros", 8, 8, 8, "None", "All", "Legendary", true, false, "At the end of your turn deal 8 damage to a random minion");
            deck[0] = _temp;
            _temp = new CardMinion("Lich King", 8, 8, 8, "None", "All", "Legendary", true, false, "At the end of your turn, add a random Death Knight card to your hand");
            deck[1] = _temp;
            _temp = new CardMinion("Deathwing", 10, 12, 12, "None", "All", "Legendary", true, false, "Destroy all other minions and discard your hand");
            deck[2] = _temp;
            _temp = new CardMinion("Baron Rivendare", 4, 1, 7, "None", "All", "Legendary", true, false, "Your deathrattles trigger twice");
            deck[3] = _temp;
            _temp = new CardMinion("Baron Geddon", 7, 7, 7, "None", "All", "Legendary", true, false, "At the end of your turn deal 2 damage to ALL characters");
            deck[4] = _temp;
            _temp = new CardMinion("C'Thun", 10, 6, 6, "None", "All", "Legendary", true, false, "Deal damage equal to this minion's attack randomly split among all enemies");
            deck[5] = _temp;
            _temp = new CardMinion("N'Zoth", 10, 5, 7, "None", "All", "Legendary", true, false, "Summon your Deathrattle minions that died this game");
            deck[6] = _temp;
            _temp = new CardMinion("Y'Shaarj", 10, 10, 10, "None", "All", "Legendary", true, false, "At the end of your turn put a minion from your deck into the battlefield");
            deck[7] = _temp;
            _temp = new CardMinion("Bloodmage Thalnos", 2, 1, 1, "None", "All", "Legendary", true, false, "Deathrattle: Draw a card");
            deck[8] = _temp;
            _temp = new CardMinion("High Inquistor Whitemane", 6, 5, 7, "None", "All", "Legendary", true, false, "Summon all friendly minion that died this turn");
            deck[9] = _temp;
        }

        public bool checkEquality()
        {
            for(int i = 0; i < deck.Length - 1; i++)
            {
                if(deck[i].Equals(deck[i + 1]))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
