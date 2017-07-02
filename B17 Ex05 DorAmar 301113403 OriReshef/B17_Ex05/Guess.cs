using System;
using System.Collections.Generic;
using System.Drawing;

namespace B17_Ex05
{
    public class Guess
    {
        private List<eGameOptions> m_GuessAttempt;
        private int m_NumberOfinputs;

        public List<eGameOptions> GuessAttempt { get => m_GuessAttempt; }

        public int NumberOfinputs { get => m_NumberOfinputs; set => m_NumberOfinputs = value; }

        public Guess()
        {
            m_GuessAttempt = new List<eGameOptions>();
        }

        public Guess(int i_GuessLength)
        {
            m_GuessAttempt = new List<eGameOptions>(i_GuessLength);

            for (int i = 0; i < i_GuessLength; i++)
            {
                m_GuessAttempt.Add(eGameOptions.Blue);
            }
        }

        public void AddColorToGuess(int i_GuessIdx, Color i_ColorGuess)
        {
            GuessAttempt.Insert(i_GuessIdx, (eGameOptions)Enum.Parse(typeof(eGameOptions), i_ColorGuess.Name));
            if(NumberOfinputs < 4)
            {
                NumberOfinputs++;
            }

            GuessAttempt.RemoveAt(GuessAttempt.Count - 1);
        }

        public enum eGameOptions
        {
            Red = 1,
            Blue,
            Green,
            White,
            Brown,
            Yellow,
            Pink,
            Purple
        }
    }
}
