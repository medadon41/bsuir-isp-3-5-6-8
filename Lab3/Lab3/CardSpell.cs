using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    class CardSpell: Card
    {
        public CardSpell(string s_name, int s_mana, string s_hero, string s_rarity, string desc)
        {
            name = s_name;
            manacost = s_mana;
            hero = s_hero;
            rarity = s_rarity;
            description.Append(desc);
        }

        /*
        void cast(ref Players cp)
        {
            if(this.isTargetNeeded == true)
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
                string _target = Console.ReadLine();
                while (!CheckInt(_target))
                {
                    Console.Write("Choose the target (the position on the board): ");
                    _target = Console.ReadLine();
                }
                int target = int.Parse(_target);
                string _todo = this.WhatToDo(description);
                if(_todo.StartsWith('1') && _todo.EndsWith('1'))
                {
                    cp[_index].board[target].ChangeHealth(int.Parse(_todo.Substring(2, 0)));
                } else if (_todo.StartsWith('1') && _todo.EndsWith('2'))
                {
                    for (int i = 0; i < cp[0].board; i++)
                    cp[_index].board[target].ChangeHealth(int.Parse(_todo.Substring(2, 0)));
                }
            }
        }
        */
    }
}
