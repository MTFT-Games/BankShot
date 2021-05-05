using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;

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
            waves = new List<List<string>>();
            ReadWaves();
            waveBreak = false;
            timeBetweenWaves = 3;
            //This can be changed to change the amount of time before the first wave.
            timePassed = 0;
            warningsToDraw = new List<Rectangle>();
            blink = true;
        }

        private void ReadWaves()
        {
            StreamReader reader;
            try
            {
                reader = new StreamReader("Content/waves.data");

                string[] splitLine = reader.ReadLine().Split('x');
                int width = int.Parse(splitLine[0]);
                int height = int.Parse(splitLine[1]);

                int tileSize = Program.game.GetWindowSize().Height / height;
                int readWave = 0;
                do
                {
                    reader.ReadLine();
                    waves.Add(new List<string>());
                    for (int y = 0; y < height; y++)
                    {
                        string[] line = reader.ReadLine().Split('|');
                        for (int x = 0; x < width; x++)
                        {
                            int enemyID;
                            if (int.TryParse(line[x], out enemyID))
                            {
                                string parsedEnemyType = "";
                                switch (enemyID)
                                {
                                    case 1:
                                        parsedEnemyType = "Ranged";
                                        break;
                                    case 2:
                                        parsedEnemyType = "Chaser";
                                        break;
                                    case 3:
                                        parsedEnemyType = "Pacer";
                                        break;
                                    case 4:
                                        parsedEnemyType = "Flying";
                                        break;
                                    default:
                                        break;
                                }
                                waves[readWave].Add($"{parsedEnemyType}|{tileSize * x}|{(tileSize * (y+1))-100}");
                            }
                        }
                    }
                    readWave++;
                } while (reader.ReadLine() != "|EOF|");

                
                
            } catch (Exception)
            {

                throw;
            }
            if (reader != null)
            {
                reader.Close();
            }
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
                if (wave / 2 + 4 <= 14)
                {
                    waveToSpawn = rng.Next(0, wave / 2 + 4);
                }
                else
                {
                    waveToSpawn = rng.Next(0, 14);
                }
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
                        case "Pacer":
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
                Game1.soundEffects[3].Play();
                Rectangle rect = new Rectangle(0, 0, 100, 100);
                string[] splitEntry = null;
                for (int i = 0; i < waves[waveToSpawn].Count; i++)
                {
                    splitEntry = waves[waveToSpawn][i].Split('|');
                    warningsToDraw.Add(new Rectangle(Convert.ToInt32(splitEntry[1]), Convert.ToInt32(splitEntry[2]), 100, 100));
                }
                //Game1.upgradeManager.EndShopping();
                //
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
                if (warningsToDraw.Count != 0)
                {
                    sb.DrawString(Game1.largeFont, $"WAVE INCOMING", new Vector2(450, 500), Color.Red);
                }
            }
        }
    }
}
