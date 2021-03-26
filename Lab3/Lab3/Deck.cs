using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    class Deck
    {
        private Card[] cardSet;

        public Deck()
        {
            cardSet = new Card[10];
        }

        public Card this[int index]
        {
            get => cardSet[index];
            set => cardSet[index] = value;
        }

        /*
        static void FillCardSet(ref Card[] arr)
        {
            int manacost;
            string name;
            string hero;
            string rarity;
            string id;

            string s_mana;
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write("Enter the name of the card: ");
                name = Console.ReadLine();
                Console.Write("Enter the cost of the card: ");
                s_mana = Console.ReadLine();
                while (!CheckInt(s_mana))
                {
                    Console.Write("Enter the cost of the card: ");
                    s_mana = Console.ReadLine();
                }
                manacost = int.Parse(s_mana);
                Console.Write("Enter the class of the card (who can use it): ");
                hero = Console.ReadLine();
                Console.Write("Enter the rarity of the card: ");
                rarity = Console.ReadLine();
                arr[i] = new Card(name, manacost, hero, rarity);
                Console.Write("Enter the id of the card: ");
                id = Console.ReadLine();
                arr[i].ID = id;
                Console.Clear();
            }
        }
        */
    }
}
