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
    /// <para>The external tool allowing editing of maps, stats, upgrades, etc</para>
    /// </summary>
    public partial class Editor : Form
    {
        private PictureBox[,] map;
        bool unsavedChanges = false;
        string filePath;

        /// <summary>
        /// Initializes a new Editor window.
        /// </summary>
        public Editor()
        {
            InitializeComponent();
            filePath = "../../../BankShot/Content/";
            LoadContent();
        }

        /// <summary>
        /// Loads all of the editable content from the main game project.
        /// </summary>
        private void LoadContent()
        {
            // Update status bar.
            statusLabel.Text = "Loading content";
            loadingBar.Value = 0;

            // Load each component
            LoadThumbnails();
            LoadMap();

            // Update status bar.
            statusLabel.Text = "Content loaded, ready";
        }

        /// <summary>
        /// Load in the lists of tiles and background images
        /// </summary>
        private void LoadThumbnails()
        {
            // Update status bar.
            statusLabel.Text = "Loading content: thumbnails";
            // TODO: ENCASE IN TRY
            // TODO: DONT NAME THEM ABD JUST USE THEIR IMAGE
            // Get the filepaths of all backgrounds in the Backgrounds folder
            // and add them to the ListView to be selected and used later.
            string[] backgroundPaths = Directory.GetFiles(filePath + "Backgrounds");
            for (int i = 0; i < backgroundPaths.Length; i++)
            {
                backgroundImages.Images.Add(Image.FromFile(backgroundPaths[i]));
                backgroundList.Items.Add(
                    backgroundPaths[i].Substring(backgroundPaths[i].LastIndexOf('\\')), 
                    backgroundList.Items.Count);
            }

            // Update status bar.
            loadingBar.Value += 10;

            // Get the filepaths of all map tiles in the MapTiles folder
            // and add them to the ListView to be selected and used later.
            string[] tilePaths = Directory.GetFiles(filePath + "MapTiles");
            for (int i = 0; i < tilePaths.Length; i++)
            {
                tileSet.Images.Add(Image.FromFile(tilePaths[i]));
                tileList.Items.Add(tilePaths[i].Substring(tilePaths[i].LastIndexOf('\\')), 
                    tileList.Items.Count);
            }

            // Update status bar.
            loadingBar.Value += 10;
        }

        /// <summary>
        /// Fills the map box with a blank grid of tiles of the specified 
        /// dimensions. Hardcoded to set the tile size to fit in the game 
        /// window size.
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

            // Resize window to fit.
            //mapBox.Size = new Size((width * tileSize) + 4, 450);
            //this.Size = new Size(136 + mapBox.Width, 505);

            // Fill map.
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    map[x, y] = new PictureBox();
                    map[x, y].BackColor = Color.Transparent;
                    map[x, y].Location =
                        new Point((x * tileSize) + 3, (y * tileSize) + 3);
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
        /// Called when the mouse enters any tile and changes its image to the 
        /// currently selected tile if the left mouse button is held or clears 
        /// it if the right button is held.
        /// </summary>
        /// <param name="sender">The tile that sent the MouseEnter event.</param>
        /// <param name="e"></param>
        private void TileMousedOver(object sender, EventArgs e)
        {
            // Check which mouse button is held if any and take the appropriate
            // action.
            if (Control.MouseButtons == MouseButtons.Left)
            {
                ChangeTile(sender, false);
            } 
            else if (Control.MouseButtons == MouseButtons.Right)
            {
                ChangeTile(sender, true);
            }
        }

        /// <summary>
        /// Change the image of any tile that triggered an event that 
        /// calls this to the currently selected image or clears the image if 
        /// the clear bool is set.
        /// </summary>
        /// <param name="sender">The tile to be changed.</param>
        /// <param name="clear">True if the tile should cleared instead of set.</param>
        private void ChangeTile(object sender, bool clear)
        {
            if (clear)
            {
                ((PictureBox)sender).Image = null;
            }
            else
            {
                ((PictureBox)sender).Image =
                    Image.FromFile(filePath + "MapTiles" + tileList.SelectedItems[0].Text);
            }

            //mark unsaved changes
            if (!unsavedChanges)
            {
                unsavedChanges = true;
                Text += '*';
            }
        }

        /// <summary>
        /// Called when a tile is clicked, changes or clears the tile depending 
        /// on the mouse button clicked.
        /// </summary>
        /// <param name="sender">The tile that was clicked.</param>
        /// <param name="e">The arguments object associated with this event.</param>
        private void TileClicked(object sender, MouseEventArgs e)
        {
            // Release mouse capture in order to allow dragging
            ((PictureBox)sender).Capture = false;

            // Change or clear the tile depending on the mouse button pressed
            // at the time.
            if (e.Button == System.Windows.Forms.MouseButtons.Right) 
            {
                ChangeTile(sender, true);
            }
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                ChangeTile(sender, false);
            }
        }
        
        /// <summary>
        /// Exits the program after prompting to save changes if necessary.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void backgroundList_ItemActivate(object sender, EventArgs e)
        {
            mapBackground.Image = Image.FromFile(filePath + "Backgrounds" + ((ListView)sender).SelectedItems[0].Text);
        }

        /// <summary>
        /// Loads the map in from the file.
        /// </summary>
        private void LoadMap()
        {
            // Checks for unsaved changes and warns the user to save first.
            if (unsavedChanges)
            {
                if (UnsavedWarning())
                {
                    return;
                }
            }

            // Update the status bar.
            statusLabel.Text = "Loading content: loading map";

            // Read the file according to the format specified in Save().
            StreamReader reader = null;
            try
            {
                reader = new StreamReader(File.OpenRead(filePath + "map.data"));

                // Read header info.
                string[] header = reader.ReadLine().Split('|');
                int width = int.Parse(header[0]);
                int height = int.Parse(header[1]);

                // Clear and re-make the map with the read dimensions.
                mapBackground.Controls.Clear();
                InitializeMap(width, height);

                // Read and set background image path
                mapBackground.Image = Image.FromFile(filePath + "Background/" 
                    + reader.ReadLine());
                
                //read and apply map data
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        switch (reader.Read())
                        {
                            default:
                                map[x, y].Image = Image.FromFile("center.png");
                                break;
                            case 48:
                                map[x, y].Image = Image.FromFile("down.png");
                                break;
                            case 49:
                                map[x, y].Image = Image.FromFile("downleft.png");
                                break;
                            case 50:
                                map[x, y].Image = Image.FromFile("downright.png");
                                break;
                            case 51:
                                map[x, y].Image = Image.FromFile("left.png");
                                break;
                            case 52:
                                map[x, y].Image = Image.FromFile("right.png");
                                break;
                            case 53:
                                map[x, y].Image = Image.FromFile("up.png");
                                break;
                            case 54:
                                map[x, y].Image = Image.FromFile("upleft.png");
                                break;
                            case 55:
                                map[x, y].Image = Image.FromFile("upright.png");
                                break;
                            case 56:
                                break;
                            case 57:
                                break;
                            case 58:
                                break;
                            case 59:
                                break;
                            case 60:
                                break;
                        }
                    }
                }

                //inform user of successful load and update titlebar
                MessageBox.Show(
                        "Map successfully loaded from\n" + filePath,
                        "Map loaded",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                Text = "Level Editor - " + filePath.Substring(
                    filePath.LastIndexOf('\\') + 1);
                unsavedChanges = false;
                
            } catch (Exception ex)
            {
                MessageBox.Show(
                        "Map could not be loaded.\nError: " + ex.Message,
                        "Error loading map",
                         MessageBoxButtons.OK,
                         MessageBoxIcon.Error);
            }
            if (reader != null)
            {
                reader.Close();
            }
        }

        private bool UnsavedWarning()
        {
            throw new NotImplementedException();
        }
    }
}
