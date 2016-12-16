﻿using System;
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

            MAP_SIZE = map.Size;
            CELL = 300 / MAP_SIZE;

            Map bot = Map.BuildMap(MAP_SIZE);

            __MyField = map.FillCells();
            __BotField = bot.FillCells();

            Bot();
            MyDraw();
            BotDraw();
        }

        private void MyDraw()
        {
            Bitmap bmp = new Bitmap(300, 300);

            Graphics graph = Graphics.FromImage(bmp);

            for (int y = 0; y < MAP_SIZE; y++)
            {
                for (int x = 0; x < MAP_SIZE; x++)
                {
                    SolidBrush brush = __MyField[x, y].GetColor();
                    graph.FillRectangle(brush, x * CELL, y * CELL, CELL, CELL);
                }
            }

            for (int i = 0; i <= MAP_SIZE; i++)
            {
                graph.DrawLine(__pen, i * CELL, 0, i * CELL, MAP_SIZE * CELL);
                graph.DrawLine(__pen, 0, i * CELL, MAP_SIZE * CELL, i * CELL);
            }

            graph.DrawRectangle(__pen, 0, 0, 299, 299);

            MyField.Image = bmp;
        }

        private void BotDraw()
        {
            Bitmap bmp = new Bitmap(300, 300);

            Graphics graph = Graphics.FromImage(bmp);

            for (int y = 0; y < MAP_SIZE; y++)
            {
                for (int x = 0; x < MAP_SIZE; x++)
                {
                    SolidBrush brush = __BotField[x, y].GetColor();
                    if (__BotField[x, y] != CellType.Ship)
                        graph.FillRectangle(brush, x * CELL, y * CELL, CELL, CELL);
                }
            }

            for (int i = 0; i <= MAP_SIZE; i++)
            {
                graph.DrawLine(__pen, i * CELL, 0, i * CELL, MAP_SIZE * CELL);
                graph.DrawLine(__pen, 0, i * CELL, MAP_SIZE * CELL, i * CELL);
            }

            graph.DrawRectangle(__pen, 0, 0, 299, 299);


            BotField.Image = bmp;
        }

        private void BotField_MouseDown(object sender, MouseEventArgs e)
        {
            MyDraw();

            if (MyTurn)
            {
                int x = e.X / CELL;
                int y = e.Y / CELL;

                if (__BotField[x, y] == CellType.None)
                    MyTurn = false;

                if (!__BotField[x, y].Shooted())
                    __BotField[x, y] = __BotField[x, y].CheckCell();

                IsKilled(__BotField); // Проверяем убили ли кораблик

                BotDraw();
                Task.Delay(200).Wait();
                Bot();
            }
        }

        private void Bot()
        {
            while (!MyTurn)
            {
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
                        if (!IsKilled(__MyField))
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

                    while (dX == 0 && dY == 0) // Если сторона в которую двигается бот не выбрана
                    {
                        if (rotate == 0 && tempY > 0)
                            dY = -1;
                        if (rotate == 1 && tempX < MAP_SIZE - 1)
                            dX = 1;
                        if (rotate == 2 && tempY < MAP_SIZE - 1)
                            dY = 1;
                        if (rotate == 3 && tempX > 0)
                            dX = -1;

                        if (!__MyField[tempX + dX, tempY + dY].Shooted()) // Если по этой стороне не стреляли, 
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

                    while (!IsKilled(__MyField) && (dX != 0 || dY != 0)) // Если не убили, и выбрана сторона движения, то идем в тело
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

                        MyDraw(); //Отрисовываем каждый ход
                    }

                    if (IsKilled(__MyField)) // Если убили, то обнуляем наши дельты, и так же меняем бул переменную, на то что бы кораблик заново выбирал рандомную точку
                    {
                        hited = false;
                        dX = 0;
                        dY = 0;
                    }
                }

                Task.Delay(400).Wait();
            }
            MyDraw();
        }

        public void ChangeMove(ref int X, ref int Y) //Говнокод
        {
            dX = -dX;
            dY = -dY;
            X = hitedX; 
            Y = hitedY;
        }

        private bool IsKilled(CellType[,] field) //Говнокод
        {
            int count = 0;
            bool found = false;

            for (int y = 0; y < MAP_SIZE; y++)
            {
                for (int x = 0; x < MAP_SIZE; x++)
                {
                    if (field[x, y] == CellType.Destroyed)
                    {
                        count++; //Говнокод

                        if (IsKilled_FindShip(x, y, field))
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

                return true;
            }

            return false;
        }

        private bool IsKilled_FindShip(int x, int y, CellType[,] field) //Говнокод
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
    }
}