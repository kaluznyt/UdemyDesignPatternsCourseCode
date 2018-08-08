namespace Coding.Exercise
{
    using System;

    public class GameEventArgs
    {
        public ActionType Action;

        public bool Handled { get; set; }

        public enum ActionType
        {
            Joined, Left
        }
    }

    public class Game
    {
        public event EventHandler<GameEventArgs> GameEvent;

        public event EventHandler<int> SyncRats;

        public void Join(Rat rat)
        {
            this.SyncRats += rat.OnGame_SyncRats;
            GameEvent?.Invoke(this, new GameEventArgs { Action = GameEventArgs.ActionType.Joined, Handled = false });
            this.GameEvent += rat.OnGame_GameEvent;
        }

        public void Leave(Rat rat)
        {
            this.SyncRats -= rat.OnGame_SyncRats;
            this.GameEvent -= rat.OnGame_GameEvent;

            GameEvent?.Invoke(this, new GameEventArgs { Action = GameEventArgs.ActionType.Left, Handled = false });
        }

        public void Sync(int e)
        {
            this.SyncRats?.Invoke(this, e);
        }
    }

    public class Rat : IDisposable
    {
        public int Attack = 1;

        private readonly Game _game;

        public Rat(Game game)
        {
            this._game = game;
            JoinGame();
        }

        private void JoinGame()
        {
            this._game.Join(this);
        }

        public void Dispose()
        {
            LeaveGame();
        }

        private void LeaveGame()
        {
            this._game.Leave(this);
        }

        public void OnGame_SyncRats(object sender, int e)
        {
            this.Attack = Math.Max(this.Attack, e);
        }

        public void OnGame_GameEvent(object sender, GameEventArgs e)
        {
            if (e.Action == GameEventArgs.ActionType.Joined)
            {
                if (!e.Handled)
                {
                    this.Attack++;
                    e.Handled = true;
                    this._game.Sync(this.Attack);
                }
            }
            else
            {
                this.Attack--;
                this._game.Sync(this.Attack);
            }
        }
    }
}

