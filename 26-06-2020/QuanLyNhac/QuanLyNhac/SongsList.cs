using QuanLyNhac.models;
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
    public partial class SongsList : Form
    {
        private List<Genre> genres;
        private Song selectedSong;
        private DetailSong detailSong;
        List<Song> foundSongs;
        public SongsList()
        {
            InitializeComponent();
            this.reloadData();
        }
        private void reloadData()
        {
            this.treeViewGenre.Nodes.Clear();
            this.treeViewGenre.Nodes.Add("Songs");
            genres = Database.SharedInstance().getAllGenres();
            this.treeViewGenre.Nodes[0].Nodes.Clear();
            genres.ForEach(genre =>
            {
                this.treeViewGenre.Nodes[0].Nodes.Add(genre.GenreName);
            });            
            this.treeViewGenre.NodeMouseClick += TreeViewGenre_NodeMouseClick;
            this.listViewSongs.Columns.Clear();

        }

        private void TreeViewGenre_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            string selectedGenreName = e.Node.Text;
            if (e.Node.Level == 0) {
                //root node 
                return;
            }
            Genre selectedGenre = Database.SharedInstance()
                        .getGenreFromName(selectedGenreName);
            int genreID = selectedGenre.ID;
            this.foundSongs = Database.SharedInstance().getSongsByGenreId(genreID);
            this.listViewSongs.Columns.Clear();
            this.listViewSongs.Columns.Add("ID");
            this.listViewSongs.Columns.Add("Title");
            this.listViewSongs.Columns.Add("ArtistName");
            this.listViewSongs.Items.Clear();
            this.listViewSongs.FullRowSelect = true;
            this.foundSongs.ForEach(eachSong => {
                ListViewItem item1 = new ListViewItem(eachSong.ID.ToString());
                item1.SubItems.Add(new ListViewItem.ListViewSubItem(item1, eachSong.Title));
                item1.SubItems.Add(new ListViewItem.ListViewSubItem(item1, eachSong.ArtistName));
                this.listViewSongs.Items.Add(item1);
            });
            this.listViewSongs.MouseClick += ListViewSongs_MouseClick;
            
        }

        private void ListViewSongs_MouseClick(object sender, MouseEventArgs e)
        {
            int selectedSongId = Convert.ToInt32(this.listViewSongs.SelectedItems[0].SubItems[0].Text);
            this.selectedSong = this.foundSongs.Where(song => song.ID == selectedSongId).FirstOrDefault();
            
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedSong == null)
            {
                return;
            }
            if (this.detailSong == null                 
                || this.detailSong.IsDisposed == true)
            {
                this.detailSong = new DetailSong();
            }
            this.detailSong.SelectedSong = selectedSong;
            this.detailSong.Disposed += DetailSong_Disposed;
            this.detailSong.Show();
        }

        private void DetailSong_Disposed(object sender, EventArgs e)
        {
            this.reloadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedSong == null)
            {
                return;
            }
            var messageBox = MessageBox.Show(
                "Are you sure to delete this ?", "Delete song", 
                MessageBoxButtons.YesNo, 
                MessageBoxIcon.Question, 
                MessageBoxDefaultButton.Button1);
            if (messageBox == System.Windows.Forms.DialogResult.Yes) {
                Database.SharedInstance().deleteSong(this.selectedSong);
                this.reloadData();
            }

        }
    }
}
