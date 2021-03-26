using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    class Players
    {
        private Player[] players;

        public Players()
        {
            players = new Player[2];
            Player player1 = new Player();
            players[0] = player1;
            Player player2 = new Player();
            players[1] = player2;
        }

        public Player this[int index]
        {
            get => players[index];
            set => players[index] = value;
        }
    }
}
