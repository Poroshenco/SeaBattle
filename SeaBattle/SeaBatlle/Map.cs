using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using SeaBattle.Lib;

namespace SeaBatlle
{
    public class Map
    {
        public Map(int size)
        {
            Size = size;
            Cells = new MapCell[size, size];

            for (var x = 0; x < size; x++)
                for (var y = 0; y < size; y++)
                    Cells[x, y] = new MapCell();

            Ships = new List<Ship>();
        }

        public int Size { get; }

        public MapCell[,] Cells { get; }

        public List<Ship> Ships { get; }

        public CellType[,] FillCells()
        {
            var field = new CellType[Size, Size];

            for (var y = 0; y < Size; y++)
            {
                for (var x = 0; x < Size; x++)
                {
                    if (Cells[x, y].Type == CellType.Ship)
                        field[x, y] = CellType.Ship;
                }
            }

            return field;
        }

        public bool DeleteShip(int x, int y)
        {
            var cell = Cells[x, y];
            var ship = cell.Ship;

            if (ship == null)
                return false;

            Ships.Remove(ship);

            foreach (var point in ship.Points)
            {
                Cells[point.X, point.Y].Ship = null;
                Cells[point.X, point.Y].Type = CellType.None;
            }

            return true;
        }

        public Ship GetShip(int x, int y)
        {
            var cell = Cells[x, y];

            return cell.Ship;
        }

        public bool Check(Ship ship)
        {
            foreach (var point in ship.Points)
            {
                if (!IsOnMap(point))
                    return false;

                for (var dx = -1; dx < 2; dx++)
                {
                    for (var dy = -1; dy < 2; dy++)
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

        public int GetAmountForShipType(ShipType type)
        {
            var count = type.GetCountForType();

            var freeShips = count - CountOfShips(type);

            return freeShips;
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

            var shipPoints = new Point[shipSize];

            for (var i = 0; i < shipSize; i++)
                shipPoints[i] = new Point(startPoint.X + dx*i, startPoint.Y + dy*i);

            var ship = new Ship(type, shipPoints);

            if (!Check(ship))
                return false;

            Ships.Add(ship);

            foreach (var point in shipPoints)
            {
                var cell = Cells[point.X, point.Y];
                Cells[point.X, point.Y].Type = CellType.Ship;

                cell.Ship = ship;
            }

            return true;
        }

        public static Map BuildMap(int size)
        {
            var map = new Map(size);

            var rand = new Random();

            foreach (ShipType shipType in Enum.GetValues(typeof (ShipType)))
            {
                var shipCount = shipType.GetCountForType();

                for (var i = 0; i < shipCount;)
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