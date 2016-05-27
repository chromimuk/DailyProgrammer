using System;

namespace DailyProgrammer
{
    /// <summary>
    /// https://www.reddit.com/r/dailyprogrammer/comments/4cb7eh/20160328_challenge_260_easy_garage_door_opener/
    /// </summary>
    public class e260_Garage_Door : IChallenge<int[]>
    {
        // everything here is public and so it can be used in Test without being a pain
        public enum Actions { Click = 0, Wait = 1 };
        public const int STATE_OPEN = 0;
        public const int STATE_OPENING = 1;
        public const int STATE_STOPPEDWHILEOPENING = 2;
        public const int STATE_CLOSING = 3;
        public const int STATE_STOPPEDWHILECLOSING = 4;
        public const int STATE_CLOSED = 5;


        public int[] GetResult(object input)
        {
            Actions[] actions = (Actions[])input;
            int[] result = new int[actions.Length + 1];

            GarageDoor door = new GarageDoor();
            result[0] = door.GetCodeCurrentState();

            for (int i = 0; i < actions.Length; i++)
            {
                if (actions[i] == Actions.Click)
                    door.PressClick();
                else
                    door.Wait();

                result[i + 1] = door.GetCodeCurrentState();
            }

            return result;
        }


        /// Let's use the State Pattern to implement the garage door behavior, what could go WRONG
        class GarageDoor
        {
            public StateBehavior CurrentState { get; set; }

            // possible states
            public StateBehavior StateOpen { get; set; }
            public StateBehavior StateOpening { get; set; }
            public StateBehavior StateStopWhileOpening { get; set; }
            public StateBehavior StateClosing { get; set; }
            public StateBehavior StateStopWhileClosing { get; set; }
            public StateBehavior StateClosed { get; set; }


            public GarageDoor()
            {
                StateOpen = new StateOpenBehavior(this);
                StateOpening = new StateOpeningBehavior(this);
                StateStopWhileOpening = new StateStoppedWhileOpeningBehavior(this);
                StateClosing = new StateClosingBehavior(this);
                StateStopWhileClosing = new StateStoppedWhileClosingBehavior(this);
                StateClosed = new StateClosedBehavior(this);

                CurrentState = StateClosed;
            }

            public void PressClick()
            {
                CurrentState.Click();
            }

            public void Wait()
            {
                CurrentState.Wait();
            }

            public int GetCodeCurrentState()
            {
                return CurrentState.GetCode();
            }


            public abstract class StateBehavior
            {
                protected GarageDoor door;
                public StateBehavior(GarageDoor d) { door = d; }

                public virtual void Click() { }
                public virtual void Wait() { }
                public abstract int GetCode();
            }

            class StateOpenBehavior : StateBehavior
            {
                public StateOpenBehavior(GarageDoor d) : base(d) { }
                public override void Click() { door.CurrentState = door.StateClosing; }
                public override int GetCode() { return STATE_OPEN; }
            }

            class StateOpeningBehavior : StateBehavior
            {
                public StateOpeningBehavior(GarageDoor d) : base(d) { }
                public override void Click() { door.CurrentState = door.StateStopWhileOpening; }
                public override void Wait() { door.CurrentState = door.StateOpen; }
                public override int GetCode() { return STATE_OPENING; }
            }

            class StateStoppedWhileOpeningBehavior : StateBehavior
            {
                public StateStoppedWhileOpeningBehavior(GarageDoor d) : base(d) { }
                public override void Click() { door.CurrentState = door.StateClosing; }
                public override int GetCode() { return STATE_STOPPEDWHILEOPENING; }
            }

            class StateClosingBehavior : StateBehavior
            {
                public StateClosingBehavior(GarageDoor d) : base(d) { }
                public override void Click() { door.CurrentState = door.StateStopWhileClosing; }
                public override void Wait() { door.CurrentState = door.StateClosed; }
                public override int GetCode() { return STATE_CLOSING; }
            }

            class StateStoppedWhileClosingBehavior : StateBehavior
            {
                public StateStoppedWhileClosingBehavior(GarageDoor d) : base(d) { }
                public override void Click() { door.CurrentState = door.StateOpening; }
                public override int GetCode() { return STATE_STOPPEDWHILECLOSING; }
            }

            class StateClosedBehavior : StateBehavior
            {
                public StateClosedBehavior(GarageDoor d) : base(d) { }
                public override void Click() { door.CurrentState = door.StateOpening; }
                public override int GetCode() { return STATE_CLOSED; }
            }
        }

    }
}
