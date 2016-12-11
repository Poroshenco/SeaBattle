﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeaBatlle
{
    public partial class Build : Form
    {
        private readonly int CELL_SIZE;
        private bool DrawShip;
        private ShipType ShipDrawType;

        private bool Rotate = true;
        private int dx, dy, drawX, drawY;
        private Map __Map;

        private const int MAP_SIZE = 10;

        public Build()
        {
            InitializeComponent();

            __Map = new Map(MAP_SIZE);
            CELL_SIZE = 300 / __Map.Size;
            this.KeyPreview = true;

            Draw();
        }

        public void Draw()
        {
            Bitmap bmp = new Bitmap(Picture.Width, Picture.Height);

            Graphics graph = Graphics.FromImage(bmp);

            Pen pen = new Pen(Color.Black);

            graph.Clear(Color.White);

            graph.DrawRectangle(pen, 0, 0, 558, 359);


            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4 - i; j++)
                {
                    int X = 360 + j * CELL_SIZE;
                    int Y = 40 + Convert.ToInt32(CELL_SIZE * i * 2.5);

                    SolidBrush brush = GetColor(i);
                    graph.FillRectangle(brush, X, Y, CELL_SIZE, CELL_SIZE);
                    graph.DrawRectangle(pen, X, Y, CELL_SIZE, CELL_SIZE);
                }

            for (int x = 0; x < __Map.Size; x++)
            {
                for (int y = 0; y < __Map.Size; y++)
                {
                    Ship ship = __Map.GetShip(x, y);

                    var brush = ship == null ?
                        new SolidBrush(Color.White) :
                        ship.Type.GetColor();

                    graph.FillRectangle(brush, x * CELL_SIZE + 30, y * CELL_SIZE + 30, CELL_SIZE, CELL_SIZE);
                }
            }

            for (int i = 0; i <= MAP_SIZE; i++)
            {
                graph.DrawLine(pen, 30 + i * CELL_SIZE, 30, 30 + i * CELL_SIZE, MAP_SIZE * CELL_SIZE + 30);
                graph.DrawLine(pen, 30, 30 + i * CELL_SIZE, MAP_SIZE * CELL_SIZE + 30, 30 + i * CELL_SIZE);
            }

            if (DrawShip)
            {
                int count = ShipTypeExtention.GetSize(ShipDrawType);
                SolidBrush brush = ShipTypeExtention.GetColor(ShipDrawType);

                int tempX = drawX;
                int tempY = drawY;
                for (int i = 0; i < count; i++)
                {
                    graph.FillRectangle(brush, tempX, tempY, CELL_SIZE, CELL_SIZE);
                    graph.DrawRectangle(pen, tempX, tempY, CELL_SIZE, CELL_SIZE);

                    if (Rotate)
                        tempX += CELL_SIZE;
                    else
                        tempY += CELL_SIZE;
                }
            }

            Picture.Image = bmp;
        }

        private void AutoBuild_Click(object sender, EventArgs e)
        {
            Refresh();
            __Map = Map.BuildMap(MAP_SIZE);

            Draw();
        }

        public SolidBrush GetColor(int y)
        {
            var type = ShipTypeExtention.GetTypeOfShip(y);

            var count = type.GetCountForType();

            if (ShipDrawType == type && DrawShip)
                count--;

            var freeShips = count - __Map.CountOfShips(type);

            if (freeShips <= 0)
                return new SolidBrush(Color.White);

            return type.GetColor();
        }

        private void Picture_MouseMove(object sender, MouseEventArgs e)
        {
            if (DrawShip)
            {
                if (Rotate)
                {
                    drawX = e.X - dx;
                    drawY = e.Y - dy;
                }
                if (!Rotate)
                {
                    drawX = e.X - dy;
                    drawY = e.Y - dx;
                }

                Draw();
            }
        }

        private void Build_KeyDown(object sender, KeyEventArgs e)
        {
            char rotate = e.KeyData.ToString().ToLower()[0];
            if (rotate == 'r')
            {
                if (Rotate)
                {
                    drawX = drawX + dx - dy;
                    drawY = drawY + dy - dx;
                }
                else
                {
                    drawX = drawX - dx + dy;
                    drawY = drawY + dx - dy;
                }
                Rotate = !Rotate;
            }



            Draw();
        }

        private void Clean_Click(object sender, EventArgs e)
        {
            __Map = new Map(MAP_SIZE);
            Refresh();
            Draw();
        }

        private bool OnMap(int x, int y)
        {
            return x > 15 && x < 315 && y > 15 && y < 315;
        }

        private void Picture_MouseDown(object sender, MouseEventArgs e)
        {
            int j = 4;

            int i = 0;
            int k = 0;

            bool found = false;
            for (i = 0; i < 4; i++)
            {
                for (k = 0; k < j; k++)
                {
                    int _Y = 40 + Convert.ToInt32(CELL_SIZE * i * 2.5);
                    int _X = 360 + k * CELL_SIZE;

                    if (e.X >= _X && e.X <= _X + CELL_SIZE && e.Y >= _Y && e.Y <= CELL_SIZE + _Y)
                    {
                        dx = e.X - _X + CELL_SIZE * k;
                        dy = e.Y - _Y;
                        found = true;
                        break;
                    }
                }

                if (found)
                    break;
                j--;
            }

            if (MouseButtons.Left == e.Button && i < 4)
            {
                ShipDrawType = ShipTypeExtention.GetTypeOfShip(i);

                if (GetColor(i)!=new SolidBrush(Color.White))
                {
                    if (found)
                    {
                        DrawShip = true;
                        Rotate = true;

                        drawX = e.X - dx;
                        drawY = e.Y - dy;

                        Draw();
                    }
                }
            }

            if (MouseButtons.Right == e.Button)
            {
                if (OnMap(drawX, drawY))
                {
                    int x = (e.X - 30) / CELL_SIZE;
                    int y = (e.Y - 30) / CELL_SIZE;

                    __Map.DeleteShip(x, y);

                    Draw();
                }
            }
        }

        private void Picture_MouseUp(object sender, MouseEventArgs e)
        {
            if (DrawShip)
            {
                if (OnMap(drawX, drawY))
                {
                    int x = (drawX - 30 + CELL_SIZE / 2) / CELL_SIZE;
                    int y = (drawY - 30 + CELL_SIZE / 2) / CELL_SIZE;

                    __Map.TryPutShip(new Point(x, y), ShipDrawType, !Rotate);
                }

                DrawShip = false;
            }

            Draw();
        }
    }
}