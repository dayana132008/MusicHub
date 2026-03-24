using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormMusicHub
{

    public partial class Form1 : Form
    {
        private MusicHub.Business.AlbumBusiness albumBusiness = new MusicHub.Business.AlbumBusiness();
        private ArtistBusiness artistBusiness = new ArtistBusiness();
        private PlaylistBusiness playlistBusiness = new PlaylistBusiness();
       
        public Form1()
        {
            InitializeComponent();
        }

        public void hideObject()
        {
            label2.Hide();
            label3.Hide();
            label4.Hide();
            label5.Hide();
            label6.Hide();
            label7.Hide();
            label8.Hide();
            label9.Hide();
            label10.Hide();
            label11.Hide();
            label12.Hide();
            label13.Hide();

            textBox1.Hide();
            textBox2.Hide();
            textBox3.Hide();
            textBox4.Hide();
            textBox5.Hide();
            textBox6.Hide();
            textBox7.Hide();
            textBox8.Hide();
            textBox9.Hide();
            textBox10.Hide();
            textBox11.Hide();
            textBox12.Hide();

            button1.Hide();
            button2.Hide();
            button3.Hide();

            dataGridView1.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            hideObject();
        }


    }
}
