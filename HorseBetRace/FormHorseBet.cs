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
            SetUpRace();
        }

        //Setting up the data for race
        public void SetUpRace()
        {
            // Instantiate the Horses
            Horse.StartingPosition = pbHorse1.Right - pbRaceTrack.Left;
            Horse.RaceTrackLength = pbRaceTrack.Right - pbHorse1.Left; //fixing length of race - till finish line
            HorsesArray[0] = new Horse { Mypb = pbHorse1, HorseID = "#1" };
            HorsesArray[1] = new Horse { Mypb = pbHorse2, HorseID = "#2" };
            HorsesArray[2] = new Horse { Mypb = pbHorse3, HorseID = "#3" };
            HorsesArray[3] = new Horse { Mypb = pbHorse4, HorseID = "#4" };
            //create an array of punters and instantiate Factory classes
            for (var i = 0; i < 3; i++) MyPunters[i] = Factory.GetAPunter(i);

            //set the labels to the classes and update radiobuttons
            MyPunters[0].MyLabel = lblJoe;
            MyPunters[0].MyRadioButton = rbJoe;
            MyPunters[0].MaxBet = lblMaxBet;
            MyPunters[1].MyLabel = lblBob;
            MyPunters[1].MyRadioButton = rbBob;
            MyPunters[1].MaxBet = lblMaxBet;
            MyPunters[2].MyLabel = lblAl;
            MyPunters[2].MyRadioButton = rbAl;
            MyPunters[2].MaxBet = lblMaxBet;
            foreach (var punter in MyPunters) punter.UpdateLabels();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnBet.Enabled = true;
            btnRace.Enabled = false;
            btnRestart.Enabled = true;
        }

        private void rbAl_CheckedChanged(object sender, EventArgs e)
        {
            //Sets the maximum/minimum bet based of cash
            nudCash.Minimum = 5;
            nudCash.Maximum = MyPunters[2].Cash;
        }

        private void rbBob_CheckedChanged(object sender, EventArgs e)
        {
            //Sets the maximum/minimum bet based of cash
            nudCash.Minimum = 5;
            nudCash.Maximum = MyPunters[1].Cash;
        }

        private void rbJoe_CheckedChanged(object sender, EventArgs e)
        {
            //Sets the maximum/minimum bet based of cash
            nudCash.Minimum = 5;
            nudCash.Maximum = MyPunters[0].Cash;
        }

        public void GameOverCheck() // Checks to see if punter are busted and the game is over
        {
            if (MyPunters[0].Cash <= 0 && MyPunters[1].Cash <= 0 && MyPunters[2].Cash <= 0)
            {
                var message = "Do you want to Play Again?";
                var title = "GAME OVER!";
                var buttons = MessageBoxButtons.YesNo;
                var result = MessageBox.Show(message,
                    title,
                    buttons);
                if (result == DialogResult.Yes)
                {
                    SetUpRace(); //restart game
                    ResetRace();
                    rbJoe.Enabled = true;
                    rbBob.Enabled = true;
                    rbAl.Enabled = true;

                }
                else
                {
                    Close();
                }
            }
        }

        public void ResetBetAmount() // Rest the bet amounts to zero if the punter is busted
        {
            if (MyPunters[0].Cash == 0) MyPunters[0].MyBet.Amount = 0;

            if (MyPunters[1].Cash == 0) MyPunters[1].MyBet.Amount = 0;

            if (MyPunters[2].Cash == 0) MyPunters[2].MyBet.Amount = 0;
        }

        public void ResetRace() //Reset labels, bet amounts and horses back to start
        {
            //resets the label text
            MyPunters[0].UpdateLabels();
            MyPunters[1].UpdateLabels();
            MyPunters[2].UpdateLabels();
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
            foreach (var t in HorsesArray) t.TakeStartingPosition();

            btnBet.Enabled = true;
            btnRace.Enabled = false;
        }

        private void btnBet_Click(object sender, EventArgs e)
        {
            var punter = 0;
            if (rbJoe.Checked)
                punter = 0;
            else if (rbBob.Checked)
                punter = 1;
            else if (rbAl.Checked) punter = 2;

            MyPunters[punter].PlaceBet((int)nudCash.Value,
                (int)nudHorseNumber.Value -
                1); // Updates the bet amount and horse number using the Place bet in punter class
            MyPunters[punter].UpdateLabels();
            btnRace.Enabled = true; // Enable race button
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
                    foreach (var t in HorsesArray) t.TakeStartingPosition();

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

        private void timer1_Tick(object sender, EventArgs e)
        {
            var NoWinner = true;
            int winningHorse;
            timer1.Enabled = false;
            btnRace.Enabled = false; //disable start race button
            while (NoWinner)
            {
                // loop until we have a winner
                Application.DoEvents();
                for (var i = 0; i < HorsesArray.Length; i++)
                    if (Horse.Run(HorsesArray[i]))
                    {
                        winningHorse = i;
                        NoWinner = false;
                        MessageBox.Show("Horse #" + (winningHorse + 1) + " Wins");
                        foreach (var punter in MyPunters)
                            if (punter.MyBet != null)
                            {
                                punter.Collect(
                                    winningHorse); //give double amount to all who've won or deduce betted amount
                                punter.MyLabel.ResetText();
                                punter.UpdateLabels();
                            }

                        foreach (var horse in HorsesArray) horse.TakeStartingPosition();

                        break;
                    }
            }

            btnBet.Enabled = true;
            GameOverCheck();
            ResetBetAmount();
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
            SetUpRace();
            ResetBetAmount();
            ResetRace();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            // Closes the form
            Close();
        }
    }
}