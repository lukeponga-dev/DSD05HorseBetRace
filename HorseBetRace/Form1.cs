using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            HorsesRace();
            LabelsClear();
            Punters();
        }

        public void LabelsClear()
        {
            lblJoe.Text = "";
            lblBob.Text = "";
            lblAl.Text = "";
        }

        public void Punters()
        {
            //create an array of punters and instantiate Factory classes
            for (int i = 0; i < 3; i++)
            {
                MyPunters[i] = Factory.GetAPunter(i);
            }

            //set the text boxs to the classes and update
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

            MyPunters[punter].PlaceBet((int)nudCash.Value, (int)nudHorseNumber.Value - 1); // Updates the bet amount and horse number using the Placebet in punter class

        }
    }
}
