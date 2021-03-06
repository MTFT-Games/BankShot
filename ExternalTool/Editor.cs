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
        private List<PictureBox[,]> waves;
        private List<Upgrade> upgrades;
        string currentBackground;
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
            LoadWaves();
            LoadUpgrades();
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
                currentBackground = reader.ReadLine();
                mapBackground.Image = Image.FromFile(CONTENTPATH + "Backgrounds/" 
                    + currentBackground);
                
                // Read and apply map data where each character is mapped to a
                // tile.
                for (int y = 0; y < height; y++)
                {
                    string[] line = reader.ReadLine().Split('|');
                    for (int x = 0; x < width; x++)
                    {
                        int tileID;
                        if (int.TryParse(line[x], out tileID)){
                            map[x, y].Image = tileSet.Images[tileID];
                            map[x, y].Controls[0].Text = line[x];
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
            Array.Sort<string>(tilePaths);
            for (int i = 0; i < tilePaths.Length; i++)
            {
                tileSet.Images.Add(Image.FromFile(tilePaths[i]));
                thumbnailSet.Images.Add(tileSet.Images[i]);
                tileList.Items.Add(
                    tilePaths[i].Substring(
                        tilePaths[i].LastIndexOf('\\')), 
                    tileList.Items.Count);
            }

            // TODO: Load upgrade icons into an image list and put the paths in the dropdown in the same order
            // Get the file paths of all icons in the UpgradeIcons folder
            // and add them to the upgrade icon dropdown to be selected and used later.
            string[] upgradeIconPaths
                = Directory.GetFiles(CONTENTPATH + "UpgradeIcons");
            for (int i = 0; i < upgradeIconPaths.Length; i++)
            {
                upgradeIcons.Images.Add(Image.FromFile(upgradeIconPaths[i]));
                upgradeImageDrop.Items.Add(
                    upgradeIconPaths[i].Substring(
                        upgradeIconPaths[i].LastIndexOf('\\')+1));
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
                    map[x, y].Cursor = Cursors.Cross;
                    mapBackground.Controls.Add(map[x, y]);
                    map[x, y].MouseDown += TileClicked;
                    map[x, y].MouseEnter += TileMousedOver;
                    map[x, y].Controls.Add(new Label());
                   // map[x, y].Controls[0].ForeColor = Color.Transparent;
                   // map[x, y].Controls[0].Font = new Font("Comic Sans MS", 0.1f);
                    map[x, y].Controls[0].Visible = false;
                    map[x, y].Controls[0].Enabled = false;
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
                ((PictureBox)sender).Controls[0].Text = "";
            }
            else
            {
                if (tileList.SelectedItems.Count > 0)
                {
                    // Set the image of sender to the selected tile.
                    ((PictureBox)sender).Image =
                        tileSet.Images[tileList.SelectedItems[0].ImageIndex];
                    ((PictureBox)sender).Controls[0].Text
                        = tileList.SelectedItems[0].ImageIndex.ToString();
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
            currentBackground = ((ListView)sender).SelectedItems[0].Text.Substring(1);
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
            SaveUpgrades();
            SaveWaves();
            unsavedChanges = false; 
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

                writer.WriteLine(map.GetLength(0) + "x" + map.GetLength(1));

                writer.WriteLine(currentBackground);
                
                for (int y = 0; y < map.GetLength(1); y++)
                {
                    for (int x = 0; x < map.GetLength(0); x++)
                    {
                        if (map[x, y].Controls[0].Text != "")
                        {
                            writer.Write(map[x, y].Controls[0].Text + "|");
                        } else
                        {
                            writer.Write(".|");
                            //
                        }
                    }
                        
                    writer.WriteLine();
                }
                
                unsavedChanges = false;
                Text = "Editor";
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

        private void upgradeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            upgradeImageDrop.Text = upgrades[upgradeList.SelectedIndices[0]].iconPath;

            ((CheckBox)upgradeDmg.Controls[1]).Checked = upgrades[upgradeList.SelectedIndices[0]].damageIsMultiplier;
            if (((CheckBox)upgradeDmg.Controls[1]).Checked)
            {
                ((TrackBar)upgradeDmg.Controls[2]).Value = (int)(upgrades[upgradeList.SelectedIndices[0]].damageModifier * 100);
            } else
            {
                ((TrackBar)upgradeDmg.Controls[2]).Value = (int)(upgrades[upgradeList.SelectedIndices[0]].damageModifier);
            }

            ((CheckBox)upgradeProjSpeed.Controls[1]).Checked = upgrades[upgradeList.SelectedIndices[0]].projectileSpeedIsMultiplier;
            if (((CheckBox)upgradeProjSpeed.Controls[1]).Checked)
            {
                ((TrackBar)upgradeProjSpeed.Controls[2]).Value = (int)(upgrades[upgradeList.SelectedIndices[0]].projectileSpeedModifier * 100);
            } else
            {
                ((TrackBar)upgradeProjSpeed.Controls[2]).Value = (int)(upgrades[upgradeList.SelectedIndices[0]].projectileSpeedModifier);
            }

            ((CheckBox)upgradeProjHome.Controls[1]).Checked = upgrades[upgradeList.SelectedIndices[0]].projectileHomingIsMultiplier;
            ((TrackBar)upgradeProjHome.Controls[2]).Value = (int)(upgrades[upgradeList.SelectedIndices[0]].projectileHomingModifier*100);

            ((CheckBox)upgradeShieldCool.Controls[1]).Checked = upgrades[upgradeList.SelectedIndices[0]].shieldCooldownIsMultiplier;
            ((TrackBar)upgradeShieldCool.Controls[2]).Value = (int)(upgrades[upgradeList.SelectedIndices[0]].shieldCooldownModifier * 100);

            ((CheckBox)upgradeKnock.Controls[1]).Checked = upgrades[upgradeList.SelectedIndices[0]].knockbackIsMultiplier;
            if (((CheckBox)upgradeKnock.Controls[1]).Checked)
            {
                ((TrackBar)upgradeKnock.Controls[2]).Value = (int)(upgrades[upgradeList.SelectedIndices[0]].knockbackModifier * 100);
            } else
            {
                ((TrackBar)upgradeKnock.Controls[2]).Value = (int)(upgrades[upgradeList.SelectedIndices[0]].knockbackModifier);
            }


            ((CheckBox)upgradeProjCount.Controls[1]).Checked = upgrades[upgradeList.SelectedIndices[0]].projectileCountIsMultiplier;
            if (((CheckBox)upgradeProjCount.Controls[1]).Checked)
            {
                ((TrackBar)upgradeProjCount.Controls[2]).Value = (int)(upgrades[upgradeList.SelectedIndices[0]].projectileCountModifier * 100);
            } else
            {
                ((TrackBar)upgradeProjCount.Controls[2]).Value = (int)(upgrades[upgradeList.SelectedIndices[0]].projectileCountModifier);
            }

            ((TrackBar)upgradeProjSize.Controls[2]).Value = (int)(upgrades[upgradeList.SelectedIndices[0]].projectileSizeModifier * 100);

            ((CheckBox)upgradeShieldHealth.Controls[1]).Checked = upgrades[upgradeList.SelectedIndices[0]].shieldHealthIsMultiplier;
            if (((CheckBox)upgradeShieldHealth.Controls[1]).Checked)
            {
                ((TrackBar)upgradeShieldHealth.Controls[2]).Value = (int)(upgrades[upgradeList.SelectedIndices[0]].shieldHealthModifier * 100);
            } else
            {
                ((TrackBar)upgradeShieldHealth.Controls[2]).Value = (int)(upgrades[upgradeList.SelectedIndices[0]].shieldHealthModifier);
            }

            ((CheckBox)upgradeHealth.Controls[1]).Checked = upgrades[upgradeList.SelectedIndices[0]].healthIsMultiplier;
            if (((CheckBox)upgradeHealth.Controls[1]).Checked)
            {
                ((TrackBar)upgradeHealth.Controls[2]).Value = (int)(upgrades[upgradeList.SelectedIndices[0]].healthModifier * 100);
            } else
            {
                ((TrackBar)upgradeHealth.Controls[2]).Value = (int)(upgrades[upgradeList.SelectedIndices[0]].healthModifier);
            }

            ((CheckBox)upgradeKnockResist.Controls[1]).Checked = upgrades[upgradeList.SelectedIndices[0]].knockbackResistIsMultiplier;
            if (((CheckBox)upgradeKnockResist.Controls[1]).Checked)
            {
                ((TrackBar)upgradeKnockResist.Controls[2]).Value = (int)(upgrades[upgradeList.SelectedIndices[0]].knockbackResistModifier * 100);
            } else
            {
                ((TrackBar)upgradeKnockResist.Controls[2]).Value = (int)(upgrades[upgradeList.SelectedIndices[0]].knockbackResistModifier);
            }

            upgradeJump.Checked = upgrades[upgradeList.SelectedIndices[0]].additionalJump;


            ((CheckBox)upgradeROF.Controls[1]).Checked = upgrades[upgradeList.SelectedIndices[0]].rateOfFireIsMultiplier;
            ((TrackBar)upgradeROF.Controls[2]).Value = (int)(upgrades[upgradeList.SelectedIndices[0]].rateOfFireModifier * 100);

            ((CheckBox)upgradeProjSpread.Controls[1]).Checked = upgrades[upgradeList.SelectedIndices[0]].projectileSpreadIsMultiplier;
            ((TrackBar)upgradeProjSpread.Controls[2]).Value = (int)(upgrades[upgradeList.SelectedIndices[0]].projectileSpreadModifier * 100);

            ((CheckBox)upgradeShieldRegen.Controls[1]).Checked = upgrades[upgradeList.SelectedIndices[0]].shieldRegenIsMultiplier;
            ((TrackBar)upgradeShieldRegen.Controls[2]).Value = (int)(upgrades[upgradeList.SelectedIndices[0]].shieldRegenModifier * 100);

            ((CheckBox)upgradeHealthRegen.Controls[1]).Checked = upgrades[upgradeList.SelectedIndices[0]].healthRegenIsMultiplier;
            ((TrackBar)upgradeHealthRegen.Controls[2]).Value = (int)(upgrades[upgradeList.SelectedIndices[0]].healthRegenModifier * 100);

            ((TrackBar)upgradeWeight.Controls[1]).Value = upgrades[upgradeList.SelectedIndices[0]].weight;


            upgradeName.Text = upgrades[upgradeList.SelectedIndices[0]].name;

            upgradeDesc.Text = upgrades[upgradeList.SelectedIndices[0]].description;

            ((TrackBar)UpgradeCost.Controls[1]).Value = upgrades[upgradeList.SelectedIndices[0]].cost;
        }

        /// <summary>
        /// Set display to show correct value.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBar_Scroll(object sender, EventArgs e)
        {
            //can simplify
            if(((Control)sender).Parent.Controls[1] is CheckBox)
            {
                if (((CheckBox)((Control)sender).Parent.Controls[1]).Checked)
                {
                        ((Control)sender).Parent.Controls[0].Text = (((TrackBar)sender).Value/100.0).ToString();
                } else
                {
                    if(((TrackBar)sender).Value > 0)
                    {
                        ((Control)sender).Parent.Controls[0].Text = '+' + ((TrackBar)sender).Value.ToString();
                    } else
                    {
                        ((Control)sender).Parent.Controls[0].Text = ((TrackBar)sender).Value.ToString();
                    }
                }
            } else
            {
            ((Control)sender).Parent.Controls[0].Text = ((TrackBar)sender).Value.ToString();
            }
        }

        private void multiplier_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            {
                ((TrackBar)((Control)sender).Parent.Controls[2]).Minimum = 0;
                ((TrackBar)((Control)sender).Parent.Controls[2]).Maximum = 300;
            } else
            {
                ((TrackBar)((Control)sender).Parent.Controls[2]).Minimum = -20;
                ((TrackBar)((Control)sender).Parent.Controls[2]).Maximum = 20;
            }
        }

        /// <summary>
        /// Set display to show correct decimal value.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBar_DecScroll(object sender, EventArgs e)
        {
            // TODO: Clean up this absolute mess. How dio I do this without having an anurism?
            if (((Control)sender).Parent.Controls[1] is CheckBox)
            {
                if (((CheckBox)((Control)sender).Parent.Controls[1]).Checked)
                {
                    ((Control)sender).Parent.Controls[0].Text = (((TrackBar)sender).Value / 100.0).ToString();
                } else
                {
                    if (((TrackBar)sender).Value > 0)
                    {
                        ((Control)sender).Parent.Controls[0].Text = '+' + (((TrackBar)sender).Value/ 100.0).ToString();
                    } else
                    {
                        ((Control)sender).Parent.Controls[0].Text = (((TrackBar)sender).Value / 100.0).ToString();

                    }
                }
            } else
            {
                ((Control)sender).Parent.Controls[0].Text = ((TrackBar)sender).Value.ToString();
            }
        }

        private void multiplier_DecCheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            {
                ((TrackBar)((Control)sender).Parent.Controls[2]).Minimum = 0;
                ((TrackBar)((Control)sender).Parent.Controls[2]).Maximum = 300;
            } else
            {
                ((TrackBar)((Control)sender).Parent.Controls[2]).Minimum = -2000;
                ((TrackBar)((Control)sender).Parent.Controls[2]).Maximum = 2000;
            }
        }

        private void upgradeImageDrop_SelectedIndexChanged(object sender, EventArgs e)
        {
            upgradeIcon.Image = upgradeIcons.Images[((ComboBox)sender).SelectedIndex];
        }

        private void UpdateUpgrade(object sender, EventArgs e)
        {
            if (upgradeList.SelectedIndices.Count > 0)
            {
                upgrades[upgradeList.SelectedIndices[0]].iconPath = upgradeImageDrop.Text;

                upgrades[upgradeList.SelectedIndices[0]].damageIsMultiplier = ((CheckBox)upgradeDmg.Controls[1]).Checked;
                upgrades[upgradeList.SelectedIndices[0]].damageModifier = double.Parse(((Label)upgradeDmg.Controls[0]).Text);

                upgrades[upgradeList.SelectedIndices[0]].projectileSpeedIsMultiplier = ((CheckBox)upgradeProjSpeed.Controls[1]).Checked;
                upgrades[upgradeList.SelectedIndices[0]].projectileSpeedModifier = double.Parse(((Label)upgradeProjSpeed.Controls[0]).Text);

                upgrades[upgradeList.SelectedIndices[0]].projectileHomingIsMultiplier = ((CheckBox)upgradeProjHome.Controls[1]).Checked;
                upgrades[upgradeList.SelectedIndices[0]].projectileHomingModifier = double.Parse(((Label)upgradeProjHome.Controls[0]).Text);

                upgrades[upgradeList.SelectedIndices[0]].shieldCooldownIsMultiplier = ((CheckBox)upgradeShieldCool.Controls[1]).Checked;
                upgrades[upgradeList.SelectedIndices[0]].shieldCooldownModifier = double.Parse(((Label)upgradeShieldCool.Controls[0]).Text);

                upgrades[upgradeList.SelectedIndices[0]].knockbackIsMultiplier = ((CheckBox)upgradeKnock.Controls[1]).Checked;
                upgrades[upgradeList.SelectedIndices[0]].knockbackModifier = double.Parse(((Label)upgradeKnock.Controls[0]).Text);


                upgrades[upgradeList.SelectedIndices[0]].projectileCountIsMultiplier = ((CheckBox)upgradeProjCount.Controls[1]).Checked;
                upgrades[upgradeList.SelectedIndices[0]].projectileCountModifier = double.Parse(((Label)upgradeProjCount.Controls[0]).Text);

                upgrades[upgradeList.SelectedIndices[0]].projectileSizeModifier = double.Parse(((Label)upgradeProjSize.Controls[0]).Text);

                upgrades[upgradeList.SelectedIndices[0]].shieldHealthIsMultiplier = ((CheckBox)upgradeShieldHealth.Controls[1]).Checked;
                upgrades[upgradeList.SelectedIndices[0]].shieldHealthModifier = double.Parse(((Label)upgradeShieldHealth.Controls[0]).Text);

                upgrades[upgradeList.SelectedIndices[0]].healthIsMultiplier = ((CheckBox)upgradeHealth.Controls[1]).Checked;
                upgrades[upgradeList.SelectedIndices[0]].healthModifier = double.Parse(((Label)upgradeHealth.Controls[0]).Text);

                upgrades[upgradeList.SelectedIndices[0]].knockbackResistIsMultiplier = ((CheckBox)upgradeKnockResist.Controls[1]).Checked;
                upgrades[upgradeList.SelectedIndices[0]].knockbackResistModifier = double.Parse(((Label)upgradeKnockResist.Controls[0]).Text);

                upgrades[upgradeList.SelectedIndices[0]].additionalJump = upgradeJump.Checked;


                upgrades[upgradeList.SelectedIndices[0]].rateOfFireIsMultiplier = ((CheckBox)upgradeROF.Controls[1]).Checked;
                upgrades[upgradeList.SelectedIndices[0]].rateOfFireModifier = double.Parse(((Label)upgradeROF.Controls[0]).Text);

                upgrades[upgradeList.SelectedIndices[0]].projectileSpreadIsMultiplier = ((CheckBox)upgradeProjSpread.Controls[1]).Checked;
                upgrades[upgradeList.SelectedIndices[0]].projectileSpreadModifier = double.Parse(((Label)upgradeProjSpread.Controls[0]).Text);

                upgrades[upgradeList.SelectedIndices[0]].shieldRegenIsMultiplier = ((CheckBox)upgradeShieldRegen.Controls[1]).Checked;
                upgrades[upgradeList.SelectedIndices[0]].shieldRegenModifier = double.Parse(((Label)upgradeShieldRegen.Controls[0]).Text);

                upgrades[upgradeList.SelectedIndices[0]].healthRegenIsMultiplier = ((CheckBox)upgradeHealthRegen.Controls[1]).Checked;
                upgrades[upgradeList.SelectedIndices[0]].healthRegenModifier = double.Parse(((Label)upgradeHealthRegen.Controls[0]).Text);

                upgrades[upgradeList.SelectedIndices[0]].weight = int.Parse(((Label)upgradeWeight.Controls[0]).Text);


                upgrades[upgradeList.SelectedIndices[0]].name = upgradeName.Text;
                upgradeList.Items[upgradeList.SelectedIndices[0]].Text = upgradeName.Text;

                upgrades[upgradeList.SelectedIndices[0]].description = upgradeDesc.Text;

                upgrades[upgradeList.SelectedIndices[0]].cost = int.Parse(((Label)UpgradeCost.Controls[0]).Text);

                unsavedChanges = true;
            }
        }

        private void newUpgradeBtn_Click(object sender, EventArgs e)
        {
            upgrades.Add(new Upgrade(
                "New upgrade",
                "",
                false, 0,
                false, 0,
                false, 0,
                false, 0,
                1,
                false, 0,
                false, 0,
                false, 0,
                false, 0,
                false, 0,
                false, 0,
                false, 0,
                false, 0,
                false, 0,
                false,
                "DmgIcon.png",
                0,
                0));
            upgradeList.Items.Add("New upgrade");
            unsavedChanges = true;
        }

        /// <summary>
        /// Loads all upgrades in from the file.
        /// </summary>
        private void LoadUpgrades() 
        {
            // TODO: Error loading multiline
            StreamReader reader = null;
            try
            {
                upgrades = new List<Upgrade>();
                reader = new StreamReader(CONTENTPATH + "upgrades.data");
                do
                {
                    string name = reader.ReadLine();
                    string description = "";
                    do
                    {
                        description += reader.ReadLine();
                    } while (description.Substring(description.Length - 2) != "||");

                    string[] line = reader.ReadLine().Split(' ');
                    bool damageIsMultiplier = bool.Parse(line[0]);
                    double damageModifier = double.Parse(line[1]);

                    line = reader.ReadLine().Split(' ');
                    bool projectileCountIsMultiplier = bool.Parse(line[0]);
                    double projectileCountModifier = double.Parse(line[1]);

                    line = reader.ReadLine().Split(' ');
                    bool rateOfFireIsMultiplier = bool.Parse(line[0]);
                    double rateOfFireModifier = double.Parse(line[1]);

                    line = reader.ReadLine().Split(' ');
                    bool projectileSpeedIsMultiplier = bool.Parse(line[0]);
                    double projectileSpeedModifier = double.Parse(line[1]);

                    double projectileSizeModifier = double.Parse(reader.ReadLine());

                    line = reader.ReadLine().Split(' ');
                    bool projectileSpreadIsMultiplier = bool.Parse(line[0]);
                    double projectileSpreadModifier = double.Parse(line[1]);

                    line = reader.ReadLine().Split(' ');
                    bool projectileHomingIsMultiplier = bool.Parse(line[0]);
                    double projectileHomingModifier = double.Parse(line[1]);

                    line = reader.ReadLine().Split(' ');
                    bool shieldHealthIsMultiplier = bool.Parse(line[0]);
                    double shieldHealthModifier = double.Parse(line[1]);

                    line = reader.ReadLine().Split(' ');
                    bool shieldRegenIsMultiplier = bool.Parse(line[0]);
                    double shieldRegenModifier = double.Parse(line[1]);

                    line = reader.ReadLine().Split(' ');
                    bool shieldCooldownIsMultiplier = bool.Parse(line[0]);
                    double shieldCooldownModifier = double.Parse(line[1]);

                    line = reader.ReadLine().Split(' ');
                    bool healthIsMultiplier = bool.Parse(line[0]);
                    double healthModifier = double.Parse(line[1]);

                    line = reader.ReadLine().Split(' ');
                    bool healthRegenIsMultiplier = bool.Parse(line[0]);
                    double healthRegenModifier = double.Parse(line[1]);

                    line = reader.ReadLine().Split(' ');
                    bool knockbackIsMultiplier = bool.Parse(line[0]);
                    double knockbackModifier = double.Parse(line[1]);

                    line = reader.ReadLine().Split(' ');
                    bool knockbackResistIsMultiplier = bool.Parse(line[0]);
                    double knockbackResistModifier = double.Parse(line[1]);

                    bool additionalJump = bool.Parse(reader.ReadLine());

                    string iconPath = reader.ReadLine();
                    int weight = int.Parse(reader.ReadLine());
                    int cost = int.Parse(reader.ReadLine());

                    upgrades.Add(new Upgrade(
                        name,
                        description.Substring(0, description.Length-2),
                        damageIsMultiplier,
                        damageModifier,
                        projectileCountIsMultiplier,
                        projectileCountModifier,
                        rateOfFireIsMultiplier,
                        rateOfFireModifier,
                        projectileSpeedIsMultiplier,
                        projectileSpeedModifier,
                        projectileSizeModifier,
                        projectileSpreadIsMultiplier,
                        projectileSpreadModifier,
                        projectileHomingIsMultiplier,
                        projectileHomingModifier,
                        shieldHealthIsMultiplier,
                        shieldHealthModifier,
                        shieldRegenIsMultiplier,
                        shieldRegenModifier,
                        shieldCooldownIsMultiplier,
                        shieldCooldownModifier,
                        healthIsMultiplier,
                        healthModifier,
                        healthRegenIsMultiplier,
                        healthRegenModifier,
                        knockbackIsMultiplier,
                        knockbackModifier,
                        knockbackResistIsMultiplier,
                        knockbackResistModifier,
                        additionalJump,
                        iconPath,
                        weight,
                        cost));
                    upgradeList.Items.Add(name);
                } while (reader.ReadLine()!="|||");
            } catch (Exception)
            {

                throw;
            }
            if (reader != null)
            {
                reader.Close();
            }
        }

        private void SaveUpgrades()
        {
            UpdateUpgrade(null, null);

            StreamWriter writer = null;
            try
            {
                writer = new StreamWriter(CONTENTPATH + "upgrades.data", false);
                for (int i = 0; i < upgrades.Count; i++)
                {
                    writer.WriteLine(upgrades[i].name);
                    //check this later for multiline work
                    writer.WriteLine(upgrades[i].description + "||");
                    writer.WriteLine(upgrades[i].damageIsMultiplier.ToString() + " " + upgrades[i].damageModifier.ToString());
                    writer.WriteLine(upgrades[i].projectileCountIsMultiplier.ToString() + " " + upgrades[i].projectileCountModifier.ToString());
                    writer.WriteLine(upgrades[i].rateOfFireIsMultiplier.ToString() + " " + upgrades[i].rateOfFireModifier.ToString());
                    writer.WriteLine(upgrades[i].projectileSpeedIsMultiplier.ToString() + " " + upgrades[i].projectileSpeedModifier.ToString());
                    writer.WriteLine(upgrades[i].projectileSizeModifier.ToString());
                    writer.WriteLine(upgrades[i].projectileSpreadIsMultiplier.ToString() + " " + upgrades[i].projectileSpreadModifier.ToString());
                    writer.WriteLine(upgrades[i].projectileHomingIsMultiplier.ToString() + " " + upgrades[i].projectileHomingModifier.ToString());
                    writer.WriteLine(upgrades[i].shieldHealthIsMultiplier.ToString() + " " + upgrades[i].shieldHealthModifier.ToString());
                    writer.WriteLine(upgrades[i].shieldRegenIsMultiplier.ToString() + " " + upgrades[i].shieldRegenModifier.ToString());
                    writer.WriteLine(upgrades[i].shieldCooldownIsMultiplier.ToString() + " " + upgrades[i].shieldCooldownModifier.ToString());
                    writer.WriteLine(upgrades[i].healthIsMultiplier.ToString() + " " + upgrades[i].healthModifier.ToString());
                    writer.WriteLine(upgrades[i].healthRegenIsMultiplier.ToString() + " " + upgrades[i].healthRegenModifier.ToString());
                    writer.WriteLine(upgrades[i].knockbackIsMultiplier.ToString() + " " + upgrades[i].knockbackModifier.ToString());
                    writer.WriteLine(upgrades[i].knockbackResistIsMultiplier.ToString() + " " + upgrades[i].knockbackResistModifier.ToString());
                    writer.WriteLine(upgrades[i].additionalJump.ToString());
                    writer.WriteLine(upgrades[i].iconPath);
                    writer.WriteLine(upgrades[i].weight);
                    writer.WriteLine(upgrades[i].cost);
                    if(i == upgrades.Count - 1)
                    {
                        writer.WriteLine("|||");
                    } else
                    {
                        writer.WriteLine();
                    }
                }
            } catch (Exception)
            {

                throw;
            }
            if (writer != null)
            {
                writer.Close();
            }

        }

        private void DeleteUpgrade(object sender, EventArgs e)
        {
            // TODO: addd 'are you sure' dialogue
            upgrades.RemoveAt(upgradeList.SelectedIndices[0]);
            upgradeList.Items.RemoveAt(upgradeList.SelectedIndices[0]);
            upgradeList.Items[0].Selected = true;
            upgradeList_SelectedIndexChanged(upgradeList, null);
            unsavedChanges = true;
        }

        private void Editor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (unsavedChanges)
            {
                if (UnsavedWarning())
                {
                    e.Cancel = true;
                }
            }
        }

        private void MapMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(((TabControl)sender).SelectedIndex == 1)
            {
                WaveEnable((int)waveCounter.Value, true);
            } else
            {
                WaveEnable((int)waveCounter.Value, false);
            }
        }

        private void WaveEnable(int wave, bool enable)
        {
            for (int y = 0; y < waves[0].GetLength(1); y++)
            {
                for (int x = 0; x < waves[0].GetLength(0); x++)
                {
                    waves[wave][x, y].Enabled = enable;
                    waves[wave][x, y].Visible = enable;
                }
            }
        }

        private void LoadWaves()
        {
            StreamReader reader = null;
            try
            {
                reader = new StreamReader(CONTENTPATH + "waves.data");
                waves = new List<PictureBox[,]>();

                string[] splitLine = reader.ReadLine().Split('x');
                int width = int.Parse(splitLine[0]);
                int height = int.Parse(splitLine[1]);
                int wave = 0;

                do
                {
                    reader.ReadLine();

                    waves.Add(new PictureBox[width, height]);


                    // Find proper tile size.
                    int tileSize = mapBackground.Height / height;

                    // Fill the map.
                    for (int y = 0; y < height; y++)
                    {
                        splitLine = reader.ReadLine().Split('|');
                        for (int x = 0; x < width; x++)
                        {
                            waves[wave][x, y] = new PictureBox();
                            waves[wave][x, y].BackColor = Color.Transparent;
                            //waves[wave][x, y].Location =
                            //    new Point((x * tileSize), (y * tileSize));
                            waves[wave][x, y].SizeMode = PictureBoxSizeMode.StretchImage;
                            waves[wave][x, y].Size = new Size(tileSize, tileSize);
                            waves[wave][x, y].Cursor = Cursors.Cross;
                            waves[wave][x, y].MouseDown += WaveTileClicked;
                            waves[wave][x, y].Enabled = false;
                            waves[wave][x, y].Visible = false;
                            waves[wave][x, y].Controls.Add(new Label());
                            waves[wave][x, y].Controls[0].Visible = false;
                            waves[wave][x, y].Controls[0].Enabled = false;

                            int tileID;
                            if (int.TryParse(splitLine[x], out tileID))
                            {
                                waves[wave][x, y].Controls[0].Text = splitLine[x];
                                waves[wave][x, y].Image = enemyIcons.Images[0];
                                switch (tileID)
                                {
                                    case 1:
                                        waves[wave][x, y].BackColor = Color.Red;
                                        break;
                                    case 2:
                                        break;
                                    case 3:
                                        waves[wave][x, y].BackColor = Color.Green;
                                        break;
                                    case 4:
                                        waves[wave][x, y].BackColor = Color.Brown;
                                        break;
                                    default:
                                        break;
                                }
                            }
                            
                            map[x, y].Controls.Add(waves[wave][x, y]);
                        }
                    }

                    wave++;
                } while (reader.ReadLine() != "|EOF|");

                waveCounter.Maximum = wave - 1;
            } catch (Exception)
            {

                throw;
            }
            if(reader != null)
            {
                reader.Close();
            }
        }

        private void WaveTileClicked(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                // Clear the image of sender if clear param is set.
                ((PictureBox)sender).Image = null;
                ((PictureBox)sender).Controls[0].Text = "";
                ((PictureBox)sender).BackColor = Color.Transparent;
            } else if (enemySelect.SelectedIndex != -1)
            {
                // Set the image of sender to the selected tile.
                ((PictureBox)sender).Image = enemyIcons.Images[0];
                ((PictureBox)sender).Controls[0].Text = (enemySelect.SelectedIndex + 1).ToString();
                switch ((int)enemySelect.SelectedIndex + 1)
                {
                    case 1:
                        ((PictureBox)sender).BackColor = Color.Red;
                        break;
                    case 2:
                        break;
                    case 3:
                        ((PictureBox)sender).BackColor = Color.Green;
                        break;
                    case 4:
                        ((PictureBox)sender).BackColor = Color.Brown;
                        break;
                    default:
                        break;
                }
            }

            // Set unsaved changes.
            if (!unsavedChanges)
            {
                unsavedChanges = true;
                Text += '*';
            }
        }

        private void waveCounter_ValueChanged(object sender, EventArgs e)
        {
            WaveEnable((int)waveCounter.Value, true);

            if (((int)waveCounter.Value + 1) < waves.Count)
            {
                WaveEnable((int)waveCounter.Value + 1, false);
            }

            if (((int)waveCounter.Value - 1) >= 0)
            {
            WaveEnable((int)waveCounter.Value-1, false);
            }
        }

        private void SaveWaves()
        {
            StreamWriter writer = null;
            try
            {
                writer = new StreamWriter(CONTENTPATH + "waves.data", false);

                writer.WriteLine($"{waves[0].GetLength(0)}x{waves[0].GetLength(1)}");
                for (int i = 0; i < waves.Count; i++)
                {
                    writer.WriteLine(i);
                    for (int y = 0; y < waves[0].GetLength(1); y++)
                    {
                        for (int x = 0; x < waves[0].GetLength(0); x++)
                        {
                            if (waves[i][x, y].Controls[0].Text != "")
                            {
                                writer.Write(waves[i][x, y].Controls[0].Text + "|");
                            } else
                            {
                                writer.Write(".|");
                            }
                        }
                        writer.WriteLine();
                    }
                    if (i == waves.Count - 1)
                    {
                        writer.WriteLine("|EOF|");
                    } else
                    {
                        writer.WriteLine();
                    }
                }
            } catch (Exception)
            {

                throw;
            }
            if (writer != null)
            {
                writer.Close();
            }
        }

        private void Editor_Load(object sender, EventArgs e)
        {

        }
    }
}
