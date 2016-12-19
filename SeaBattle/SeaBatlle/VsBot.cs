using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeaBatlle
{
    public partial class VsBot : Form
    {
        private CellType[,] __MyField;
        private CellType[,] __BotField;

        private int MAP_SIZE;
        private int CELL;

        private int dX;
        private int dY;
        private bool hited;
        private int hitedX;
        private int hitedY;

        private Pen __pen;
        private bool MyTurn;
        Random rand;

        public VsBot(Map map)
        {
            InitializeComponent();

            rand = new Random();
            __pen = new Pen(Color.Black);

            dX = 0;
            dY = 0;

            MyTurn = rand.Next(0, 2) == 0;
            Walketh.Image = Draw.Arrow(MyTurn);

            MAP_SIZE = map.Size;
            CELL = 300 / MAP_SIZE;

            Map bot = Map.BuildMap(MAP_SIZE);

            __MyField = map.FillCells();
            __BotField = bot.FillCells();

            Bot();

            MyField.Image = __MyField.DrawMap(true);
            BotField.Image = __BotField.DrawMap(false);
        }
        
        private void BotField_MouseDown(object sender, MouseEventArgs e)
        {
            Walketh.Image = Draw.Arrow(!MyTurn);

            if (MyTurn)
            {
                int x = e.X / CELL;
                int y = e.Y / CELL;

                if (__BotField[x, y] == CellType.None)
                    MyTurn = false;

                if (!__BotField[x, y].Shooted())
                    __BotField[x, y] = __BotField[x, y].CheckCell();

                __BotField.IsKilled(); // Проверяем убили ли кораблик

                BotField.Image = __BotField.DrawMap(false);

                Walketh.Image = Draw.Arrow(!MyTurn);
                Task.Delay(200).Wait();
                Bot();
            }
        }

        private void Bot()
        {
            while (!MyTurn)
            {
                Walketh.Image = Draw.Arrow(!MyTurn);

                if (!hited)
                {
                    int x = rand.Next(0, MAP_SIZE);
                    int y = rand.Next(0, MAP_SIZE);

                    while (true)
                    {
                        if (!__MyField[x, y].Shooted()) 
                            break;

                        x = rand.Next(0, MAP_SIZE);
                        y = rand.Next(0, MAP_SIZE);
                    }

                    __MyField[x, y] = __MyField[x, y].CheckCell();

                    if (__MyField[x, y] == CellType.Missed)
                        MyTurn = true;

                    if (__MyField[x, y] == CellType.Destroyed)
                        if (!__MyField.IsKilled())
                        {
                            hited = true;
                            hitedX = x;
                            hitedY = y;
                        }
                }

                if (hited)
                {
                    int rotate = rand.Next(0, 4); // В какую сторону будет двигатся бот
                    int tempX = hitedX;
                    int tempY = hitedY;

                    while (dX == 0 && dY == 0) // Если сторона в которую стреляет бот не выбрана
                    {
                        if (rotate == 0 && tempY > 0)
                            dY = -1;
                        if (rotate == 1 && tempX < MAP_SIZE - 1)
                            dX = 1;
                        if (rotate == 2 && tempY < MAP_SIZE - 1)
                            dY = 1;
                        if (rotate == 3 && tempX > 0)
                            dX = -1;

                        if (!__MyField[tempX + dX, tempY + dY].Shooted()) // Если в эту сторону не стреляли, то смотрим, попал бот или нет ниже
                        {
                            tempX += dX;
                            tempY += dY;
                            break;
                        }

                        rotate = rand.Next(0, 4);
                        dX = 0;
                        dY = 0;
                    }

                    __MyField[tempX, tempY] = __MyField[tempX, tempY].CheckCell(); // Смотрим попали мы или нет

                    if (__MyField[tempX, tempY] == CellType.Missed) // Если не попали, 
                    {
                        MyTurn = true; // То ходит человек
                        dX = 0; 
                        dY = 0;
                        break;
                    }

                    while (!__MyField.IsKilled() && (dX != 0 || dY != 0)) // Если не убили, и выбрана сторона движения, то идем в тело
                    {
                        tempX += dX; // Добавляем к координатам дельту (в какую сторону двигаемся)
                        tempY += dY;

                        if (tempY > MAP_SIZE - 1 || tempY < 0 || tempX > MAP_SIZE - 1 || tempX < 0 || // Если корблик еще не убит, но мы стреляем за границы, то мы не стреляем за границы, а меняем сторону в которую будет стрелять бот
                            __MyField[tempX, tempY].Shooted()) // Так же если мы стреляем в точку в которую уже стреляли, и кораблик еще не убит, то меняем сторону в которую бот будет стрелять
                        {
                            ChangeMove(ref tempX, ref tempY);
                            continue;
                        }

                        __MyField[tempX, tempY] = __MyField[tempX, tempY].CheckCell(); // Проверяем куда стрельнул бот (попал или не попал)

                        if (__MyField[tempX, tempY] == CellType.Missed) //Если бот не попал, то ходит человек
                        {
                            MyTurn = true;
                            ChangeMove(ref tempX, ref tempY); //Бот не попал, но кораблик еще не убит, то бот начинает стрелять в другую сторону относительно начальной точки попадания
                            break;
                        }

                        MyField.Image = __MyField.DrawMap(true); //Отрисовываем каждый ход
                    }

                    if (__MyField.IsKilled()) // Если убили, то обнуляем наши дельты, и так же меняем бул переменную, на то что бы кораблик заново выбирал рандомную точку
                    {
                        hited = false;
                        dX = 0;
                        dY = 0;
                    }
                }

                Task.Delay(200).Wait();
            }

            Walketh.Image = Draw.Arrow(!MyTurn);
            MyField.Image = __MyField.DrawMap(true);
        }

        public void ChangeMove(ref int X, ref int Y) // Меняем сторону в которую стреляет бот
        {
            dX = -dX;
            dY = -dY;
            X = hitedX; // А так же обновляем точку в которую попал бот, что бы снова стрелять относительно неё
            Y = hitedY;
        }
    }
}
