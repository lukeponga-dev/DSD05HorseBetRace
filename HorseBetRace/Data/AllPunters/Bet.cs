﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorseBetRace.Data.AllPunters
{
   public class Bet
    {
        public int Amount { get; set; } // Amount of cash that was bet
        public int Horse { set; get; } // Number of the Horse the bet is placed on
        public Punter Bettor { get; set; } // Punter who placed bet

        public string GetDescription() //Return a string who placed the bet, how much the bet is, which number horse its on 
        {
            string description = Bettor.PunterName + " bet $" + Amount + " on Horse " + (Horse + 1);
            return description;
            //If amount is 0 no bet is place
            
        }

        public int PayOut(int winner)//The winner is winner of race if the horse won return the amount bet
        {
            if (winner == Horse)
            {
                return Amount;

            }
            else//else negative amount bet 

            {
                return -1 * Amount;
            }
        }
    }
}
