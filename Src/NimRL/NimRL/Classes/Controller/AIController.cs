using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using NimRL.Classes.Model.Player;
using NimRL.Classes.Model.AI;
using System.Windows.Forms.DataVisualization.Charting;

namespace NimRL.Classes.Controller
{
    public class AIController
    {
        // Constants
        private static readonly List<int> _OPTIMIZED_CHOICES = new List<int>()
        {
            0, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3
        };
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
            const int INDIFERENT_CHOICE = 0;
            const int IMPORTANT_CHOICES_NB = 20 - (20 / 4); // use const

            float percentageSum = 0;
            Dictionary<int, Dictionary<int, int>> valuesMapByMatchesNb = this.Agent.GetValuesMapByMatchesNb();
            for (int i = 20; i >= 1; i--) // todo use const
            {
                if (valuesMapByMatchesNb.ContainsKey(i))
                {
                    Dictionary<int, int> valueByActionDict = valuesMapByMatchesNb[i];

                    int optimizedAction = AIController._OPTIMIZED_CHOICES[i-1];
                    if (optimizedAction != INDIFERENT_CHOICE)
                    {
                        // find highest valued action and it's percentage
                        KeyValuePair<int, int> highestValuedAction = valueByActionDict.ElementAt(0);
                        for (int j = 1; j < valueByActionDict.Count; j++)
                        {
                            KeyValuePair<int, int> currentAction = valueByActionDict.ElementAt(j);
                            if (currentAction.Value > highestValuedAction.Value)
                            {
                                highestValuedAction = currentAction;
                            }
                        }

                        float highestValuedActionPercentage =  (float)highestValuedAction.Value / valueByActionDict.Values.Sum();

                        percentageSum += highestValuedActionPercentage;
                    }
                }
            }

            return percentageSum / IMPORTANT_CHOICES_NB;
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
