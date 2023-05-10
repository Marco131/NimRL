using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using NimRL.Classes.Model.Player;
using NimRL.Classes.Model.AI;

namespace NimRL.Classes.Controller
{
    public class AIController
    {
        // Constants
        // todo optimized choices const list
        private const int _INITIAL_ROUNDS_NB = 0;

        // Fields
        private int _roundsNb;
        private Agent _agent;


        // Properties
        public int RoundsNb { get => _roundsNb; private set => _roundsNb = value; }
        public Agent Agent { get => _agent; private set => _agent = value; }


        // Ctor
        public AIController()
        {
            this.RoundsNb = AIController._INITIAL_ROUNDS_NB;

            this.Agent = new Agent();
        }


        // Methods
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

        /// <summary>
        /// Calls the agent to give reinforcement for the actions of a round, increments the number of rounds
        /// </summary>
        /// <param name="loserActions">List of actions from the player that lost</param>
        /// <param name="winnerActions">List of actions from the player that won</param>
        public void RequestReinforcementUpdate(int[] loserActions, int[] winnerActions)
        {
            this.Agent.GiveReinforcement(loserActions, winnerActions);

            this.RoundsNb += 1;
        }
    }
}
