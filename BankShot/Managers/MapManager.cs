using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace BankShot
{
    /// <summary>
    /// Reads in, sets, and draws Maps to use as levels.
    /// coded by Machi
    /// </summary>
    public class MapManager
    {
        //Fields///////////////////////////////////////////
        private Map currentMap;
        private List<Map> mapList;
        //Constructors/////////////////////////////////////
        public MapManager(Map currentMap, List<Map> mapList)
        {
            this.currentMap = currentMap;
            this.mapList = mapList;
        }

        /// <summary>
        /// Initializes a new MapManager and loads content from map.data.
        /// </summary>
        public MapManager()
        {
            LoadMaps();
        }

        /// <summary>
        /// Method author: Noah Emke
        /// Loads the map or future list of maps from the file according to 
        /// the format in ExternalTool.Save().
        /// </summary>
        private void LoadMaps()
        {
            StreamReader reader = null;
            try
            {
                reader = new StreamReader("Content/map.data");

                // Read header info.
                string[] header = reader.ReadLine().Split('x');
                int width = int.Parse(header[0]);
                int height = int.Parse(header[1]);

                //int tileSize = Game1. .Height / height;
                
                // Clear and re-make the map with the read dimensions.
                throw new NotImplementedException();
            }catch
            {

            }
        }

        //Methods//////////////////////////////////////////
        //read in maps from file
        public void Draw(SpriteBatch sb)
        {
            foreach(GameObject block in currentMap.MapArray)
            {
                block.Draw(sb);
            }
        }
        //Properties///////////////////////////////////////
        public Map CurrentMap
        {
            get { return currentMap; }
            set { currentMap = value; }
        }

        public List<Map> MapList
        {
            get { return mapList; }
            set { MapList = value; }
        }
    }
}
