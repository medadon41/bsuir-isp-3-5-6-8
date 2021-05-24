using System;

namespace Lab3
{
    public delegate void CommitAttack();

    class Program
    {
        public static void сheckInt(ref string _num, ref int num)
        {
            while (_num == null)
            {
                try
                {
                    _num = Console.ReadLine();
                    num = int.Parse(_num) - 1;
                }
                catch (FormatException)
                {
                    Console.Write("\nError. Enter only number from 1 to 5: ");
                    _num = null;
                }
            }
        }

        private static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }

        static void Main(string[] args)
        {
            Players players = new Players();

            players[0].board.Fill();
            players[1].board.Fill();

            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Enemy Board~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");
            players[1].board.Show();
            Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Your Board~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            players[0].board.Show();

            Console.Write("\nChoose a minion which will attack (it's position on your board): ");
            
            string _minion = null;
            int minion = 0;

            сheckInt(ref _minion, ref minion);

            Console.Write("\nChoose a minion to attack (it's position on enemy board): ");
            string _target = null;
            int target = 0;

            сheckInt(ref _target, ref target);

            players[0].board[minion].CommitedAttack += DisplayMessage;

            bool repeat = true;

            while (repeat)
            {
                repeat = false;
                try
                {
                    players[0].board[minion].Attack(players[1].board[target]);
                }
                catch (IndexOutOfRangeException)
                {
                    Console.Write("\nError. Enter only numbers from 1 to 5");
                    Console.Write("\nChoose a minion which will attack (it's position on your board): ");

                    _minion = null;
                    minion = 0;

                    сheckInt(ref _minion, ref minion);

                    Console.Write("\nChoose a minion to attack (it's position on enemy board): ");
                    _target = null;
                    target = 0;

                    сheckInt(ref _target, ref target);

                    repeat = true;
                }
            }

            players[0].board.Refill(players[0].hand[0]);
            players[1].board.Refill(players[0].hand[0]);

            Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Enemy Board~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");
            players[1].board.Show();
            Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Your Board~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            players[0].board.Show();

            Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Your Hand~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            players[0].hand.Fill();
            players[0].hand.Show();

            players[0].deck.fillDeck();
            int pick = 0;
            do
            {
                Console.WriteLine("Choose what card to cast: ");
                switch (Console.ReadLine())
                {
                    case "1": players[0].hand[0].Cast(ref players); break;
                    case "2": players[0].hand[1].Cast(ref players); break;
                    case "3": players[0].hand[2].Cast(ref players); break;
                    case "4": players[0].hand[3].Cast(ref players); break;
                    default: pick = 1; break;
                }
            } while (pick != 0);

            //Console.Clear();
            Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Enemy Board~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");
            players[1].board.Show();
            Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Your Board~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            players[0].board.Show();
            Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Your Hand~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            players[0].hand.Show();
        }

    }
}

