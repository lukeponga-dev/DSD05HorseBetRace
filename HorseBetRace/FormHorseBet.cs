using HorseBetRace.Data.AllPunters;
using System;
using System.Windows.Forms;

namespace HorseBetRace
{
    public partial class FormHorseBet : Form
    {
        private readonly Horse[] HorsesArray = new Horse[4];
        private readonly Punter[] MyPunters = new Punter[3];

        public FormHorseBet()
        {
            InitializeComponent();
            HorsesRace();
            Punters();
            LabelsClear();
            NotBetYet();
        }

        //Setting up the data for race

        #region Load Data

        public void HorsesRace() // Instantiate the Horses
        {
            HorsesArray[0] = new Horse { Mypb = pbHorse1, StartingPosition = pbHorse1.Left, HorseName = "#1", RaceTrackLength = pbRaceTrack.Width - pbHorse1.Width, Rand = new Random() };
            HorsesArray[1] = new Horse { Mypb = pbHorse2, StartingPosition = pbHorse2.Left, HorseName = "#2", RaceTrackLength = pbRaceTrack.Width - pbHorse2.Width, Rand = HorsesArray[0].Rand };
            HorsesArray[2] = new Horse { Mypb = pbHorse3, StartingPosition = pbHorse3.Left, HorseName = "#3", RaceTrackLength = pbRaceTrack.Width - pbHorse3.Width, Rand = HorsesArray[0].Rand };
            HorsesArray[3] = new Horse { Mypb = pbHorse4, StartingPosition = pbHorse4.Left, HorseName = "#4", RaceTrackLength = pbRaceTrack.Width - pbHorse4.Width, Rand = HorsesArray[0].Rand };
        }

        public void LabelsClear() // Clears the labels
        {
            lblJoe.Text = "";
            lblBob.Text = "";
            lblAl.Text = "";
            lblMaxBet.Text = "";
        }

        public void Punters()
        {
            //create an array of punters and instantiate Factory classes
            for (int i = 0; i < 3; i++)
            {
                MyPunters[i] = Factory.GetAPunter(i);
            }

            //set the labels to the classes and update radiobuttons
            MyPunters[0].MyLabel = lblJoe;
            MyPunters[0].MyRadioButton = rbJoe;
            MyPunters[0].MyRadioButton.Text = MyPunters[0].PunterName + " has $" + MyPunters[0].Cash;
            MyPunters[1].MyLabel = lblBob;
            MyPunters[1].MyRadioButton = rbBob;
            MyPunters[1].MyRadioButton.Text = MyPunters[1].PunterName + " has $" + MyPunters[1].Cash;
            MyPunters[2].MyLabel = lblAl;
            MyPunters[2].MyRadioButton = rbAl;
            MyPunters[2].MyRadioButton.Text = MyPunters[2].PunterName + " has $" + MyPunters[2].Cash;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnBet.Enabled = true;
            btnRace.Enabled = false;
            btnRestart.Enabled = true;
        }
        private void NotBetYet()
        {
            lblJoe.Text = MyPunters[0].PunterName + MyPunters[0].NotBetYet;
            lblBob.Text = MyPunters[1].PunterName + MyPunters[1].NotBetYet;
            lblAl.Text = MyPunters[2].PunterName + MyPunters[2].NotBetYet;
        }

        #endregion Load Data

        #region Radio Buttons Checked/Changed

        private void rbAl_CheckedChanged(object sender, EventArgs e)
        {
            //set the max bet label to amount of cash punter has
            lblMaxBet.Text = MyPunters[2].PunterName + " Max Bet Amount $" + MyPunters[2].Cash.ToString();
            //Show that Al is betting in the bet label
            lblBettor.Text = MyPunters[2].PunterName + " $";
            //Sets the maximum/minimum bet based of cash
            nudCash.Minimum = 5;
            nudCash.Maximum = MyPunters[2].Cash;
        }

        private void rbBob_CheckedChanged(object sender, EventArgs e)
        {
            //set the max bet label to amount of cash punter has
            lblMaxBet.Text = MyPunters[1].PunterName + " Max Bet Amount $" + MyPunters[1].Cash.ToString();
            //Show that Bob is betting in the bet label
            lblBettor.Text = MyPunters[1].PunterName + " $";
            //Sets the maximum/minimum bet based of cash
            nudCash.Minimum = 5;
            nudCash.Maximum = MyPunters[1].Cash;
        }

        private void rbJoe_CheckedChanged(object sender, EventArgs e)
        {
            //set the max bet label to amount of cash punter has
            lblMaxBet.Text = MyPunters[0].PunterName + " Max Bet Amount $" + MyPunters[0].Cash.ToString();
            //Show that Joe is betting in the bet label
            lblBettor.Text = MyPunters[0].PunterName + " $";
            //Sets the maximum/minimum bet based of cash
            nudCash.Minimum = 5;
            nudCash.Maximum = MyPunters[0].Cash;
        }

        #endregion Radio Buttons Checked/Changed

        public void BettorBroke() // Checks to see if any punters are broke and cant continue
        {
            if (MyPunters[0].Cash <= 0) // Joe
            {
                lblJoe.Text = MyPunters[0].PunterName + MyPunters[0].Busted;
                rbJoe.Enabled = false;
            }

            if (MyPunters[1].Cash <= 0) // Bob
            {
                lblBob.Text = MyPunters[1].PunterName + MyPunters[1].Busted;
                rbBob.Enabled = false;
            }

            if (MyPunters[2].Cash <= 0) // Al
            {
                lblAl.Text = MyPunters[2].PunterName + MyPunters[2].Busted;
                rbAl.Enabled = false;
            }
        }

        public void GameOverCheck() // Checks to see if the game is over
        {
            if (MyPunters[0].Cash <= 0 && MyPunters[1].Cash <= 0 && MyPunters[2].Cash <= 0)
            {
                MessageBox.Show(@"Game Won! Your bettors are broke!");
                LabelsClear();
                ResetRace();
                this.Close();
            }
        }

        public void ResetBetAmount() // Rest the bet amounts to zero if the punter is busted
        {
            if (MyPunters[0].Cash == 0)
            {
                MyPunters[0].MyBet.Amount = 0;
            }

            if (MyPunters[1].Cash == 0)
            {
                MyPunters[1].MyBet.Amount = 0;
            }
            if (MyPunters[2].Cash == 0)
            {
                MyPunters[2].MyBet.Amount = 0;
            }
        }

        public void ResetRace() //Reset labels, bet amounts and horses back to start
        {
            //resets the label text
            NotBetYet();

            //resets the bet amounts to zero
            var myBet = MyPunters[0].MyBet;
            if (myBet != null)
            {
                myBet.Amount = 0;
                var bet = MyPunters[1].MyBet;
                if (bet != null)
                {
                    bet.Amount = 0;
                    var o = MyPunters[2].MyBet;
                    if (o != null) o.Amount = 0;
                }
            }
            //resets the max bet label text
            lblMaxBet.ResetText();
            //resets punters max bet amount to new cash amount
            nudCash.Maximum = MyPunters[2].Cash;
            nudCash.Maximum = MyPunters[1].Cash;
            nudCash.Maximum = MyPunters[0].Cash;

            //Reset horses back to start
            foreach (Horse t in HorsesArray)
            {
                t.Mypb.Left = t.StartingPosition;
            }

            btnBet.Enabled = true;
            btnRace.Enabled = false;
        }

        private void btnBet_Click(object sender, EventArgs e)
        {
            var punter = 0;
            if (rbJoe.Checked)
            {
                punter = 0;
            }
            else if (rbBob.Checked)
            {
                punter = 1;
            }
            else if (rbAl.Checked)
            {
                punter = 2;
            }

            MyPunters[punter].PlaceBet((int)nudCash.Value, (int)nudHorseNumber.Value - 1); // Updates the bet amount and horse number using the Place bet in punter class

            btnRace.Enabled = true; // Enable race button
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            // Closes the form
            this.Close();
        }

        private void btnRace_Click(object sender, EventArgs e)
        {
            // check bet amount is not more than cash
            try
            {
                if (MyPunters[0].Cash < MyPunters[0].MyBet.Amount)
                {
                    MessageBox.Show("Joe does not have enough to proceed");
                    btnRace.Enabled = false;
                }

                if (MyPunters[1].Cash < MyPunters[1].MyBet.Amount)
                {
                    MessageBox.Show("Bob does not have enough to proceed");
                    btnRace.Enabled = false;
                }

                if (MyPunters[2].Cash < MyPunters[2].MyBet.Amount)
                {
                    MessageBox.Show("Al does not have enough to proceed");
                    btnRace.Enabled = false;
                }
                else
                {
                    //Reset starting positions
                    foreach (Horse t in HorsesArray)
                    {
                        t.Mypb.Left = t.StartingPosition;
                    }
                    //start timer for the race
                    timer1.Enabled = true;
                    // Disable bet & race buttons while racing
                    btnBet.Enabled = false;
                    btnRace.Enabled = false;
                    rbJoe.Checked = false;
                    rbBob.Checked = false;
                    rbAl.Checked = false;
                    ResetBetAmount();
                }
            }
            catch
            {
                MessageBox.Show("Please place all bets");
            }
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            // Enable radio buttons
            rbJoe.Enabled = true;
            rbBob.Enabled = true;
            rbAl.Enabled = true;
            // Disable timer
            timer1.Enabled = false;
            // Enable bet button
            btnBet.Enabled = true;

            Punters();
            ResetBetAmount();
            ResetRace();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Run the timer for the race and return the winner and bet results
            try
            {
                int winner;

                for (int i = 0; i < HorsesArray.Length; i++)
                {
                    if (HorsesArray[i].Run(pbRaceTrack)) // use Horse.run class for race if true return a winner and stop timer event
                    {
                        winner = i;
                        timer1.Enabled = false;
                        MessageBox.Show(@"Horse #" + (winner + 1) + " Wins");

                        for (int j = 0; j < MyPunters.Length; j++)
                        {
                            if (MyPunters[j].MyBet.PayOut(winner) != 0) //payout is not 0
                                MyPunters[j].Cash += MyPunters[j].MyBet.PayOut(winner);
                            MyPunters[j].MyRadioButton.Text = MyPunters[j].PunterName + " has $" + MyPunters[j].Cash; //Updates the radio button with new cash amount
                        }

                        ResetRace(); // Resets the labels, bet amounts, and starting positions
                        ResetBetAmount(); // Reset bet amounts if bettor is busted
                        BettorBroke(); // Checks to see if anyone is busted and disables them
                        GameOverCheck(); // Checks to see if the game is over close if true
                        break;
                    }
                }
            }
            catch
            {
                MessageBox.Show(@"A Bet was not placed");
            }
        }
    }
}