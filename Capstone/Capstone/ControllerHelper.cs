using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone
{
    class ControllerHelper
    {
        List<Controller> AIcontrollers;
        List<Controller> playerControllers;
        private static ControllerHelper instance;
        public static ControllerHelper Instance
        {
            get
            {
                instance = (instance == null) ? new ControllerHelper() : instance;

                return instance;
            }
        }

        private ControllerHelper()
        {
            playerControllers = new List<Controller>();

            AIcontrollers = new List<Controller>();
        }

        public Controller GetPlayer(int index)
        {
            return playerControllers.ElementAt(index);
        }
        public List<Controller> GetPlayers()
        {
            return playerControllers;
        }
        public Controller GetAI(int index)
        {
            return AIcontrollers.ElementAt(index);
        }
        public List<Controller> GetAIs()
        {
            return AIcontrollers;
        }
       
       

    }
}
