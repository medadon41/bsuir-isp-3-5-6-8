using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    abstract class Card : IShowable, IEqutable<Card>
    {
        //inspired by hearthstone

        public string name;
        public int manacost;
        public string hero;
        public int attack;
        public int health;
        public bool isInHand = false;
        public SpellType stype;
        public string rarity;
        public StringBuilder description = new StringBuilder();
        public bool isTargetNeeded;
        private string id;

        public Card() { }
        public Card(string s_name, int s_mana, string s_hero, string s_rarity, string desc)
        {
            name = s_name;
            manacost = s_mana;
            hero = s_hero;
            rarity = s_rarity;
            description.Append(desc);
        }

        public string ID
        {
            set
            {
                id = value;
            }
        }

        public bool CheckInt(string _int)
        {
            if (int.TryParse(_int, out int test)) { return true; }
            else return false;
        }

        public void ChangeManacost(int mn)
        {
            this.manacost += mn;
            if (manacost < 0)
            {
                this.manacost = 0;
            }
        }

        public bool Equals(Card card)
        {
            return (this.name, this.description) == (card.name, card.description);
        }

        public void Show()
        {
            Console.WriteLine($"{this.manacost}");

            Console.WriteLine($"{this.name}");
            Console.WriteLine($"Rarity: {this.rarity} ");

            Console.WriteLine($"{this.description}");

            Console.WriteLine($"Class: {this.hero} ");
            Console.WriteLine("-----------------------");
        }

        public abstract void Cast(ref Players cp);

        public string WhatToDo(StringBuilder _desc)
        {
            string _res = _desc.ToString();
            string[] s_desc = _res.Split(' ');

            StringBuilder result = new StringBuilder(6);
            
            for (int i = 0; i < _desc.Length; i++)
            {
                if(s_desc[i].ToLower() == "if")
                {
                    this.stype = SpellType.Draw;
                    return "5-5-0";
                }
                else if (s_desc[i].ToLower() == "deal")
                {
                    this.stype = SpellType.Damage;
                    result.Append("1-");
                    if (s_desc[i + 3].ToLower() == "a") {
                        result.Append($"{s_desc[i + 1]}-");
                        result.Append('1');                                 //1-n-1 == deal n damage to a minion
                        _res = result.ToString();                           //1-n-2 == deal n damage to all minions
                        return _res;                                        //2-n-1 == restore n health to a minion
                    } else                                                  //2-n-2 == restore n health to all minions
                    {                                                       //3-1-0 == draw a card
                        result.Append($"{s_desc[i + 1]}-");                 //3-n-0 == draw n cards
                        result.Append('2');
                        _res = result.ToString();
                        return _res;
                    }
                } else if(s_desc[i].ToLower() == "restore")
                {
                    this.stype = SpellType.Heal;
                    result.Append("2-");
                    if (s_desc[i + 4].ToLower() == "a")
                    {
                        result.Append($"{s_desc[i + 1]}-");
                        result.Append('1');
                        _res = result.ToString();
                        return _res;
                    }
                    else
                    {
                        result.Append($"{s_desc[i + 1]}-");
                        result.Append('2');
                        _res = result.ToString();
                        return _res;
                    }
                } else if (s_desc[i].ToLower() == "draw")
                {
                    this.stype = SpellType.Draw;
                    result.Append("3-");
                    if (s_desc[i + 1].ToLower() == "a")
                    {
                        result.Append($"1-");
                        result.Append('0');                              
                        _res = result.ToString();                          
                        return _res;                                        
                    }
                    else                                                  
                    {
                        result.Append($"{s_desc[i + 1]}-");
                        result.Append('0');
                        _res = result.ToString();
                        return _res;
                    }
                }
            }
            this.stype = SpellType.None;
            result.Append("0-0-0");
            _res = result.ToString();
            return _res;
        }
    }
}
