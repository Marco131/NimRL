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
        private const int _DEFAULT_ROUNDS_NB = 0;

        // Fields
        private int _roundsNb;
        private Agent _agent;


        // Properties
        public int RoundsNb { get => _roundsNb; private set => _roundsNb = value; }
        public Agent Agent { get => _agent; private set => _agent = value; }


        // Ctor
        public AIController()
        {
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


        public void RequestReinforcementUpdate(int[] p1Actions, int[] p2Actions)
        {
            // todo implement RequestReinforcementUpdate
        }
    }
}
