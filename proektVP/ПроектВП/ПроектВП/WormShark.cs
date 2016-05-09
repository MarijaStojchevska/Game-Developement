using System;
using System.Drawing;
using System.Windows.Forms;

namespace ПроектВП
{
    public class WormShark
    {
        public Bitmap Slika { get; set; }
        public Point Location { get; set; }
        public bool RemoveAnimal { get; set; }
       public Color Color { get; set; }
        public bool Poen { get; set; }
        public int Type { get; set; } //napravi go so abstract class ili enum
        public Size Size { get; set; }
        public WormShark(Point p)
        {
            
            Location = p;
        }
        public void addImage(double probShark,double probGreen)
        {
            Random r = new Random();
            double type = r.NextDouble();
            if (type <= probShark)
            {
                  Slika = ПроектВП.Properties.Resources.shark;
            //    Color = Color.Black;
                  Size = new Size(100, 120);
                Type = 0; //shark
            }
           else  if (type >= probShark && type <= probGreen)
            {

                 Slika = ПроектВП.Properties.Resources.green;
               // Slika = new Bitmap("Pictures/green.gif");
                Color = Color.Green;
                 Size = new Size(60, 60);
                Type = 1;
            }
            else
            {
                  Slika = ПроектВП.Properties.Resources.red;
                Color = Color.Red;
                Size = new Size(60, 60);
                Type = 2;
            }

        }

        internal void IsItHit(Point p)
        {
            if (Math.Abs(p.X - Location.X) < 40 && Math.Abs(p.Y - Location.Y) < 40)//treba podobar nachin
            {
                Poen = true;
                RemoveAnimal = true;
            }
            
        }

        public void Draw(Graphics g)
        {
           
            Rectangle rect = new Rectangle(Location, Size);
            /*PictureBox pb = new PictureBox();
            pb.Image = Slika;
            pb.Size = Size;
            pb.Location = Location;
           */g.DrawImage(Slika,rect);
          
         //   g.FillEllipse(new SolidBrush(Color), Location.X, Location.Y, 30, 30);
            if (Location.X <= 0)
                RemoveAnimal = true;
        }
        public void Move()
        {
            Location = new Point(Location.X - 90, Location.Y);
        }
    }
}
