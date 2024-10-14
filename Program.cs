using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Control_Gym.Capa_de_presentacion;
using libzkfpcsharp;


namespace Control_Gym
{
    internal static class Program
    {
        public static bool isRegistering { get; set; } = false;
        public static bool isIdentifying { get; set; } = true;
        public static int idSocioSeleccionado { get; set; } = -1;
        public static zkfp fpInstance { get; set; } = new zkfp();
        public static int RegisterCount { get; set; } = 0;
        public static int REGISTER_FINGER_COUNT {get; set;} = 3;

        public static byte[][] RegTmps { get; set; } = new byte[REGISTER_FINGER_COUNT][];
        public static byte[] CapTmp { get; set; } = new byte[2048];


        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);            
            Application.Run(new FormContenedor2());
        }
    }
}
