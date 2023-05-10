using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NimRL.Classes.Model.AI;

namespace NimRL.Classes.Model.Player
{
    public class Robot : Player
    {
        // Constants
        public const string NAME = "Robot";
        private const PlayerType _TYPE = PlayerType.Robot;


        // Fields
        private Agent _agent;


        // Properties
        public Agent Agent { get => _agent; private set => _agent = value; }


        // Ctor
        public Robot(Agent agent) : base(_TYPE)
        {
            this.Agent = agent;
        }


        // Methods
        /// <summary>
        /// Gets an action from the agent
        /// </summary>
        /// <param name="matchesNb"></param>
        /// <returns>Action</returns>
        public int GetAction(int matchesNb)
        {
            int action = this.Agent.GetAction(matchesNb);
            return action;
        }


        /// <summary>
        /// Gets the name of the class
        /// </summary>
        /// <returns>Name of the class</returns>
        public override string GetName()
        {
            return Robot.NAME;
        }
    }
}
