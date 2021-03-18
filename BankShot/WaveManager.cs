using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BankShot
{
    class WaveManager
    {
        //fields

        private int wave;
        //timer object field?
        //list of waves?
        private bool waveBreak;

        //constructor------------------------------------------------------------------------------

        public WaveManager()
        {


        }

        //accessors. accessors for timer and list are to be added once those are figured out ------

        public int Wave
        {
            get { return wave; }
            set { wave = value; }
        }

        //timer accessor here

        //list accessor here

        public bool WaveBreak
        {
            get { return waveBreak; }
            set { waveBreak = value; }
        }

        //methods. only headers and comments. params unfinished. ----------------------------------

        public bool CompleteWave(out bool cleared)
        {
            //called in update, will return true if wave is completed,
            //and contains an out variable that tells if the player cleared 
            //or timed out

        }

        public void NextWave()
        {
            //advances to next wave, tells enemy manager to spawn new enemies
            


        }

    }
}
