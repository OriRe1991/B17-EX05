using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace B17_Ex05
{
    class MaxGuessForm : Form
    {
        private Button m_ButtonNumberOfChances;
        private Button m_ButtonStart;
        private int m_StartNumOfChances = Config.k_MinNumOfGusses;

        public MaxGuessForm()
        {
            this.Size = new Size(300, 150);
            this.Text = "Bool Pgia";
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.StartPosition = FormStartPosition.CenterScreen;

        }

        public int StartNumOfChances { get => m_StartNumOfChances; }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            initControls();
        }

        private void initControls()
        {
            m_ButtonNumberOfChances = new Button();
            m_ButtonNumberOfChances.Text = string.Format("Number of chances: {0}", StartNumOfChances);
            m_ButtonNumberOfChances.AutoSize = true;
            m_ButtonNumberOfChances.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            m_ButtonNumberOfChances.Dock = DockStyle.Top;

            m_ButtonStart = new Button();
            m_ButtonStart.Text = "Start";
            m_ButtonStart.AutoSize = true;
            m_ButtonStart.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            m_ButtonStart.Location = new Point(this.ClientSize.Width - (m_ButtonStart.Width + 8), this.ClientSize.Height - (m_ButtonStart.Height + 8));

            this.Controls.AddRange(new Control[] { m_ButtonStart, m_ButtonNumberOfChances });

            this.m_ButtonStart.Click += new EventHandler(m_ButtonStart_Click);
            this.m_ButtonNumberOfChances.Click += new EventHandler(m_ButtonNumberOfChances_Click);
        }

        private void m_ButtonNumberOfChances_Click(object sender, EventArgs e)
        {
            if (this.StartNumOfChances < Config.k_MaxNumOfGusses)
            {
                this.m_StartNumOfChances++;
            }

            else
            {
                this.m_StartNumOfChances = Config.k_MinNumOfGusses;
            }

            m_ButtonNumberOfChances.Text = string.Format("Number of chances: {0}", StartNumOfChances);
        }

        private void m_ButtonStart_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
