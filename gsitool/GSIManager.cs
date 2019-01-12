using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSGSI;
using CSGSI.Nodes;
using System.Diagnostics;

namespace gsitool
{
    class GSIManager
    {
        public event EventHandler<DataEventArgs> OnGameStateReceived;
        public List<PlayerNode> players;

        GameStateListener gsl;
        NewGameStateHandler gameStateHandler;
        string bindIPAddress = "localhost";
        int bindPort = 3000;

        public GSIManager()
        {
            Initialize();
        }

        public GSIManager(ConfigData configData)
        {
            bindIPAddress = configData.bindIP;
            bindPort = configData.bindPort;
            Initialize();
        }

        public void Stop()
        {
            gsl.Stop();
        }

        void Initialize()
        {
            if (bindIPAddress.Equals("localhost", StringComparison.InvariantCultureIgnoreCase))
            {
                gsl = new GameStateListener(3000);
            }
            else
            {
                gsl = new GameStateListener("http://" + bindIPAddress + ":" + bindPort.ToString() + "/");
            }

            gameStateHandler = new NewGameStateHandler(OnNewGameState);
            gsl.NewGameState += gameStateHandler;
            gsl.EnableRaisingIntricateEvents = true;
            gsl.Start();
        }

        void OnNewGameState(GameState gs)
        {
            players = gs.AllPlayers.PlayerList as List<PlayerNode>;
            DataEventArgs args = new DataEventArgs
            {
                Data = gs
            };
            OnGameStateReceived?.Invoke(this,args);
        }
    }
}
