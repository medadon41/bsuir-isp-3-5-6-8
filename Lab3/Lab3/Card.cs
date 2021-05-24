using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    abstract class Card : IShowable
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

        public delegate Players CommitCast(Players cp);

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

        public CommitCast WhatToDo(StringBuilder _desc)
        {
            string _res = _desc.ToString();
            string[] s_desc = _res.Split(' ');


            CommitCast nothing = (cp) => { Console.WriteLine("Oops, not supported yet. ");
                return cp;
            };
            
            for (int i = 0; i < s_desc.Length; i++)
            {
                if(s_desc[i].ToLower() == "if")
                {
                    this.stype = SpellType.Draw;
                    return nothing;
                }
                else if (s_desc[i].ToLower() == "deal")
                {
                    this.stype = SpellType.Damage;
                    CommitCast dealDamage = (cp) =>
                    {
                        if (s_desc[i + 4].ToLower() == "a")
                        {
                            int _rep = 0;
                            int _index = 0;
                            do
                            {
                                Console.WriteLine("Choose the board (enemy/mine (e/m)): ");
                                switch (Console.ReadLine())
                                {
                                    case "e": _index = 1; break;
                                    case "m": _index = 0; break;
                                    default: _rep = 1; break;
                                }
                            } while (_rep != 0);
                            Console.WriteLine("Choose the target (the position on the board): ");

                            string _target = null;
                            int target = 0;
                            Program.сheckInt(ref _target, ref target);
                            bool repeat = true;

                            while (repeat)
                            {
                                repeat = false;
                                try
                                {
                                    cp[_index].board[target].ChangeHealth(-int.Parse(s_desc[i + 1]));
                                }
                                catch (IndexOutOfRangeException)
                                {
                                    _target = null;
                                    target = 0;
                                    Console.Write("Error. Enter only numbers from 1 to 5: ");
                                    Program.сheckInt(ref _target, ref target);
                                    repeat = true;
                                }
                            }
                        }
                        else
                        {
                            for (int i = 0; i < cp[0].board.length(); i++)
                                cp[0].board[i].ChangeHealth(-int.Parse(s_desc[1]));

                            for (int i = 0; i < cp[1].board.length(); i++)
                                cp[1].board[i].ChangeHealth(-int.Parse(s_desc[1]));
                        }

                        return cp;
                    };
                    return dealDamage;
                } else if(s_desc[i].ToLower() == "restore")
                {
                    this.stype = SpellType.Heal;
                    CommitCast restoreHealth = (cp) =>
                    {
                        if (s_desc[i + 4].ToLower() == "a")
                        {
                            int _rep = 0;
                            int _index = 0;
                            do
                            {
                                Console.WriteLine("Choose the board (enemy/mine (e/m)): ");
                                switch (Console.ReadLine())
                                {
                                    case "e": _index = 1; break;
                                    case "m": _index = 0; break;
                                    default: _rep = 1; break;
                                }
                            } while (_rep != 0);
                            Console.WriteLine("Choose the target (the position on the board): ");
                            string _target = null;
                            int target = 0;
                            Program.сheckInt(ref _target, ref target);
                            bool repeat = true;

                            while (repeat)
                            {
                                repeat = false;
                                try
                                {
                                    cp[_index].board[target].ChangeHealth(-int.Parse(s_desc[i + 1]));
                                }
                                catch (IndexOutOfRangeException)
                                {
                                    _target = null;
                                    target = 0;
                                    Console.Write("Error. Enter only numbers from 1 to 5: ");
                                    Program.сheckInt(ref _target, ref target);
                                    repeat = true;
                                }
                            }
                        }
                        else
                        {
                            for (int i = 0; i < cp[0].board.length(); i++)
                                cp[0].board[i].ChangeHealth(int.Parse(s_desc[i + 1]));

                            for (int i = 0; i < cp[1].board.length(); i++)
                                cp[1].board[i].ChangeHealth(int.Parse(s_desc[i + 1]));
                        }

                        return cp;
                    };
                    return restoreHealth;
                } else if (s_desc[i].ToLower() == "draw")
                {
                    this.stype = SpellType.Draw;
                    if (s_desc[i + 1].ToLower() == "a")
                    {
                        CommitCast drawCard = (cp) =>
                        {
                            cp[0].hand.Draw(this, cp[0].deck);
                            return cp;
                        };
                        return drawCard;
                    }
                    else                                                  
                    {
                        return nothing;
                    }
                }
            }
            this.stype = SpellType.None;
            return nothing;
        }
    }
}
