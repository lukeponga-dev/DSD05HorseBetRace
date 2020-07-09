namespace HorseBetRace.Data.AllPunters
{
    public class Bet
    {
        public int Amount { get; set; } // Amount of cash that was bet
        public int Horse { get; set; } // Number of the Horse the bet is placed on
        public Punter Bettor { get; set; } // Punter who placed bet

        public string GetDescription() //Return a string who placed the bet, how much the bet is, which number horse its on
        {
            string labeldescription = $"{Bettor.PunterName} bets ${Amount} on Horse #{Horse + 1}";
            return labeldescription;

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