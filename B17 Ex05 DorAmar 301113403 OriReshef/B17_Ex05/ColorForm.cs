using System;
using System.Drawing;
using System.Windows.Forms;

namespace B17_Ex05
{
    public class ColorForm: Form
    {
        private Color m_CurrPick;

        public Color CurrPick { get => m_CurrPick; }

        public ColorForm()
        {
            this.Text = "Pick A Color";
            m_CurrPick = new Color();
            initControls();
        }

        private void initControls()
        {
            TableLayoutPanel gameButtonPanel = new TableLayoutPanel();
            gameButtonPanel.RowCount = 2;
            gameButtonPanel.ColumnCount = 4;
            gameButtonPanel.AutoSize = true;
            gameButtonPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            gameButtonPanel.Location = new Point(this.Left, this.Bottom - gameButtonPanel.Height);
            this.Controls.Add(gameButtonPanel);

            for (int i = 0; i < gameButtonPanel.RowCount; i++)
            {
                for (int j = 0; j < gameButtonPanel.ColumnCount; j++)
                {
                    GuessButton button = new GuessButton(new Point(j, i));
                    int currColorIdx = (i * 4) + j + 1;
                    button.BackColor = Color.FromName(((Guess.eGameOptions)(currColorIdx)).ToString());
                    gameButtonPanel.Controls.Add(button, j, i);
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