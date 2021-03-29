using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

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
