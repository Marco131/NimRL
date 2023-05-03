using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NimRL.Classes.Model.Player
{
    public abstract class Player
    {
        // Fields
        private PlayerType _currentPlayerType;
        private EndGameState _currentEndGameState;

        private int? _lastChosenAction;
        private List<int> _gameActions;


        // Properties
        public PlayerType CurrentPlayerType { get => _currentPlayerType; protected set => _currentPlayerType = value; }
        public EndGameState CurrentEndGameState { get => _currentEndGameState; protected set => _currentEndGameState = value; }

        public int? LastChosenAction { get => _lastChosenAction; protected set => _lastChosenAction = value; }
        public List<int> GameActions { get => _gameActions; protected set => _gameActions = value; }


        // Ctor
        public Player(PlayerType playerType)
        {
            this.CurrentPlayerType = playerType;
            this.CurrentEndGameState = EndGameState.None;

            this.LastChosenAction = null;
            this.GameActions = new List<int>();
        }


        // Methods
        /// <summary>
        /// Changes the current end game state
        /// </summary>
        /// <param name="newEndGameState">New end game state</param>
        public void ChangeCurrentEndGameState(EndGameState newEndGameState)
        {
            this.CurrentEndGameState = newEndGameState;
        }

        /// <summary>
        /// Adds the last chosen action to the list of actions
        /// </summary>
        /// <exception cref="Exception">Throws exception there's no last chosen action</exception>
        protected void AddActionToList()
        {
            // if LastChosenAction isn't null add it to the list, if it is throw an exception
            this.GameActions.Add(
                this.LastChosenAction ?? throw new Exception("The player hasn't chose an action yet")
            );
        }

        /// <summary>
        /// Empties the action list
        /// </summary>
        public void EmptyActionList()
        {
            this.GameActions.Clear();
        }


        public abstract string GetName();

        public override string ToString()
        {
            string result;

            if (this.CurrentEndGameState == EndGameState.None)
            {
                result = "The players last action were : ";
                result += string.Join("-", this.GameActions);
            }
            else
            {
                if (this.CurrentEndGameState == EndGameState.Winner)
                {
                    result = "The player is a winner";
                }
                else // Loser
                {
                    result = "The player is a loser";
                }
            }

            return result;
        }
    }
}
