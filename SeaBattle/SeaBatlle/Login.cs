using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SeaBatlle
{
    public partial class Login : Form
    {
        public static int MAP_SIZE;
        public static int Linkors;
        public static int AirCrafters;
        public static int Cruisers;
        public static int Esmineces;

        public static bool BotEnable;
        public static bool OnLanEnable;
        public static bool PvPEnable;

        public Login()
        {
            InitializeComponent();
            
            StreamReader sr = new StreamReader("Settings.txt");

            MAP_SIZE = int.Parse(sr.ReadLine());
            Linkors = int.Parse(sr.ReadLine());
            AirCrafters = int.Parse(sr.ReadLine());
            Cruisers = int.Parse(sr.ReadLine());
            Esmineces = int.Parse(sr.ReadLine());

            sr.Close();
        }
        
        private void VsBot_Click(object sender, EventArgs e)
        {
            BotEnable = true;
            PvPEnable = false;
            OnLanEnable = false;

            Build build = new Build();
            build.Show();

            SaveSettings();
            this.Hide();
        }

        private void PVP_Click(object sender, EventArgs e)
        {
            BotEnable = false;
            PvPEnable = true;
            OnLanEnable = false;

            PvP_EnterNicknames pvp = new PvP_EnterNicknames();
            pvp.Show();
            this.Hide();
        }

        private void Lan_Click(object sender, EventArgs e)
        {
            BotEnable = false;
            PvPEnable = false;
            OnLanEnable = true;
            

        }

        private void MapSettings_Click(object sender, EventArgs e)
        {
            Map_Settings ms = new Map_Settings();

            ms.Show();
        }

        private void SaveSettings()
        {
            StreamWriter sw = new StreamWriter("Settings.txt");
            sw.WriteLine(MAP_SIZE);
            sw.WriteLine(Linkors);
            sw.WriteLine(AirCrafters);
            sw.WriteLine(Cruisers);
            sw.WriteLine(Esmineces);
            sw.Close();
        }
    }
}
