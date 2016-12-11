using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBatlle
{
    public enum CellType
    {
        None,
        Ship,
        Destroyed,
        Missed,
        Temp
    }

    public static class CellExtention
    {
        public static bool Shooted(this CellType type)
        {
            return type == CellType.Destroyed || type == CellType.Missed;
        }

        public static SolidBrush GetColor(this CellType type)
        {
            switch (type)
            {
                case CellType.Ship:
                    return new SolidBrush(Color.Black);
                case CellType.Destroyed:
                    return new SolidBrush(Color.Blue);
                case CellType.Missed:
                    return new SolidBrush(Color.Yellow);
                default:
                    return new SolidBrush(Color.White);
            }
        }
    }
}
