using System;
using System.Drawing;
using System.Windows.Forms;
using SeaBattle.Lib;

namespace SeaBatlle
{
    public partial class Build : Form
    {
        private readonly int CELL_SIZE;
        private Map __MapTemp;
        private bool __NextPlayer;
        private bool DrawShip;
        private int dx, dy, drawX, drawY;

        private CellType[,] firstplayerfield;

        private readonly int MAP_SIZE = Login.MAP_SIZE;

        private bool Rotate = true;
        private ShipType ShipDrawType;

        public Build()
        {
            InitializeComponent();

            __MapTemp = new Map(MAP_SIZE);

            firstplayerfield = new CellType[MAP_SIZE, MAP_SIZE];

            CELL_SIZE = 300/__MapTemp.Size;
            KeyPreview = true;


            Draw();
        }

        private void Draw()
        {
            var bmp = new Bitmap(Picture.Width, Picture.Height);

            var graph = Graphics.FromImage(bmp);

            var pen = new Pen(Color.Black);

            graph.Clear(Color.White);

            graph.DrawRectangle(pen, 0, 0, 558, 359);


            for (var i = 0; i < 4; i++)
                for (var j = 0; j < 4 - i; j++)
                {
                    var X = 360 + j*CELL_SIZE;
                    var Y = 40 + Convert.ToInt32(CELL_SIZE*i*2.5);

                    var brush = GetColor(i);
                    graph.FillRectangle(brush, X, Y, CELL_SIZE, CELL_SIZE);
                    graph.DrawRectangle(pen, X, Y, CELL_SIZE, CELL_SIZE);
                }

            for (var x = 0; x < __MapTemp.Size; x++)
            {
                for (var y = 0; y < __MapTemp.Size; y++)
                {
                    var ship = __MapTemp.GetShip(x, y);

                    var brush = ship == null
                        ? new SolidBrush(Color.White)
                        : ship.Type.GetColor();

                    graph.FillRectangle(brush, x*CELL_SIZE + 30, y*CELL_SIZE + 30, CELL_SIZE, CELL_SIZE);
                }
            }

            for (var i = 0; i <= MAP_SIZE; i++)
            {
                graph.DrawLine(pen, 30 + i*CELL_SIZE, 30, 30 + i*CELL_SIZE, MAP_SIZE*CELL_SIZE + 30);
                graph.DrawLine(pen, 30, 30 + i*CELL_SIZE, MAP_SIZE*CELL_SIZE + 30, 30 + i*CELL_SIZE);
            }

            if (DrawShip)
            {
                var count = ShipDrawType.GetSize();
                var brush = ShipDrawType.GetColor();

                var tempX = drawX;
                var tempY = drawY;

                for (var i = 0; i < count; i++)
                {
                    graph.FillRectangle(brush, tempX, tempY, CELL_SIZE, CELL_SIZE);
                    graph.DrawRectangle(pen, tempX, tempY, CELL_SIZE, CELL_SIZE);

                    if (Rotate)
                        tempX += CELL_SIZE;
                    else
                        tempY += CELL_SIZE;
                }
            }

            Picture.Image = bmp;
        }

        private void AutoBuild_Click(object sender, EventArgs e)
        {
            __MapTemp = Map.BuildMap(MAP_SIZE);

            ButtonNextEnable();
            Draw();
        }

        public SolidBrush GetColor(int y)
        {
            var type = ShipTypeExtention.GetTypeOfShip(y);

            var amount = __MapTemp.GetAmountForShipType(type);

            if (ShipDrawType == type && DrawShip)
                amount--;

            if (amount <= 0)
                return new SolidBrush(Color.White);

            return type.GetColor();
        }

        private void Picture_MouseMove(object sender, MouseEventArgs e)
        {
            if (DrawShip)
            {
                if (Rotate)
                {
                    drawX = e.X - dx;
                    drawY = e.Y - dy;
                }
                if (!Rotate)
                {
                    drawX = e.X - dy;
                    drawY = e.Y - dx;
                }

                Draw();
            }
        }

        private void Build_KeyDown(object sender, KeyEventArgs e)
        {
            var rotate = e.KeyData.ToString().ToLower()[0];
            if (rotate == 'r')
            {
                if (Rotate)
                {
                    drawX = drawX + dx - dy;
                    drawY = drawY + dy - dx;
                }
                else
                {
                    drawX = drawX - dx + dy;
                    drawY = drawY + dx - dy;
                }
                Rotate = !Rotate;
            }

            Draw();
        }

        private void Clean_Click(object sender, EventArgs e)
        {
            __MapTemp = new Map(MAP_SIZE);

            ButtonNextEnable();
            Draw();
        }

        private bool CheckForEnableButtonNext()
        {
            foreach (ShipType shipType in Enum.GetValues(typeof (ShipType)))
            {
                if (__MapTemp.GetAmountForShipType(shipType) > 0)
                    return false;
            }
            return true;
        }

        private void ButtonNextEnable()
        {
            if (CheckForEnableButtonNext())
                Next.Enabled = true;
            else
            {
                Next.Enabled = false;
            }
        }

        private void Next_Click(object sender, EventArgs e)
        {
            switch (Login.GameMode)
            {
                case Mode.VsBot:
                {
                    var bot = new VsBot(__MapTemp);

                    Hide();
                    bot.Show();
                    break;
                }
                case Mode.OnLan:
                {
                    var onlan = new OnLan(__MapTemp.FillCells());
                    onlan.Show();
                    Hide();
                    break;
                }
                case Mode.TwoPlayes:
                {
                    if (__NextPlayer)
                    {
                        var pvp = new PvP_Game(firstplayerfield, __MapTemp.FillCells());

                        Hide();
                        pvp.Show();
                    }
                    if (!__NextPlayer)
                    {
                        firstplayerfield = __MapTemp.FillCells();
                        __MapTemp = new Map(MAP_SIZE);
                        __NextPlayer = true;
                        Draw();
                    }
                    break;
                }
            }
        }

        private bool OnMap(int x, int y)
        {
            return x > 30 - CELL_SIZE/2 && x < 330 - CELL_SIZE/2 && y > 30 - CELL_SIZE/2 && y < 330 - CELL_SIZE/2;
        }

        private void Picture_MouseDown(object sender, MouseEventArgs e)
        {
            var j = 4;

            int i;
            int k;

            var found = false;
            for (i = 0; i < 4; i++)
            {
                for (k = 0; k < j; k++)
                {
                    var y = 40 + Convert.ToInt32(CELL_SIZE*i*2.5);
                    var x = 360 + k*CELL_SIZE;

                    if (e.X >= x && e.X <= x + CELL_SIZE && e.Y >= y && e.Y <= CELL_SIZE + y)
                    {
                        dx = e.X - x + CELL_SIZE*k;
                        dy = e.Y - y;
                        found = true;
                        break;
                    }
                }

                if (found)
                    break;
                j--;
            }

            if (MouseButtons.Left == e.Button && i < 4)
            {
                ShipDrawType = ShipTypeExtention.GetTypeOfShip(i);

                if (__MapTemp.GetAmountForShipType(ShipDrawType) > 0)
                {
                    if (found)
                    {
                        DrawShip = true;
                        Rotate = true;

                        drawX = e.X - dx;
                        drawY = e.Y - dy;

                        Draw();
                    }
                }
            }

            if (MouseButtons.Right == e.Button)
            {
                if (e.X > 30 && e.X < 330 && e.Y > 30 && e.Y < 330)
                {
                    var x = (e.X - 30)/CELL_SIZE;
                    var y = (e.Y - 30)/CELL_SIZE;

                    __MapTemp.DeleteShip(x, y);

                    Draw();
                }
            }
            ButtonNextEnable();
        }

        private void Picture_MouseUp(object sender, MouseEventArgs e)
        {
            if (DrawShip)
            {
                if (OnMap(drawX, drawY))
                {
                    var x = (drawX - 30 + CELL_SIZE/2)/CELL_SIZE;
                    var y = (drawY - 30 + CELL_SIZE/2)/CELL_SIZE;

                    __MapTemp.TryPutShip(new Point(x, y), ShipDrawType, !Rotate);
                }

                DrawShip = false;
            }

            ButtonNextEnable();
            Draw();
        }
    }
}