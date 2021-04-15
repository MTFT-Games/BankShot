using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace BankShot {

    public enum GameState
    {
        MainMenu, 
        Game, 
        Pause, 
        Leaderboard, 
        GameOver
    }

    public class Game1 : Game {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        //font, texture and menu obj for testing- to be replaced
        private SpriteFont font;
        private Texture2D buttonTx;

        //menus
        private MainMenu mainMenu;
        private PauseMenu pauseMenu;
        private LeaderboardMenu leaderboardMenu;
        private GameOverMenu gameOverMenu;

        //menu misc
        private int[] scores;

        //enemies
        public static EnemyManager enemyManager;

        //previous mouse state
        private MouseState msPrev;

        //maps
        public static MapManager mapManager;
        public static Map map1;
        public static List<Map> mapList;

        //upgrades
        public static UpgradeManager upgradeManager;
        public static WaveManager waveManager;

        //holds current game state (out variables)
        public GameState state;

        //Testing player
        public static Player player;

        public static GameObject[] walls;

        //Testing gun and projectile creation.
        private Gun gun;
        private Shield shield;
        private Texture2D projectileTexture;
        private Texture2D gunTexture;
        private Texture2D shieldTexture;
        public static ProjectileManager projectileManager;

        //Other Test Textures
        private Texture2D playerTexture;
        private Texture2D wallTexture;
        private Texture2D enemyTexture;

        //testing boolean
        private bool test;
        
        public Game1() {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize() {
            // TODO: Add your initialization logic here
            state = GameState.MainMenu;

            scores = new int[5];

          
            test = false;

            // PLEASE TELL NOAH IF WE NEED TO CHANGE THE WINDOW ASPECT RATIO
            // SO THAT HE CAN CHANGE THE MAP TO FIT
            _graphics.PreferredBackBufferWidth = 800;  // set this value to the desired width of your window
            _graphics.PreferredBackBufferHeight = 480;   // set this value to the desired height of your window
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent() {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            //menu testing
            font = Content.Load<SpriteFont>("File");
            buttonTx = Content.Load<Texture2D>("button1");

            //menu init
            mainMenu = new MainMenu(font, buttonTx);
            pauseMenu = new PauseMenu(font);
            leaderboardMenu = new LeaderboardMenu(font, scores);
            gameOverMenu = new GameOverMenu(font);

            //Textures
            gunTexture = Content.Load<Texture2D>("Gun");
            projectileTexture = Content.Load<Texture2D>("Bullet");
            wallTexture = Content.Load<Texture2D>("Wall");
            playerTexture = Content.Load<Texture2D>("Player");
            enemyTexture = Content.Load<Texture2D>("Enemy");
            shieldTexture = Content.Load<Texture2D>("Shield");


            player = new Player(playerTexture, new Rectangle(100, 100, 100, 200), new List<Rectangle>(), true, 5, new Vector2(0, 0));
            walls = new GameObject[] { new GameObject(wallTexture, new Rectangle(0, 900, 500, 100), new List<Rectangle>(), true), 
                                       new GameObject(wallTexture, new Rectangle(650, 900, 500, 100), new List<Rectangle>(), true),
                                       new GameObject(wallTexture, new Rectangle(200, 500, 300, 100), new List<Rectangle>(), true)};
            enemyManager = new EnemyManager(new List<List<object>>() { new List<object>() { enemyTexture, new Rectangle(300, 300, 100, 200), new List<Rectangle>(), true, 5, new Vector2(0, 0), 5, 0 } });
            //enemyManager.SpawnEnemies();
            enemyManager.SpawnedEnemies.Add(new Enemy(enemyTexture, new Rectangle(700, 700, 100, 200), new List<Rectangle>(), true, 5, new Vector2(0, 0), 5, 0));

            //Gun Creation! 
            projectileManager = new ProjectileManager();
            gun = new Gun(gunTexture, new Rectangle(400, 100, 100, 50), new List<Rectangle>(), true, 2, 2, true, 2, 20, new Vector2(0, 0), projectileTexture, new Rectangle(400, 100, 20, 20), new List<Rectangle>(), true, true, true);
            player.CurrentWeapon = gun;

            //Shield Creation!
            shield = new Shield(shieldTexture, new Rectangle(player.Rect.X - 10, player.Rect.Y - 10, player.Rect.Width + 20, player.Rect.Height + 20), new List<Rectangle>(), true, new Vector2(0, 0));
            player.CurrentShield = shield;
            //Map manager
            mapManager = new MapManager(new Map(walls, wallTexture), new List<Map>());

            //Enemy manager
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime) {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            //gathers keybaord and mouse states for use in update methods
            KeyboardState kbs = Keyboard.GetState();
            MouseState ms = Mouse.GetState();

            //state machine based on the GameState enum
            switch (state)
            {
                case GameState.MainMenu:
                    mainMenu.Update(kbs, ms, msPrev, out state);
                    break;
                case GameState.Game:
                    //Testing gun and projectile creation.
                    projectileManager.UpdateProjectiles();
                    player.Update();
                    enemyManager.UpdateEnemies();
                    break;
                case GameState.Pause:
                    pauseMenu.Update(kbs, ms, msPrev, test, out state);
                    break;
                case GameState.Leaderboard:
                    leaderboardMenu.Update(kbs, ms, msPrev, out state);
                    break;
                case GameState.GameOver:
                    gameOverMenu.Update(kbs, ms, msPrev, out state);
                    break;

            }

            msPrev = ms;

            // TODO: Add your update logic here
            Input.Update();
          

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            //begins spritebatch
            _spriteBatch.Begin();

            //state machine based on the GameState enum
            switch (state)
            {
                case GameState.MainMenu:
                    _spriteBatch.DrawString(font, state.ToString(), new Vector2(10, 10), Color.White);
                    mainMenu.Draw(_spriteBatch, _graphics);
                    break;
                case GameState.Game:
                    //Commented these out because they were breaking everything
                    //mapManager.Draw(_spriteBatch);
                    //enemyManager.DrawEnemies(_spriteBatch);
                    player.Draw(_spriteBatch);
                    foreach (GameObject wall in walls)
                    {
                        wall.Draw(_spriteBatch);
                    }
                    //Testing gun and projectile creation.
                    projectileManager.DrawProjectiles(_spriteBatch);
                    _spriteBatch.DrawString(font, $"Height: {projectileManager.height}", new Vector2(300, 300), Color.White);
                    _spriteBatch.DrawString(font, $"Width: {projectileManager.width}", new Vector2(300, 350), Color.White);
                    enemyManager.DrawEnemies(_spriteBatch);
                    if (enemyManager.SpawnedEnemies.Count > 0)
                    {
                        _spriteBatch.DrawString(font, "Enemy Health: " + enemyManager.SpawnedEnemies[0].Health, new Vector2(100, 100), Color.White);
                    }
                    break;
                case GameState.Pause:
                    pauseMenu.Draw(_spriteBatch, _graphics);
                    break;
                case GameState.Leaderboard:
                    leaderboardMenu.Draw(_spriteBatch, _graphics);
                    break;
                case GameState.GameOver:
                    gameOverMenu.Draw(_spriteBatch, _graphics);
                    break;

            }


            _spriteBatch.End();
            base.Draw(gameTime);
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
