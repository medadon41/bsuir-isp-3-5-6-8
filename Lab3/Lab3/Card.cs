using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    class Card
    {
        //inspired by hearthstone

        public string name;
        public int manacost;
        public string hero;
        public string rarity;
        private string id;

        public Card(string s_name, int s_mana, string s_hero, string s_rarity)
        {
            name = s_name;
            manacost = s_mana;
            hero = s_hero;
            rarity = s_rarity;
        }

        public string ID
        {
            set
            {
                id = value;
            }
        }

        public void ChangeManacost(int mn)
        {
            this.manacost += mn;
            if (manacost < 0)
            {
                this.manacost = 0;
            }
        }
    }
}
