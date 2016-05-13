using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ПроектВП
{
    public partial class Form1 : Form
    {
        public bool IsUserLogged { get; set; }
        public string FishName { get; set; }
        public bool PlayMusic { get; set; }
        public User NewUser { get; set; }
        SoundPlayer Music = new SoundPlayer("Sounds/background.wav");
        public Form1()
        {
            InitializeComponent();
            pbZvuk.BackColor = Color.Transparent;
            pbZvuk_Click(null, null);


        }
        private void MusicPlay()
        {
            Music.PlayLooping();
            PlayMusic = true;
            pbZvuk.ImageLocation = "Pictures//sound_on.png";
           


        }
        private void MusicStop()
        {
            Music.Stop();
            PlayMusic = false;
            pbZvuk.ImageLocation = "Pictures//sound_off.png";
        }
        private void btnNajava_MouseEnter(object sender, EventArgs e)
        {
            MouseEnter(btnNajava);
        }
        private void MouseEnter(Button b)
        {
            b.ForeColor = Color.Red;
        }
        private void MouseLeave(Button b)
        {
            b.ForeColor = Color.Black;
        }
        private void btnNajava_MouseLeave(object sender, EventArgs e)
        {
            MouseLeave(btnNajava);
        }

        private void btnInstrukcii_MouseEnter(object sender, EventArgs e)
        {
            MouseEnter(btnInstrukcii);
        }

        private void btnInstrukcii_MouseLeave(object sender, EventArgs e)
        {
            MouseLeave(btnInstrukcii);
        }

        private void btnIgraj_MouseLeave(object sender, EventArgs e)
        {
            MouseLeave(btnIgraj);
        }

        private void btnIgraj_MouseEnter(object sender, EventArgs e)
        {
            MouseEnter(btnIgraj);
           
        }

        private void btnIgraj_Click(object sender, EventArgs e)
        {
            if(!IsUserLogged)
            {
                ToolTip tt1 = new ToolTip();
                tt1.SetToolTip(btnIgraj, "Прво мора да се најавите за да играте");
                return;
            }
            MessageBox.Show("Со среќа рибо " + FishName + " ^_^","Почеток на игра",MessageBoxButtons.OK,MessageBoxIcon.Information);
            GameForm Game = new GameForm(NewUser);
            Game.ShowDialog();

        }

        private void btnNajava_Click(object sender, EventArgs e)
        {
            LoginForm Login = new LoginForm();
            if(Login.ShowDialog()==DialogResult.OK)
            {
                NewUser=new User(Login.Name);
               
                IsUserLogged = true;
                
                
            }
        }

        private void btnInstrukcii_Click(object sender, EventArgs e)
        {
            InstructionForm Instructions = new InstructionForm();
            Instructions.ShowDialog();
        }

        private void pbZvuk_Click(object sender, EventArgs e)
        {
            if (PlayMusic)
                MusicStop();
            else
                MusicPlay();
            pbZvuk.SizeMode = PictureBoxSizeMode.StretchImage;
        }
    }
}
