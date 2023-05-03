using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using NimRL.Classes.Model.Player;

namespace NimRL.Classes.Controller
{
    public class GameController
    {
        // Constants
        private const int _DEFAULT_PLAYER = 1;
        private const int _MATCHES_NB = 20;


        // Fields
        private Player _player1;
        private Player _player2;
        private int _currentPlayer;

        private int _matchesNb;
        private bool _hasGameEnded;

        // Properties
        public Player Player1 { get => _player1; private set => _player1 = value; }
        public Player Player2 { get => _player2; private set => _player2 = value; }
        public int CurrentPlayer { get => _currentPlayer; private set => _currentPlayer = value; }

        private int _MatchesNb { get => _matchesNb; set => _matchesNb = value; }
        public bool HasGameEnded { get => _hasGameEnded; private set => _hasGameEnded = value; }


        // Ctor
        public GameController(Player initialPlayer1, Player initialPlayer2)
        {
            this.Player1 = initialPlayer1;
            this.Player2 = initialPlayer2;

            PrepareGame();
        }


        // Methods
        public void UpdatePlayerTypes(PlayerType p1Type, PlayerType p2Type)
        {
            // todo implement UpdatePlayerTypes
        }

        public void UpdatePlayer1Type(PlayerType type)
        {
            // todo implement UpdatePlayer1Type
        }

        public void UpdatePlayer2Type(PlayerType type)
        {
            // todo implement UpdatePlayer2Type
        }


        public void PrepareGame()
        {
            this.HasGameEnded = false;

            this.CurrentPlayer = GameController._DEFAULT_PLAYER;
            this._MatchesNb = GameController._MATCHES_NB;

            this.Player1.ChangeCurrentEndGameState(EndGameState.None);
            this.Player2.ChangeCurrentEndGameState(EndGameState.None);
        }

        /// <summary>
        /// Get the number of matches left on the ongoing game
        /// </summary>
        /// <returns>Number of matches left</returns>
        /// <exception cref="Exception">Thrown if the game is not ongoing</exception>
        public int GetMatchesNb()
        {
            if (!this.HasGameEnded)
            {
                return this._MatchesNb;
            }
            else
            {
                throw new Exception("The game is not ongoing");
            }
        }

        public string[] GetPlayersType()
        {
            // todo implement GetPlayersType
            return new string[2];
        }

        public int[] GetPlayersLastAction()
        {
            // todo implement GetPlayersLastAction
            return new int[2];
        }

        public List<int>[] GetPlayersGameAction()
        {
            // todo implement GetPlayersGameAction
            return new List<int>[2];
        }
        
        public bool IsRvR()
        {
            // todo implement IsRvR
            return true;
        }

        public Player GetWinner()
        {
            // todo implement GetWinner
            return null;
        }

        public Player GetLoser()
        {
            // todo implement GetLoser
            return null;
        }


        public void PlayGameAutomatically(int nbOfGames)
        {
            // todo implement PlayGameAutomatically
        }
        
        public void ContinuePlaying(int matches)
        {
            // todo implement ContinuePlaying

            System.Diagnostics.Debug.WriteLine(matches);
        }

        private void RequestRobotAction()
        {
            // todo implement RequestRobotAction
        }
    }
}
