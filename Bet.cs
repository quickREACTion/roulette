using System;
using System.Collections.Generic;

namespace SpinToWin2
{
    public class Bet
    { 
        public int Amount;
        public string Type;
        public Bet(string BetType, int BetAmount)
        {
            Amount = BetAmount;
            Type = BetType;
        } 
    }
}