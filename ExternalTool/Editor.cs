using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ExternalTool
{
    /// <summary>
    /// Author: Noah Emke
    /// <para>The external tool allowing editing of maps, stats, upgrades, 
    /// and potentially more.</para>
    /// </summary>
    public partial class Editor : Form
    {
        private PictureBox[,] map;
        bool unsavedChanges = false;
        const string CONTENTPATH = "../../../BankShot/Content/";

        /// <summary>
        /// Initializes a new Editor window.
        /// </summary>
        public Editor()
        {
            InitializeComponent();
            LoadContent();
        }

        /// <summary>
        /// Loads all of the editable content from the main game project.
        /// </summary>
        private void LoadContent()
        {
            // Checks for unsaved changes and warns the user to save first.
            if (unsavedChanges && UnsavedWarning())
            {
                return;
            }

            // Update status bar.
            statusLabel.Text = "Loading content";
            loadingBar.Value = 0;
            // TODO: Set max loading bar value.

            // Load each component
            LoadThumbnails();
            LoadMap();
            // TODO: Load other components when ready.

            // Update status bar.
            statusLabel.Text = "Content loaded, ready";
        }

        /// <summary>
        /// Loads the map in from the file.
        /// </summary>
        private void LoadMap()
        {
            // Update the status bar.
            statusLabel.Text = "Loading content: loading map";

            // Read the file according to the format specified in Save().
            StreamReader reader = null;
            try
            {
                reader = new StreamReader(CONTENTPATH + "map.data");

                // Read header info.
                string[] header = reader.ReadLine().Split('x');
                int width = int.Parse(header[0]);
                int height = int.Parse(header[1]);

                // Clear and re-make the map with the read dimensions.
                mapBackground.Controls.Clear();
                InitializeMap(width, height);

                // Read and set background image path
                mapBackground.Image = Image.FromFile(CONTENTPATH + "Backgrounds/" 
                    + reader.ReadLine());
                
                // Read and apply map data where each character is mapped to a
                // tile.
                for (int y = 0; y < height; y++)
                {
                    string line = reader.ReadLine();
                    for (int x = 0; x < width; x++)
                    {
                        // Map the read character to an image to load in place.
                        switch (line[x])
                        {
                            default:
                                break;
                            case '0':
                                map[x, y].Image = Image.FromFile(
                                    CONTENTPATH + "MapTiles/down.png");
                                break;
                            case '1':
                                map[x, y].Image = Image.FromFile(
                                    CONTENTPATH + "MapTiles/downleft.png");
                                break;
                            case '2':
                                map[x, y].Image = Image.FromFile(
                                    CONTENTPATH + "MapTiles/downright.png");
                                break;
                            case '3':
                                map[x, y].Image = Image.FromFile(
                                    CONTENTPATH + "MapTiles/left.png");
                                break;
                            case '4':
                                map[x, y].Image = Image.FromFile(
                                    CONTENTPATH + "MapTiles/right.png");
                                break;
                            case '5':
                                map[x, y].Image = Image.FromFile(
                                    CONTENTPATH + "MapTiles/up.png");
                                break;
                            case '6':
                                map[x, y].Image = Image.FromFile(
                                    CONTENTPATH + "MapTiles/upleft.png");
                                break;
                            case '7':
                                map[x, y].Image = Image.FromFile(
                                    CONTENTPATH + "MapTiles/upright.png");
                                break;
                            case '8':
                                map[x, y].Image = Image.FromFile(
                                    CONTENTPATH + "MapTiles/center.png");
                                break;
                            case '9':
                                break;
                            case 'a':
                                break;
                            case 'b':
                                break;
                            case 'c':
                                break;
                        }
                    }
                }

                // Update status bar.
                loadingBar.Value += 50;
                // TODO: Measure and set bar value.

                unsavedChanges = false;
                
            } catch (Exception ex)
            {
                // TODO: Integrate error icon.
            }
            if (reader != null)
            {
                reader.Close();
            }
        }

        /// <summary>
        /// Load in the lists of tiles and background images for the user to 
        /// pick from.
        /// </summary>
        private void LoadThumbnails()
        {
            // Update status bar.
            statusLabel.Text = "Loading content: thumbnails";
            
            // Get the file paths of all backgrounds in the Backgrounds folder
            // and add them to the ListView to be selected and used later.
            string[] backgroundPaths 
                = Directory.GetFiles(CONTENTPATH + "Backgrounds");
            for (int i = 0; i < backgroundPaths.Length; i++)
            {
                backgroundImages.Images.Add(Image.FromFile(backgroundPaths[i]));
                backgroundList.Items.Add(
                    backgroundPaths[i].Substring(
                        backgroundPaths[i].LastIndexOf('\\')), 
                    backgroundList.Items.Count);
            }

            // Get the file paths of all map tiles in the MapTiles folder
            // and add them to the ListView to be selected and used later.
            string[] tilePaths = Directory.GetFiles(CONTENTPATH + "MapTiles");
            for (int i = 0; i < tilePaths.Length; i++)
            {
                tileSet.Images.Add(Image.FromFile(tilePaths[i]));
                tileList.Items.Add(
                    tilePaths[i].Substring(
                        tilePaths[i].LastIndexOf('\\')), 
                    tileList.Items.Count);
            }

            // Update status bar.
            loadingBar.Value += 20;
        }

        /// <summary>
        /// Fills the map box with a blank grid of tiles of the specified 
        /// dimensions. Hard-coded the tile size to fit in the window.
        /// </summary>
        /// <param name="width">Width of the map to be made in tiles.</param>
        /// <param name="height">Height of the map to be made in tiles.</param>
        private void InitializeMap(int width, int height)
        {
            // Update status bar.
            string previoustext = statusLabel.Text;
            statusLabel.Text = "Loading content: initializing map";

            map = new PictureBox[width, height];

            // Find proper tile size.
            int tileSize = mapBackground.Height / height;

            // TODO: Redo this to only resize the width of the mapBackground 
            // in order to match the aspect ratio of the map.
            // Resize window to fit.
            //mapBox.Size = new Size((width * tileSize) + 4, 450);
            //this.Size = new Size(136 + mapBox.Width, 505);

            // Fill the map.
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    map[x, y] = new PictureBox();
                    map[x, y].BackColor = Color.Transparent;
                    map[x, y].Location =
                        new Point((x * tileSize), (y * tileSize));
                    map[x, y].SizeMode = PictureBoxSizeMode.StretchImage;
                    map[x, y].Size = new Size(tileSize, tileSize);
                    mapBackground.Controls.Add(map[x, y]);
                    map[x, y].MouseDown += TileClicked;
                    map[x, y].MouseEnter += TileMousedOver;

                }
            }

            // Update status bar.
            loadingBar.Value += 90;
            statusLabel.Text = previoustext;
        }

        /// <summary>
        /// Called when a tile is clicked and changes its image to the 
        /// currently selected tile if the left mouse button was clicked or 
        /// clears it if the right button was clicked.
        /// </summary>
        /// <param name="sender">The tile that was clicked.</param>
        /// <param name="e">The arguments object associated with this event.</param>
        private void TileClicked(object sender, MouseEventArgs e)
        {
            // Release mouse capture in order to allow dragging.
            ((PictureBox)sender).Capture = false;

            // Change or clear the tile depending on the mouse button pressed
            // at the time.
            if (e.Button == System.Windows.Forms.MouseButtons.Right) 
            {
                // Clear.
                ChangeTile(sender, true);
            }
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                // Set to selected tile.
                ChangeTile(sender, false);
            }
        }

        /// <summary>
        /// Called when the mouse enters any tile and changes its image to the 
        /// currently selected tile if the left mouse button is held or clears 
        /// it if the right button is held.
        /// </summary>
        /// <param name="sender">The tile that sent the MouseEnter event.</param>
        private void TileMousedOver(object sender, EventArgs e)
        {
            // Check which mouse button is held if any and take the appropriate
            // action.
            if (Control.MouseButtons == MouseButtons.Left)
            {
                // Set to selected tile.
                ChangeTile(sender, false);
            } 
            else if (Control.MouseButtons == MouseButtons.Right)
            {
                // Clear.
                ChangeTile(sender, true);
            }
        }

        /// <summary>
        /// Change the image of the sender tile to the currently selected image 
        /// or clears the image if the clear parameter is set.
        /// </summary>
        /// <param name="sender">The tile to be changed.</param>
        /// <param name="clear">True if the tile should cleared instead of set.</param>
        private void ChangeTile(object sender, bool clear)
        {
            if (clear)
            {
                // Clear the image of sender if clear param is set.
                ((PictureBox)sender).Image = null;
            }
            else
            {
                if (tileList.SelectedItems.Count > 0)
                {
                    // Set the image of sender to the selected tile.
                    ((PictureBox)sender).Image =
                        Image.FromFile(CONTENTPATH + "MapTiles" +
                        tileList.SelectedItems[0].Text);
                }
            }

            // Set unsaved changes.
            if (!unsavedChanges)
            {
                unsavedChanges = true;
                Text += '*';
            }
        }

        /// <summary>
        /// Called when an item from the background list gets activated and 
        /// sets the current background to that which was activated.
        /// </summary>
        /// <param name="sender">The list of backgrounds that had an item 
        /// activated.</param>
        private void backgroundList_ItemActivate(object sender, EventArgs e)
        {
            mapBackground.Image 
                = Image.FromFile(
                    CONTENTPATH + "Backgrounds" 
                        + ((ListView)sender).SelectedItems[0].Text);
        }

        /// <summary>
        /// Exits the program after prompting to save changes if necessary.
        /// </summary>
        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            // Checks for unsaved changes and warns the user to save first.
            if (unsavedChanges && UnsavedWarning())
            {
                return;
            }

            this.Close();
        }

        /// <summary>
        /// Alerts the user that there are unsaved changes and asks if they 
        /// would like to save before continuing.
        /// </summary>
        /// <returns>
        /// True if the user selects cancel and the current operation 
        /// should be canceled. Otherwise false.
        /// </returns>
        private bool UnsavedWarning()
        {
            // Ask the user if they would like to save or cancel the current
            // action.
            DialogResult result = MessageBox.Show(
                    "There are unsaved changes on this map, would you like to " +
                    "save before continuing?",
                    "Unsaved changes",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Warning);

            // Do what the user indicated from the message box.
            if (result == DialogResult.Yes)
            {
                Save();
                return false;
            } else if (result == DialogResult.No)
            {
                return false;
            } else
            {
                return true;
            }
        }

        /// <summary>
        /// Saves all editable components to the appropriate data files.
        /// </summary>
        private void Save()
        {
            SaveMap();
        }

        /// <summary>
        /// Writes the current map to the map.data file according to the 
        /// following format:<br/><br/>
        /// WidthxHeight<br/>
        /// The file name of the background image<br/>
        /// A grid of characters the size of the map previously indicated with 
        /// each character representing a tile as follows:<br/><br/>
        /// 0: down<br/>1: downleft<br/>2: downright<br/>3: left<br/>4: right<br/>
        /// 5: up<br/>6: upleft<br/>7: upright<br/>8: center<br/>
        /// anything else: empty
        /// </summary>
        private void SaveMap()
        {
            StreamWriter writer = null;
            try
            {
                writer = new StreamWriter(CONTENTPATH + "map.data", false);

                writer.WriteLine(map.GetLength(0) + 'x' + map.GetLength(1));

                string[] backgroundPaths
                    = Directory.GetFiles(CONTENTPATH + "Backgrounds");
                string background = "";
                for (int i = 0; i < backgroundPaths.Length; i++)
                {
                    if(mapBackground.Image == Image.FromFile(backgroundPaths[i]))
                    {
                        background = backgroundPaths[i].Substring(
                            backgroundPaths[i].LastIndexOf('\\'));
                        break;
                    }
                }
                writer.WriteLine(background);

                string[] tilePaths
                    = Directory.GetFiles(CONTENTPATH + "MapTiles");
                for (int y = 0; y < map.GetLength(1); y++)
                {
                    for (int x = 0; x < map.GetLength(0); x++)
                    {
                        string tile = "";
                        for (int i = 0; i < tilePaths.Length; i++)
                        {
                            if (map[x, y].Image == Image.FromFile(tilePaths[i]))
                            {
                                tile = tilePaths[i];
                                break;
                            }
                        }
                        switch (tile)
                        {
                            default:
                                writer.Write('.');
                                break;
                            case CONTENTPATH + "MapTiles/down.png":
                                writer.Write(0);
                                break;
                            case CONTENTPATH + "MapTiles/downleft.png":
                                writer.Write(1);
                                break;
                            case CONTENTPATH + "MapTiles/downright.png":
                                writer.Write(2);
                                break;
                            case CONTENTPATH + "MapTiles/left.png":
                                writer.Write(3);
                                break;
                            case CONTENTPATH + "MapTiles/right.png":
                                writer.Write(4);
                                break;
                            case CONTENTPATH + "MapTiles/up.png":
                                writer.Write(5);
                                break;
                            case CONTENTPATH + "MapTiles/upleft.png":
                                writer.Write(6);
                                break;
                            case CONTENTPATH + "MapTiles/upright.png":
                                writer.Write(7);
                                break;
                            case CONTENTPATH + "MapTiles/center.png":
                                writer.Write(8);
                                break;
                        }
                    }
                    writer.WriteLine();
                }
                unsavedChanges = false;
            } catch (Exception ex)
            {
                MessageBox.Show(
                  "Map could not be saved.\nError: " + ex.Message,
                  "Error saving map",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Error);
            }
            if (writer != null)
            {
                writer.Close();
            }
            statusLabel.Text = "Saved";
        }

        private void saveMenuItem_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void saveMapMenuItem_Click(object sender, EventArgs e)
        {
            SaveMap();
        }
    }
}
