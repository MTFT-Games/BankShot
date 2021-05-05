using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

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
        public static int tileSize;
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
            mapList = new List<Map>();
            LoadMaps();
            currentMap = mapList[0];
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

                tileSize = Program.game.GetWindowSize().Height / height;

                // Read and set background image path
                string readBackground = reader.ReadLine();
                readBackground = readBackground.Substring(0, readBackground.Length - 4);
                currentBackground =
                    Program.game.Content.Load<Texture2D>("Backgrounds/" +
                    readBackground);

                // Load all the tile textures into a list to make parsing the 
                // map file and making gameobjects easier
                List<Texture2D> tileSet = new List<Texture2D>();
                string[] tilePaths = Directory.GetFiles("Content/MapTiles");
                Array.Sort<string>(tilePaths);
                for (int i = 0; i < tilePaths.Length; i++)
                {
                    string parsedPath = tilePaths[i].Substring(8, tilePaths[i].Length - 12);
                    tileSet.Add(Program.game.Content.Load<Texture2D>(
                        parsedPath));
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
                                    tileSize * x,
                                    tileSize * y,
                                    tileSize,
                                    tileSize),
                                true));
                        }
                    }
                }
            } catch
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
            Rectangle window = Program.game.GetWindowSize();
            sb.Draw(currentMap.BackgroundImage, window, Color.White);
            //sb.Draw(Program.game.barUnderlay, new Rectangle(-115, -130, (int)(380 * 1.205), (int)(420 * 1.205)), Color.Gold);
            sb.Draw(Program.game.barUnderlay, new Rectangle(-125, -130, (int) (380 * 1.2), (int)(415 * 1.2)), Color.Black);
            foreach (GameObject block in currentMap.MapArray)
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
