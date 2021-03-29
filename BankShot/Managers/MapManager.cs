using System;
using System.Collections.Generic;
using System.Text;

namespace BankShot
{
    /// <summary>
    /// Reads in, sets, and draws Maps to use as levels.
    /// coded by Machi
    /// </summary>
    class MapManager
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
        //Properties///////////////////////////////////////
        public Map CurrentMap
        {
            get { return currentMap; }
        }
    }
}
