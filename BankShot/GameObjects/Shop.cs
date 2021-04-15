using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace BankShot
{
    public class Shop : GameObject, IMoveable
    {
        //Fields
        private List<Upgrade> forSale;
        protected Vector2 velocity;
        
        

        //Properties
        public Vector2 Velocity
        {
            get
            {
                return velocity;
            }
            set
            {
                velocity = value;
            }
        }

        //Methods
       
        /// <summary>
        /// Constructor
        /// </summary>
        /// 
        public Shop(Texture2D texture, Rectangle transform, List<Rectangle> collisionBoxes, bool active, List<Upgrade> sale)
            : base(texture, transform, collisionBoxes, active)
        {
            forSale = sale;
        }


        //MOVED TO UPGRADE MANAGER
        public void Spawn(SpriteBatch sb, Color c)
        {
            

        }
        
        public void ExitScreen() 
        {
            while (position.X != -100)
            {
                position.X--;
            }

        }

        //These methods have not been explicitly defined:

        //Tell the upgrade manager to span another, end, or apply a bought upgrade

        // Check for player in front of upgrade and display info

        //Check for confirmation while player is in front of upgrade

        public void Draw(SpriteBatch sb, Color c)
        {
            sb.Draw(texture, rect, Color.White);
           
        }

        public virtual void Move()
        {
            position += velocity;
        }

        public override void Update()
        {
            this.Move();
            X = (int)position.X;
            Y = (int)position.Y;
        }
    }
}
