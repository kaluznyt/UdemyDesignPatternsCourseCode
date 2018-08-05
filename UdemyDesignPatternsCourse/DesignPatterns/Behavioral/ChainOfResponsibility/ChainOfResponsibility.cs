namespace UdemyDesignPatternsCourse.DesignPatterns.Behavioral.ChainOfResponsibility
{
    using System;

    using UdemyDesignPatternsCourse.DesignPatterns.Behavioral.ChainOfResponsibility.BrokerChain;
    using UdemyDesignPatternsCourse.DesignPatterns.Behavioral.ChainOfResponsibility.Coding.Exercise;

    using Xunit;

    using Game = UdemyDesignPatternsCourse.DesignPatterns.Behavioral.ChainOfResponsibility.BrokerChain.Game;

    public class ChainOfResponsibility : IDemo
    {
        public void Run()
        {
            //MethodChainClassingImplementation();

            //EventBroker();
        }

        [Fact]
        public void CodingExerciseTest()
        {
            var game = new Coding.Exercise.Game();
            var goblin = new Goblin(game);
            game.Creatures.Add(goblin);
            Assert.Equal(1, goblin.Attack);
            Assert.Equal(1, goblin.Defense);
        }

        private static void EventBroker()
        {
            var game = new Game();
            var goblin = new BrokerChain.Creature(game, "Goblin", 2, 2);
            Console.WriteLine(goblin);

            using (new BrokerChain.DoubleAttackModifier(game, goblin))
            using (new IncreaseDefenseModifier(game, goblin))
            {
                Console.WriteLine(goblin);
            }

            Console.WriteLine(goblin);
        }

        private static void MethodChainClassingImplementation()
        {
            var goblin = new Creature("goblin", 2, 3);

            Console.WriteLine(goblin);

            var root = new CreatureModifier(goblin);

            root.Add(new DoubleAttackModifier());
            root.Add(new IncreasedDefenseModifier());

            root.Handle();

            Console.WriteLine(goblin);
        }
    }

    namespace BrokerChain
    {

        public class Game
        {
            public event EventHandler<Query> Queries;

            public void PerformQuery(object sender, Query q)
            {
                this.Queries?.Invoke(sender, q);
            }
        }

        public class Query
        {
            public string CreatureName;

            public enum Argument
            {
                Attack,

                Defense
            }

            public Argument WhatToQuery;

            public int Value;

            public Query(string creatureName, Argument whatToQuery, int value)
            {
                this.CreatureName = creatureName;
                this.WhatToQuery = whatToQuery;
                this.Value = value;
            }
        }

        public class Creature
        {
            private Game game;

            public string Name;

            private int attack, defense;

            public Creature(Game game, string name, int attack, int defense)
            {
                this.game = game;
                this.Name = name;
                this.attack = attack;
                this.defense = defense;
            }

            public int Attack
            {
                get
                {
                    var q = new Query(this.Name, Query.Argument.Attack, this.attack);
                    this.game.PerformQuery(this, q);
                    return q.Value;
                }
            }

            public int Defense
            {
                get
                {
                    var q = new Query(this.Name, Query.Argument.Defense, this.attack);
                    this.game.PerformQuery(this, q);
                    return q.Value;
                }
            }

            public override string ToString()
            {
                return $"{nameof(this.Name)}: {this.Name}, {nameof(this.Attack)}: {this.Attack}, {nameof(this.Defense)}: {this.Defense}";
            }
        }

        public abstract class CreatureModifier : IDisposable
        {
            protected Game game;

            protected Creature creature;

            protected CreatureModifier(Game game, Creature creature)
            {
                this.game = game;
                this.creature = creature;
                game.Queries += this.Handle;
            }

            protected abstract void Handle(object sender, Query q);

            public void Dispose()
            {
                this.game.Queries -= this.Handle;
            }
        }

        public class DoubleAttackModifier : CreatureModifier
        {
            public DoubleAttackModifier(Game game, Creature creature)
                : base(game, creature)
            {
            }

            protected override void Handle(object sender, Query q)
            {
                if (q.CreatureName == this.creature.Name && q.WhatToQuery == Query.Argument.Attack)
                {
                    q.Value *= 2;
                }
            }
        }

        public class IncreaseDefenseModifier : CreatureModifier
        {
            public IncreaseDefenseModifier(Game game, Creature creature)
                : base(game, creature)
            {
            }

            protected override void Handle(object sender, Query q)
            {
                if (q.CreatureName == this.creature.Name && q.WhatToQuery == Query.Argument.Defense)
                {
                    q.Value += 3;
                }
            }
        }
    }
}
