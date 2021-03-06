using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;

namespace BankShot
{
    public enum GameState
    {
        MainMenu,
        Game,
        Pause,
        Leaderboard,
        GameOver,
        Shop
    }



    public class Game1 : Game
    {

        public GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        //music
        public static Song song;

        //sound fx
        public static List<SoundEffect> soundEffects;


        // Menu fields.
        private MainMenu mainMenu;
        private PauseMenu pauseMenu;
        private LeaderboardMenu leaderboardMenu;
        private GameOverMenu gameOverMenu;

        // Misc fields.
        // TODO: Remove and replace uses with Input class
        private MouseState msPrev;
        public GameState state;
        public static Player player;
        private bool testMode;
        // TODO: Put this in the learderboard menu.
        private int[] scores;
        public int score;

        // Manager fields.
        public EnemyManager enemyManager;
        public static MapManager mapManager;
        public static UpgradeManager upgradeManager;
        public static ProjectileManager projectileManager;
        public static WaveManager waveManager;

        // Texture fields.
        public Texture2D titleBG;
        public Texture2D pauseBG;
        public Texture2D gameoverBG;
        public Texture2D leaderboardBG;
        // TODO: Move enemyTexture into enemy manager with file read overhaul.
        public Texture2D enemyTextureSlime;
        public Texture2D enemyTextureCat;
        public Texture2D enemyTextureChest;
        // TODO: Use here instead of passing everywhere
        public static Texture2D buttonTx;
        public Texture2D healthBar;
        public Texture2D waveBar;
        public Texture2D barUnderlay;

        public Texture2D warningTexture;
        

        // Font fields.
        // TODO: Find better fonts and make a proper button texture. 
        public static SpriteFont font;
        public static SpriteFont largeFont;

        // TODO: Should we use accessors or just make them public? Look at
        // class guidelines

        /// <summary>
        /// Gets or sets weather testing mode is active.
        /// </summary>
        public bool Test
        {
            get { return testMode; }
            set { testMode = value; }
        }

        internal void SortScores()
        {
            scores[5] = score;
            Array.Sort(scores);
            leaderboardMenu = new LeaderboardMenu(Font, scores, score);
        }

        /// <summary>
        /// Gets the placeholder font.
        /// </summary>
        public SpriteFont Font { get { return font; } }

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            soundEffects = new List<SoundEffect>();
        }

        protected override void Initialize()
        {
            state = GameState.MainMenu;
            scores = new int[6];
            score = 0;
            testMode = false;

            // PLEASE TELL NOAH IF WE NEED TO CHANGE THE WINDOW ASPECT RATIO
            // SO THAT HE CAN CHANGE THE MAP TO FIT.
            // Set screen size.
            _graphics.PreferredBackBufferWidth = 1600;
            _graphics.PreferredBackBufferHeight = 960;
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            //sound loading
            song = Content.Load<Song>("BankShotRough");
          

            soundEffects.Add(Content.Load<SoundEffect>("chaching"));
            soundEffects.Add(Content.Load<SoundEffect>("coinflip"));
            soundEffects.Add(Content.Load<SoundEffect>("coin"));
            soundEffects.Add(Content.Load<SoundEffect>("warning"));
            soundEffects.Add(Content.Load<SoundEffect>("shoproll"));
            soundEffects.Add(Content.Load<SoundEffect>("gameover"));
            soundEffects.Add(Content.Load<SoundEffect>("ouch"));
            soundEffects.Add(Content.Load<SoundEffect>("shieldbreak"));



            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // Load fonts.
            font = Content.Load<SpriteFont>("Arial12");
            largeFont = Content.Load<SpriteFont>("Arial36");

            // Load Backgrounds
            titleBG = Content.Load<Texture2D>("TitleScreen");
            pauseBG = Content.Load<Texture2D>("PauseScreen");
            gameoverBG = Content.Load<Texture2D>("GameOverScreen");
            leaderboardBG = Content.Load<Texture2D>("LeaderboardScreen");

            // Load UI Textures
            buttonTx = Content.Load<Texture2D>("Button");
            healthBar = Content.Load<Texture2D>("HealthBar");
            waveBar = Content.Load<Texture2D>("WaveTimer");
            barUnderlay = Content.Load<Texture2D>("BarUnderlay");

            //Load Enemy Textures
            enemyTextureSlime = Content.Load<Texture2D>("GoldSlime");
            enemyTextureCat = Content.Load<Texture2D>("LuckyCat");
            enemyTextureChest = Content.Load<Texture2D>("Chester");
            warningTexture = Content.Load<Texture2D>("exclamationPoint");
            // Load menus.
            mainMenu = new MainMenu(font, buttonTx);
            pauseMenu = new PauseMenu(font, buttonTx);
            //leaderboardMenu = new LeaderboardMenu(font, scores, score);
            gameOverMenu = new GameOverMenu(font);

            // Load managers.
            waveManager = new WaveManager();
            mapManager = new MapManager();
            projectileManager = new ProjectileManager();
            upgradeManager = new UpgradeManager(
                new Rectangle(700, 800, 60, 60), 
                new List<Rectangle>(), 
                true);
            player = new Player(
                new Rectangle(100, 100, 100, 100), 
                new List<Rectangle>(), 
                true, 
                15, 
                new Vector2(0, 0));
            enemyManager = new EnemyManager();                        
        }

        protected override void Update(GameTime gameTime)
        {
            // Quit input combo.
            if ((Keyboard.GetState().IsKeyDown(Keys.LeftAlt) 
                || Keyboard.GetState().IsKeyDown(Keys.RightAlt))
                && Keyboard.GetState().IsKeyDown(Keys.F4))
            {
                Exit();
            }



            Input.Update();

            // State machine based on the GameState.
            switch (state)
            {
                case GameState.MainMenu:
                    if (Input.MouseClick(1))
                    {
                        soundEffects[0].Play();
                    }
                    resetGame();
                    mainMenu.Update(out state);
                    break;
                case GameState.Game:

                    

                    //Testing gun and projectile creation.
                    projectileManager.UpdateProjectiles(gameTime);
                    player.Update(gameTime);
                    enemyManager.UpdateEnemies(gameTime);
                    waveManager.Update(gameTime);
                    upgradeManager.Update(gameTime);

                    if (player.Health <= 0)
                    {
                        Game1.soundEffects[5].Play();
                        state = GameState.GameOver;
                    }


                    if (Input.KeyClick(Keys.P) || Input.KeyClick(Keys.Escape))
                    {
                        state = GameState.Pause;
                    }



                    break;
                case GameState.Pause:
                    if (Input.MouseClick(1))
                    {
                        soundEffects[0].Play();
                    }
                    pauseMenu.Update(testMode, out state);
                    break;
                case GameState.Leaderboard:
                    if (Input.MouseClick(1))
                    {
                        soundEffects[0].Play();
                    }
                    leaderboardMenu.Update(out state);
                    break;
                case GameState.GameOver:
                   
                    if (Input.MouseClick(1))
                    {
                        soundEffects[0].Play();
                    }
                    gameOverMenu.Update(out state);
                    break;
                    //case GameState.Shop:
                    //   currentShop  = upgradeManager.MakeShop();

                    //   currentShop.Update(upgradeManager, ms, player);

                    //   currentShop = null;

                    //   state = GameState.Game;


                    //   break;

            }
            // TODO: Add your update logic here


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            //begins spritebatch
            _spriteBatch.Begin();

            //debug, show mouse position

            //state machine based on the GameState enum
            switch (state)
            {
                case GameState.MainMenu:
                    //_spriteBatch.DrawString(font, state.ToString(), new Vector2(10, 10), Color.White);
                    _spriteBatch.Draw(titleBG, new Vector2(0, 0), Color.White);
                    mainMenu.Draw(_spriteBatch, _graphics);
                    break;
                case GameState.Game:



                    //Commented these out because they were breaking everything
                    mapManager.Draw(_spriteBatch);
                    player.Draw(_spriteBatch);
                    //foreach (GameObject wall in walls)
                    //{
                    //    wall.Draw(_spriteBatch);
                    //}
                    //Testing gun and projectile creation.
                    projectileManager.DrawProjectiles(_spriteBatch);
                    //_spriteBatch.DrawString(font, $"Max: {player.MaxHealth}", new Vector2(300, 300), Color.White);
                    //_spriteBatch.DrawString(font, $"Health: {player.Health}", new Vector2(300, 350), Color.White);
                    enemyManager.DrawEnemies(_spriteBatch);
                    // if (enemyManager.SpawnedEnemies.Count > 0)
                    {
                        //    _spriteBatch.DrawString(font, "Enemy Health: " + enemyManager.SpawnedEnemies[0].Health, new Vector2(100, 100), Color.White);
                    }
                    upgradeManager.Draw(_spriteBatch);
                    // health bar waves and timer
         

                    double currHealthBar = ((double)player.Health / (double)player.MaxHealth) * 200;

                    _spriteBatch.Draw(healthBar, new Rectangle(65, 60, 200, 50), Color.Gray);
                    _spriteBatch.Draw(healthBar, new Rectangle(65, 60, (int)currHealthBar, 50), Color.White);
                    _spriteBatch.DrawString(font, "Health", new Vector2(135, 75), Color.White);

                    double currShieldCoolDown = (1 - ((double)player.CurrentShield.TimeSinceBreak / (double)player.CurrentShield.CoolDown)) * 200;

                    _spriteBatch.Draw(waveBar, new Rectangle(65, 125, 200, 50), Color.Gray);
                    _spriteBatch.Draw(waveBar, new Rectangle(65, 125, 200 - (int)currShieldCoolDown, 50), Color.Aqua);
                    if ((int)currShieldCoolDown == 0)
                    {
                        _spriteBatch.DrawString(font, "Shield Ready", new Vector2(105, 140), Color.White);
                    }

                    double currTime = (waveManager.Timer / 30) * 200;

                    _spriteBatch.Draw(waveBar, new Rectangle(65, 190, 200, 50), Color.Gray);
                    _spriteBatch.Draw(waveBar, new Rectangle(65, 190, 200 - (int)currTime, 50), Color.White);

                    _spriteBatch.DrawString(font, $"Wave Number: {waveManager.Wave}", new Vector2(65, 260), Color.White);




                    if (enemyManager.SpawnedEnemies.Count > 0)
                    {
                        //_spriteBatch.DrawString(font, $"Y Velocity: {enemyManager.SpawnedEnemies[0].Velocity.X}", new Vector2(15, 165), Color.White);
                        //_spriteBatch.DrawString(font, $"Health: {enemyManager.SpawnedEnemies[0].Health}", new Vector2(15, 265), Color.White);
                    }

                    //player wallet writing
                    _spriteBatch.DrawString(
                        font,
                        "Current Haul: $" + player.Money,
                        new Vector2(65, 290),
                        Color.White);

                    if (waveManager.Wave <= 1)
                    {
                        if (waveManager.Timer < 5)
                        {
                            _spriteBatch.Draw(buttonTx, new Rectangle(350, 60, 420, 100), Color.White);

                            _spriteBatch.DrawString(font,
                                "Use WASD to move, and Left Click to shoot!",
                                new Vector2(370, 80),
                                Color.White);
                            _spriteBatch.DrawString(font,
                                "Use Right Click to Shield Projectiles!",
                                new Vector2(370 + 15, 120),
                                Color.White);
                        }
                    }

                    waveManager.Draw(_spriteBatch);
                    break;
                case GameState.Pause:
                    _spriteBatch.Draw(pauseBG, new Vector2(0, 0), Color.White);

                    pauseMenu.Draw(_spriteBatch, _graphics);

                    break;
                case GameState.Leaderboard:
                    _spriteBatch.Draw(leaderboardBG, new Vector2(0, 0), Color.White);
                    leaderboardMenu.Draw(_spriteBatch, _graphics, buttonTx);
                    break;
                case GameState.GameOver:
                    _spriteBatch.Draw(gameoverBG, new Vector2(0, 0), Color.White);
                    gameOverMenu.Draw(_spriteBatch, _graphics, buttonTx);
                    break;


            }
            //_spriteBatch.DrawString(font, $"{Input.MousePosition}", new Vector2(800, 200), Color.White);//


            _spriteBatch.End();
            base.Draw(gameTime);
        }

        /// <summary>
        /// resets all game values. called at beginning of game
        /// </summary>
        public void resetGame()
        {
           
            Initialize();
            LoadContent();
        }


        /// <summary>
        /// Method author: Noah Emke<br/>
        /// A helper method to get the size of the screen.
        /// </summary>
        /// <returns>A rectangle the size of the game window.</returns>
        public Rectangle GetWindowSize()
        {
            return new Rectangle(
                0,
                0,
                _graphics.PreferredBackBufferWidth,
                _graphics.PreferredBackBufferHeight);
        }
    }
}
