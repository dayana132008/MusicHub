using MusicHub.Business;
using MusicHub.Data.Models;
using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace WinForm_MusicHub
{

    public partial class Form1 : Form
    {
        private AlbumBusiness albumBusiness = new AlbumBusiness();
        private ArtistBusiness artistBusiness = new ArtistBusiness();
        private PlaylistBusiness playlistBusiness = new PlaylistBusiness();
        private SongBusiness songBusiness = new SongBusiness();
        private UserBusiness userBusiness = new UserBusiness();

        private int editId;
        public int flag;
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

        private void UpdateGridAlbum()
        {

            dataGridView1.DataSource = albumBusiness.GetAll();
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void UpdateGridArtist()
        {
            dataGridView1.DataSource = artistBusiness.GetAll();
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private void UpdateGridPlaylist()
        {

            dataGridView1.DataSource = playlistBusiness.GetAll();
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private void UpdateGridSong()
        {

            dataGridView1.DataSource = songBusiness.GetAll();

            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private void UpdateGridUser()
        {
            dataGridView1.DataSource = userBusiness.GetAll();
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private void ClearTextBoxes()
        {
            textBox1.Text = "";
            textBox2.Text = "0";
            textBox3.Text = "0";
            textBox4.Text = "0";
            textBox5.Text = "0";
        }

        public void albumShow()
        {
            UpdateGridAlbum();
            ClearTextBoxes();
        }
        public void artistShow()
        {
            UpdateGridArtist();
            ClearTextBoxes();
        }
        public void playlistShow()
        {
            UpdateGridPlaylist();
            ClearTextBoxes();
        }
        public void songShow()
        {
            UpdateGridSong();
            ClearTextBoxes();
        }
        public void userShow()
        {
            UpdateGridUser();
            ClearTextBoxes();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }
        private void albumB_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            label2.Text = "ID";
            label2.Visible = true;
            label3.Text = "Title";
            label3.Visible = true;
            label4.Text = "ReleaseYear";
            label4.Visible = true;
            label5.Text = "ArtistId";
            label5.Visible = true;
            label6.Hide();
            label7.Hide(); 
            label8.Hide();
            label9.Hide(); 
            label10.Hide();
            label11.Hide();
            label12.Hide();

            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Hide();
            textBox6.Hide();
            textBox7.Hide();
            textBox8.Hide();
            textBox9.Hide();
            textBox10.Hide();
            textBox11.Hide();
            textBox12.Hide();
            albumB.Visible = true;
            button1.Visible = true;//insert
            button2.Visible = true;//save
            button3.Visible = true;//delete
            flag = 1;
            comboBox1.Items.Clear();
            comboBox1.Items.Add("List all entries");
            comboBox1.Items.Add("Add new entry");
            comboBox1.Items.Add("Update entry");
            comboBox1.Items.Add("Fetch entry by ID");
            comboBox1.Items.Add("Delete entry by ID");
            comboBox1.Items.Add("Exit");
        }

        private void artistB_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            label2.Text = "ID";
            label2.Visible = true;
            label3.Text = "Name";
            label3.Visible = true;
            label4.Text = "Country";
            label4.Visible = true;
            label5.Text = "Genre";
            label5.Visible = true;
            label6.Hide();
            label7.Hide();
            label8.Hide();
            label9.Hide();
            label10.Hide();
            label11.Hide();
            label12.Hide();

            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Hide();
            textBox6.Hide();
            textBox7.Hide();
            textBox8.Hide();
            textBox9.Hide();
            textBox10.Hide();
            textBox11.Hide();
            textBox12.Hide();
            artistB.Visible = true;
            button1.Visible = true;//insert
            button2.Visible = true;//save
            button3.Visible = true;//delete
            flag = 2;
            comboBox1.Items.Clear();
            comboBox1.Items.Add("List all entries");
            comboBox1.Items.Add("Add new entry");
            comboBox1.Items.Add("Update entry");
            comboBox1.Items.Add("Fetch entry by ID");
            comboBox1.Items.Add("Delete entry by ID");
            comboBox1.Items.Add("Exit");
        }

        private void playlistB_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            label2.Text = "ID";
            label2.Visible = true;
            label3.Text = "name";
            label3.Visible = true;
            label4.Text = "CreatedDate";
            label4.Visible = true;
            label5.Hide();
            label6.Hide();
            label7.Hide();
            label8.Hide();
            label9.Hide();
            label10.Hide();
            label11.Hide();
            label12.Hide();

            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Hide();
            textBox5.Hide();
            textBox6.Hide();
            textBox7.Hide();
            textBox8.Hide();
            textBox9.Hide();
            textBox10.Hide();
            textBox11.Hide();
            textBox12.Hide();
            playlistB.Visible = true;
            button1.Visible = true;//insert
            button2.Visible = true;//save
            button3.Visible = true;//delete
            flag = 3;
            comboBox1.Items.Clear();
            comboBox1.Items.Add("List all entries");
            comboBox1.Items.Add("Add new entry");
            comboBox1.Items.Add("Update entry");
            comboBox1.Items.Add("Fetch entry by ID");
            comboBox1.Items.Add("Delete entry by ID");
            comboBox1.Items.Add("Exit");
        }

        private void songB_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            label2.Text = "ID";
            label2.Visible = true;
            label3.Text = "Title";
            label3.Visible = true;
            label4.Text = "Duration";
            label4.Visible = true;
            label5.Text = "AlbumId";
            label5.Visible = true;
            label6.Hide();
            label7.Hide();
            label8.Hide();
            label9.Hide();
            label10.Hide();
            label11.Hide();
            label12.Hide();

            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Hide();
            textBox6.Hide();
            textBox7.Hide();
            textBox8.Hide();
            textBox9.Hide();
            textBox10.Hide();
            textBox11.Hide();
            textBox12.Hide();
            songB.Visible = true;
            button1.Visible = true;//insert
            button2.Visible = true;//save
            button3.Visible = true;//delete
            flag = 4;
            comboBox1.Items.Clear();
            comboBox1.Items.Add("List all entries");
            comboBox1.Items.Add("Add new entry");
            comboBox1.Items.Add("Update entry");
            comboBox1.Items.Add("Fetch entry by ID");
            comboBox1.Items.Add("Delete entry by ID");
            comboBox1.Items.Add("Exit");
        }

        private void userB_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            label2.Text = "ID";
            label2.Visible = true;
            label3.Text = "Username";
            label3.Visible = true;
            label4.Text = "Email";
            label4.Visible = true;
            label5.Hide();
            label6.Hide();
            label7.Hide();
            label8.Hide();
            label9.Hide();
            label10.Hide();
            label11.Hide();
            label12.Hide();

            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Hide();
            textBox5.Hide();
            textBox6.Hide();
            textBox7.Hide();
            textBox8.Hide();
            textBox9.Hide();
            textBox10.Hide();
            textBox11.Hide();
            textBox12.Hide();
            playlistB.Visible = true;
            button1.Visible = true;//insert
            button2.Visible = true;//save
            button3.Visible = true;//delete
            flag = 5;
            comboBox1.Items.Clear();
            comboBox1.Items.Add("List all entries");
            comboBox1.Items.Add("Add new entry");
            comboBox1.Items.Add("Update entry");
            comboBox1.Items.Add("Fetch entry by ID");
            comboBox1.Items.Add("Delete entry by ID");
            comboBox1.Items.Add("Exit");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null) return;

            string choice = comboBox1.SelectedItem.ToString();

            if (choice == "List all entries")
            {
                if (flag == 1) albumShow();
                if (flag == 2) artistShow();
                if (flag == 3) playlistShow();
                if (flag == 4) songShow();
                if (flag == 5) userShow();
            }
            if (choice == "Fetch entry by ID")
            {
                int id = int.Parse(textBox1.Text);

                if (flag == 1) // Album
                {
                    var album = albumBusiness.Get(id);
                    dataGridView1.DataSource = new List<Album> { album };
                }
                if (flag == 2) // Artist
                {
                    var artist = artistBusiness.Get(id);
                    dataGridView1.DataSource = new List<Artist> { artist };
                }
                if (flag == 3) // Playlist
                {
                    var playlist = playlistBusiness.Get(id);
                    dataGridView1.DataSource = new List<Playlist> { playlist };
                }
                if (flag == 4) // Song
                {
                    var song = songBusiness.Get(id);
                    dataGridView1.DataSource = new List<Song> { song };
                }
                if (flag == 5) // User
                {
                    var user = userBusiness.Get(id);
                    dataGridView1.DataSource = new List<User> { user };
                }
            }
            if (choice == "Exit")
            {
                this.Close();
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void insert_Click_1(object sender, EventArgs e)//insert
        {
            if (flag == 1)
            {
                int id = int.Parse(textBox1.Text);
                string title = textBox2.Text;
                int releaseYear = int.Parse(textBox3.Text);
                int artistId = int.Parse(textBox4.Text);

                Album album = new Album();
                album.AlbumId = id;
                album.Title = title;
                album.ReleaseYear = releaseYear;
                album.ArtistId = artistId;

                albumBusiness.Add(album);
                UpdateGridAlbum();
                //   ClearTextBoxes();
            }
            if (flag == 2)
            {
                int id = int.Parse(textBox1.Text);
                string name = textBox2.Text;
                string country = textBox3.Text;
                string genre = textBox4.Text;

                Artist artist = new Artist();
                artist.ArtistId = id;
                artist.Name = name;
                artist.Country = country;
                artist.Genre = genre;

                artistBusiness.Add(artist);
                UpdateGridArtist();
                //   ClearTextBoxes();
            }
            if (flag == 3)
            {
                int id = int.Parse(textBox1.Text);
                string name = textBox2.Text;
                string input = textBox3.Text; 

                Playlist playlist = new Playlist();
                playlist.PlaylistId = id;
                playlist.Name = name;
                
                string[] parts = input.Split('.');

                int day = int.Parse(parts[0]);
                int month = int.Parse(parts[1]);
                int year = int.Parse(parts[2]);

                DateOnly createdDate = new DateOnly(year, month, day);

                playlist.CreatedDate = createdDate;

                playlistBusiness.Add(playlist);
                UpdateGridPlaylist();
                //   ClearTextBoxes();
            }
            if (flag == 4)
            {
                int id = int.Parse(textBox1.Text);
                string title = textBox2.Text;
                int duration = int.Parse(textBox3.Text);
                int albumId = int.Parse(textBox4.Text);


                Song song = new Song();
                song.SongId = id;
                song.Title = title;
                song.Duration = duration;
                song.AlbumId = albumId;

                songBusiness.Add(song);
                UpdateGridSong();
                //   ClearTextBoxes();
            }
            if (flag == 5)
            {
                int id = int.Parse(textBox1.Text);
                string username = textBox2.Text;
                string email = textBox3.Text;

                User user = new User();
                user.UserId = id;
                user.Username = username;
                user.Email = email;

                userBusiness.Add(user);
                UpdateGridUser();
                //   ClearTextBoxes();
            }
            
        }

        private void save_Click_1(object sender, EventArgs e)//save
        {
            if (flag == 1)
            {
                Album album = new Album();
                album.AlbumId = int.Parse(textBox1.Text);
                album.Title = textBox2.Text;
                album.ReleaseYear = int.Parse(textBox3.Text);
                album.ArtistId = int.Parse(textBox4.Text);

                albumBusiness.Update(album);
                UpdateGridAlbum();
            }
            if (flag == 2) // Artist
            {
                Artist artist = new Artist();
                artist.ArtistId = int.Parse(textBox1.Text);
                artist.Name = textBox2.Text;
                artist.Country = textBox3.Text;
                artist.Genre = textBox4.Text;

                artistBusiness.Update(artist);
                UpdateGridArtist();
            }

            if (flag == 3) // Playlist
            {
                Playlist playlist = new Playlist();
                playlist.PlaylistId = int.Parse(textBox1.Text);
                playlist.Name = textBox2.Text;
                string input = textBox3.Text;
                string[] parts = input.Split('.');

                int day = int.Parse(parts[0]);
                int month = int.Parse(parts[1]);
                int year = int.Parse(parts[2]);

                DateOnly createdDate = new DateOnly(year, month, day);

                playlist.CreatedDate = createdDate;

                playlistBusiness.Update(playlist);
                UpdateGridPlaylist();
            }

            if (flag == 4) // Song
            {
                Song song = new Song();
                song.SongId = int.Parse(textBox1.Text);
                song.Title = textBox2.Text;
                song.Duration = int.Parse(textBox3.Text);
                song.AlbumId = int.Parse(textBox4.Text);

                songBusiness.Update(song);
                UpdateGridSong();
            }

            if (flag == 5) // User
            {
                User user = new User();
                user.UserId = int.Parse(textBox1.Text);
                user.Username = textBox2.Text;
                user.Email = textBox3.Text;

                userBusiness.Update(user);
                UpdateGridUser(); 
            }
        }

        private void delete_Click_2(object sender, EventArgs e)//delete
        {
            if (flag == 1) // Album
            {
                int id = int.Parse(textBox1.Text);
                albumBusiness.Delete(id);
                UpdateGridAlbum();
            }

            if (flag == 2) // Artist
            {
                int id = int.Parse(textBox1.Text);
                artistBusiness.Delete(id);
                UpdateGridArtist();
            }

            if (flag == 3) // Playlist
            {
                int id = int.Parse(textBox1.Text);
                playlistBusiness.Delete(id);
                UpdateGridPlaylist();
            }

            if (flag == 4) // Song
            {
                int id = int.Parse(textBox1.Text);
                songBusiness.Delete(id);
                UpdateGridSong();
            }

            if (flag == 5) // User
            {
                int id = int.Parse(textBox1.Text);
                userBusiness.Delete(id);
                UpdateGridUser();
            }
        }

    }
    }
