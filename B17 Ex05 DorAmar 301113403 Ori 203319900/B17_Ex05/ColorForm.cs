using System;
using System.Drawing;
using System.Windows.Forms;

namespace B17_Ex05
{
    public class ColorForm : Form
    {
        private Color m_CurrPick;
        private TableLayoutPanel m_GameButtonPanel = null;

        public Color CurrPick { get => m_CurrPick; }

        public TableLayoutPanel GameButtonPanel { get => m_GameButtonPanel; }

        public ColorForm()
        {
            this.Text = "Pick A Color";
            m_CurrPick = new Color();
            initControls();
        }

        private void initControls()
        {
            m_GameButtonPanel = new TableLayoutPanel();
            m_GameButtonPanel.RowCount = 2;
            m_GameButtonPanel.ColumnCount = 4;
            m_GameButtonPanel.AutoSize = true;
            m_GameButtonPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            m_GameButtonPanel.Location = new Point(0, 0);
            this.Controls.Add(GameButtonPanel);

            for (int i = 0; i < GameButtonPanel.RowCount; i++)
            {
                for (int j = 0; j < GameButtonPanel.ColumnCount; j++)
                {
                    GuessButton button = new GuessButton(new Point(j, i));
                    int currColorIdx = (i * 4) + j + 1;
                    button.BackColor = Color.FromName(((Guess.eGameOptions)currColorIdx).ToString());
                    GameButtonPanel.Controls.Add(button, j, i);
                    button.Click += new EventHandler(GuessButton_ClicK);
                }
            }
        }

        private void GuessButton_ClicK(object sender, EventArgs e)
        {
            m_CurrPick = (sender as Button).BackColor;
            (sender as Button).Enabled = false;
            this.Hide();
        }
    }
}