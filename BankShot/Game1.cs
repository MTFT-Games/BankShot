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
        private MainMenu mnu;
        private Texture2D buttonTx;

        public static EnemyManager enemyManager;
        public GameState state;

        //Testing player
        public Player player;
        //Testing gun and projectile creation.
        /*
        private Gun gun;
        private Texture2D gunTexture;
        private Texture2D projectileTexture;
        */
        public Game1() {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize() {
            // TODO: Add your initialization logic here
            state = GameState.MainMenu;
           
            
            base.Initialize();
        }

        protected override void LoadContent() {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            //menu testing
            font = Content.Load<SpriteFont>("File");
            buttonTx = Content.Load<Texture2D>("button1");
            mnu = new MainMenu(font, buttonTx);
            //end menu testing


            //Testing gun and projectile creation.
            /*
            gunTexture = Content.Load<Texture2D>("button1");
            projectileTexture = Content.Load<Texture2D>("button2");
            gun = new Gun(gunTexture, new Rectangle(100, 100, 100, 100), new List<Rectangle>(), true, 2, 2, true, 2, 5, new Vector2(0, 0), projectileTexture, new Rectangle(150, 100, 100, 100), new List<Rectangle>(), true);
            */

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

                    break;
                case GameState.Game:

                    break;
                case GameState.Pause:

                    break;
                case GameState.Leaderboard:

                    break;
                case GameState.GameOver:

                    break;

            }



            // TODO: Add your update logic here

            //Testing gun and projectile creation.
            //Input.Update();
            //gun.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            //begins spritebatch
            _spriteBatch.Begin();
            
        
            //state machine based on the GameState enum
            switch (state)
            {
                case GameState.MainMenu:

                    //for menu testing
                    _spriteBatch.DrawString(font, state.ToString(), new Vector2(10, 10), Color.White);
                    mnu.Draw(_spriteBatch, _graphics);
                    //end menu testing

                    break;
                case GameState.Game:

                    break;
                case GameState.Pause:

                    break;
                case GameState.Leaderboard:

                    break;
                case GameState.GameOver:

                    break;

            }

            //Testing gun and projectile creation.
            //gun.Draw(_spriteBatch);

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
