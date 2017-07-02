using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace B17_Ex05
{
    public class GuessButton : Button
    {
        private Point m_Location;

        public GuessButton(Point i_Location)
        {
            m_Location = i_Location;
            this.BackColor = Color.Gray;
            this.Width = 40;
            this.Height = 40;
        }

        public new Point Location { get => m_Location; }
    }
}
