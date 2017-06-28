using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace B17_Ex05
{
    public class BulPgiaForm : Form
    {
        private IGameInterface m_logic;
        private MaxGuessForm m_MaxGuessDialog;
        private ColorForm m_ColorForm;
        private Guess m_CurrGuess;
        public BulPgiaForm()
        {
            this.Text = "Bool Pgia";
            m_MaxGuessDialog = new MaxGuessForm();
            m_MaxGuessDialog.ShowDialog();
            m_logic = new GameEngine(m_MaxGuessDialog.StartNumOfChances);
            m_MaxGuessDialog.Close();
            m_ColorForm = new ColorForm();
            m_logic.StartNewGame();
            this.InitControls();
            this.m_CurrGuess = new Guess(Config.k_GuessLength);
            //this.ShowDialog();
        }

        private void InitControls()
        {
            TableLayoutPanel gameButtonPanel = new TableLayoutPanel();
            gameButtonPanel.AutoSize = true;
            gameButtonPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            gameButtonPanel.Location = new Point(this.Left, this.Bottom - gameButtonPanel.Height);
            createButtonMatrix(gameButtonPanel, m_logic.NumOfRounds, Config.k_GuessLength);
            gameButtonPanel.Name = "gameButtonPanel";
            this.Controls.Add(gameButtonPanel);
            
        }

        private void createButtonMatrix(TableLayoutPanel i_TablePanel, int i_numOfLines, int i_LineLength)
        {
            i_TablePanel.RowCount = i_numOfLines;
            i_TablePanel.ColumnCount = i_LineLength + 2;
            for (int i = 0; i < i_numOfLines; i++)
            {
                for (int j = 0; j < i_LineLength; j++)
                {
                    GuessButton button = new GuessButton(new Point(j, i));
                    if (i != 0)
                    {
                        button.Enabled = false;
                    }
                    i_TablePanel.Controls.Add(button, j, i);
                    button.Click += new EventHandler(GuessButton_ClicK);
                }
                ButtonMakeGuess makeGuessButton = new ButtonMakeGuess(i);
                makeGuessButton.Text = "-->>";
                makeGuessButton.Enabled = false;
                makeGuessButton.Location = new Point(i_TablePanel.Right, i_TablePanel.Top + 40 * i);
                this.Controls.Add(makeGuessButton);
                makeGuessButton.Click += new EventHandler(makeGuessButton_Click);
            }
            
        }

        private void makeGuessButton_Click(object sender, EventArgs e)
        {
            m_logic.makeGuess(this.m_CurrGuess);
            int currRound = m_logic.CurrentRound;
            foreach (GuessButton button in this.Controls) 
            {
                if(button.Location.Y == currRound)
                {
                    button.Enabled = false;
                }

                else if(button.Location.Y == currRound + 1)
                {
                    button.Enabled = true;
                }
            }

            (sender as ButtonMakeGuess).Enabled = false;
            foreach (Button button in m_ColorForm.Controls)
            {
                button.Enabled = true;
            }
        }

        private void GuessButton_ClicK(object sender, EventArgs e)
        {
            m_ColorForm.ShowDialog();
            (sender as GuessButton).BackColor = m_ColorForm.CurrPick;
            m_CurrGuess.AddColorToGuess((sender as GuessButton).Location.X, m_ColorForm.CurrPick);
            if(m_CurrGuess.GuessAttempt.Count() == Config.k_GuessLength)
            {
                foreach (ButtonMakeGuess button in this.Controls)
                {
                    if (button.RoundNumber == (sender as GuessButton).Location.Y)
                    {
                        button.Enabled = true;
                    }
                }
                    
            }
            //m_ColorForm.Hide();
        }
    }
}
