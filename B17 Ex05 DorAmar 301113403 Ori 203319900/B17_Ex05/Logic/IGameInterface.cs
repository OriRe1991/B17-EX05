using System;
using System.Collections.Generic;

namespace B17_Ex05
{
    public interface IGameInterface
    {
        int NumOfRounds { get; }

        int CurrentRound { get; }

        List<Guess> GuessList { get; }

        List<GuessResult> GuessResultList { get; }

        Dictionary<Guess.eGameOptions, int> GeneratedSequence { get; }

        void StartNewGame();

        void makeGuess(Guess i_UserGuess);

        bool IsGameOver { get; }

        bool IsVictory { get; }
    }
}
