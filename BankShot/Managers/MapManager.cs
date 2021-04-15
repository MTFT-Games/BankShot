using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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
            this.mapList = new List<Map>();
            LoadMaps();
            this.currentMap = mapList[0];
        }

        /// <summary>
        /// Method author: Noah Emke
        /// Loads the map or future list of maps from the file according to 
        /// the format in ExternalTool.Save().
        /// </summary>
        private void LoadMaps()
        {
            // Make a list to hold the gameobjects as we read them
            List<GameObject> loadedMap = new List<GameObject>();
            Texture2D currentBackground = null;

            StreamReader reader = null;
            try
            {
                reader = new StreamReader("Content/map.data");

                // Read header info.
                string[] header = reader.ReadLine().Split('x');
                int width = int.Parse(header[0]);
                int height = int.Parse(header[1]);

                int tileSize = Program.game.GetWindowSize().Height / height;

                // Read and set background image path
                currentBackground =
                    Program.game.Content.Load<Texture2D>("Backgrounds/" + reader.ReadLine());

                // Load all the tile textures into a list to make parsing the 
                // map file and making gameobjects easier
                List<Texture2D> tileSet = new List<Texture2D>();
                string[] tilePaths = Directory.GetFiles("MapTiles");
                Array.Sort<string>(tilePaths);
                for (int i = 0; i < tilePaths.Length; i++)
                {
                    tileSet.Add(Program.game.Content.Load<Texture2D>(tilePaths[i]));
                }

                // Read and apply map data where each character is mapped to a
                // tile.
                for (int y = 0; y < height; y++)
                {
                    string[] line = reader.ReadLine().Split('|');
                    for (int x = 0; x < width; x++)
                    {
                        int tileID;
                        if (int.TryParse(line[x], out tileID))
                        {
                            loadedMap.Add(new GameObject(
                                tileSet[tileID],
                                new Rectangle(
                                    tileSize*x,
                                    tileSize*y,
                                    tileSize,
                                    tileSize),
                                true));
                        }
                    }
                }
            }catch
            {
                // Currently no way to deal with not having a map so just
                // crash the game.
                Program.game.Exit();
            }

            mapList.Add(new Map(loadedMap.ToArray(), currentBackground));
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
