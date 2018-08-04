using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyDesignPatternsCourse.DesignPatterns.Structural.ChainOfResponsibility
{
    namespace Coding.Exercise
    {
        public abstract class Creature
        {
            protected Game game;

            private int attack;

            private int defense;

            public int Attack
            {
                get
                {
                    return this.attack + this.game.AttackBonus(this);
                }
                set
                {
                    this.attack = value;
                }
            }

            public int Defense
            {
                get
                {
                    return this.defense + this.game.DefenseBonus(this);
                }
                set
                {
                    this.defense = value;
                }
            }
        }

        public class Goblin : Creature
        {
            public Goblin(Game game)
            {
                this.game = game;
                this.Attack = this.Defense = 1;
            }
        }

        public class GoblinKing : Goblin
        {
            public GoblinKing(Game game)
                : base(game)
            {
                this.Attack = this.Defense = 3;
            }
        }

        public class Game
        {
            public IList<Creature> Creatures = new List<Creature>();

            public int AttackBonus(Creature creature)
            {
                return (this.Creatures.OfType<GoblinKing>().Any() ? 1 : 0);
            }

            public int DefenseBonus(Creature creature)
            {
                return this.Creatures.Where(c => !c.Equals(creature)).OfType<Goblin>().Count();
            }
        }
    }
}
