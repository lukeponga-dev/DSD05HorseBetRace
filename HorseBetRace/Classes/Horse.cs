using System;
using System.Drawing;
using System.Windows.Forms;

namespace HorseBetRace
{
    public class Horse
    {
        // The horse number
        public string HorseID { get; set; }

        // Where my picture box starts
        public static int StartingPosition { get; set; }

        public static int RaceTrackLength { get; set; }
        public PictureBox Mypb { get; set; } = null;
        public int Location { get; set; } = 0;
        public static Random Rand { get; set; } = new Random(); // An instance of random for the random generator

        public static bool Run(Horse obj)
        {
            int distance = Rand.Next(2, 6);
            if (obj.Mypb != null)
                obj.MoveHorse(distance);

            obj.Location += distance;
            if (obj.Location >= (RaceTrackLength - StartingPosition))
            {
                return true;
            }

            return false;
        }

        public void MoveHorse(int distance)
        {
            Point P = Mypb.Location;
            P.X += distance;
            Mypb.Location = P; // move horses
        }

        public void TakeStartingPosition()
        {
            MoveHorse(-Location); //reset horse location to start
            Location = 0;
        }
    }
}