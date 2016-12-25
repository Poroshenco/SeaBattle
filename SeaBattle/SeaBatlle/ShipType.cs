using System;
using System.Drawing;

namespace SeaBatlle
{
    public enum ShipType
    {
        Linkor,
        AirCarrier,
        Cruiser,
        Esminec
    }

    public static class ShipTypeExtention
    {
        public static ShipType GetTypeOfShip(int y)
        {
            switch (y)
            {
                case 0:
                    return ShipType.Linkor;
                case 1:
                    return ShipType.AirCarrier;
                case 2:
                    return ShipType.Cruiser;
                case 3:
                    return ShipType.Esminec;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static SolidBrush GetColor(this ShipType type)
        {
            switch (type)
            {
                case ShipType.Esminec:
                    return new SolidBrush(Color.Purple);
                case ShipType.Cruiser:
                    return new SolidBrush(Color.Orange);
                case ShipType.AirCarrier:
                    return new SolidBrush(Color.Brown);
                case ShipType.Linkor:
                    return new SolidBrush(Color.Black);
                default:
                    throw new ArgumentOutOfRangeException(nameof(type));
            }
        }

        public static int GetCountForType(this ShipType type)
        {
            switch (type)
            {
                case ShipType.Esminec:
                    return Login.Esmineces;
                case ShipType.Cruiser:
                    return Login.Cruisers;
                case ShipType.AirCarrier:
                    return Login.AirCrafters;
                case ShipType.Linkor:
                    return Login.Linkors;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type));
            }
        }

        public static int GetSize(this ShipType type)
        {
            switch (type)
            {
                case ShipType.Esminec:
                    return 1;
                case ShipType.Cruiser:
                    return 2;
                case ShipType.AirCarrier:
                    return 3;
                case ShipType.Linkor:
                    return 4;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type));
            }
        }
    }
}