using System;
using System.Collections.Generic;
using System.Drawing;

namespace B17_Ex05
{
    public class Guess
    {
        private List<eGameOptions> m_GuessAttempt = null;
        private int m_NumberOfinputs = 0;
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
            GuessAttempt.Insert(i_GuessIdx ,(eGameOptions)Enum.Parse(typeof(eGameOptions), i_ColorGuess.Name));
            if(NumberOfinputs<4)
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

        //private bool checkUserInput(string i_userGuess)
        //{
        //    bool validUserInput = false;

        //    HashSet<char> doubleCheck = new HashSet<char>();
        //    if (i_userGuess.Length == Config.k_GuessLength)
        //    {
        //        foreach (char item in i_userGuess)
        //        {
        //            validUserInput = item >= 'A' && item <= 'H';

        //            if(validUserInput == false)
        //            {
        //                Console.WriteLine("chars have to be between A and H!");
        //            }

        //            // check if symbol appears more than once
        //            if(doubleCheck.Contains(item))
        //            {
        //                Console.WriteLine("chars cant appear more than once!");
        //            }

        //            if (validUserInput && doubleCheck.Contains(item) == false)
        //            {
        //                doubleCheck.Add(item);
        //            }
        //            else
        //            {
        //                validUserInput = false;
        //                break;
        //            }
        //        }
        //    }

        //    return validUserInput;
        //}
    }
}
