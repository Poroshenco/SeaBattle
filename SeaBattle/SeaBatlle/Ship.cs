using System.Drawing;

namespace SeaBatlle
{
    public class Ship
    {
        public Ship(ShipType type, Point[] points)
        {
            Type = type;
            Points = points;
        }

        public ShipType Type { get; set; }

        public Point[] Points { get; set; }
    }
}