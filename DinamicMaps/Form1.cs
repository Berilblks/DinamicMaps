
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Windows.Forms;

namespace DinamicMaps
{
    public partial class Form1 : Form
    {
        GMapOverlay overlay1;
        public Form1()
        {
            InitializeComponent();
            InitializeMap();
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
            int markerId = (int)item.Tag;
            Console.WriteLine("Marker ID: " + markerId + "click the marker");
        }
    }
}