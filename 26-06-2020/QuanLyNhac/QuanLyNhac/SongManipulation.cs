using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhac
{
    public partial class SongManipulation : Form
    {
        private SongsList songsList;
        public SongManipulation()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void allSongsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (songsList == null) {
                songsList = new SongsList();
                songsList.MdiParent = this;
            }
            songsList.Show();
        }
    }
}
