// todo make the game controller independent of the players' enums
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using NimRL.Classes.Model.Player;
using NimRL.Classes.Model.AI;

namespace NimRL.Classes.Controller
{
    public class GameController
    {
        // Constants
        private const int _DEFAULT_PLAYER = 1;
        private const int _MATCHES_NB = 20;


        // Fields
        private AIController _aiController;

        private Player _player1;
        private Player _player2;
        private int _currentPlayerNb;

        private int _matchesNb;
        private bool _hasGameEnded;

        // Properties
        private AIController _AIController { get => _aiController; set => _aiController = value; }

        public Player Player1 { get => _player1; private set => _player1 = value; }
        public Player Player2 { get => _player2; private set => _player2 = value; }
        public int CurrentPlayerNb { get => _currentPlayerNb; private set => _currentPlayerNb = value; }

        private int _MatchesNb { 
            get => _matchesNb;
            set { 
                if(value < 0)
                {
                    value = 0;
                }

                _matchesNb = value;
            } 
        }
        public bool HasGameEnded { get => _hasGameEnded; private set => _hasGameEnded = value; }


        // Ctor
        public GameController(Player initialPlayer1, Player initialPlayer2, AIController aiController)
        {
            this.Player1 = initialPlayer1;
            this.Player2 = initialPlayer2;

            this._AIController = aiController;

            PrepareGame();
        }


        // Methods
        /// <summary>
        /// Makes a certain player a Robot
        /// </summary>
        /// <param name="playerNb">Player to turn to Robot</param>
        /// <param name="agent">Robot's agent</param>
        public void MakePlayerRobot(int playerNb, Agent agent)
        {
            if (playerNb == 1)
            {
                this.Player1 = new Robot(agent);
            }
            else if (playerNb == 2)
            {
                this.Player2 = new Robot(agent);
            }
        }

        /// <summary>
        /// Make a certain player a Human
        /// </summary>
        /// <param name="playerNb">Player to turn to Human</param>
        public void MakePlayerHuman(int playerNb)
        {
            if (playerNb == 1)
            {
                this.Player1 = new Human();
            }
            else if (playerNb == 2)
            {
                this.Player2 = new Human();
            }
        }

        /// <summary>
        /// Sets up the values for a game
        /// </summary>
        public void PrepareGame()
        {
            this.HasGameEnded = false;

            this.CurrentPlayerNb = GameController._DEFAULT_PLAYER;
            this._MatchesNb = GameController._MATCHES_NB;

            // prepare players
            this.Player1.PrepareForNewGame();
            this.Player2.PrepareForNewGame();

            // if the first player is a robot request action
            Player currentPlayer = GetCurrentPlayer();
            if (currentPlayer.PlayerType == PlayerType.Robot)
            {
                RequestRobotAction(currentPlayer as Robot);
            }
        }

        public void EndGamePreventively()
        {
            this.HasGameEnded = true;
            this._MatchesNb = 0;
        }

        /// <summary>
        /// Get the number of matches left on the ongoing game
        /// </summary>
        /// <returns>Number of matches left</returns>
        public int GetMatchesNb()
        {
            return this._MatchesNb;
        }

        /// <summary>
        /// Returns the players' types as strings
        /// </summary>
        /// <returns>Players' types in a string array</returns>
        public string[] GetPlayersTypes()
        {
            string[] types = new string[]
            {
                this.Player1.GetName(),
                this.Player2.GetName()
            };

            return types;
        }

        /// <summary>
        /// Returns the players' last actions
        /// </summary>
        /// <returns>Players' last actions in an int array</returns>
        public int?[] GetPlayersLastAction()
        {
            int?[] actions = new int?[]
            {
                this.Player1.LastChosenAction,
                this.Player2.LastChosenAction
            };

            return actions;
        }

        /// <summary>
        /// Return the players' actions for the current game
        /// </summary>
        /// <returns>Players' actions for the current game in an array of int arrays</returns>
        public int[][] GetPlayersGameActions()
        {
            int[][] playersGameActions = new int[][]
            {
                this.Player1.GameActions.ToArray(),
                this.Player2.GameActions.ToArray()
            };

            return playersGameActions;
        }

        /// <summary>
        /// Returns true if the current game is played between two robots, else false
        /// </summary>
        /// <returns>Is the current game is played between two robots</returns>
        public bool IsRvR()
        {
            bool isRvR = false;

            if (this.Player1.PlayerType == PlayerType.Robot && this.Player2.PlayerType == PlayerType.Robot)
            {
                isRvR = true;
            }

            return isRvR;
        }

        /// <summary>
        /// Returns the current player
        /// </summary>
        /// <returns>Current player</returns>
        public Player GetCurrentPlayer()
        {
            Player player;

            if (this.CurrentPlayerNb == 1)
            {
                player = this.Player1;
            }
            else
            {
                player = this.Player2;
            }

            return player;
        }

        /// <summary>
        /// Changes the current player
        /// </summary>
        public void ChangeCurrentPlayer()
        {
            if (this.CurrentPlayerNb == 1)
            {
                this.CurrentPlayerNb = 2;
            }
            else
            {
                this.CurrentPlayerNb = 1;
            }
        }

        /// <summary>
        /// Returns the player that has won the game
        /// </summary>
        /// <returns>Player that has won</returns>
        /// <exception cref="Exception">Throws an exception if the game hasn't ended</exception>
        public Player GetWinner()
        {
            if (this.HasGameEnded)
            {
                Player winner;

                if (this.Player1.CurrentEndGameState == EndGameState.Winner)
                {
                    winner = this.Player1;
                }
                else // player2
                {
                    winner = this.Player2;
                }

                return winner;
            }
            else
            {
                throw new Exception("There's no winner yet, the game hasn't ended");
            }
        }

        /// <summary>
        /// Returns the player that has lost the game
        /// </summary>
        /// <returns>Player that has lost</returns>
        /// <exception cref="Exception">Throws an exception if the game hasn't ended</exception>
        public Player GetLoser()
        {
            if (this.HasGameEnded)
            {
                Player loser;

                if (this.Player1.CurrentEndGameState == EndGameState.Loser)
                {
                    loser = this.Player1;
                }
                else // player2
                {
                    loser = this.Player2;
                }

                return loser;
            }
            else
            {
                throw new Exception("There's no loser yet, the game hasn't ended");
            }
        }


        public void PlayGameAutomatically(int nbOfGames)
        {
            if (IsRvR())
            {
                for (int i = 0; i < nbOfGames; i++)
                {
                    PrepareGame();

                    RequestRobotAction(GetCurrentPlayer() as Robot);
                }
            }
            else
            {
                throw new Exception("Automatic games are only possible between two robots");
            }
        }
        
        public void ContinuePlaying(int matches)
        {
            if (!this.HasGameEnded)
            {
                PickMatches(GetCurrentPlayer(), matches);

                ChangeCurrentPlayer();

                // check if game has ended
                if (this._MatchesNb == 0)
                {
                    EndGame();
                }
                else
                {
                    Player currentPlayer = GetCurrentPlayer();
                    if (currentPlayer.PlayerType == PlayerType.Robot)
                    {
                        RequestRobotAction(currentPlayer as Robot);
                    }

                    // else wait until the human player plays
                }
            }
        }

        private void EndGame()
        {
            this.HasGameEnded = true;

            if (GetCurrentPlayer() == this.Player1)
            {
                this.Player1.ChangeCurrentEndGameState(EndGameState.Winner);
                this.Player2.ChangeCurrentEndGameState(EndGameState.Loser);
            }
            else
            {
                this.Player1.ChangeCurrentEndGameState(EndGameState.Loser);
                this.Player2.ChangeCurrentEndGameState(EndGameState.Winner);
            }

            // Update AI
            int[][] playersGameActions = GetPlayersGameActions();
            if (playersGameActions.Length == 2)
            {
                int[] p1GameAction = playersGameActions[0];
                int[] p2GameAction = playersGameActions[1];
                this._AIController.RequestReinforcementUpdate(p1GameAction, p2GameAction);
            }
        }

        /// <summary>
        /// Deducts the player's matches and updates their last chosen action
        /// </summary>
        /// <param name="player">Player that picked the matches</param>
        /// <param name="matchesToDeduct"></param>
        private void PickMatches(Player player, int matchesToDeduct)
        {
            this._MatchesNb -= matchesToDeduct;

            player.UpdateLastChosenAction(matchesToDeduct);
        }

        private void RequestRobotAction(Robot robot)
        {
            int action = robot.GetAction(this._MatchesNb);

            ContinuePlaying(action);
        }
    }
}
