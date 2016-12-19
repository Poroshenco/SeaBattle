using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
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

                Build build = new Build();
                build.Show();
                this.Hide();
            }
        }
    }
}
