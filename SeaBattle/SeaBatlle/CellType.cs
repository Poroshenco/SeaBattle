using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SeaBatlle
{
    public enum CellType
    {
        None,
        Ship,
        Destroyed,
        Missed
    }

    public static class CellExtention
    {
        public static bool Shooted(this CellType type)
        {
            return type == CellType.Destroyed || type == CellType.Missed;
        }

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
                        graph.FillRectangle(brush, x*CELL, y*CELL, CELL, CELL);
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

        public static bool IsKilled(this CellType[,] field)
        {
            int count = 0;
            bool found = false;
            int MAP_SIZE = Login.MAP_SIZE;

            for (int y = 0; y < MAP_SIZE; y++)
            {
                for (int x = 0; x < MAP_SIZE; x++)
                {
                    if (field[x, y] == CellType.Destroyed)
                    {
                        count++;

                        if (IsKilled_FindShip(x, y, field, MAP_SIZE))
                            found = true;
                    }
                }
            }

            if (!found)
            {
                for (int y = 0; y < MAP_SIZE; y++)
                {
                    for (int x = 0; x < MAP_SIZE; x++)
                    {
                        if (field[x, y] == CellType.Destroyed)
                        {
                            for (int dy = -1; dy < 2; dy++)
                            {
                                for (int dx = -1; dx < 2; dx++)
                                {
                                    int _x = x + dx;
                                    int _y = y + dy;

                                    if (_x < 0 || _x > MAP_SIZE - 1 || _y < 0 || _y > MAP_SIZE - 1)
                                        continue;

                                    if (field[_x, _y] != CellType.Destroyed)
                                        field[_x, _y] = CellType.Missed;
                                }
                            }
                        }
                    }
                }

                return true; // Если кораблик убили, возвращаем true
            }

            return false; // Если кораблик не убили, то возвращаем false
        }

        private static bool IsKilled_FindShip(int x, int y, CellType[,] field, int MAP_SIZE) // Проверяем каждую клетку, если вокруг неё есть кораблик, возращаем true
        {
            if (x > 0)
                if (field[x - 1, y] == CellType.Ship)
                    return true;
            if (x < MAP_SIZE - 1)
                if (field[x + 1, y] == CellType.Ship)
                    return true;
            if (y > 0)
                if (field[x, y - 1] == CellType.Ship)
                    return true;
            if (y < MAP_SIZE - 1)
                if (field[x, y + 1] == CellType.Ship)
                    return true;

            return false;
        }

        public static SolidBrush GetColor(this CellType type)
        {
            switch (type)
            {
                case CellType.Ship:
                    return new SolidBrush(Color.Black);
                case CellType.Destroyed:
                    return new SolidBrush(Color.Brown);
                case CellType.Missed:
                    return new SolidBrush(Color.DarkBlue);
                default:
                    return new SolidBrush(Color.White);
            }
        }

        public static CellType CheckCell(this CellType type)
        {
            switch (type)
            {
                case CellType.Ship:
                    return CellType.Destroyed;
                case CellType.None:
                    return CellType.Missed;
                default:
                    return type;
            }
        }

    }
}
