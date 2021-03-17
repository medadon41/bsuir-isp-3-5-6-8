using System;

namespace Lab3
{

    class card
    {
        //inspired by hearthstone

        public string name;
        public int manacost;
        public string hero;
        public string rarity;
        private string id;


        public card()
        {
        }

        public card(string s_name, int s_mana, string s_hero, string s_rarity)
        {
            name = s_name;
            manacost = s_mana;
            hero = s_hero;
            rarity = s_rarity;
        }

        public string ID
        {
            set
            {
                id = value;
            }
        }
    }
    class Program
    {
        static bool intCheck(string _int)
        {
            if (int.TryParse(_int, out int test)) { return true; }
            else return false;
        }
        static void cardSetFill(ref card[] arr)
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
                while (!intCheck(s_mana))
                {
                    Console.Write("Enter the cost of the card: ");
                    s_mana = Console.ReadLine();
                }
                manacost = int.Parse(s_mana);
                Console.Write("Enter the class of the card (who can use it): ");
                hero = Console.ReadLine();
                Console.Write("Enter the rarity of the card: ");
                rarity = Console.ReadLine();
                arr[i] = new card(name, manacost, hero, rarity);
                Console.Write("Enter the id of the card: ");
                id = Console.ReadLine();
                arr[i].ID = id;
                Console.Clear();
            }
        }

        static void showCardSet(card[] arr)
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

            card[] cardSet = new card[n];

            cardSetFill(ref cardSet);

            Console.WriteLine("Your card set: \n");
            showCardSet(cardSet);
        }

    }
}

