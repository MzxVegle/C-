using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Login
{
    class FrmHelper
    {
        static int j = 0;
        static int num = 0;
        
        public static void openEffects(Form frm, Timer timer)
        {
            frm.Opacity += 0.02;
            if (frm.Opacity == 1)
            {
                timer.Enabled = false;
            }
        }
        public static void moveEffects(Form frm, Timer timer, Panel panel)
        {
            
            Point XY = new Point();
            if (num == 0)
            {
                j++;
                XY.X = j;
                XY.Y = frm.Height - panel.Height - 40;
                panel.Location = XY;
                if (panel.Location.X == frm.Width - panel.Width - 15)
                {

                    num = 1;
                }
            }
            else if (num == 1)
            {

                j--;
                XY.X = j;
                XY.Y = frm.Height - panel.Height - 40;
                panel.Location = XY;
                if (j == 0)
                {
                    num = 0;
                }
            }
        }
    }
}
