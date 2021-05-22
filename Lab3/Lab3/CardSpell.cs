using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    class CardSpell : Card
    {
        public bool isTargetNeeded;
        public CardSpell(string s_name, int s_mana, string s_hero, string s_rarity, string desc, bool trg)
        {
            name = s_name;
            manacost = s_mana;
            hero = s_hero;
            rarity = s_rarity;
            isTargetNeeded = trg;
            description.Append(desc);
        }



        public override void Cast(ref Players cp)
        {
            CommitCast WTD = WhatToDo(description);

            cp = WTD(cp);

            
           cp[0].hand.Refill(this);
           cp[0].board.Refill(this);
        }

    }
}
