// This file includes the Player class.
// Players are able to make bets, lose and gain chips
// Players must input their name and start with zero chips

using System;
using System.Collections.Generic;

namespace SpinToWin2
{
    public class Player
    {
        public string Name;
        public int Chips;
        public List<Bet> Bets = new List<Bet>();

        public Player(string nickname)
        {
            Name = nickname;
            Chips = 10;
        }

        // Add chips to the player's total
        public void BuyChips(int BuyIn)
        {   
            if(BuyIn > 0)
            {
                Chips += BuyIn; 
            }
            else
            {
                System.Console.WriteLine("Must input at least a dollar!");
            }
        }

        // public void DisplayInfo() {
        //     System.Console.WriteLine("Gambler Name: " + Name);
        // }


        public string pickNum(Wheel board) {
            Wheel something = board as Wheel;
            // System.Console.WriteLine("Place your bet!");
            // string playerBet = Console.ReadLine();
            System.Console.WriteLine("Pick your Number");
            string PlayerPick = Console.ReadLine();
            int currentPlayerPick = Convert.ToInt32(PlayerPick); 
            System.Console.WriteLine(" ");
            return PlayerPick;
        }


    }
}