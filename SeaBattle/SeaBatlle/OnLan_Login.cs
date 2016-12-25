using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace SeaBatlle
{
    public partial class OnLan_Login : Form
    {
        public static string Nickname;
        public static string Ip;
        private readonly List<string> __Nicknames;

        public OnLan_Login()
        {
            InitializeComponent();

            __Nicknames = new List<string>();

            ServerIp.Text = "192.168.0.103";

            using (var sr = new StreamReader("Nicknames.txt"))
            {
                string str = null;
                while ((str = sr.ReadLine()) != null)
                    __Nicknames.Add(str);
            }
        }

        private void RandomNickname_Click(object sender, EventArgs e)
        {
            var rand = new Random();
            PlayerNickname.Text = __Nicknames[rand.Next(0, __Nicknames.Count)];
        }

        private void Next_Click(object sender, EventArgs e)
        {
            if (PlayerNickname.Text != "" && PlayerNickname.Text.IndexOf(" ") == -1)
            {
                var build = new Build();
                Nickname = PlayerNickname.Text;
                Ip = ServerIp.Text;
                build.Show();
                Hide();
            }
        }
    }
}