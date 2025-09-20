
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
            overlay1 = new GMapOverlay();                           //bir katman oluşturuldu.
            map.Overlays.Add(overlay1);                             //katman haritaya eklendi. (önce katman daha sonra marker eklenir)


        }

        private void button1_Click(object sender, EventArgs e)
        {
            PointLatLng location1 = new PointLatLng(Convert.ToDouble(textBoxEnlem.Text), 
                                                    Convert.ToDouble(textBoxBoylam.Text));
            GMarkerGoogle marker = new GMarkerGoogle(location1, GMarkerGoogleType.lightblue_dot);
            overlay1.Markers.Add(marker);                           //marker katmana eklendi.
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            map.Dispose();
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}