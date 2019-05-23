using System;
using System.Drawing;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms.ToolTips;
using System.Globalization;
using System.Threading;

namespace regex
{
    public partial class Form1 : Form
    {
        string latitude, longitude;
        string country;

        double lat, lon;        

        private Size sz;
        private bool asd = false;

        public Form1()
        {
            InitializeComponent();
            sz = new Size(Width, Height);
        }
        private void SizeForm()
        {
            if (!asd)
            {
                Size = new Size(710, 390);
                asd = !asd;
                button1.Text = "Скрыть";
            }
            else
            {
                Size = new Size(sz.Width, sz.Height);
                asd = !asd;
                button1.Text = "Показать";
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string line = "";
            if (IsAddressValid(tbInputIP.Text))
            {
                using (WebClient wc = new WebClient())
                    line = wc.DownloadString($"http://free.ipwhois.io/xml/{tbInputIP.Text}");

                Match match = Regex.Match(line, "<continent>(.*?)</continent>(.*?)<country>(.*?)</country>(.*?)<city>(.*?)</city>" +
                    "(.*?)<latitude>(.*?)</latitude>(.*?)<longitude>(.*?)</longitude>(.*?)<timezone_gmt>(.*?)</timezone_gmt>");

                lblShowInfo.Text = match.Groups[1].Value + "\n" + match.Groups[3].Value + "\n" + match.Groups[5].Value + "\n" +
                    match.Groups[7].Value + "\n" + match.Groups[9].Value + "\n" + match.Groups[11].Value + "\n";

                latitude = match.Groups[7].Value;
                longitude = match.Groups[9].Value;
                country = match.Groups[3].Value;

                CultureInfo temp_culture = Thread.CurrentThread.CurrentCulture;
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                lat = double.Parse(latitude);
                lon = double.Parse(longitude);
                Thread.CurrentThread.CurrentCulture = temp_culture;

                SizeForm();

                gMapControl1_Load(sender, e);

                label2.Text = "Введите IP:";
            }
            else
            {
                label2.Text = "Неправильный IP";
            }        
        }
        
        private void tbInputIP_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(tbInputIP.Text, "[^0-9-.]"))
            {
                tbInputIP.Text = tbInputIP.Text.Remove(tbInputIP.Text.Length - 1);
                tbInputIP.SelectionStart = tbInputIP.TextLength;
            }
        }
        public bool IsAddressValid(string addrString)
        {
            IPAddress address;
            return IPAddress.TryParse(addrString, out address);
        }

        private void gMapControl1_Load(object sender, EventArgs e)
        {
            //Настройка для компонента Gmap
            gMap.Bearing = 0;
            //Перетаскивание карты правой кнопкой мыши
            gMap.CanDragMap = true;
            //Перетаскивание карты левой кнопкой мыши
            gMap.DragButton = MouseButtons.Left;

            gMap.GrayScaleMode = true;

            //Все маркеры будут показаны
            gMap.MarkersEnabled = true;
            //Максимальное приблежение
            gMap.MaxZoom = 18;
            //Минимальное приближение
            gMap.MinZoom = 2;
            //Курсор мыши в центр экрана
            gMap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionWithoutCenter;
            //Отключение негативного режима
            gMap.NegativeMode = false;
            //Разрешение полигонов
            gMap.PolygonsEnabled = true;
            //Разрешение маршрутов
            gMap.RoutesEnabled = true;
            //Скрытие внешней сетки каты
            gMap.ShowTileGridLines = false;
            //При загрузке 10-кратное увеличение
            gMap.Zoom = 10;

            //Чья карта используется
            gMap.MapProvider = GMapProviders.GoogleMap;

            //Загрузка этой точки на карте
            GMaps.Instance.Mode = AccessMode.ServerOnly;
            gMap.Position = new PointLatLng(lat, lon); // !!!!!!!!!!!!!!!!!!!!!

            //Создаём новый список маркеров
            GMapOverlay markersOverlay = new GMapOverlay("markers");

            //Инициализая красного маркера с указанием его координат
            GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(lat, lon), GMarkerGoogleType.red);
            marker.ToolTip = new GMapRoundedToolTip(marker);

            //Текст отображаемый с маркером
            marker.ToolTipText = country;
            //Добавляем маркер в список маркеров
            markersOverlay.Markers.Add(marker);
            gMap.Overlays.Add(markersOverlay);

            //Установка максимального, минимального и екущего значения элемента управления
            trackBar1.Maximum = 18;
            trackBar1.Minimum = 2;
            trackBar1.Value = (int)gMap.Zoom;
        }
        private void gMap_OnMapTypeChanged(GMapProvider type)
        {
            trackBar1.Value = (int)gMap.Zoom;
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            gMap.Zoom = trackBar1.Value;
        }
    }
}
