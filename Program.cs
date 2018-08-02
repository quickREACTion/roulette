using System;
using System.Threading;

namespace SpinToWin2
{
    class Program
    {
        static void Main(string[] args)
        {

            //Initiatialize new wheel and welcome user
            Wheel TestWheel = new Wheel();
            RoulletteTimed();
            System.Console.WriteLine("");
            System.Console.WriteLine("");

            System.Console.WriteLine("Enter your NAME Gambler!");
            System.Console.WriteLine("");

            //Create new user
            System.Console.Write("Your Name: ");
            string PlayerPick = Console.ReadLine();
            Player TestPlayer = new Player(PlayerPick);
            Roullette();

            //Display user info and Game Instructions
            // TestPlayer.DisplayInfo();
            TestWheel.Instructions(TestPlayer);


            //Start Gameplay loop
            while(TestPlayer.Chips > 0 && TestPlayer.Chips < 100) {
                TestWheel.DisplayBetTypes(TestPlayer);
                System.Console.WriteLine(" ");
                System.Console.WriteLine("Hope you placed your bets appropriately! ");
                System.Console.WriteLine("The wheel will begin to spin in...");
                Thread.Sleep(500);
                System.Console.Write(".");
                Thread.Sleep(500);
                System.Console.Write(".");
                Thread.Sleep(500);
                System.Console.Write(".");
                Thread.Sleep(500);
                System.Console.WriteLine(".");
                Thread.Sleep(1000);
                System.Console.WriteLine("3...");
                Thread.Sleep(1000);
                System.Console.WriteLine("2...");
                Thread.Sleep(1000);
                System.Console.WriteLine("1...");
                Thread.Sleep(1000);
                System.Console.WriteLine(" ");
                TestWheel.Spin(TestPlayer);
            }
                TestWheel.WinGame(TestPlayer);
                TestWheel.GameOver(TestPlayer);
        }

        public static void RoulletteTimed()
        {
            Console.Clear();
            System.Console.WriteLine("                       888        888   888            ");
            Thread.Sleep(500);
            System.Console.WriteLine("                       888        888   888            ");
            Thread.Sleep(500);
            System.Console.WriteLine("                       888        888   888            ");
            Thread.Sleep(500);
            System.Console.WriteLine("888d888 .d88b. 888  888888 .d88b. 888888888888 .d88b.  ");
            Thread.Sleep(500);
            System.Console.WriteLine("888P'  d88''88b888  888888d8P  Y8b888   888   d8P  Y8b ");
            Thread.Sleep(500);
            System.Console.WriteLine("888    888  888888  88888888888888888   888   88888888 ");
            Thread.Sleep(500);
            System.Console.WriteLine("888    Y88..88PY88b 888888Y8b.    Y88b. Y88b. Y8b.     ");
            Thread.Sleep(500);
            System.Console.WriteLine("888     'Y88P'  'Y88888888 'Y8888  'Y888 'Y888 'Y8888  ");
            Thread.Sleep(500);
        }

        public static void Roullette()
        {
            Console.Clear();
            System.Console.WriteLine("                       888        888   888            ");
            System.Console.WriteLine("                       888        888   888            ");
            System.Console.WriteLine("                       888        888   888            ");
            System.Console.WriteLine("888d888 .d88b. 888  888888 .d88b. 888888888888 .d88b.  ");
            System.Console.WriteLine("888P'  d88''88b888  888888d8P  Y8b888   888   d8P  Y8b ");
            System.Console.WriteLine("888    888  888888  88888888888888888   888   88888888 ");
            System.Console.WriteLine("888    Y88..88PY88b 888888Y8b.    Y88b. Y88b. Y8b.     ");
            System.Console.WriteLine("888     'Y88P'  'Y88888888 'Y8888  'Y888 'Y888 'Y8888  ");
        }
    }
}
