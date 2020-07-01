using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HorseBetRace
{
  public class Horse
    {
        // Sets the Horse name
        public string HorseName { get; set; }
        // Where my picture box starts
        public int StartingPosition { get; set; }
        public int RaceTrackLength { get; set; } // How long my racetrack is
        public PictureBox Mypb { get; set; } = null; // The picturebox object
        public Random Rand { get; set; } // An instance of random for the random generator

        public bool Run(PictureBox raceTrack)
        {
            // Move forward 1, 2, 3 or 4 spaces at random
            Mypb.Left += Rand.Next(0, 6);

            // Return true if race is won
            if (Mypb.Right > raceTrack.Right)
            {
                return true;
            }

            return false;
        }
    }
}
