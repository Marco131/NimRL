﻿using System;
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
        public int GetAction(int matchesNb)
        {
            // todo implement GetAction
            return 0;
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