using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace BankShot
{
    public struct Map
    {
        //Fields
        private GameObject[] map;
        private Texture2D backgroundImage;
        //Properties

        /// <summary>
        /// Gets the gameobject at the given index of the list of map objects.
        /// </summary>
        /// <param name="index">The index of the gameobject to be retrieved.</param>
        /// <returns>The gameobject representing a wall or platform.</returns>
        public GameObject this[int index]
        {
            get { return map[index]; }
        }

        public Texture2D BackgroundImage
        {
            get { return backgroundImage; }
        }

        public GameObject[] MapArray
        {
            get { return map; }
        }

        public Map(GameObject[] map, Texture2D backgroundImage)
        {
            this.map = map;
            this.backgroundImage = backgroundImage;
        }
    }
}
