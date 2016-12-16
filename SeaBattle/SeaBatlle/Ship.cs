using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBatlle
{
    public class Ship
    {
        public ShipType Type { get; set; }

        public Point[] Points { get; set; }

        public Ship(ShipType type, Point[] points)
        {
            Type = type;
            Points = points;
        }
    }
}
