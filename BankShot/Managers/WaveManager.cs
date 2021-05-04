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
        private Random rng;
        private int wave;
        private double timer;
        private List<List<string>> waves;
        private bool waveBreak;
        private double timeBetweenWaves;
        private double timePassed;

        private bool waveChosen;
        private int waveToSpawn;

        private List<Rectangle> warningsToDraw;
        private double nextBlinkTime;
        private bool blink;

        /// <summary>
        /// Gets the current wave number.
        /// </summary>
        public int Wave { get { return wave; } }

        public double Timer { get { return timer; } }

        /// <summary>
        /// Gets weather or not the wave cycle is currently broken.
        /// </summary>
        public bool WaveBreak
        {
        set { waveBreak = value; }
        }
        public double TimePassed
        {
            get
            {
                return timePassed;
            }
            set
            {
                timePassed = value;
                if (timePassed > 10)
                {
                    timePassed = 10;
                }
            }
        }

        /// <summary>
        /// Initialize a new wave manager and read a list of waves from a file.
        /// </summary>
        public WaveManager()
        {
            rng = new Random();
            wave = 0;
            timer = 0;
            // TODO: Read from file
            waves = new List<List<string>>
            {
                new List<string>
                {
                    "Chaser|400|480",
                    "Chaser|840|150",
                    "Platform|970|470",
                    "Chaser|1180|480",
                    "Ranged|810|200",
                    "Flying|810|150",
                    "Platform|400|680"
                },
                new List<string>
                {
                    "Chaser|400|480",
                    "Chaser|840|150",
                    "Platform|970|470",
                    "Chaser|1180|480",
                    "Ranged|810|200",
                    "Platform|400|680"
                }
            };
            waveBreak = false;
            timeBetweenWaves = 2;
            //This can be changed to change the amount of time before the first wave.
            timePassed = 0;
            warningsToDraw = new List<Rectangle>();
            blink = true;
        }

        /// <summary>
        /// Performs all actions and checks that should occur every frame.
        /// </summary>
        /// <param name="time">The gametime object for this game.</param>
        public void Update(GameTime time)
        {


            // Check if the wave has been cleared or the time has run out
            if ((Program.game.enemyManager.SpawnedEnemies.Count == 0) || (timer > 30))
            {
                if (waveBreak && (Game1.upgradeManager.Shops.Count == 0))
                {
                    Game1.player.Heal(Game1.player.MaxHealth / 5);
                    Game1.upgradeManager.MakeShop();
                }
                if (!waveBreak)
                {
                    if (timePassed < 0)
                    {
                        timePassed = 0;
                    }
                    timePassed += time.ElapsedGameTime.TotalSeconds;
                    Game1.player.Heal(Game1.player.MaxHealth / 10);
                    NextWave();
                    /*
                    if (timePassed > timeBetweenWaves)
                    {
                        NextWave();
                        timePassed = -1;
                    }
                    */
                }
            }

            if (!(Program.game.enemyManager.SpawnedEnemies.Count == 0))
            {
                timer += time.ElapsedGameTime.TotalSeconds;
            }
        }

        /// <summary>
        /// Advances the wave number and spawns a new wave.
        /// </summary>
        public void NextWave()
        {
            if (!waveChosen)
            {
                waveToSpawn = rng.Next(0, waves.Count);
                waveChosen = true;
            }
            if (timePassed > timeBetweenWaves)
            {
                wave++;
                timer = 0;
                warningsToDraw.Clear();
                for (int i = 0; i < waves[waveToSpawn].Count; i++)
                {
                    string[] splitEntry = waves[waveToSpawn][i].Split('|');
                    switch (splitEntry[0])
                    {
                        case "Enemy":
                            Program.game.enemyManager.Spawn<Enemy>(
                            new Vector2(
                                float.Parse(splitEntry[1]),
                                float.Parse(splitEntry[2])));
                            break;

                        case "Chaser":
                            Program.game.enemyManager.Spawn<ChaserEnemy>(
                            new Vector2(
                                float.Parse(splitEntry[1]),
                                float.Parse(splitEntry[2])));
                            break;

                        case "Ranged":
                            Program.game.enemyManager.Spawn<RangedEnemy>(
                            new Vector2(
                                float.Parse(splitEntry[1]),
                                float.Parse(splitEntry[2])));
                            break;

                        case "Flying":
                            Program.game.enemyManager.Spawn<FlyingEnemy>(
                            new Vector2(
                                float.Parse(splitEntry[1]),
                                float.Parse(splitEntry[2])));
                            break;
                        case "Platform":
                            Program.game.enemyManager.Spawn<PlatformEnemy>(
                            new Vector2(
                                float.Parse(splitEntry[1]),
                                float.Parse(splitEntry[2])));
                            break;
                    } 
                }
                timePassed = -1;
                waveChosen = false;
                nextBlinkTime = 0;
                blink = true;
                if (wave % 3 == 0)
                {
                    waveBreak = true;
                }
            }
            else if (warningsToDraw.Count == 0)
            {
                Rectangle rect = new Rectangle(0, 0, 100, 100);
                string[] splitEntry = null;
                for (int i = 0; i < waves[waveToSpawn].Count; i++)
                {
                    splitEntry = waves[waveToSpawn][i].Split('|');
                    warningsToDraw.Add(new Rectangle(Convert.ToInt32(splitEntry[1]), Convert.ToInt32(splitEntry[2]), 100, 100));
                }
            }

        }

        public void Draw(SpriteBatch sb)
        {
            //Every .5 seconds, the blink bool changes to its opposite
            //If it's true, then the warnings are drawn
            if (timePassed > nextBlinkTime)
            {
                nextBlinkTime = timePassed + .5;
                
                blink = !blink;
            }
            if (blink)
            {
                foreach (Rectangle rect in warningsToDraw)
                {
                    sb.Draw(Program.game.warningTexture, rect, Color.White);
                }
            }
        }
    }
}
