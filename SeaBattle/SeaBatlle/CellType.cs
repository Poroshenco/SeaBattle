using System.Drawing;
using SeaBattle.Lib;

namespace SeaBatlle
{
    public static class CellExtention
    {
        public static bool Shooted(this CellType type)
        {
            return type == CellType.Destroyed || type == CellType.Missed;
        }

        public static bool IsKilled(this CellType[,] field)
        {
            var count = 0;
            var found = false;
            var MAP_SIZE = Login.MAP_SIZE;

            for (var y = 0; y < MAP_SIZE; y++)
            {
                for (var x = 0; x < MAP_SIZE; x++)
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
                for (var y = 0; y < MAP_SIZE; y++)
                {
                    for (var x = 0; x < MAP_SIZE; x++)
                    {
                        if (field[x, y] == CellType.Destroyed)
                        {
                            for (var dy = -1; dy < 2; dy++)
                            {
                                for (var dx = -1; dx < 2; dx++)
                                {
                                    var _x = x + dx;
                                    var _y = y + dy;

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

        private static bool IsKilled_FindShip(int x, int y, CellType[,] field, int MAP_SIZE)
            // Проверяем каждую клетку, если вокруг неё есть кораблик, возращаем true
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