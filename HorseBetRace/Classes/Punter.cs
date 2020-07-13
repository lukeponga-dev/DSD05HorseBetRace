using System;
using System.Drawing;
using System.Windows.Forms;

namespace HorseBetRace.Data.AllPunters
{
    public abstract class Punter
    {
        public abstract string PunterName { get; set; } // The punters name
        public abstract Bet MyBet { get; set; }  // An instance of Bet() that has punters bet
        public abstract int Cash { get; set; } // How much money punter has
        public abstract RadioButton MyRadioButton { get; set; } //Radiobutton
        public abstract Label MyLabel { get; set; } //Label
        public bool Busted { get; set; }
        public Label MaxBet { get; set; }

        public void UpdateLabels() // Set my label to my bets description and the label on the radio button to show the punters cash
        {
            if (MyBet == null)
            {
                MyLabel.Text = string.Format("{0} hasn't placed any bets", PunterName);
            }
            else
            {
                MyLabel.Text = MyBet.GetDescription();
            }
            if (Cash == 0)
            {
                Busted = true;
                MyLabel.Text = string.Format("BUSTED!");
                MyRadioButton.Enabled = false;
                MyLabel.ForeColor = Color.Red;
            }
            MyRadioButton.Text = String.Format("{0} has ${1}", PunterName, Cash);
            MaxBet.Text = string.Format("Max bet ${0}", Cash);
        }

        public void PlaceBet(int betAmount, int horseToWin) // Place a new bet and store it in my bet field
        {
            //Displays error message if bet amount is greater than available cash
            if (Cash < betAmount)
            {
                MessageBox.Show($"{PunterName} doesn't have enough to bet");
            }
            else //else place a new bet and store it
            {
                MyBet = new Bet { Amount = betAmount, Horse = horseToWin, Bettor = this };
                UpdateLabels();
            }
        }

        public void Collect(int Winner)
        {
            Cash += MyBet.PayOut(Winner);
        }
    }
}