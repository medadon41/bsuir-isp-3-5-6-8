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
            if (this.isTargetNeeded == true)
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
                int target = int.Parse(_target) - 1;
                string _todo = this.WhatToDo(description);
                if (_todo.StartsWith('1') && _todo.EndsWith('1'))
                {
                    cp[_index].board[target].ChangeHealth(-int.Parse(_todo.Substring(2, 1)));
                }
                else if (_todo.StartsWith('2') && _todo.EndsWith('1'))
                {
                    cp[_index].board[target].ChangeHealth(int.Parse(_todo.Substring(2, 1)));

                }

            }
            else
            {
                string _todo = this.WhatToDo(description);
                if (_todo.StartsWith('1') && _todo.EndsWith('2'))
                {
                    for (int i = 0; i < cp[0].board.length(); i++)
                        cp[0].board[i].ChangeHealth(-int.Parse(_todo.Substring(2, 1)));

                    for (int i = 0; i < cp[1].board.length(); i++)
                        cp[1].board[i].ChangeHealth(-int.Parse(_todo.Substring(2, 1)));
                }
                else if (_todo.StartsWith('2') && _todo.EndsWith('2'))
                {
                    for (int i = 0; i < cp[0].board.length(); i++)
                        cp[0].board[i].ChangeHealth(int.Parse(_todo.Substring(2, 1)));

                    for (int i = 0; i < cp[1].board.length(); i++)
                        cp[1].board[i].ChangeHealth(int.Parse(_todo.Substring(2, 1)));
                }
                else if (_todo.StartsWith('3') && _todo.Substring(2, 1) == "1")
                {
                    cp[0].hand.Draw(this, ref cp[0].deck);
                    return;
                } 
                else if (_todo.StartsWith('5'))
                {
                    cp[0].hand.Draw(this, ref cp[0].deck);
                    if (!cp[0].deck.checkEquality())
                    {
                        for (int i = 0; i < cp[0].board.length(); i++)
                            cp[0].board[i].ChangeHealth(int.Parse(_todo.Substring(2, 1)));

                        for (int i = 0; i < cp[1].board.length(); i++)
                            cp[1].board[i].ChangeHealth(int.Parse(_todo.Substring(2, 1)));
                        return;
                    } 
                    else
                    {
                        return;
                    }
                }
            }

           cp[0].hand.Refill(this);
           cp[0].board.Refill(this);
        }

    }
}
