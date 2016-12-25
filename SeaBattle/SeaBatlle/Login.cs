using System;
using System.IO;
using System.Windows.Forms;

namespace SeaBatlle
{
    public enum Mode
    {
        OnLan,
        VsBot,
        TwoPlayes
    }

    public partial class Login : Form
    {
        public static int MAP_SIZE;
        public static int Linkors;
        public static int AirCrafters;
        public static int Cruisers;
        public static int Esmineces;

        public static Mode GameMode;

        public Login()
        {
            InitializeComponent();

            var sr = new StreamReader("Settings.txt");

            MAP_SIZE = int.Parse(sr.ReadLine());
            Linkors = int.Parse(sr.ReadLine());
            AirCrafters = int.Parse(sr.ReadLine());
            Cruisers = int.Parse(sr.ReadLine());
            Esmineces = int.Parse(sr.ReadLine());

            sr.Close();
        }

        private void VsBot_Click(object sender, EventArgs e)
        {
            GameMode = Mode.VsBot;

            var build = new Build();
            build.Show();

            SaveSettings();
            Hide();
        }

        private void PVP_Click(object sender, EventArgs e)
        {
            GameMode = Mode.TwoPlayes;

            var pvp = new PvP_EnterNicknames();
            pvp.Show();

            SaveSettings();
            Hide();
        }

        private void Lan_Click(object sender, EventArgs e)
        {
            GameMode = Mode.OnLan;

            var onlan_login = new OnLan_Login();
            onlan_login.Show();

            SaveSettings();
            Hide();
        }

        private void MapSettings_Click(object sender, EventArgs e)
        {
            var ms = new Map_Settings();

            ms.Show();
        }

        private void SaveSettings()
        {
            var sw = new StreamWriter("Settings.txt");
            sw.WriteLine(MAP_SIZE);
            sw.WriteLine(Linkors);
            sw.WriteLine(AirCrafters);
            sw.WriteLine(Cruisers);
            sw.WriteLine(Esmineces);
            sw.Close();
        }
    }
}