using System;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using SeaBattle.Lib;

namespace SeaBatlle
{
    public partial class OnLan : Form
    {
        private readonly int CELL;
        private readonly Socket client;

        private readonly Encoding encoding;
        private readonly CellType[,] MyField;
        private bool MyTurn;
        private CellType[,] OponentField;

        public OnLan(CellType[,] map)
        {
            InitializeComponent();
            MyNickname.Text = "Field: " + OnLan_Login.Nickname;

            var ipAddr = IPAddress.Parse(OnLan_Login.Ip);
            var port = 25565;
            var ipEnd = new IPEndPoint(ipAddr, port);

            CELL = 300/Login.MAP_SIZE;
            encoding = new UTF8Encoding();

            var bytes = new byte[1024];
            var bytes_ForMap = new byte[16384];


            client = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            client.Connect(ipEnd);
            client.Send(encoding.GetBytes(OnLan_Login.Nickname));

            var mapsettings = new MapSettings();
            mapsettings.MapSize = Login.MAP_SIZE;
            mapsettings.Linkors = Login.Linkors;
            mapsettings.AirCrafters = Login.AirCrafters;
            mapsettings.Cruisers = Login.Cruisers;
            mapsettings.Esmineces = Login.Esmineces;
            mapsettings.Map = map;

            var json = JsonConvert.SerializeObject(mapsettings);
            client.Send(encoding.GetBytes(json));

            MyField = map;
            MyFieldImage.Image = MyField.DrawMap(true);

            Task.Factory.StartNew((() =>
            {
                var oponentnickname = encoding.GetString(bytes, 0, client.Receive(bytes));

                Action action = () => { OponentNickname.Text = "Field: " + oponentnickname; };
                if (OponentNickname.InvokeRequired)
                    OponentNickname.Invoke(action);
                else
                    action();

                client.Send(encoding.GetBytes("I recieved nickname"));

                json = encoding.GetString(bytes_ForMap, 0, client.Receive(bytes_ForMap));
                OponentField = JsonConvert.DeserializeObject<CellType[,]>(json);

                DrawOponent();

                client.Send(encoding.GetBytes("I recieved field"));

                if (encoding.GetString(bytes, 0, client.Receive(bytes)) == "Your turn")
                    MyTurn = true;
                else
                    MyTurn = false;

                DrawWalketh();

                Task.Factory.StartNew((() =>
                {
                    while (true)
                    {
                        if (!MyTurn)
                        {
                            try
                            {
                                var shot =
                                    JsonConvert.DeserializeObject<Point>(encoding.GetString(bytes, 0,
                                        client.Receive(bytes)));
                                MyField[shot.X, shot.Y] = MyField[shot.X, shot.Y].CheckCell();

                                if (MyField[shot.X, shot.Y] == CellType.Missed)
                                    MyTurn = true;

                                DrawMyField();
                                DrawWalketh();
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Server closed");
                                break;
                            }
                        }
                    }
                }));
            }));
        }

        private void DrawMyField()
        {
            Action action = () => { MyFieldImage.Image = MyField.DrawMap(true); };
            if (MyFieldImage.InvokeRequired)
                MyFieldImage.Invoke(action);
            else
                action();
        }

        private void DrawWalketh()
        {
            Action action = () => { Walketh.Image = Draw.Arrow(MyTurn); };
            if (Walketh.InvokeRequired)
                Walketh.Invoke(action);
            else
                action();
        }

        private void DrawOponent()
        {
            Action action = () => { OponentFieldImage.Image = OponentField.DrawMap(false); };

            if (OponentFieldImage.InvokeRequired)
                OponentFieldImage.Invoke(action);
            else
                action();
        }

        private void OponentFieldImage_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (MyTurn)
                {
                    var X = e.X/CELL;
                    var Y = e.Y/CELL;

                    if (!OponentField[X, Y].Shooted())
                    {
                        var shot = new Point(X, Y);

                        OponentField[X, Y] = OponentField[X, Y].CheckCell();

                        if (OponentField[X, Y] == CellType.Missed)
                            MyTurn = false;

                        client.Send(encoding.GetBytes(JsonConvert.SerializeObject(shot)));
                        OponentField.IsKilled();

                        DrawWalketh();
                        DrawOponent();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Server closed");
            }
        }
    }
}