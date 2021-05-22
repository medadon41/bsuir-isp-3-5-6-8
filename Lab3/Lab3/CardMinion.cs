using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    class CardMinion: Card, IShowable
    {
        public string type = "None";
        public bool isAlive = true;
        public bool isTargetable;

        public int maxHealth;
        public override void Cast (ref Players cp) { }

        public delegate string LogHandler(string message);

        public event LogHandler CommitedAttack;

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
            stype = SpellType.None;
            maxHealth = s_health;
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
            if(health + hp > maxHealth)
            {
                health = maxHealth;
            } else
            {
                health += hp;
            }
            if (health <= 0)
            {
                isAlive = false;
            }
        }

        public void Attack(CardMinion target)
        {
            target.ChangeHealth(-this.attack);
            this.ChangeHealth(-target.attack);

            CommitedAttack?.Invoke($"New attack: {this.name}({this.attack}/{this.health}) attacked {target.name}({target.attack}/{target.health})");
        }

        public void Show()
        {
            Console.WriteLine($"{this.manacost}");

            Console.WriteLine($"{this.name}");
            Console.WriteLine($"Rarity: {this.rarity} ");

            Console.WriteLine($"{this.description}");
           
            StringBuilder s_stats = new StringBuilder(this.description.Length);
            s_stats.Append(this.attack);
            for (int j = 0; j < this.name.Length - 1; j++)
            {
                s_stats.Append(' ');
            }
            s_stats.Append(this.health);

            Console.WriteLine($"{s_stats}");

            Console.WriteLine($"Class: {this.hero} ");
            Console.WriteLine("-----------------------");
        }
    }
}
