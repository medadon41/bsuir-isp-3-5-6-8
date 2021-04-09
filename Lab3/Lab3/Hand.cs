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
        public int length()
        {
            return hand.Length;
        }
        public void fillHand()
        {
            CardSpell _temp;
            _temp = new CardSpell("Chaos Nova", 5, "Demon Hunter", "Common", "Deal 4 damage to all minions", false);
            _temp.isInHand = true;
            hand[0] = _temp;
            _temp = new CardSpell("Circle of Healing", 0, "Priest", "Common", "Restore 4 Health to all minions", false);
            _temp.isInHand = true;
            hand[1] = _temp;
            _temp = new CardSpell("Flash Heal", 1, "Paladin", "Common",  "Restore 5 Health to a minion ", true);
            _temp.isInHand = true;
            hand[2] = _temp;
            _temp = new CardSpell("Flash of Light", 1, "Paladin", "Common", "Draw a card", false);
            _temp.isInHand = true;
            hand[3] = _temp;
        }
        public void Show()
        {
            for(int i = 0; i < hand.Length; i++) { 

                Console.WriteLine($"{hand[i].manacost}");

                Console.WriteLine($"{hand[i].name}");
                Console.WriteLine($"Rarity: {hand[i].rarity} ");

                Console.WriteLine($"{hand[i].description}");

                //showing stats

               if (hand[i].health != 0)
               {
                  StringBuilder s_stats = new StringBuilder(hand[i].description.Length);
                  s_stats.Append(hand[i].attack);
                  for (int j = 0; j < hand[i].name.Length - 1; j++)
                  {
                      s_stats.Append(' ');
                  }
                  s_stats.Append(hand[i].health);

                  Console.WriteLine($"{s_stats}");         
               }
                Console.WriteLine($"Class: {hand[i].hero} ");
                Console.WriteLine("-----------------------");
            }
                
        }

        public int handRefill(Card card)
        {
           card.isInHand = false;
            int _mod = 0;
            for (int i = 0; i < hand.Length; i++)
            {
                if (!hand[i].isInHand)
                {
                    _mod++;
                }
            }
          if (card.stype != SpellType.Draw)
           {
                Card[] bTemp = new Card[4 - _mod];

                int j = 0;
                for (int i = 0; i < hand.Length; i++)
                {
                    while (j < hand.Length)
                    {
                        if (hand[j].isInHand)
                        {
                            bTemp[i] = hand[j];
                            break;
                        }
                        j++;
                    }
                    j++;
                }
                hand = bTemp;
            }
            return _mod;
        }
        public void Draw(Card tcard, ref Deck deck)
        {
            int _mod = handRefill(tcard);
            Random rng = new Random();
            int ind = rng.Next(0, deck.length());

            Card[] bTemp = new Card[hand.Length];

            for (int i = 0; i < bTemp.Length - 1; i++)
            {
                bTemp[i] = hand[i];
            }

            bTemp[bTemp.Length - 1] = deck[ind];

            hand = bTemp;

        }
           
        
    }
}
