using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    class CardMinion: Card
    {
        public int attack;
        public int health;
        public string type = "None";
        public bool isAlive = true;
        public bool isTargetable;

        public CardMinion(string s_name, int s_mana, int s_attack, int s_health, string s_type, string s_hero, string s_rarity, bool s_trgt, bool s_ntrgt, string desc)
        {
            name = s_name;
            manacost = s_mana;
            attack = s_attack;
            health = s_health;
            type = s_type;
            hero = s_hero;
            rarity = s_rarity;
            isTargetable = s_trgt;
            isTargetNeeded = s_ntrgt;
            description.Append(desc);
        }

        public void ChangeAttack(int tk)
        {
            attack += tk;
            if (attack < 0)
            {
                attack = 0;
            }
        }

        public void ChangeHealth(int hp)
        {
            health += hp;
            if (health <= 0)
            {
                isAlive = false;
            }
        }

        public void Attack(CardMinion target)
        {
            target.ChangeHealth(-this.attack);
            this.ChangeHealth(-target.attack);
        }
    }
}
