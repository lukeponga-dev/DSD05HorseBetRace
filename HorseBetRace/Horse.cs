using System;
using System.Windows.Forms;

namespace HorseBetRace
{
    public class Horse
    {
        public string HorseName { get; set; }

        // Where my picture box starts
        public int StartingPosition { get; set; }

        public int RaceTrackLength { get; set; }
        public PictureBox Mypb { get; set; } = null;
        public Random Rand { get; set; } // An instance of random for the random generator

        public bool Run(PictureBox raceTrack)
        {
            // Move forward spaces at random
            Mypb.Left += Rand.Next(1, 20);

            // Return true if race is won
            if (Mypb.Right > raceTrack.Right)
            {
                return true;
            }

            return false;
        }
    }
}