using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExternalTool
{
    public partial class Editor : Form
    {
        public Editor()
        {
            InitializeComponent();
            //LoadContent();
        }


        private void LoadContent(string filePath)
        {

        }

        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
