using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gsitool
{
    static class Program
    {

        public static ConfigData config;
        public static GSIManager GsiManager;
        public static PlayerSeatNode[] playerSeats = new PlayerSeatNode[10];

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (config == null)
            {
                config = new ConfigData();
                config.Load();
            }
            for (int i = 0; i < 10; i++)
            {
                PlayerSeatNode seat = new PlayerSeatNode
                {
                    Name = "",
                    SteamID = "",
                    SeatNumber = i + 1
                };
                playerSeats[i] = seat;
            }
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit);
            GsiManager = new GSIManager(config);
            Sender sender = new Sender(config.listeners);
            GsiManager.OnGameStateReceived += sender.OnNewData;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GsitoolForm());
        }

        static void OnProcessExit(object sender, EventArgs e)
        {
            config.Save();
            GsiManager.Stop();
        }
    }
}
