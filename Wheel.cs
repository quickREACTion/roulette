// This class is to create the wheel on which the tiles reside.
// The wheel is built with a List of Tiles, not unlike the deck of cards assignment.

// We are using a european style wheel with the following values:
// 37 slots (0, 1-36)
// Right side (of the zero) has 9 black numbers (2, 4, 6, 8, 10, 11, 13, 15, 17) and 9 red numbers (19, 21, 23, 25, 27, 30, 32, 34, 36)
// Left side (of the zero) also has 9 black (20, 22, 24, 26, 28, 29, 31, 33, 35) and 9 red numbers (1, 3, 5, 7, 9, 12, 14, 16, 18)
// All numbers are inside of the wheel

using System;
using System.Collections.Generic;

namespace SpinToWin2
{
    public class Wheel
    {
        public List<Tile> Tiles = new List<Tile>();

        public Wheel()
        {   
            //create seperate lists of black and red numbers
            int[] BlackNumbers = {2,4,6,8,10,11,13,15,17,20,22,24,26,28,29,31,33,35};
            int[] RedNumbers = {1,3,5,7,9,12,14,16,18,19,21,23,25,27,30,32,34,36};

            // Add black numbered tiles to Wheel.Tiles
            for(int i = 0; i < BlackNumbers.Length; i++)
            {
                Tile AddTile = new Tile();
                AddTile.Color = "black";
                AddTile.Value = BlackNumbers[i];
                Tiles.Add(AddTile);
            }

            // Add red numbered tiles to Wheel.Tiles
            for(int i = 0; i < RedNumbers.Length; i++)
            {
                Tile AddTile = new Tile();
                AddTile.Color = "red";
                AddTile.Value = RedNumbers[i];
                Tiles.Add(AddTile);
            }
            
            // Add green zero tile to Wheel.Tiles
            Tile GreenTile = new Tile();
            GreenTile.Color = "green";
            GreenTile.Value = 0;
            Tiles.Add(GreenTile);

        }

        public void Instructions(Player CurrentPlayer) {
            System.Console.WriteLine(" ");
            System.Console.WriteLine("Welcome to Spin To Win!");
            System.Console.WriteLine($"Good luck {CurrentPlayer.Name}!");
            System.Console.WriteLine(" ");
        }

        // Spin method spins the wheel and return a random tile. It also prints the color and value.
        public Tile Spin(Player CurrentPlayer)
        {
            Random rand = new Random();
            Tile CurrentTile = Tiles[rand.Next(Tiles.Count)];
            System.Console.WriteLine(" ");
            System.Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$");
            System.Console.WriteLine($"$$$$$$$$$$$ THE ROULLETTE BALL ROLLED A {CurrentTile.Color} {CurrentTile.Value}! $$$$$$$$$$");
            System.Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$");
            System.Console.WriteLine(" ");

            foreach (Bet CurrentBet in CurrentPlayer.Bets)
            {
                System.Console.Write($"You bet on {CurrentBet.Type} ");
                if(CurrentBet.Type == "odd" && CurrentTile.Value % 2 != 0) {
                    int Winnings = CurrentBet.Amount * 2;
                    CurrentPlayer.Chips += Winnings;
                    System.Console.WriteLine($"and won {Winnings} chips!");
                    
                }
                else if(CurrentBet.Type == "odd" && CurrentTile.Value % 2 == 0) {
                    System.Console.WriteLine($"and lost {CurrentBet.Amount} chips!");
                }
                else if(CurrentBet.Type == "even" && CurrentTile.Value % 2 == 0) {
                    int Winnings = CurrentBet.Amount * 2;
                    CurrentPlayer.Chips += Winnings;
                    System.Console.WriteLine($"and won {Winnings} chips!");
                }
                else if(CurrentBet.Type == "even" && CurrentTile.Value % 2 != 0) {
                    System.Console.WriteLine($"and lost {CurrentBet.Amount} chips!");
                }
                else if(CurrentBet.Type == CurrentTile.Color) {
                    int Winnings = CurrentBet.Amount * 2;
                    CurrentPlayer.Chips += Winnings;
                    System.Console.WriteLine($"and won {Winnings} chips!");
                }
                else if(CurrentBet.Type == "black" && CurrentTile.Color == "red")
                {
                    System.Console.WriteLine($"and lost {CurrentBet.Amount} chips!");
                }
                else if(CurrentBet.Type == "red" && CurrentTile.Color == "black")
                {
                    System.Console.WriteLine($"and lost {CurrentBet.Amount} chips!");
                }
                else if(Convert.ToInt32(CurrentBet.Type) == CurrentTile.Value) {
                    int Winnings = CurrentBet.Amount * 35;
                    CurrentPlayer.Chips += Winnings;
                    System.Console.WriteLine($"and won {Winnings} chips!");
                }  
                else
                {
                    System.Console.WriteLine($"and lost {CurrentBet.Amount} chips!");
                }                
                    System.Console.WriteLine(" ");
            }
            CurrentPlayer.Bets.Clear();
            return CurrentTile;
        }

        public void DisplayBetTypes(Player CurrentPlayer)
        {
            string KeepBetting = "n";
            System.Console.WriteLine($"Your current chip count is {CurrentPlayer.Chips}!");
            System.Console.WriteLine(" ");
            //Start the betting process            
            while (KeepBetting == "n")
            {
                //Prompt player for bet type
                System.Console.WriteLine("Which bet would you like?");
                System.Console.WriteLine("Your options are odd/even, red/black, or single/number");
                System.Console.WriteLine("Type odd, even, red, black, or the number you want to play.");
                string BetType = Console.ReadLine();
                System.Console.WriteLine(" ");

                System.Console.WriteLine($"How much would you like to bet? You have {CurrentPlayer.Chips}");
                string strBetAmount = Console.ReadLine().ToLower();
                int intBetAmount = Convert.ToInt32(strBetAmount);

                //Check bet type player inputs and add to player.bets or push error if not a valid bet type
                if  (BetType == "odd" || BetType == "even")  
                {
                    Bet Bet = new Bet(BetType, intBetAmount);
                    CurrentPlayer.Bets.Add(Bet);
                    CurrentPlayer.Chips -= intBetAmount;
                } 
                else if (BetType == "black" || BetType == "red") {
                    Bet Bet = new Bet(BetType, intBetAmount);
                    CurrentPlayer.Bets.Add(Bet);
                    CurrentPlayer.Chips -= intBetAmount; 
                } 
                else if (Convert.ToInt32(BetType) > 0 && Convert.ToInt32(BetType) < 37) {
                    Bet Bet = new Bet(BetType, intBetAmount);
                    CurrentPlayer.Bets.Add(Bet);
                    CurrentPlayer.Chips -= intBetAmount;
                } 
                else {
                    System.Console.WriteLine("Please input a correct bet type.");
                }

                if(CurrentPlayer.Chips > 0){
                    //Check if player is finished betting
                    System.Console.WriteLine("Are you finished betting? Type y or n.");
                    KeepBetting = Console.ReadLine();
                }
                else
                {
                    KeepBetting = "y";
                }
            }
            Console.Clear();
        }

        public void WinGame(Player CurrentPlayer) {
            if (CurrentPlayer.Chips >= 100) {
                System.Console.WriteLine("Congratulations! You have defeated the Roulette Wheel!");
            } 
        }
        public void GameOver(Player CurrentPlayer) {
            if (CurrentPlayer.Chips <= 0) {
                System.Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$");
                System.Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$ You lose! The House Always wins! $$$$$$$$$$$$$$$$$$$$$$$$$$$$$");
                System.Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$");

            }
        }

    }
}