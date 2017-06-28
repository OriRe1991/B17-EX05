using System;
using System.Collections.Generic;
using System.Drawing;

namespace B17_Ex05
{
    public class Guess
    {
        private List<eGameOptions> m_GuessAttempt = null;
        public List<eGameOptions> GuessAttempt { get => m_GuessAttempt; }

        public Guess()
        {
            m_GuessAttempt = new List<eGameOptions>();
        }

        public Guess(int i_GuessLength)
        {
            m_GuessAttempt = new List<eGameOptions>(i_GuessLength);
        }

        public void AddColorToGuess(int i_GuessIdx, Color i_ColorGuess)
        {
            GuessAttempt.Insert(i_GuessIdx ,(eGameOptions)Enum.Parse(typeof(eGameOptions), i_ColorGuess.Name));
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
