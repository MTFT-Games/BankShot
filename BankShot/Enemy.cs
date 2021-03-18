using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BankShot
{
    class Enemy : Character, IDamages
    {
        //Fields

        //Enemy Stats will be included as Fields

        //Constructor
        public Enemy(Texture2D texture, Rectangle transform, List<Rectangle> collisionBoxes, bool active, int maxHealth, Vector2 velocity)
            : base(texture,transform,collisionBoxes,active,maxHealth,velocity)
        {

        }
        //Methods
        public void DealDamage(IDamagable target)) { }

        //I'm not sure that we know what these methods do yet
        //so I am just including the list we had in the 
        //diagram.
        public bool Pathfind(GameObject target)
        {
            bool shouldTurn = false;


            return shouldTurn;
        }
        //Pathfind, Move at player, Target player, General ai functions, Attack player
    }
}
