using System;
using System.Windows.Forms;

namespace SeaBatlle
{
    public partial class PvP_EnterNicknames : Form
    {
        public static string FirstPlayerNickname;
        public static string SecondPlayerNickname;

        public PvP_EnterNicknames()
        {
            InitializeComponent();
        }

        private void Next_Click(object sender, EventArgs e)
        {
            if (FirstNickname.Text != "" && SecondNickname.Text != "")
            {
                FirstPlayerNickname = FirstNickname.Text;
                SecondPlayerNickname = SecondNickname.Text;

                var build = new Build();
                build.Show();
                Hide();
            }
        }
    }
}