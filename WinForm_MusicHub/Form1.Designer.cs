namespace WinForm_MusicHub
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            comboBox1 = new ComboBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            albumB = new Button();
            artistB = new Button();
            playlistB = new Button();
            songB = new Button();
            userB = new Button();
            button9 = new Button();
            dataGridView1 = new DataGridView();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            textBox6 = new TextBox();
            textBox7 = new TextBox();
            textBox8 = new TextBox();
            textBox9 = new TextBox();
            textBox10 = new TextBox();
            textBox11 = new TextBox();
            textBox12 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Modern No. 20", 54.74999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(26, 10);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(342, 76);
            label1.TabIndex = 0;
            label1.Text = "MusicHub";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(41, 130);
            comboBox1.Margin = new Padding(4, 3, 4, 3);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(140, 23);
            comboBox1.TabIndex = 1;
            comboBox1.Click += comboBox1_SelectedIndexChanged;
            // 
            // button1
            // 
            button1.Location = new Point(41, 224);
            button1.Margin = new Padding(4, 3, 4, 3);
            button1.Name = "button1";
            button1.Size = new Size(88, 27);
            button1.TabIndex = 2;
            button1.Text = "Insert";
            button1.UseVisualStyleBackColor = true;
            button1.Click += insert_Click_1;
            // 
            // button2
            // 
            button2.Location = new Point(41, 285);
            button2.Margin = new Padding(4, 3, 4, 3);
            button2.Name = "button2";
            button2.Size = new Size(88, 27);
            button2.TabIndex = 3;
            button2.Text = "Save";
            button2.UseVisualStyleBackColor = true;
            button2.Click += save_Click_1;
            // 
            // button3
            // 
            button3.Location = new Point(41, 342);
            button3.Margin = new Padding(4, 3, 4, 3);
            button3.Name = "button3";
            button3.Size = new Size(88, 27);
            button3.TabIndex = 4;
            button3.Text = "Delete";
            button3.UseVisualStyleBackColor = true;
            button3.Click += delete_Click_2;
            // 
            // albumB
            // 
            albumB.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            albumB.Location = new Point(248, 128);
            albumB.Margin = new Padding(4, 3, 4, 3);
            albumB.Name = "albumB";
            albumB.Size = new Size(88, 27);
            albumB.TabIndex = 5;
            albumB.Text = "Album";
            albumB.UseVisualStyleBackColor = true;
            albumB.Click += albumB_Click;
            // 
            // artistB
            // 
            artistB.Location = new Point(398, 128);
            artistB.Margin = new Padding(4, 3, 4, 3);
            artistB.Name = "artistB";
            artistB.Size = new Size(88, 27);
            artistB.TabIndex = 6;
            artistB.Text = "Artist";
            artistB.UseVisualStyleBackColor = true;
            artistB.Click += artistB_Click;
            // 
            // playlistB
            // 
            playlistB.Location = new Point(556, 128);
            playlistB.Margin = new Padding(4, 3, 4, 3);
            playlistB.Name = "playlistB";
            playlistB.Size = new Size(88, 27);
            playlistB.TabIndex = 7;
            playlistB.Text = "Playlist";
            playlistB.UseVisualStyleBackColor = true;
            playlistB.Click += playlistB_Click;
            // 
            // songB
            // 
            songB.Location = new Point(323, 182);
            songB.Margin = new Padding(4, 3, 4, 3);
            songB.Name = "songB";
            songB.Size = new Size(88, 27);
            songB.TabIndex = 8;
            songB.Text = "Song";
            songB.UseVisualStyleBackColor = true;
            songB.Click += songB_Click;
            // 
            // userB
            // 
            userB.Location = new Point(481, 182);
            userB.Margin = new Padding(4, 3, 4, 3);
            userB.Name = "userB";
            userB.Size = new Size(88, 27);
            userB.TabIndex = 9;
            userB.Text = "User";
            userB.UseVisualStyleBackColor = true;
            userB.Click += userB_Click;
            // 
            // button9
            // 
            button9.Location = new Point(41, 458);
            button9.Margin = new Padding(4, 3, 4, 3);
            button9.Name = "button9";
            button9.Size = new Size(88, 27);
            button9.TabIndex = 10;
            button9.Text = "Exit";
            button9.UseVisualStyleBackColor = true;
            button9.Click += button9_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(248, 224);
            dataGridView1.Margin = new Padding(4, 3, 4, 3);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(396, 261);
            dataGridView1.TabIndex = 11;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(707, 134);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(17, 15);
            label2.TabIndex = 12;
            label2.Text = "Id";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(707, 164);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(29, 15);
            label3.TabIndex = 13;
            label3.Text = "Title";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(707, 194);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(68, 15);
            label4.TabIndex = 14;
            label4.Text = "ReleaseYear";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(707, 224);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(45, 15);
            label5.TabIndex = 15;
            label5.Text = "ArtistId";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(707, 254);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(39, 15);
            label6.TabIndex = 16;
            label6.Text = "Name";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(707, 285);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(50, 15);
            label7.TabIndex = 17;
            label7.Text = "Country";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(707, 315);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(38, 15);
            label8.TabIndex = 18;
            label8.Text = "Genre";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(707, 345);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(72, 15);
            label9.TabIndex = 19;
            label9.Text = "CreatedDate";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(707, 375);
            label10.Margin = new Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new Size(53, 15);
            label10.TabIndex = 20;
            label10.Text = "Duration";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(707, 405);
            label11.Margin = new Padding(4, 0, 4, 0);
            label11.Name = "label11";
            label11.Size = new Size(53, 15);
            label11.TabIndex = 21;
            label11.Text = "AlbumId";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(707, 435);
            label12.Margin = new Padding(4, 0, 4, 0);
            label12.Name = "label12";
            label12.Size = new Size(60, 15);
            label12.TabIndex = 22;
            label12.Text = "Username";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(707, 465);
            label13.Margin = new Padding(4, 0, 4, 0);
            label13.Name = "label13";
            label13.Size = new Size(36, 15);
            label13.TabIndex = 23;
            label13.Text = "Email";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(818, 130);
            textBox1.Margin = new Padding(4, 3, 4, 3);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(116, 23);
            textBox1.TabIndex = 24;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(818, 160);
            textBox2.Margin = new Padding(4, 3, 4, 3);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(116, 23);
            textBox2.TabIndex = 25;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(818, 190);
            textBox3.Margin = new Padding(4, 3, 4, 3);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(116, 23);
            textBox3.TabIndex = 26;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(818, 220);
            textBox4.Margin = new Padding(4, 3, 4, 3);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(116, 23);
            textBox4.TabIndex = 27;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(818, 250);
            textBox5.Margin = new Padding(4, 3, 4, 3);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(116, 23);
            textBox5.TabIndex = 28;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(818, 282);
            textBox6.Margin = new Padding(4, 3, 4, 3);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(116, 23);
            textBox6.TabIndex = 29;
            // 
            // textBox7
            // 
            textBox7.Location = new Point(818, 312);
            textBox7.Margin = new Padding(4, 3, 4, 3);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(116, 23);
            textBox7.TabIndex = 30;
            // 
            // textBox8
            // 
            textBox8.Location = new Point(818, 342);
            textBox8.Margin = new Padding(4, 3, 4, 3);
            textBox8.Name = "textBox8";
            textBox8.Size = new Size(116, 23);
            textBox8.TabIndex = 31;
            // 
            // textBox9
            // 
            textBox9.Location = new Point(818, 372);
            textBox9.Margin = new Padding(4, 3, 4, 3);
            textBox9.Name = "textBox9";
            textBox9.Size = new Size(116, 23);
            textBox9.TabIndex = 32;
            // 
            // textBox10
            // 
            textBox10.Location = new Point(818, 402);
            textBox10.Margin = new Padding(4, 3, 4, 3);
            textBox10.Name = "textBox10";
            textBox10.Size = new Size(116, 23);
            textBox10.TabIndex = 33;
            // 
            // textBox11
            // 
            textBox11.Location = new Point(818, 432);
            textBox11.Margin = new Padding(4, 3, 4, 3);
            textBox11.Name = "textBox11";
            textBox11.Size = new Size(116, 23);
            textBox11.TabIndex = 34;
            // 
            // textBox12
            // 
            textBox12.Location = new Point(818, 462);
            textBox12.Margin = new Padding(4, 3, 4, 3);
            textBox12.Name = "textBox12";
            textBox12.Size = new Size(116, 23);
            textBox12.TabIndex = 35;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(976, 519);
            Controls.Add(textBox12);
            Controls.Add(textBox11);
            Controls.Add(textBox10);
            Controls.Add(textBox9);
            Controls.Add(textBox8);
            Controls.Add(textBox7);
            Controls.Add(textBox6);
            Controls.Add(textBox5);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label13);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(dataGridView1);
            Controls.Add(button9);
            Controls.Add(userB);
            Controls.Add(songB);
            Controls.Add(playlistB);
            Controls.Add(artistB);
            Controls.Add(albumB);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(comboBox1);
            Controls.Add(label1);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button albumB;
        private System.Windows.Forms.Button artistB;
        private System.Windows.Forms.Button playlistB;
        private System.Windows.Forms.Button songB;
        private System.Windows.Forms.Button userB;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.TextBox textBox12;
    }
}

