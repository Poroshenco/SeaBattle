using System;
using System.Windows.Forms;
using SeaBattle.Lib;

namespace SeaBatlle
{
    public partial class PvP_Game : Form
    {
        private readonly CellType[,] __FirstPlayerField;

        private bool __FirstPlayerTurn;
        private readonly CellType[,] __SecondPlayerField;
        private readonly int CELL;

        public PvP_Game(CellType[,] map_1, CellType[,] map_2)
        {
            InitializeComponent();

            var rand = new Random();
            __FirstPlayerTurn = rand.Next(0, 2) == 0;

            Walketh.Image = Draw.Arrow(__FirstPlayerTurn);

            CELL = 300/Login.MAP_SIZE;

            __FirstPlayerField = map_1;
            __SecondPlayerField = map_2;

            FirstNickname.Text = PvP_EnterNicknames.FirstPlayerNickname + " field:";
            SecondNickname.Text = PvP_EnterNicknames.SecondPlayerNickname + " field:";

            FirstPlayerPicture.Image = __FirstPlayerField.DrawMap(false);
            SecondPlayerPicture.Image = __SecondPlayerField.DrawMap(false);
        }

        private void FirstPlayerPicture_MouseDown(object sender, MouseEventArgs e)
        {
            if (!__FirstPlayerTurn)
            {
                var x = e.X/CELL;
                var y = e.Y/CELL;

                if (!__FirstPlayerField[x, y].Shooted())
                {
                    __FirstPlayerField[x, y] = __FirstPlayerField[x, y].CheckCell();

                    if (__FirstPlayerField[x, y] == CellType.Missed)
                        __FirstPlayerTurn = true;

                    __FirstPlayerField.IsKilled();
                    FirstPlayerPicture.Image = __FirstPlayerField.DrawMap(false);
                }
            }

            Walketh.Image = Draw.Arrow(__FirstPlayerTurn);
        }

        private void SecondPlayerPicture_MouseDown(object sender, MouseEventArgs e)
        {
            if (__FirstPlayerTurn)
            {
                var x = e.X/CELL;
                var y = e.Y/CELL;

                if (!__SecondPlayerField[x, y].Shooted())
                {
                    __SecondPlayerField[x, y] = __SecondPlayerField[x, y].CheckCell();

                    if (__SecondPlayerField[x, y] == CellType.Missed)
                        __FirstPlayerTurn = false;

                    __SecondPlayerField.IsKilled();
                    SecondPlayerPicture.Image = __SecondPlayerField.DrawMap(false);
                }
            }

            Walketh.Image = Draw.Arrow(__FirstPlayerTurn);
        }
    }
}