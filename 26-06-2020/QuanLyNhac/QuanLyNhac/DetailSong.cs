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
    public partial class DetailSong : Form
    {
        private Song selectedSong;
        public Song SelectedSong {
            get { return this.selectedSong; }
            set { 
                this.selectedSong = value;
                //update UI !
                this.txtTitle.Text = this.selectedSong.Title;
                this.txtArtistName.Text = this.selectedSong.ArtistName;
                var allGenres = Database.SharedInstance().getAllGenres();
                this.comboBoxGenre.DataSource = allGenres;
                this.comboBoxGenre.DisplayMember = "GenreName";
                var selectedGenre = allGenres
                    .Where(genre => genre.ID == this.selectedSong.GenreID).FirstOrDefault();
                this.comboBoxGenre.SelectedItem = selectedGenre;
            }
        }
        public DetailSong()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //From UI => OBject => DB
            this.selectedSong.Title = this.txtTitle.Text;
            this.selectedSong.ArtistName = this.txtArtistName.Text;
            this.selectedSong.GenreID = (this.comboBoxGenre.SelectedItem as Genre).ID;

            Database.SharedInstance().updateSong(this.selectedSong);
            this.Close();
        }
    }
}
