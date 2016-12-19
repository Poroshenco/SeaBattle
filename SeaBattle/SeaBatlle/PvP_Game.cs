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
    public partial class PvP_Game : Form
    {
        private CellType[,] FirstPlayerField;
        private CellType[,] SecondPlayerField;

        private bool FirstPlayerTurn;
        private int CELL;

        public PvP_Game(CellType[,] map_1, CellType[,] map_2)
        {
            InitializeComponent();

            Random rand = new Random();
            FirstPlayerTurn = rand.Next(0, 2) == 0;
            CELL = 300 / Login.MAP_SIZE;

            FirstPlayerField = map_1;
            SecondPlayerField = map_2;

            FirstNickname.Text = PvP_EnterNicknames.FirstPlayerNickname + " field:";
            SecondNickname.Text = PvP_EnterNicknames.SecondPlayerNickname + " field:";

            FirstPlayerPicture.Image = FirstPlayerField.DrawMap(false);
            SecondPlayerPicture.Image = SecondPlayerField.DrawMap(false);
        }

        private void FirstPlayerPicture_MouseDown(object sender, MouseEventArgs e)
        {
            if (FirstPlayerTurn)
            {
                int x = e.X/CELL;
                int y = e.Y/CELL;

                FirstPlayerField[x, y] = FirstPlayerField[x, y].CheckCell();

                if (FirstPlayerField[x, y] == CellType.Missed)
                    FirstPlayerTurn = false;

                FirstPlayerField.IsKilled();
                FirstPlayerPicture.Image = FirstPlayerField.DrawMap(false);
            }
        }

        private void SecondPlayerPicture_MouseDown(object sender, MouseEventArgs e)
        {
            if (!FirstPlayerTurn)
            {
                int x = e.X / CELL;
                int y = e.Y / CELL;

                SecondPlayerField[x, y] = SecondPlayerField[x, y].CheckCell();

                if (SecondPlayerField[x, y] == CellType.Missed)
                    FirstPlayerTurn = true;

                SecondPlayerField.IsKilled();
                SecondPlayerPicture.Image = SecondPlayerField.DrawMap(false);
            }
        }
    }
}
