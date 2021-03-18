using System;

namespace Lab3
{

    class Program
    {
        static bool CheckInt(string _int)
        {
            if (int.TryParse(_int, out int test)) { return true; }
            else return false;
        }
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

        static void ShowCardSet(Card[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"Card: {arr[i].name} ");
                Console.WriteLine($"Cost: {arr[i].manacost} ");
                Console.WriteLine($"Class: {arr[i].hero} ");
                Console.WriteLine($"Rarity: {arr[i].rarity} ");
                Console.WriteLine("///////////////////////");
            }
        }
        static void Main(string[] args)
        {
            Console.Write("How many cards do you want to have in your card set? ");
            int n = int.Parse(Console.ReadLine());

            Card[] cardSet = new Card[n];

            FillCardSet(ref cardSet);

            Console.WriteLine("Your card set: \n");
            ShowCardSet(cardSet);

            Console.Write("Choose which card's manacost you want to change: \n");
            int m = int.Parse(Console.ReadLine());

            Console.Write("Enter the the number of mana you want to be reduced/increased by: \n");

            string _mn = Console.ReadLine();
            while (!CheckInt(_mn))
            {
                Console.Write("Enter the the number of mana you want to be reduced/increased by: \n");
                _mn = Console.ReadLine();
            }

            cardSet[m - 1].ChangeManacost(int.Parse(_mn));

            ShowCardSet(cardSet);
        }

    }
}

