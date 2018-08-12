namespace UdemyDesignPatternsCourse.DesignPatterns.Behavioral.Template_Method
{
    using System;

    public class Chess : Game
    {
        public Chess()
            : base(2)
        {
        }

        private int turn = 1;

        private int maxTurns = 10;


        protected override void Start()
        {
            Console.WriteLine($"Starting the game of chess with {this.numberOfPlayers} players");
        }

        protected override void TakeTurn()
        {
            Console.WriteLine($"Turn {this.turn++} taken by player {this.currentPlayer}");
            this.currentPlayer = (this.currentPlayer + 1) % this.numberOfPlayers;
        }

        protected override bool HaveWinner => this.turn == this.maxTurns;

        protected override int WinningPlayer => this.currentPlayer;
    }
}