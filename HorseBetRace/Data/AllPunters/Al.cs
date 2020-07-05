﻿using System.Windows.Forms;

namespace HorseBetRace.Data.AllPunters
{

    public class Al : Punter
    {
        private Punter _punterImplementation;

        public Al() // Sets up the punter Al
        {
            PunterName = "Al";
            Cash = 50;
        }

        public override string PunterName
        {
            get => _punterImplementation.PunterName;
            set => _punterImplementation.PunterName = value;
        }

        public override Bet MyBet
        {
            get => _punterImplementation.MyBet;
            set => _punterImplementation.MyBet = value;
        }

        public override int Cash
        {
            get => _punterImplementation.Cash;
            set => _punterImplementation.Cash = value;
        }

        public override RadioButton MyRadioButton
        {
            get => _punterImplementation.MyRadioButton;
            set => _punterImplementation.MyRadioButton = value;
        }

        public override Label MyLabel
        {
            get => _punterImplementation.MyLabel;
            set => _punterImplementation.MyLabel = value;
        }
    }
}
