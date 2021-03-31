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
    public partial class Editor : Form
    {
        private PictureBox[,] map;
        bool unsavedChanges = false;
        string filePath;

        public Editor()
        {
            InitializeComponent();
            filePath = "../../../BankShot/Content/";
            LoadContent();
        }


        private void LoadContent()
        {
            LoadThumbnails();

            statusLabel.Text = "Content loaded, ready";
        }

        private void LoadThumbnails()
        {
            statusLabel.Text = "Loading content: background thumbnails";
            string[] backgroundPaths = Directory.GetFiles(filePath + "Backgrounds");
            for (int i = 0; i < backgroundPaths.Length; i++)
            {
                backgroundImages.Images.Add(Image.FromFile(backgroundPaths[i]));
                backgroundList.Items.Add(backgroundPaths[i].Substring(backgroundPaths[i].LastIndexOf('\\')), backgroundList.Items.Count);
            }
            loadingBar.Value += 10;

            statusLabel.Text = "Loading content: tile thumbnails";
            string[] tilePaths = Directory.GetFiles(filePath + "MapTiles");
            for (int i = 0; i < tilePaths.Length; i++)
            {
                tileSet.Images.Add(Image.FromFile(tilePaths[i]));
                tileList.Items.Add(tilePaths[i].Substring(tilePaths[i].LastIndexOf('\\')), tileList.Items.Count);
            }
            loadingBar.Value += 10;
        }

        /// <summary>
        /// Fills the map box with a blank grid of tiles of the specified 
        /// dimensions.
        /// </summary>
        /// <param name="width">Width of the map to be made.</param>
        /// <param name="height">Width of the map to be made.</param>
        private void InitializeMap(int width, int height)
        {
            map = new PictureBox[width, height];

            //Find proper tile size
            int tileSize = 425 / height;

            //Resize window to fit
            //mapBox.Size = new Size((width * tileSize) + 4, 450);
            //this.Size = new Size(136 + mapBox.Width, 505);

            //Fill map
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    map[x, y] = new PictureBox();
                    map[x, y].BackColor = Color.Transparent;
                    map[x, y].Location =
                        new Point((x * tileSize) + 3, (y * tileSize) + 3);
                    map[x, y].Size = new Size(tileSize, tileSize);
                    mapDivider.Panel2.Controls.Add(map[x, y]);
                    map[x, y].MouseDown += TileClicked;
                    map[x, y].MouseEnter += TileMousedOver;

                }
            }
        }

        private void TileMousedOver(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void TileClicked(object sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void backgroundList_ItemActivate(object sender, EventArgs e)
        {
            mapBackground.Image = Image.FromFile(filePath + "Backgrounds\\" + ((ListView)sender).SelectedItems[0].Text);
        }
    }
}
