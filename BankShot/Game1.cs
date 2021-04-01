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
        public Player player;

        public static GameObject[] walls;

        //Testing gun and projectile creation.
        private Gun gun;
        private Texture2D projectileTexture;
        private Texture2D gunTexture;

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
            
            base.Initialize();
        }

        protected override void LoadContent() {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            //menu testing
            font = Content.Load<SpriteFont>("File");
            buttonTx = Content.Load<Texture2D>("button2");

            //menu init
            mainMenu = new MainMenu(font, buttonTx);
            pauseMenu = new PauseMenu(font);
            leaderboardMenu = new LeaderboardMenu(font, scores);
            gameOverMenu = new GameOverMenu(font);

            gunTexture = Content.Load<Texture2D>("button1");
            player = new Player(gunTexture, new Rectangle(100, 100, 100, 100), new List<Rectangle>(), true, 5, new Vector2(0, 0));
            walls = new GameObject[] { new GameObject(gunTexture, new Rectangle(100, 200, 500, 100), new List<Rectangle>(), true) };

            //Testing gun and projectile creation.
            //gunTexture = Content.Load<Texture2D>("button1");
            projectileTexture = Content.Load<Texture2D>("button2");

            //Gun Creation! 
            gun = new Gun(gunTexture, new Rectangle(400, 100, 100, 100), new List<Rectangle>(), true, 2, 2, true, 2, 5, new Vector2(0, 0), projectileTexture, new Rectangle(400, 100, 100, 100), new List<Rectangle>(), true);

            //Map manager


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
                    gun.Update();
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
            player.Update();
          

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
                    gun.Draw(_spriteBatch);
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
    }
}
