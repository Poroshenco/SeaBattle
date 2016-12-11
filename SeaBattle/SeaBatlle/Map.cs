using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBatlle
{
    class Map
    {
        public int Size { get; }

        public MapCell[,] Cells { get; }

        public List<Ship> Ships { get; }

        public Map(int size)
        {
            Size = size;
            Cells = new MapCell[size, size];

            for (int x = 0; x < size; x++)
                for (int y = 0; y < size; y++)
                    Cells[x, y] = new MapCell();

            Ships = new List<Ship>();
        }

        public bool DeleteShip(int x, int y)
        {
            var cell = Cells[x, y];
            var ship = cell.Ship;

            if (ship == null)
                return false;

            Ships.Remove(ship);

            foreach (var point in ship.Points)
                Cells[point.X, point.Y].Ship = null;

            return true;
        }

        public Ship GetShip(int x, int y)
        {
            MapCell cell = Cells[x, y];

            return cell.Ship;
        }

        public bool Check(Ship ship)
        {
            foreach (var point in ship.Points)
            {
                if (!IsOnMap(point))
                    return false;

                for (int dx = -1; dx < 2; dx++)
                {
                    for (int dy = -1; dy < 2; dy++)
                    {
                        var x = point.X + dx;
                        var y = point.Y + dy;

                        if (!IsOnMap(new Point(x, y)))
                            continue;

                        var cell = Cells[x, y];

                        if (cell.Ship != null)
                            return false;
                    }
                }
            }

            return true;
        }

        public int CountOfShips(ShipType type)
        {
            return Ships.Count(e => e.Type == type);
        }

        public bool IsOnMap(Point point)
        {
            return point.X >= 0 && point.X < Size && point.Y >= 0 && point.Y < Size;
        }

        public bool TryPutShip(Point startPoint, ShipType type, bool invert)
        {
            var dx = invert ? 0 : 1;
            var dy = invert ? 1 : 0;

            var shipSize = type.GetSize();

            Point[] shipPoints = new Point[shipSize];

            for (int i = 0; i < shipSize; i++)
                shipPoints[i] = new Point(startPoint.X + dx * i, startPoint.Y + dy * i);

            var ship = new Ship(type, shipPoints);

            if (!Check(ship))
                return false;

            Ships.Add(ship);

            foreach (var point in shipPoints)
            {
                MapCell cell = Cells[point.X, point.Y];

                cell.Ship = ship;
            }

            return true;
        }

        public static Map BuildMap(int size)
        {
            Map map = new Map(size);

            Random rand = new Random();

            foreach (ShipType shipType in Enum.GetValues(typeof(ShipType)))
            {
                int shipCount = shipType.GetCountForType();

                for (int i = 0; i < shipCount;)
                {
                    var invert = rand.Next(0, 2) == 0;
                    var x = rand.Next(0, size - shipType.GetSize() + 1);
                    var y = rand.Next(0, size - shipType.GetSize() + 1);

                    if (map.TryPutShip(new Point(x, y), shipType, invert))
                        i++;
                }
            }

            return map;
        }
    }
}
