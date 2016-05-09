using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ПроектВП
{
    public class WormSharkDoc
    {
        List<WormShark> WormsSharks { get; set; }
        private double ProbShark { get; set; }
        private double ProbGreen { get; set; }
        public int Poeni { get; set; }
        public bool IsItOver { get; set; }
        public WormSharkDoc()
        {
            WormsSharks = new List<WormShark>();
            ProbShark = 0.05;
            ProbGreen = 0.7;
            Poeni = 0;
        }
        public void AddAnimal(Point p)
        {
            Random r = new Random();
            

            int y = r.Next(0,p.Y-30);
            Point loc = new Point(p.X-20, y);
            WormShark newAnimal = new WormShark(loc);
            newAnimal.addImage(ProbShark, ProbGreen);
            WormsSharks.Add(newAnimal);
            ProbShark += 0.001;
            ProbGreen -= 0.001;
        }
        public void Draw(Graphics g)
        {
            
            foreach (WormShark ws in WormsSharks)
               ws.Draw(g);
        }
        public void Hit(Point p)
        {
            foreach (WormShark ws in WormsSharks)
            {
                ws.IsItHit(p);
            }
            for (int i = 0; i < WormsSharks.Count; i++)
                if (WormsSharks[i].RemoveAnimal)
                {
                    if (WormsSharks[i].Poen)
                    {
                        int t = WormsSharks[i].Type;
                        if(t==0)
                        {

                            IsItOver = true;
                            return;
                        }
                        if(t==1)
                        {
                            Poeni++;
                        }
                        if(t==2)
                        {
                            if(Poeni==0)
                            {
                                IsItOver = true;
                                return;
                            }
                            else
                            {
                                Poeni = (int)(Poeni * 0.5);
                            }
                        }

                    }
                    WormsSharks.Remove(WormsSharks[i]);
                }
        }
        public void Move()
        {
            foreach (WormShark ws in WormsSharks)
                ws.Move();
        }
    }
}
