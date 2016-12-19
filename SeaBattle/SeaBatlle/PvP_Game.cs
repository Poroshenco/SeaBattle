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
        private CellType[,] __FirstPlayerField;
        private CellType[,] __SecondPlayerField;

        private bool __FirstPlayerTurn;
        private int CELL;

        public PvP_Game(CellType[,] map_1, CellType[,] map_2)
        {
            InitializeComponent();

            Random rand = new Random();
            __FirstPlayerTurn = rand.Next(0, 2) == 0;

            Walketh.Image = Draw.Arrow(__FirstPlayerTurn);

            CELL = 300 / Login.MAP_SIZE;

            __FirstPlayerField = map_1;
            __SecondPlayerField = map_2;

            FirstNickname.Text = PvP_EnterNicknames.FirstPlayerNickname + " field:";
            SecondNickname.Text = PvP_EnterNicknames.SecondPlayerNickname + " field:";

            FirstPlayerPicture.Image = __FirstPlayerField.DrawMap(false);
            SecondPlayerPicture.Image = __SecondPlayerField.DrawMap(false);
        }

        private void FirstPlayerPicture_MouseDown(object sender, MouseEventArgs e)
        {
            if (__FirstPlayerTurn)
            {
                int x = e.X / CELL;
                int y = e.Y / CELL;

                if (!__FirstPlayerField[x, y].Shooted())
                {
                    __FirstPlayerField[x, y] = __FirstPlayerField[x, y].CheckCell();

                    if (__FirstPlayerField[x, y] == CellType.Missed)
                        __FirstPlayerTurn = false;

                    __FirstPlayerField.IsKilled();
                    FirstPlayerPicture.Image = __FirstPlayerField.DrawMap(false);
                }
            }

            Walketh.Image = Draw.Arrow(__FirstPlayerTurn);
        }

        private void SecondPlayerPicture_MouseDown(object sender, MouseEventArgs e)
        {
            if (!__FirstPlayerTurn)
            {
                int x = e.X / CELL;
                int y = e.Y / CELL;

                if (!__SecondPlayerField[x, y].Shooted())
                {
                    __SecondPlayerField[x, y] = __SecondPlayerField[x, y].CheckCell();

                    if (__SecondPlayerField[x, y] == CellType.Missed)
                        __FirstPlayerTurn = true;

                    __SecondPlayerField.IsKilled();
                    SecondPlayerPicture.Image = __SecondPlayerField.DrawMap(false);
                }
            }

            Walketh.Image = Draw.Arrow(__FirstPlayerTurn);
        }
    }
}
