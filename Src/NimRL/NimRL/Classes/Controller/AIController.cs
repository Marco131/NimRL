using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using NimRL.Classes.Model.Player;

namespace NimRL.Classes.Controller
{
    public class AIController
    {
        // Constants
        // todo optimized choices const list
        private const int _DEFAULT_ROUNDS_NB = 0;

        // Fields
        private Player _player1;
        private Player _player2;

        private int _roundsNb;
        //private Agent _agent;


        // Properties
        public Player Player1 { get => _player1; private set => _player1 = value; }
        public Player Player2 { get => _player2; private set => _player2 = value; }

        public int RoundsNb { get => _roundsNb; private set => _roundsNb = value; }
        //public Agent Agent { get => _agent; private set => _agent = value; }


        // Ctor
        public AIController(Player player1, Player player2)
        {
            this.Player1 = player1;
            this.Player2 = player2;

            this.RoundsNb = AIController._DEFAULT_ROUNDS_NB;
            // todo instantiate Agent
        }


        // Methods
        public string GetActionState()
        {
            // todo implement GetActionState
            return "";
        }

        public Dictionary<int, Dictionary<int, float>> GetActionValues()
        {
            // todo implement GetActionValues
            return new Dictionary<int, Dictionary<int, float>>();
        }

        public float CalculateLearningPercentage()
        {
            // todo implement CalculateLearningPercentage
            return 0;
        }


        public void RequestReinforcementUpdate()
        {
            // todo implement RequestReinforcementUpdate
        }
    }
}
