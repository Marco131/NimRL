using NimRL.Classes.Controller;
using NimRL.Classes.Model.AI;
using NimRL.Classes.Model.Player;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NimRL.Classes
{
    [Serializable]
    public class BackupManager
    {
        // Fields
        // Ai Controller
        // Agent
        public int roundsNb;

        // Policy
        public int[] policyMapKeys;
        public int[] policyMapActions;
        public int[] policyMapValues;


        // Game Controller
        // Player1
        public PlayerType p1PlayerType;
        public EndGameState p1CurrentEndGameState;

        public int? p1LastChosenAction;
        public List<int> p1GameActions;

        // Player2
        public PlayerType p2PlayerType;
        public EndGameState p2CurrentEndGameState;

        public int? p2LastChosenAction;
        public List<int> p2GameActions;


        public int currentPlayerNb;

        public int matchesNb;
        public bool hasGameEnded;
        

        // Ctor
        public BackupManager() {}


        // Methods
        public void Serialize(AIController aiController, GameController gameController)
        {
            this.roundsNb = aiController.Agent.RoundsNb;
            
            Dictionary<int, Dictionary<int, int>> valuesMapByMatchesNb = aiController.Agent.GetValuesMapByMatchesNb();
            this.policyMapKeys = valuesMapByMatchesNb.Keys.ToArray();

            List<int> policyMapActionList = new List<int>();
            List<int> policyMapValueList = new List<int>();
            foreach (Dictionary<int, int> valueByActionDict in valuesMapByMatchesNb.Values)
            {
                policyMapActionList.AddRange(valueByActionDict.Keys);
                policyMapValueList.AddRange(valueByActionDict.Values);
            }

            this.policyMapActions = policyMapActionList.ToArray();
            this.policyMapValues = policyMapValueList.ToArray();

            this.p1PlayerType = gameController.Player1.PlayerType;
            this.p1CurrentEndGameState = gameController.Player1.CurrentEndGameState;

            this.p1LastChosenAction = gameController.Player1.LastChosenAction;
            this.p1GameActions = gameController.Player1.GameActions;

            this.p2PlayerType = gameController.Player2.PlayerType;
            this.p2CurrentEndGameState = gameController.Player2.CurrentEndGameState;

            this.p2LastChosenAction = gameController.Player2.LastChosenAction;
            this.p2GameActions = gameController.Player2.GameActions;

            this.currentPlayerNb = gameController.CurrentPlayerNb;
            this.matchesNb = gameController.MatchesNb;
            this.hasGameEnded = gameController.HasGameEnded;


            using (StreamWriter sw = new StreamWriter("save.xml"))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(BackupManager));

                serializer.Serialize(sw, this);
            }
        }

        public void Deserialize()
        {

        }
    }
}
