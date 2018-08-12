namespace UdemyDesignPatternsCourse.DesignPatterns.Behavioral.Template_Method
{
    using System;

    public abstract class Game
    {
        public void Run()
        {
            this.Start();
            while (!this.HaveWinner)
            {
                this.TakeTurn();
            }
            Console.WriteLine($"Player {this.WinningPlayer} wins");
        }

        protected abstract void Start();
        protected abstract void TakeTurn();
        protected abstract bool HaveWinner { get; }
        protected abstract int WinningPlayer { get; }

        protected int currentPlayer;

        protected readonly int numberOfPlayers;

        protected Game(int numberOfPlayers)
        {
            this.numberOfPlayers = numberOfPlayers;
        }


    }
}