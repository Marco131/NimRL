using NimRL.Classes.Model.AI;
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
        private PlayerType _playerType;
        private EndGameState _currentEndGameState;

        private int? _lastChosenAction;
        private List<int> _gameActions;


        // Properties
        public PlayerType PlayerType { get => _playerType; protected set => _playerType = value; }
        public EndGameState CurrentEndGameState { get => _currentEndGameState; protected set => _currentEndGameState = value; }

        public int? LastChosenAction { get => _lastChosenAction; protected set => _lastChosenAction = value; }
        public List<int> GameActions { get => _gameActions; protected set => _gameActions = value; }


        // Ctor
        public Player(PlayerType playerType)
        {
            this.PlayerType = playerType;
            this.CurrentEndGameState = EndGameState.None;

            this.LastChosenAction = null;
            this.GameActions = new List<int>();
        }


        // Methods
        /// <summary>
        /// Prepares the player for a new game
        /// </summary>
        public void PrepareForNewGame()
        {
            ChangeCurrentEndGameState(EndGameState.None);
            EmptyActionList();
            NullLastChosenAction();
        }

        /// <summary>
        /// Changes the current end game state
        /// </summary>
        /// <param name="newEndGameState">New end game state</param>
        public void ChangeCurrentEndGameState(EndGameState newEndGameState)
        {
            this.CurrentEndGameState = newEndGameState;
        }

        /// <summary>
        /// Updates last chosen action and adds it to the list
        /// </summary>
        /// <param name="action">new last chosen action</param>
        public void UpdateLastChosenAction(int action)
        {
            this.LastChosenAction = action;

            AddActionToList();
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
        private void EmptyActionList()
        {
            this.GameActions.Clear();
        }

        /// <summary>
        /// Nulls the last chosen action
        /// </summary>
        private void NullLastChosenAction()
        {
            this.LastChosenAction = null;
        }

        /// <summary>
        /// Return whether the player is a winner or not
        /// </summary>
        /// <remarks>
        /// The player not being the winner doesn't imply that he's the loser, he could be neither one
        /// </remarks>
        /// <returns>True if the player is a winner, else false</returns>
        public bool IsTheWinner()
        {
            return this.CurrentEndGameState == EndGameState.Winner;
        }

        /// <summary>
        /// Return whether the player is a loser or not
        /// </summary>
        /// <remarks>
        /// The player not being the loser doesn't imply that he's the winner, he could be neither one
        /// </remarks>
        /// <returns>True if the player is a loser, else false</returns>
        public bool IsTheLoser()
        {
            return this.CurrentEndGameState == EndGameState.Loser;
        }

        public abstract string GetName();

        public override string ToString()
        {
            string result = this.GetName();

            return result;
        }
    }
}
