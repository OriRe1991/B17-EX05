using System;
using System.Collections.Generic;

namespace B17_Ex05
{
    public class GameEngine: IGameInterface
    {
        private int m_NumOfRounds;
        private Dictionary<Guess.eGameOptions, int> m_GeneratedSequence;
        private List<Guess> m_GuessList;
        private List<GuessResult> m_GuessResultList;
        private int m_CurrentRound;
        private Guess m_CurrentGuess;
        private GuessResult m_CurrentGuessResult;
        private bool m_IsVictory;
        private bool m_IsGameOver;

        // Getters
        public int NumOfRounds { get => m_NumOfRounds; }

        public bool IsGameOver { get => m_IsGameOver; }

        public bool IsVictory { get => m_IsVictory; }

        public List<Guess> GuessList { get => m_GuessList; }

        public List<GuessResult> GuessResultList { get => m_GuessResultList; }

        public Dictionary<Guess.eGameOptions, int> GeneratedSequence { get => m_GeneratedSequence; }

        public int CurrentRound { get => m_CurrentRound; }

        public GameEngine(int i_NumOfRounds)
        {
            this.m_NumOfRounds = i_NumOfRounds;
            this.m_GeneratedSequence = new Dictionary<Guess.eGameOptions, int>();
            this.m_GuessList = new List<Guess>();
            this.m_GuessResultList = new List<GuessResult>(); 
            this.m_CurrentRound = 0;
            this.m_CurrentGuess = null;
            this.m_IsVictory = false;
            this.m_IsGameOver = false;
        }

        public void StartNewGame()
        {
            this.generateRandomSymbolSeries();
        }

        private void generateRandomSymbolSeries()
        {
            Array symbols = Enum.GetValues(typeof(Guess.eGameOptions));
            int numOfSymbols = symbols.Length;
            Random rand = new Random();

            for (int i = 0; i < Config.k_GuessLength; i++)
            {
                const int k_FirstSymbol = 1;
                int randomNum = rand.Next(k_FirstSymbol, numOfSymbols - 1);
                Guess.eGameOptions randomSymbol = (Guess.eGameOptions)randomNum;
                while (m_GeneratedSequence.ContainsKey(randomSymbol))
                {
                    randomNum = rand.Next(k_FirstSymbol, numOfSymbols - 1);
                    randomSymbol = (Guess.eGameOptions)randomNum;
                }

                m_GeneratedSequence.Add(randomSymbol, i);
            }         
        }

        public void makeGuess(Guess i_UserGuess)
        {
            m_CurrentRound++;
            m_CurrentGuess = i_UserGuess;
            m_GuessList.Add(m_CurrentGuess);
            this.m_CurrentGuessResult = new GuessResult();
            compareGuess();
            checkVictory();
            checkGameOver();
        }

        // The computer generated sequence is stored as a dictionary
        // key: a generated symbol
        // value: the location of the symbol in the sequence
        private void compareGuess()
        {
            int symbolIndex = 0;

            foreach (Guess.eGameOptions symbol in m_CurrentGuess.GuessAttempt)
            {
                if (m_GeneratedSequence.ContainsKey(symbol))
                {
                    if (m_GeneratedSequence[symbol] == symbolIndex)
                    {
                        this.m_CurrentGuessResult.BulHits++;
                    }
                    else
                    {
                        this.m_CurrentGuessResult.PgiyaHits++;
                    }
                }

                symbolIndex++;
            }

            m_GuessResultList.Add(m_CurrentGuessResult);
        }

        public void checkGameOver()
        {
            m_IsGameOver = CurrentRound == m_NumOfRounds;
        }

        public void checkVictory()
        {
            this.m_IsVictory = m_CurrentGuessResult.BulHits == Config.k_GuessLength;
        }

    }
}
