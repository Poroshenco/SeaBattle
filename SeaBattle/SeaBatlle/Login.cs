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
        private readonly List<string> nicknames;

        public static bool BotEnable = true;
        public static bool OnLanEnable;
        public static bool PvPEnable;

        public Login()
        {
            InitializeComponent();

            nicknames = new List<string>();

            using (StreamReader sr = new StreamReader("Nicknames.txt"))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                    nicknames.Add(s);
            }
        }

        private void RAND_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            Nickname.Text = nicknames[rand.Next(0, nicknames.Count)];
        }

        private void Lan_Click(object sender, EventArgs e)
        {
            Next.Enabled = true;
        }

        private void Next_Click(object sender, EventArgs e)
        {
            if ((Nickname.Text != "" && Nickname.Text.IndexOf(" ") == -1) || BotEnable)
            {
                Build build = new Build();

                this.Hide();
                build.Show();
            }
        }

        private void VsBot_Click(object sender, EventArgs e)
        {
            BotEnable = true;
            PvPEnable = false;
            OnLanEnable = false;
            Next.Enabled = true;
        }
    }
}
