namespace UdemyDesignPatternsCourse.DesignPatterns.Behavioral.State
{
    using System.Collections.Generic;
    using System.Text;

    using Stateless;

    using static System.Console;

    enum LockState
    {
        Locked, Failed, Unlocked
    }

    public enum Health
    {
        NonReproductive,
        Pregnant,
        Reproductive
    }

    public enum Activity
    {
        GiveBirth,
        ReachPuberty,
        HaveAbortion,
        HaveUnprotectedSex,
        Histerectomy
    }

    public class State : IDemo
    {
        public void Run()
        {
            // HandmadeStateDemo();

            // StateMachineSwitchDemo();

            this.StatelessBasedStateMachine();
        }

        private void StatelessBasedStateMachine()
        {
            var statemachine = new StateMachine<Health, Activity>(Health.NonReproductive);

            statemachine.Configure(Health.NonReproductive)
                .Permit(Activity.ReachPuberty, Health.Reproductive);

            statemachine.Configure(Health.Reproductive)
                .Permit(Activity.Histerectomy, Health.NonReproductive).PermitIf(
                    Activity.HaveUnprotectedSex,
                    Health.Pregnant,
                    () => this.ParentsNotWatching);

            statemachine.Configure(Health.Pregnant).Permit(Activity.GiveBirth, Health.Reproductive)
                .Permit(Activity.HaveAbortion, Health.Reproductive);
        }

        public bool ParentsNotWatching { get; set; } = true;

        private static void StateMachineSwitchDemo()
        {
            string code = "1234";

            var state = LockState.Locked;
            var entry = new StringBuilder();

            while (true)
            {
                switch (state)
                {
                    case LockState.Locked:
                        entry.Append(ReadKey().KeyChar);

                        if (entry.ToString() == code)
                        {
                            state = LockState.Unlocked;
                            break;
                        }

                        if (!code.StartsWith(entry.ToString()))
                        {
                            state = LockState.Failed;
                        }

                        break;
                    case LockState.Failed:
                        CursorLeft = 0;
                        WriteLine("FAILED");
                        entry.Clear();
                        state = LockState.Locked;
                        break;
                    case LockState.Unlocked:
                        CursorLeft = 0;
                        WriteLine("UNLOCKED");
                        entry.Clear();
                        state = LockState.Unlocked;
                        break;
                }
            }
        }

        private static void HandmadeStateDemo()
        {
            var rules = new Dictionary<States, List<(Trigger, States)>>
            {
                [States.OffHook] =
                                                                                                    new List<(Trigger, States)>
                                                                                                         {
                                                                                                         (Trigger.CallDialed,States.Connecting)
                                                                                                         },
                [States.Connecting] =
                                                                                                    new List<(Trigger, States)>
                                                                                                        {
                                                                                                        (Trigger.HungUp,States.OffHook),
                                                                                                        (Trigger.CallConnected,States.Connected),
                                                                                                        },
                [States.Connected] =
                                                                                                    new List<(Trigger, States)>
                                                                                                        {
                                                                                                        (Trigger.LeftMessage,States.OffHook),
                                                                                                        (Trigger.HungUp,States.OffHook),
                                                                                                        (Trigger.PlacedOnHold,States.OnHold)
                                                                                                        },
                [States.OnHold] =
                                                                                                    new List<(Trigger, States)>
                                                                                                        {
                                                                                                        (Trigger.TakenOffHold,States.Connected),
                                                                                                        (Trigger.HungUp,States.OffHook)
                                                                                                        }
            };

            var state = States.OffHook;

            while (true)
            {
                WriteLine($"The phone is currently {state}");
                WriteLine($"Select a trigger:");

                for (var i = 0; i < rules[state].Count; i++)
                {
                    var (t, _) = rules[state][i];
                    WriteLine($"{i}. {t}");
                }

                var userInput = ReadLine();

                if (int.TryParse(userInput, out var input) && input < rules[state].Count)
                {
                    var (_, s) = rules[state][input];
                    state = s;
                }
                else
                {
                    WriteLine("Incorrect trigger chosen");
                }
            }
        }
    }
}
