using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BankShot
{
    class EnemyManager
    {
        //fields

        //fields will contain stats for making enemies (tbd)
        private List<Enemy> enemies;

        //constructor -----------------------------------------------------------------------------

        public EnemyManager()
        {


        }

        //accessors. accessor for enemy stat fields will be added once enemy stats are defined.----

        //enemy stat accessors here

        public List<Enemy> Enemies
        {
            //probably wont need a set. may need indexed accessor
            get { return enemies; }
            set { enemies = value; }
        }

        //methods. only headers and basic comments for now. params incomplete. --------------------

        public void SpawnEnemies()
        {
            //spawns enemies held in "enemies"

        }

        public void UpdateEnemies()
        {
            //update logic for Enemy objects stored in "enemies"

        }

        public void DrawEnemies(SpriteBatch sb)
        {
            //Draws the enemy objects in "enemies" using the given spritebatch

        }

        public string ReadStats()
        {
            //returns a string with information on each enemy's stats

        }

    }
}
