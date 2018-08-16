﻿using System;

namespace Coding.Exercise
{

    public class Creature
    {
        public int Attack, Health;

        public Creature(int attack, int health)
        {
            Attack = attack;
            Health = health;
        }
    }

    public abstract class CardGame
    {
        public Creature[] Creatures;

        public CardGame(Creature[] creatures)
        {
            Creatures = creatures;
        }

        // returns -1 if no clear winner (both alive or both dead)
        public virtual int Combat(int creature1, int creature2)
        {
            Creature first = Creatures[creature1];
            Creature second = Creatures[creature2];
            Hit(first, second);
            Hit(second, first);
            bool firstAlive = first.Health > 0;
            bool secondAlive = second.Health > 0;
            if (firstAlive == secondAlive) return -1;
            return firstAlive ? creature1 : creature2;
        }

        // attacker hits other creature
        protected abstract void Hit(Creature attacker, Creature other);
    }

    public class TemporaryCardDamageGame : CardGame
    {
        // todo
        public TemporaryCardDamageGame(Creature[] creatures)
            : base(creatures)
        {
        }

        protected override void Hit(Creature attacker, Creature other)
        {
            other.Health -= attacker.Attack;
        }

        public override int Combat(int c1, int c2)
        {
            int c1Health = Creatures[c1].Health;
            int c2Health = Creatures[c2].Health;

            var retValue = base.Combat(c1, c2);
            if (retValue == -1)
            {
                Creatures[c1].Health = c1Health;
                Creatures[c2].Health = c2Health;
            }

            return retValue;
        }
    }

    public class PermanentCardDamage : CardGame
    {
        // todo
        public PermanentCardDamage(Creature[] creatures)
            : base(creatures)
        {
        }

        protected override void Hit(Creature attacker, Creature other)
        {
            other.Health -= attacker.Attack;
        }
    }
}