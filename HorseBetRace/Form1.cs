using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HorseBetRace.Data.AllPunters;

namespace HorseBetRace
{
    public partial class Form1 : Form
    {
        Punter[] MyPunters = new Punter[3];
        Horse[] HorsesArray = new Horse[4];

        public Form1()
        {
            InitializeComponent();
            LoadData();
        }

        #region Load Data

        private void LoadData()
        {
            HorsesRace();
            LabelsClear();
            Punters();
            btnBet.Enabled = true;
            lblMaxBet.Visible = true;
            btnRace.Enabled = false;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        public void LabelsClear()
        {
            lblJoe.Text = "";
            lblBob.Text = "";
            lblAl.Text = "";
            lblMaxBet.Text = "";
        }

        public void HorsesRace() // Instantiate the Horses
        {
            HorsesArray[0] = new Horse
            {
                Mypb = pbHorse1,
                StartingPosition = pbHorse1.Left,
                HorseName = "#1",
                RaceTrackLength = pbRaceTrack.Width - pbHorse1.Width,
                Rand = new Random()
            };
            HorsesArray[1] = new Horse
            {
                Mypb = pbHorse2,
                StartingPosition = pbHorse2.Left,
                HorseName = "#2",
                RaceTrackLength = pbRaceTrack.Width - pbHorse2.Width,
                Rand = HorsesArray[0].Rand
            };
            HorsesArray[2] = new Horse
            {
                Mypb = pbHorse3,
                StartingPosition = pbHorse3.Left,
                HorseName = "#3",
                RaceTrackLength = pbRaceTrack.Width - pbHorse3.Width,
                Rand = HorsesArray[0].Rand
            };
            HorsesArray[3] = new Horse
            {
                Mypb = pbHorse4,
                StartingPosition = pbHorse4.Left,
                HorseName = "#4",
                RaceTrackLength = pbRaceTrack.Width - pbHorse4.Width,
                Rand = HorsesArray[0].Rand
            };
        }

        public void Punters()
        {
            //create an array of punters and instantiate Factory classes
            for (int i = 0; i < 3; i++)
            {
                MyPunters[i] = Factory.GetAPunter(i);
            }

            NotBetYet();

            //set the text boxs to the classes and update radiobuttons
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

        private void NotBetYet()
        {
            lblJoe.Text = MyPunters[0].PunterName + MyPunters[0].NotBetYet;
            lblBob.Text = MyPunters[1].PunterName + MyPunters[1].NotBetYet;
            lblAl.Text = MyPunters[2].PunterName + MyPunters[2].NotBetYet;
        }

        #endregion

        #region Radio Buttons Checked/Changed

        private void rbJoe_CheckedChanged(object sender, EventArgs e)
        {
            //Show that Joe is betting in the bet label
            lblBettor.Text = MyPunters[0].PunterName;
            //Sets the maxinum bet
            lblMaxBet.Text = MyPunters[0].PunterName + @" Max Bet $" + MyPunters[0].Cash;
            nudCash.Maximum = MyPunters[0].Cash;
        }

        private void rbBob_CheckedChanged(object sender, EventArgs e)
        {
            //Show that Bob is betting in the bet label 
            lblBettor.Text = MyPunters[1].PunterName;
            //Sets the maxinum bet
            lblMaxBet.Text = MyPunters[1].PunterName + @" Max Bet $" + MyPunters[1].Cash;
            nudCash.Maximum = MyPunters[1].Cash;
        }

        private void rbAl_CheckedChanged(object sender, EventArgs e)
        {
            //Show that Al is betting in the bet label 
            lblBettor.Text = MyPunters[2].PunterName;
            //Sets the maxinum bet
            lblMaxBet.Text = MyPunters[2].PunterName + @" Max Bet $" + MyPunters[2].Cash;
            nudCash.Maximum = MyPunters[2].Cash;
        }

        #endregion

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

            MyPunters[punter]
                .PlaceBet((int) nudCash.Value,
                    (int) nudHorseNumber.Value -
                    1); // Updates the bet amount and horse number using the Placebet in punter class
            btnRace.Enabled = true;
        }
        public void ResetRace() //Reset horses back to start
        {
            //resets the text box
            MyPunters[0].MyLabel.ResetText();
            MyPunters[1].MyLabel.ResetText();
            MyPunters[2].MyLabel.ResetText();
            //resets the bet amounts to zero
            MyPunters[0].MyBet.Amount = 0;
            MyPunters[1].MyBet.Amount = 0;
            MyPunters[2].MyBet.Amount = 0;

            foreach (Horse t in HorsesArray)
            {
                t.Mypb.Left = t.StartingPosition;
            }

            btnBet.Enabled = true;
            btnRace.Enabled = false;
        }
       
        #region StartRace

        private void btnRace_Click(object sender, EventArgs e)
        {
            StartRace();

        }

        private void StartRace()
        {
            //Check if the punters have enough cash to proceed with the race if not show warning
            if (MyPunters[0].Cash < nudCash.Value && rbJoe.Enabled)
            {
                MessageBox.Show(@"Sorry Joe doesn't have enough cash to proceed");
                timer1.Enabled = false;
            }

            if (MyPunters[1].Cash < nudCash.Value && rbBob.Enabled)
            {
                MessageBox.Show(@"Sorry Bob doesn't have enough cash to proceed");
                timer1.Enabled = false;
            }

            if (MyPunters[2].Cash < nudCash.Value && rbAl.Enabled)
            {
                MessageBox.Show(@"Sorry Al doesn't have enough cash to proceed");
                timer1.Enabled = false;
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
                btnBet.Enabled = false;
                btnRace.Enabled = false;

            }
        }

        #endregion

        #region Winner

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
                            if (MyPunters[j].MyBet.PayOut(winner: winner) != 0) //payout is not 0
                                MyPunters[j].Cash += MyPunters[j].MyBet.PayOut(winner); 
                            MyPunters[j].MyRadioButton.Text = MyPunters[j].PunterName + " has $" + MyPunters[j].Cash;//Updates the radio button with new cash amount
                        }

                        ResetRace();
                        ResetBetAmount();
                        BettorBroke();
                        GameOverCheck();

                        break;
                    }
                }
            }

            catch
            {
                MessageBox.Show(@"A bet was not placed");
            }
        }

        #endregion

   

        public void GameOverCheck() // Checks to see if the game is over
        {
            if (MyPunters[0].Cash <= 0 && MyPunters[1].Cash <= 0 && MyPunters[2].Cash <= 0)
            {
                MessageBox.Show(@"Game Over! Your bettors are broke!");
                LabelsClear();
                ResetRace();
                this.Close();}
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            // Closes the form 
            this.Close();
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            LoadData();
            ResetRace();

            btnRestart.Enabled = false;
            btnBet.Enabled = true;

        }
    }
}