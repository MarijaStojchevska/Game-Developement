using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ПроектВП
{
    public partial class GameForm : Form
    {
        bool Left { get; set; }
        bool Right { get; set; }
        bool Up { get; set; }
        bool Down { get; set; }
        Graphics g { get; set; }
        WormSharkDoc Animals;
        User CurrentUser;
        public GameForm(User Fish)
        {
            InitializeComponent();
            CurrentUser = Fish;
            DoubleBuffered = true;
            this.Bounds = Screen.PrimaryScreen.Bounds;
            pInfo.Bounds = new Rectangle(0,Screen.PrimaryScreen.Bounds.Height-100,Screen.PrimaryScreen.Bounds.Width, 100);
            g = this.CreateGraphics();   
            pbRiba.SizeMode = PictureBoxSizeMode.StretchImage;
            pbRiba.BackColor = Color.Transparent;
            lblPoeni.BackColor = Color.Transparent;
            Animals = new WormSharkDoc();
            label1.BackColor = Color.Transparent;
            tRibaDvizhenje.Start();
            tPridvizhi.Start();

        }

        private void GameForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Application.Exit();
            if(e.KeyCode==Keys.Left || e.KeyCode==Keys.A)
            {
                Left = true;
            }
            if(e.KeyCode==Keys.Right || e.KeyCode==Keys.D)
            {
                Right = true;
            }
            if(e.KeyCode==Keys.Up || e.KeyCode==Keys.W)
            {
                Up = true;
            }
            if(e.KeyCode==Keys.Down || e.KeyCode==Keys.S)
            {
                Down = true;
            }
        }

        private void GameForm_KeyUp(object sender, KeyEventArgs e)
        {
            Left = false;Right = false;Up = false;Down = false;
        }

        private void tRibaDvizhenje_Tick(object sender, EventArgs e)
        {
            
            if(Up && Left)
            {
                if (pbRiba.Location.Y > 15 && (pbRiba.Location.X > 15))
 pbRiba.Location = new Point(pbRiba.Location.X + (int)(15 * Math.Cos(135 * (Math.PI / 180))), pbRiba.Location.Y - (int)(15 * Math.Sin(135 * (Math.PI / 180))));


            }
            else if(Up && Right)
            {
                if (pbRiba.Location.Y > 15 && (pbRiba.Location.X < Screen.PrimaryScreen.Bounds.Width - 125))
 pbRiba.Location = new Point(pbRiba.Location.X + (int)(15 * Math.Cos(45 * (Math.PI / 180))), pbRiba.Location.Y - (int)(15 * Math.Sin(45 * (Math.PI / 180))));

            }
            else if(Down && Right)
            {
                if((pbRiba.Location.Y < pInfo.Location.Y - 115) && (pbRiba.Location.X < Screen.PrimaryScreen.Bounds.Width - 125))
                pbRiba.Location = new Point(pbRiba.Location.X + (int)(15 * Math.Cos(315 * (Math.PI / 180))), pbRiba.Location.Y - (int)(15 * Math.Sin(315 * (Math.PI / 180))));

            }
            else if(Down && Left)
            {
                if((pbRiba.Location.Y < pInfo.Location.Y - 115) && (pbRiba.Location.X > 15))
pbRiba.Location = new Point(pbRiba.Location.X - (int)(15 * Math.Cos(315 * (Math.PI / 180))), pbRiba.Location.Y - (int)(15 * Math.Sin(315 * (Math.PI / 180))));

            }

            else if(Up)
            {
                if(pbRiba.Location.Y>15)
                pbRiba.Location = new Point(pbRiba.Location.X,pbRiba.Location.Y-15);
            }
           else if (Down)
            {
                if(pbRiba.Location.Y<pInfo.Location.Y-115)
                pbRiba.Location = new Point(pbRiba.Location.X, pbRiba.Location.Y+15);
            }
            else if (Left)
            {
                if(pbRiba.Location.X>15)
                pbRiba.Location = new Point(pbRiba.Location.X-15, pbRiba.Location.Y);
            }
            else if (Right)
            {
                if(pbRiba.Location.X<Screen.PrimaryScreen.Bounds.Width-125)
                pbRiba.Location = new Point(pbRiba.Location.X+15 , pbRiba.Location.Y);
            }
            Animals.Hit(pbRiba.Location);
        }

        private void tPridvizhi_Tick(object sender, EventArgs e)
        {
            
            Animals.AddAnimal(new Point(Width, Height));
            Animals.Move();
            
            if(Animals.IsItOver)
            {
                tPridvizhi.Stop();
                tRibaDvizhenje.Stop();
                MessageBox.Show("Total Points: " + Animals.Poeni, "Game Over");
                Application.Exit();
            }
            tPridvizhi.Interval = Math.Abs(tPridvizhi.Interval - 3);
            lblPoeni.Text = Animals.Poeni.ToString();
            Invalidate();
            //  GameForm_Paint(null, null);
           
        }

        private void GameForm_Paint(object sender, PaintEventArgs e)
        {
           Animals.Draw(g);
        }
        
    }
}
