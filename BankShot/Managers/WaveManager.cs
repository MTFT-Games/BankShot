using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BankShot
{
    /// <summary>
    /// Author: Noah Emke<br/>
    /// Manages wave advancement, pausing, count, and shop spawning.
    /// </summary>
    public class WaveManager
    {
        private int wave;
        private double timer;
        private List<List<Enemy>> waves;
        private bool waveBreak;

        /// <summary>
        /// Initialize a new wave manager and read a list of waves from a file.
        /// </summary>
        public WaveManager()
        {
            wave = 0;
            timer = 0;
            // TODO: Read from file
            waves = new List<List<Enemy>>
            {
                new List<Enemy>
                {
                    new Enemy(
                        Program.game.Content.Load<Texture2D>("Enemy"),
                        new Rectangle(400, 480, 75, 150),
                        true,
                        5,
                        Vector2.Zero,
                        2,
                        50)
                }
            };
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
            cleared = false;
            return false;

        }

        public void NextWave()
        {
            //advances to next wave, tells enemy manager to spawn new enemies
            


        }

    }
}
