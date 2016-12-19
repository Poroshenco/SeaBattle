using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBatlle
{
    public static class Draw
    {
        public static Bitmap DrawMap(this CellType[,] field, bool show_ships)
        {
            Bitmap bmp = new Bitmap(300, 300);
            Graphics graph = Graphics.FromImage(bmp);

            int MAP_SIZE = Login.MAP_SIZE;
            int CELL = 300 / MAP_SIZE;
            Pen pen = new Pen(Color.Black);

            for (int y = 0; y < MAP_SIZE; y++)
            {
                for (int x = 0; x < MAP_SIZE; x++)
                {
                    if (field[x, y] != CellType.Ship || show_ships)
                    {
                        SolidBrush brush = field[x, y].GetColor();
                        graph.FillRectangle(brush, x * CELL, y * CELL, CELL, CELL);
                    }
                }
            }

            for (int i = 0; i <= MAP_SIZE; i++)
            {
                graph.DrawLine(pen, i * CELL, 0, i * CELL, MAP_SIZE * CELL);
                graph.DrawLine(pen, 0, i * CELL, MAP_SIZE * CELL, i * CELL);
            }

            graph.DrawRectangle(pen, 0, 0, 299, 299);

            return bmp;
        }

        public static Bitmap Arrow(bool leftPlayerTurn)
        {
            Bitmap bmp = new Bitmap(86,50);
            Graphics gr = Graphics.FromImage(bmp);

            Pen pen = new Pen(Color.Black);
            gr.DrawRectangle(pen, 1, 1, 84, 48);

            if (!leftPlayerTurn)
            {
                gr.DrawLine(pen, 18, 18, 51, 18);
                gr.DrawLine(pen, 51, 18, 51, 8);
                gr.DrawLine(pen, 51, 8, 68, 25);
                gr.DrawLine(pen, 68, 25, 51, 42);
                gr.DrawLine(pen, 51, 42, 51, 32);
                gr.DrawLine(pen, 51, 32, 18, 32);
                gr.DrawLine(pen, 18, 32, 18, 18);
            }
            if (leftPlayerTurn)
            {
                gr.DrawLine(pen, 18, 25, 35, 42);
                gr.DrawLine(pen, 18, 25, 35, 8);
                gr.DrawLine(pen, 35, 42, 35, 32);
                gr.DrawLine(pen, 35, 8, 35, 18);
                gr.DrawLine(pen, 35, 32, 68, 32);
                gr.DrawLine(pen, 35, 18, 68, 18);
                gr.DrawLine(pen, 68, 32, 68, 18);
            }

            return bmp;
        }

    }
}
