using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

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

        // Manager fields.
        public EnemyManager enemyManager;
        public static MapManager mapManager;
        public static UpgradeManager upgradeManager;
        public static ProjectileManager projectileManager;
        public static WaveManager waveManager;

        // Texture fields.
        // TODO: Move enemyTexture into enemy manager with file read overhaul.
        public Texture2D enemyTexture;
        // TODO: Use here instead of passing everywhere
        public static Texture2D buttonTx;

        // Font fields.
        // TODO: Find better fonts and make a proper button texture. 
        public static SpriteFont font;

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

        /// <summary>
        /// Gets the placeholder font.
        /// </summary>
        public SpriteFont Font { get { return font; } }

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            state = GameState.MainMenu;
            scores = new int[5];
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
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // Load fonts.
            font = Content.Load<SpriteFont>("Arial12");

            // Load Textures
            buttonTx = Content.Load<Texture2D>("button1");
            enemyTexture = Content.Load<Texture2D>("GoldSlime");

            // Load menus.
            mainMenu = new MainMenu(font, buttonTx);
            pauseMenu = new PauseMenu(font, buttonTx);
            leaderboardMenu = new LeaderboardMenu(font, scores);
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
            enemyManager = new EnemyManager(
                new List<List<object>>() 
                { 
                    new List<object>()
                    {
                        enemyTexture,
                        new Rectangle(0, 0, 100, 100), //enemy rectangle
                        new List<Rectangle>(), //enemy 
                        true, //enemy active state
                        5, //enemy health
                        new Vector2(0, 0), //enemy velocity
                        5, //enemy attack power
                        15f, //Enemy knockback distance
                        250//Enemy's money value
                    }
                });                        
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
                    resetGame();
                    mainMenu.Update(out state);
                    break;
                case GameState.Game:
                    //Testing gun and projectile creation.
                    projectileManager.UpdateProjectiles(gameTime);
                    player.Update(gameTime);
                    enemyManager.UpdateEnemies(gameTime);
                    waveManager.Update(gameTime);
                    upgradeManager.Update();

                    if (player.Health <= 0)
                    {
                        state = GameState.GameOver;
                    }


                    if (Input.KeyClick(Keys.P) || Input.KeyClick(Keys.Escape))
                    {
                        state = GameState.Pause;
                    }



                    break;
                case GameState.Pause:
                    pauseMenu.Update(testMode, out state);
                    break;
                case GameState.Leaderboard:
                    leaderboardMenu.Update(out state);
                    break;
                case GameState.GameOver:
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

                    _spriteBatch.Draw(buttonTx, new Rectangle(15, 15, 200, 50), Color.Gray);
                    _spriteBatch.Draw(buttonTx, new Rectangle(15, 15, (int)currHealthBar, 50), Color.Red);

                    _spriteBatch.DrawString(font, $"Wave Number: {waveManager.Wave}", new Vector2(15, 65), Color.White);

                    double currTime = (waveManager.Timer / 30) * 200;

                    _spriteBatch.Draw(buttonTx, new Rectangle(15, 80, 200, 50), Color.Gray);
                    _spriteBatch.Draw(buttonTx, new Rectangle(15, 80, 200 - (int)currTime, 50), Color.Gold);

                    if (enemyManager.SpawnedEnemies.Count > 0)
                    {
                        //_spriteBatch.DrawString(font, $"Y Velocity: {enemyManager.SpawnedEnemies[0].Velocity.X}", new Vector2(15, 165), Color.White);
                        //_spriteBatch.DrawString(font, $"Health: {enemyManager.SpawnedEnemies[0].Health}", new Vector2(15, 265), Color.White);
                    }

                    //player wallet writing
                    _spriteBatch.DrawString(
                        font,
                        "Current Haul: " + player.Money,
                        new Vector2(Program.game.GetWindowSize().Width / 2, 0),
                        Color.White);


                    break;
                case GameState.Pause:
                    pauseMenu.Draw(_spriteBatch, _graphics);

                    break;
                case GameState.Leaderboard:
                    leaderboardMenu.Draw(_spriteBatch, _graphics, buttonTx);
                    break;
                case GameState.GameOver:
                    gameOverMenu.Draw(_spriteBatch, _graphics, buttonTx);
                    break;


            }
            //_spriteBatch.DrawString(font, $"{Input.MousePosition}", new Vector2(800, 200), Color.White);


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
