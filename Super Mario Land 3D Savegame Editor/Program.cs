using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Super_Mario_Land_3D_Savegame_Editor
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SM3DL_SGE());
        }
    }
}
