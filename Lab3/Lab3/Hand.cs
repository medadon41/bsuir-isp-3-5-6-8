using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    class Hand
    {
        private Card[] hand;

        public Hand()
        {
            hand = new Card[4];
        }

        public Card this[int index]
        {
            get => hand[index];
            set => hand[index] = value;
        }
    }
}
