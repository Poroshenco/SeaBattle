using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeaBatlle
{
    public partial class Map_Settings : Form
    {
        public Map_Settings()
        {
            InitializeComponent();

            _MapSize.Text = Login.MAP_SIZE.ToString();
            _Linkors.Text = Login.Linkors.ToString();
            _AirCrafters.Text = Login.AirCrafters.ToString();
            _Cruisers.Text = Login.Cruisers.ToString();
            _Esmineces.Text = Login.Esmineces.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (300 % int.Parse(_MapSize.Text) == 0 && int.Parse(_MapSize.Text) >= 10)
            {
                Login.MAP_SIZE = int.Parse(_MapSize.Text);
                Login.Linkors = int.Parse(_Linkors.Text);
                Login.AirCrafters = int.Parse(_AirCrafters.Text);
                Login.Cruisers = int.Parse(_Cruisers.Text);
                Login.Esmineces = int.Parse(_Esmineces.Text);
                this.Close();
            }
            else
            {
                MessageBox.Show("Incorrect format of map size");
            }
        }
    }
}
