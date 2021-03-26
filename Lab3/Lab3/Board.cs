using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    class Board
    {
        private CardMinion[] board;

        public Board()
        {
            board = new CardMinion[5];
        }

        public CardMinion this[int index]
        {
            get => board[index];
            set => board[index] = value;
        }

        public int length()
        {
            return board.Length;
        }
        public void fillBoard()
        {
            CardMinion _temp;
            _temp = new CardMinion("Ragnaros", 8, 8, 8, "None", "All", "Legendary", true, false, "At the end of your turn, deal 8 damage to random minion");
            board[0] = _temp;
            _temp = new CardMinion("Lich King", 8, 8, 8, "None", "All", "Legendary", true, false, " ");
            board[1] = _temp;
            _temp = new CardMinion("Deathwing", 10, 12, 12, "None", "All", "Legendary", true, false, " ");
            board[2] = _temp;
            _temp = new CardMinion("Yogg-Saron", 10, 7, 5, "None", "All", "Legendary", true, false, " ");
            board[3] = _temp;
            _temp = new CardMinion("Prophet Velen", 7, 7, 7, "None", "Priest", "Legendary", true, false, " ");
            board[4] = _temp;
        }
        public void show()
        {
            //showing manacosts
            
            for (int i = 0; i < board.Length; i++)
            {
                StringBuilder s_mana = new StringBuilder(board[i].name.Length);
                s_mana.Append(board[i].manacost.ToString());
                for (int j = 0; j < board[i].name.Length; j++)
                {
                    s_mana.Append(' ');
                }
                Console.Write($"{s_mana}\t");
            }
            Console.Write('\n');

            

            //showing names

            for (int i = 0; i < board.Length; i++)
            {
                Console.Write($"{board[i].name}\t");
            }

            Console.Write("\n");

            //showing stats
            for (int i = 0; i < board.Length; i++)
            {
                StringBuilder s_stats = new StringBuilder(board[i].description.Length);
                s_stats.Append(board[i].attack);
                for (int j = 0; j < board[i].name.Length - 1; j++)
                {
                    s_stats.Append(' ');
                }
                s_stats.Append(board[i].health);

                Console.Write($"{s_stats}\t");
                // Console.WriteLine($"Class: {board[i].hero} ");                
                // Console.WriteLine($"Rarity: {board[i].rarity} ");
            }
        }

        public void Refill()
        {
            int _mod = 0;
            for (int i = 0; i < board.Length; i++)
            {
                if(!board[i].isAlive)
                {
                    _mod++;
                }
            }
            CardMinion[] bTemp = new CardMinion[5 - _mod];
            int j = 0;
            for (int i = 0; i < board.Length; i++)
            {
                while(j < board.Length)
                {
                    if(board[j].isAlive)
                    {
                        bTemp[i] = board[j];
                        break;
                    }
                    j++;
                }
                j++;
            }
            board = bTemp;
        }
    }
}
