
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DinamicMaps
{
    public partial class Form1 : Form
    {
        GMapOverlay overlay1;
        List<car> list;
        public Form1()
        {
            InitializeComponent();
            InitializeMap();
            carListesiniOlustur();
        }

        private void carListesiniOlustur()
        {
            list = new List<car>();
            list.Add(new car("BMW", "34ABC34", "Car", "Ankara", "İstanbul", new PointLatLng(39.9334, 32.8597)));
            list.Add(new car("Mercedes", "06AG456", "Car", "istanbul", "Bursa", new PointLatLng(41.20, 30.5)));
            list.Add(new car("Renault", "01DD568", "Ticari", "Adana", "İstanbul", new PointLatLng(20.09, 25.97)));
            list.Add(new car("BMW", "34KM384", "Car", "Ankara", "Balıkesir", new PointLatLng(42.9334, 35.8597)));
            list.Add(new car("BMW", "35DK354", "Tir", "Samsun", "İstanbul", new PointLatLng(41.34, 29.8597)));
        }

        private void InitializeMap()
        {
            map.DragButton = MouseButtons.Left;
            map.MapProvider = GMapProviders.OpenStreetMap;
            map.Position = new GMap.NET.PointLatLng(39.0, 40.0);
            map.Zoom = 4;
            map.MinZoom = 1;
            map.MaxZoom = 30;
            overlay1 = new GMapOverlay();                                       //bir katman oluşturuldu.
            map.Overlays.Add(overlay1);                                         //katman haritaya eklendi. (önce katman daha sonra marker eklenir)


        }

        private void button1_Click(object sender, EventArgs e)
        {
            PointLatLng location1 = new PointLatLng(Convert.ToDouble(textBoxEnlem.Text), 
                                                    Convert.ToDouble(textBoxBoylam.Text));
            GMarkerGoogle marker = new GMarkerGoogle(location1, GMarkerGoogleType.lightblue_dot);

            marker.ToolTipText = "\n Location \n Car  \n From: Ankara \n To: İstanbul";
            marker.ToolTip.Fill = System.Drawing.Brushes.LightGray;   
            marker.ToolTip.Foreground = System.Drawing.Brushes.Black;
            marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;                 //marker üzerine gelince tooltip göster.
            marker.Tag = 101;                                                   //marker a id atandı.

            overlay1.Markers.Add(marker);                                       //marker katmana eklendi.
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            map.Dispose();
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            PointLatLng location2 = new PointLatLng(Convert.ToDouble(textBox2.Text),
                                                    Convert.ToDouble(textBox1.Text));
            GMarkerGoogle marker2 = new GMarkerGoogle(location2, GMarkerGoogleType.red_dot);
            marker2.Tag = 102;

            overlay1.Markers.Add(marker2);
        }

        private void map_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {
            string markerId = (string)item.Tag;
            //Console.WriteLine("Marker ID: " + markerId + "click the marker");

            foreach (car car in list)
            {
                if (markerId.Equals(car.Plaka))
                {
                    textBox3.Text = car.Model;
                    textBox4.Text = car.Plaka;
                    textBox5.Text = car.Tipi;
                    textBox6.Text = car.From;
                    textBox7.Text = car.To;
                    break;
                }
            }


        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (car car in list)
            {
                GMarkerGoogle markerTmp = new GMarkerGoogle(car.Location, GMarkerGoogleType.green_dot);
                markerTmp.Tag = car.Plaka;
                markerTmp.ToolTipText = car.ToString();
                markerTmp.ToolTip.Fill = System.Drawing.Brushes.LightGray;
                markerTmp.ToolTip.Foreground = System.Drawing.Brushes.Black;
                markerTmp.ToolTipMode = MarkerTooltipMode.OnMouseOver;

                overlay1.Markers.Add(markerTmp);                        // Katmana araçlar eklendi.
                Console.WriteLine(car.ToString());
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}