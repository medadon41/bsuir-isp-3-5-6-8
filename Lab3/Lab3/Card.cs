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

        public string WhatToDo(StringBuilder _desc)
        {
            string _res = _desc.ToString();
            string[] s_desc = _res.Split(' ');

            StringBuilder result = new StringBuilder(6);
            
            for (int i = 0; i < _desc.Length; i++)
            {
                string currWord = s_desc[i].ToLower();
                if (s_desc[i].ToLower() == "deals")
                {
                    result.Append("1-");
                    result.Append($"{s_desc[i + 1]}-");
                    if (s_desc[i+3].ToLower() == "a") {
                        result.Append('1');                                 //1-n-1 == deal n damage to a minion
                        _res = result.ToString();                           //1-n-2 == deal n damage to all minions
                        return _res;                                        //2-n-1 == restore n health to a minion
                    } else                                                  //2-n-2 == restore n health to all minions
                    {
                        result.Append('2');
                        _res = result.ToString();
                        return _res;
                    }
                } else if(s_desc[i].ToLower() == "restores")
                {
                    result.Append("2-");
                    result.Append($"{s_desc[i + 1]}-");
                    if (s_desc[i + 3].ToLower() == "a")
                    {
                        result.Append('1');
                        _res = result.ToString();
                        return _res;
                    }
                    else
                    {
                        result.Append('2');
                        _res = result.ToString();
                        return _res;
                    }
                }
            }
            result.Append("0-0-0");
            _res = result.ToString();
            return _res;
        }
    }
}
