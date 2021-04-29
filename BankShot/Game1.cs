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
        // TODO: Find better fonts and make a proper button texture. 
        // TODO: Use here instead of passing everywhere
        public static SpriteFont font;
        public static Texture2D buttonTx;


        // TODO: Should we use accessors or just make them public? Look at class guidelines
        public bool Test
        {
            get { return testMode; }
            set { testMode = value; }
        }

        public SpriteFont Font
        {
            get { return font; }
            set { font = value; }
        }

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            state = GameState.MainMenu;

            scores = new int[5];


            testMode = false;

            // PLEASE TELL NOAH IF WE NEED TO CHANGE THE WINDOW ASPECT RATIO
            // SO THAT HE CAN CHANGE THE MAP TO FIT
            _graphics.PreferredBackBufferWidth = 1600;  // set this value to the desired width of your window
            _graphics.PreferredBackBufferHeight = 960;   // set this value to the desired height of your window
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            //menu testing
            font = Content.Load<SpriteFont>("Arial12");
            buttonTx = Content.Load<Texture2D>("button1");

            //menu init
            mainMenu = new MainMenu(font, buttonTx);
            pauseMenu = new PauseMenu(font, buttonTx);
            leaderboardMenu = new LeaderboardMenu(font, scores);
            gameOverMenu = new GameOverMenu(font);

            //Textures
            
            enemyTexture = Content.Load<Texture2D>("GoldSlime");

            //all values except for textures are temporary
            upgradeManager = new UpgradeManager(new Rectangle(700, 800, 60, 60), new List<Rectangle>(), true);

            waveManager = new WaveManager();

            player = new Player(new Rectangle(100, 100, 100, 100), new List<Rectangle>(), true, 15, new Vector2(0, 0));

            //Enemy creation
            enemyManager = new EnemyManager(new List<List<object>>() { new List<object>() {
                enemyTexture,
                new Rectangle(0, 0, 100, 100), //enemy rectangle
                new List<Rectangle>(), //enemy 
                true, //enemy active state
                5, //enemy health
                new Vector2(0, 0), //enemy velocity
                5, //enemy attack power
                15f, //Enemy knockback distance
                250//Enemy's money value
            } });
            //enemyManager.SpawnEnemies();
            //enemyManager.SpawnedEnemies.Add(new RangedEnemy(enemyTexture, new Rectangle(100, 100, 100, 100), new List<Rectangle>(), true, 100, new Vector2(0, 0), 5, 10, new Gun(new Texture2D(this._graphics.GraphicsDevice, 1, 1), new Rectangle(100, 100, 1, 1), new List<Rectangle>(), true, 2, 2, true, .8, 20, new Vector2(0, 0), projectileTexture, new Rectangle(400, 100, 20, 20), new List<Rectangle>(), false, false, true, true), .8));

            //Gun Creation! 
            projectileManager = new ProjectileManager();

            //Shield Creation!
            player.CurrentShield = new Shield(new Rectangle(player.Rect.X - 10, player.Rect.Y - 10, player.Rect.Width + 20, player.Rect.Height + 20), new List<Rectangle>(), true, new Vector2(0, 0), 2.5);
            
            //Map manager
            mapManager = new MapManager();

            //Enemy manager
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed
                || ((Keyboard.GetState().IsKeyDown(Keys.LeftAlt) || Keyboard.GetState().IsKeyDown(Keys.RightAlt))
                && Keyboard.GetState().IsKeyDown(Keys.F4)))
                Exit();
            //gathers keybaord and mouse states for use in update methods
            Input.Update();
            KeyboardState kbs = Keyboard.GetState();
            MouseState ms = Mouse.GetState();

            //state machine based on the GameState enum
            switch (state)
            {
                case GameState.MainMenu:
                    resetGame();
                    mainMenu.Update(kbs, ms, msPrev, out state);
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


                    if (kbs.IsKeyDown(Keys.P) || Input.KeyClick(Keys.Escape))
                    {
                        state = GameState.Pause;
                    }



                    break;
                case GameState.Pause:
                    pauseMenu.Update(kbs, ms, msPrev, testMode, out state);
                    break;
                case GameState.Leaderboard:
                    leaderboardMenu.Update(kbs, ms, msPrev, out state);
                    break;
                case GameState.GameOver:
                    gameOverMenu.Update(kbs, ms, msPrev, out state);
                    break;
                    //case GameState.Shop:
                    //   currentShop  = upgradeManager.MakeShop();

                    //   currentShop.Update(upgradeManager, ms, player);

                    //   currentShop = null;

                    //   state = GameState.Game;


                    //   break;

            }

            msPrev = ms;

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
                        //_spriteBatch.DrawString(font, $"Y Velocity: {enemyManager.SpawnedEnemies[0].Velocity.Y}", new Vector2(15, 165), Color.White);
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
