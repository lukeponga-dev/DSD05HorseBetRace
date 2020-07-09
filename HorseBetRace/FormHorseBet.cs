using HorseBetRace.Data.AllPunters;
using System;
using System.Windows.Forms;
using HorseBetRace.Data;

namespace HorseBetRace
{
    public partial class FormHorseBet : Form
    {
        private readonly Horse[] _horsesArray = new Horse[4];
        private readonly Punter[] _myPunters = new Punter[3];

        public FormHorseBet()
        {
            InitializeComponent();
            HorsesRace();
            Punters();
            // LabelsClear();
            //NotBetYet();
        }
        //Setting up the data for race
        #region Load Data

        public void HorsesRace() // Instantiate the Horses
        {
            _horsesArray[0] = new Horse { Mypb = pbHorse1, StartingPosition = pbHorse1.Left, HorseID = "#1", RaceTrackLength = pbRaceTrack.Width - pbHorse1.Width, Rand = new Random() };
            _horsesArray[1] = new Horse { Mypb = pbHorse2, StartingPosition = pbHorse2.Left, HorseID = "#2", RaceTrackLength = pbRaceTrack.Width - pbHorse2.Width, Rand = _horsesArray[0].Rand };
            _horsesArray[2] = new Horse { Mypb = pbHorse3, StartingPosition = pbHorse3.Left, HorseID = "#3", RaceTrackLength = pbRaceTrack.Width - pbHorse3.Width, Rand = _horsesArray[0].Rand };
            _horsesArray[3] = new Horse { Mypb = pbHorse4, StartingPosition = pbHorse4.Left, HorseID = "#4", RaceTrackLength = pbRaceTrack.Width - pbHorse4.Width, Rand = _horsesArray[0].Rand };
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnBet.Enabled = true;
            btnRace.Enabled = false;
            btnRestart.Enabled = true;
        }

        // public void LabelsClear() // Clears the labels
        // {
        //     lblJoe.Text = "";
        //     lblBob.Text = "";
        //     lblAl.Text = "";
        //     lblMaxBet.Text = "";
        // }

        public void Punters()
        {
            //create an array of punters and instantiate Factory classes
            for (int i = 0; i < 3; i++)
            {
                _myPunters[i] = Factory.GetAPunter(i);
            }

            NotBetYet();
            //set the labels to the classes and update radiobuttons
            _myPunters[0].MyLabel = lblJoe;
            _myPunters[0].MyRadioButton = rbJoe;
            _myPunters[0].MyRadioButton.Text = $"{_myPunters[0].PunterName} has ${_myPunters[0].Cash}";
            _myPunters[1].MyLabel = lblBob;
            _myPunters[1].MyRadioButton = rbBob;
            _myPunters[1].MyRadioButton.Text = $"{_myPunters[1].PunterName} has ${_myPunters[1].Cash}";
            _myPunters[2].MyLabel = lblAl;
            _myPunters[2].MyRadioButton = rbAl;
            _myPunters[2].MyRadioButton.Text = $"{_myPunters[2].PunterName} has ${_myPunters[2].Cash}";
        }

        private void NotBetYet()//set the labels text to not placed a bet
        {
            lblJoe.Text = _myPunters[0].PunterName + _myPunters[0].NotBetYet;
            lblBob.Text = _myPunters[1].PunterName + _myPunters[1].NotBetYet;
            lblAl.Text = _myPunters[2].PunterName + _myPunters[2].NotBetYet;
        }

        #endregion Load Data      

        //This region is for RadioButton Checks for punters to assign bettors Names.
        //Added up-down minimum = 5,  maximum = bettors cash

        #region Radio Buttons Checked/Changed

        private void rbAl_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAl.Checked)
            {
                //Show that Al is betting in the bet label
                lblBettor.Text = _myPunters[2].PunterName + " $";
                //set the max bet label to amount of cash punter has
                lblMaxBet.Text = _myPunters[2].PunterName + _myPunters[2].MaxBet + _myPunters[2].Cash;
                //Sets the maximum/minimum bet based of cash
                nudCash.Minimum = 5;
                nudCash.Maximum = _myPunters[2].Cash;
            }
        }

        private void rbBob_CheckedChanged(object sender, EventArgs e)
        {
            if (rbBob.Checked)
            {
                //Show that Bob is betting in the bet label
                lblBettor.Text = _myPunters[1].PunterName + " $";
                //set the max bet label to amount of cash punter has
                lblMaxBet.Text = _myPunters[1].PunterName + _myPunters[1].MaxBet + _myPunters[1].Cash;
                //Sets the maximum/minimum bet based of cash
                nudCash.Minimum = 5;
                nudCash.Maximum = _myPunters[1].Cash;
            }
        }

        private void rbJoe_CheckedChanged(object sender, EventArgs e)
        {
            if (rbJoe.Checked)
            {
                //Show that Joe is betting in the bet label
                lblBettor.Text = _myPunters[0].PunterName + " $";
                //set the max bet label to amount of cash punter has
                lblMaxBet.Text = _myPunters[0].PunterName + _myPunters[0].MaxBet + _myPunters[0].Cash;
                //Sets the maximum/minimum bet based of cash
                nudCash.Minimum = 5;
                nudCash.Maximum = _myPunters[0].Cash;
            }
        }

        #endregion Radio Buttons Checked/Changed

        public void BettorBroke() // Checks to see if any punters are broke and cant continue
        {
            if (_myPunters[0].Cash <= 0) // Joe
            {
                lblJoe.Text = _myPunters[0].PunterName + _myPunters[0].Busted;
                rbJoe.Enabled = false;
            }

            if (_myPunters[1].Cash <= 0) // Bob
            {
                lblBob.Text = _myPunters[1].PunterName + _myPunters[1].Busted;
                rbBob.Enabled = false;
            }

            if (_myPunters[2].Cash <= 0) // Al
            {
                lblAl.Text = _myPunters[2].PunterName + _myPunters[2].Busted;
                rbAl.Enabled = false;
            }
        }

        public void GameOverCheck() // Checks to see if punter are busted and the game is over
        {
            if (_myPunters[0].Cash <= 0 && _myPunters[1].Cash <= 0 && _myPunters[2].Cash <= 0)
            {
                MessageBox.Show(@"Game Won! Your bettors are broke! - Game Over");
                this.Close();
            }
        }

        public void ResetBetAmount() // Rest the bet amounts to zero if the punter is busted
        {
            if (_myPunters[0].Cash == 0)
            {
                _myPunters[0].MyBet.Amount = 0;
            }

            if (_myPunters[1].Cash == 0)
            {
                _myPunters[1].MyBet.Amount = 0;
            }
            if (_myPunters[2].Cash == 0)
            {
                _myPunters[2].MyBet.Amount = 0;
            }
        }

        public void ResetRace() //Reset labels, bet amounts and horses back to start
        {
            //resets the label text
            NotBetYet();

            //resets the bet amounts to zero
            var myBet = _myPunters[0].MyBet;
            if (myBet != null)
            {
                myBet.Amount = 0;
                var bet = _myPunters[1].MyBet;
                if (bet != null)
                {
                    bet.Amount = 0;
                    var o = _myPunters[2].MyBet;
                    if (o != null) o.Amount = 0;
                }
            }
            //resets the max bet label text
            lblMaxBet.ResetText();
            //resets punters max bet amount to new cash amount
            nudCash.Maximum = _myPunters[2].Cash;
            nudCash.Maximum = _myPunters[1].Cash;
            nudCash.Maximum = _myPunters[0].Cash;

            //Reset horses back to start
            foreach (Horse t in _horsesArray)
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

            _myPunters[punter].PlaceBet((int)nudCash.Value, (int)nudHorseNumber.Value - 1); // Updates the bet amount and horse number using the Place bet in punter class
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
                if (_myPunters[0].Cash < _myPunters[0].MyBet.Amount)
                {
                    MessageBox.Show("Joe does not have enough to proceed");
                    btnRace.Enabled = false;
                }

                if (_myPunters[1].Cash < _myPunters[1].MyBet.Amount)
                {
                    MessageBox.Show("Bob does not have enough to proceed");
                    btnRace.Enabled = false;
                }

                if (_myPunters[2].Cash < _myPunters[2].MyBet.Amount)
                {
                    MessageBox.Show("Al does not have enough to proceed");
                    btnRace.Enabled = false;
                }
                else
                {
                    //Reset starting positions
                    foreach (Horse t in _horsesArray)
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
                for (int i = 0; i < _horsesArray.Length; i++)
                {
                    if (_horsesArray[i].Run(pbRaceTrack)) // use Horse.run class for race if true return a winner and stop timer event
                    {
                        var winner = i;
                        timer1.Enabled = false;
                        MessageBox.Show(@"Horse #" + (winner + 1) + " Wins");

                        foreach (var t in _myPunters)
                        {
                            if (t.MyBet.PayOut(winner) != 0) //payout is not 0
                                t.Cash += t.MyBet.PayOut(winner);
                            t.MyRadioButton.Text = t.PunterName + " has $" + t.Cash; //Updates the radio button with new cash amount
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