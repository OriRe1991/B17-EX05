using System.Windows.Forms;

namespace B17_Ex05
{
    public class ButtonMakeGuess : Button
    {
        private int m_RoundNumber;

        public ButtonMakeGuess(int i_RoundNumber)
        {
            m_RoundNumber = i_RoundNumber;
        }

        public int RoundNumber { get => m_RoundNumber; }
    }
}