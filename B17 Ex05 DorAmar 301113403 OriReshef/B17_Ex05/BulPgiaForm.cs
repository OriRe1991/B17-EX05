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
        private IGameInterface m_Logic;
        private MaxGuessForm m_MaxGuessDialog;
        private ColorForm m_ColorForm;
        private Guess m_CurrGuess;
        private List<ButtonMakeGuess> m_ButtonMakeGuessList = null;
        private TableLayoutPanel m_GameButtonPanel = null;
        private List<TableLayoutPanel> m_GuessResultsPanels = null;
        private TableLayoutPanel m_EndOfGameButtons = null;
        //private MessageBox m_MessageBoxGameResult;

        public BulPgiaForm()
        {
            this.Text = "Bool Pgia";
            this.CenterToScreen();
            this.m_CurrGuess = new Guess(Config.k_GuessLength);
            m_MaxGuessDialog = new MaxGuessForm();
            m_MaxGuessDialog.ShowDialog();
            m_Logic = new GameEngine(m_MaxGuessDialog.StartNumOfChances);
            m_MaxGuessDialog.Close();
            m_ColorForm = new ColorForm();
            m_Logic.StartNewGame();
            m_ButtonMakeGuessList = new List<ButtonMakeGuess>();
            this.InitControls();
        }

        private void InitControls()
        {

            m_EndOfGameButtons = new TableLayoutPanel();
            m_EndOfGameButtons.AutoSize = true;
            m_EndOfGameButtons.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            m_EndOfGameButtons.Location = new Point(0, 0);
            createEndOfGameButtons(m_EndOfGameButtons, 4);
            this.Controls.Add(m_EndOfGameButtons);

            m_GameButtonPanel = new TableLayoutPanel();
            m_GameButtonPanel.AutoSize = true;
            m_GameButtonPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            m_GameButtonPanel.Location = new Point(m_EndOfGameButtons.Location.X, m_EndOfGameButtons.Location.Y + 45);
            m_GuessResultsPanels = new List<TableLayoutPanel>();
            createButtonMatrix(m_GameButtonPanel, m_Logic.NumOfRounds, Config.k_GuessLength);
            this.Controls.Add(m_GameButtonPanel);
        }

        private void createEndOfGameButtons(TableLayoutPanel i_TablePanel, int i_LineLength)
        {
            i_TablePanel.RowCount = 1;
            i_TablePanel.ColumnCount = i_LineLength;
            for (int i = 0; i < i_LineLength; i++)
            {
                GuessButton endOfGameButton = new GuessButton(new Point(i, 0));
                endOfGameButton.BackColor = Color.Black;
                endOfGameButton.Enabled = false;
                i_TablePanel.Controls.Add(endOfGameButton, i, 0);
            }
        }

        private void createButtonMatrix(TableLayoutPanel i_TablePanel, int i_numOfLines, int i_LineLength)
        {
            i_TablePanel.RowCount = i_numOfLines;
            i_TablePanel.ColumnCount = i_LineLength;
            for (int i = 0; i < i_numOfLines; i++)
            {
                for (int j = 0; j < i_LineLength; j++)
                {
                    GuessButton button = new GuessButton(new Point(j, i));
                    if (i != 0)
                    {
                        button.Enabled = false;
                    }
                    else
                    {
                        button.Enabled = true;
                    }
                    i_TablePanel.Controls.Add(button, j, i);
                    button.Click += new EventHandler(GuessButton_ClicK);
                }

                ButtonMakeGuess makeGuessButton = new ButtonMakeGuess(i);
                makeGuessButton.InitButton(new Point(i_TablePanel.Right, m_EndOfGameButtons.Location.Y + 20 + (45 * (i+1))));
                this.Controls.Add(makeGuessButton);
                makeGuessButton.Click += new EventHandler(makeGuessButton_Click);
                m_ButtonMakeGuessList.Add(makeGuessButton);

                TableLayoutPanel guessResultPanel = new TableLayoutPanel();
                guessResultPanel.AutoSize = true;
                guessResultPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                guessResultPanel.Location = new Point(makeGuessButton.Right, m_EndOfGameButtons.Location.Y + (45 * (i + 1)));
                createGuessResultPanel(guessResultPanel, 2, 2);
                this.Controls.Add(guessResultPanel);
                m_GuessResultsPanels.Add(guessResultPanel);
            }

        }

        private void createGuessResultPanel(TableLayoutPanel i_TablePanel, int i_numOfLines, int i_LineLength)
        {
            i_TablePanel.RowCount = i_numOfLines;
            i_TablePanel.ColumnCount = i_LineLength;
            for (int i = 0; i < i_numOfLines; i++)
            {
                for (int j = 0; j < i_LineLength; j++)
                {
                    Button button = new Button();
                    button.Enabled = false;
                    button.Height = 15;
                    button.Width = 15;

                    i_TablePanel.Controls.Add(button, j, i);
                }
            }
        }

        private void makeGuessButton_Click(object sender, EventArgs e)
        {
            m_Logic.makeGuess(this.m_CurrGuess);
            int currRound = m_Logic.CurrentRound;
            foreach (GuessButton button in m_GameButtonPanel.Controls)
            {
                if (button.Location.Y == currRound - 1)
                {
                    button.Enabled = false;
                }

                else if (button.Location.Y == currRound)
                {
                    button.Enabled = true;
                }
            }

            (sender as ButtonMakeGuess).Enabled = false;
            foreach (Button button in m_ColorForm.GameButtonPanel.Controls)
            {
                button.Enabled = true;
            }
            m_CurrGuess.NumberOfinputs = 0;

            int resultBttnIndex = 0;
            for (int i = 0; i < m_Logic.GuessResultList[(sender as ButtonMakeGuess).RoundNumber].BulHits; i++)
            {
                ((Button)m_GuessResultsPanels[(sender as ButtonMakeGuess).RoundNumber].Controls[resultBttnIndex]).BackColor = Color.Black;
                resultBttnIndex++;
            }
            for (int i = m_Logic.GuessResultList[(sender as ButtonMakeGuess).RoundNumber].BulHits; i < m_Logic.GuessResultList[(sender as ButtonMakeGuess).RoundNumber].PgiyaHits; i++)
            {
                ((Button)m_GuessResultsPanels[(sender as ButtonMakeGuess).RoundNumber].Controls[resultBttnIndex]).BackColor = Color.Yellow;
            }

            if(m_Logic.IsVictory)
            {
                int index = 0;
                foreach (GuessButton btn in m_EndOfGameButtons.Controls)
                {
                    btn.BackColor = ((GuessButton)m_GameButtonPanel.Controls[((sender as ButtonMakeGuess).RoundNumber*Config.k_GuessLength) + index]).BackColor;
                    index++;
                }
                MessageBox.Show("Congratulations! You have won :))");
                this.Close();
            }

            else if(m_Logic.IsGameOver)
            {
                MessageBox.Show("Game Over!");
                this.Close();
            }
        }

        private void GuessButton_ClicK(object sender, EventArgs e)
        {
            m_ColorForm.ShowDialog();
            (sender as GuessButton).BackColor = m_ColorForm.CurrPick;
            m_CurrGuess.AddColorToGuess((sender as GuessButton).Location.X, m_ColorForm.CurrPick);
            if (m_CurrGuess.NumberOfinputs == Config.k_GuessLength)
            {
                m_ButtonMakeGuessList[(sender as GuessButton).Location.Y].Enabled = true;
            }
            //m_ColorForm.Hide();
        }
    }
}
