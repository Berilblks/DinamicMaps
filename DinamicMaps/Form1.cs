
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DinamicMaps
{
    public partial class Form1 : Form
    {
        GMapOverlay overlay1;
        List<car> list;
        SqlConnection connection = new SqlConnection(@"Data Source=LENOVO-BERIL;Initial Catalog=projelerVT;Integrated Security=True;Encrypt=False");




        public Form1()
        {
            InitializeComponent();
            InitializeMap();
            createCarList();
        }

        private void carsOpenMap()
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
                
            }

            
        }

        private void createCarList()
        {
            list = new List<car>();


            try                                                                 // Databasenin ADO.NET ile bilgileri çekilmesi
            {
                connection.Open();
                string sqlSentence = "SELECT Model, Plaka, CarType, FromWhere, ToWhere, Enlem ,Boylam FROM Cars";

                SqlDataAdapter da = new SqlDataAdapter(sqlSentence, connection);
                DataTable dt = new DataTable();
                da.Fill(dt);                                                    // VT daki veriler datatable a dolduruldu.
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;                              // datagridview e veriler aktarıldı.                
                }

                for(int i=0; i<dt.Rows.Count; i++)                              // listemixin içini çekilen verilerle doldur.
                {
                    list.Add(new car(dt.Rows[i][0].ToString(),
                                    dt.Rows[i][1].ToString(),
                                    dt.Rows[i][2].ToString(),
                                    dt.Rows[i][3].ToString(),
                                    dt.Rows[i][4].ToString(),
                                    new PointLatLng(Convert.ToDouble(dt.Rows[i][5].ToString()),
                                                    Convert.ToDouble(dt.Rows[i][6].ToString()))));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı bağlanıtısı sırasında bir hata oluştu, hata kodu:101\n " + ex.Message);
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }

            carsOpenMap();
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

        /*
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
        */

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            map.Dispose();
            Application.Exit();
        }

        /*
        private void button2_Click(object sender, EventArgs e)
        {
            PointLatLng location2 = new PointLatLng(Convert.ToDouble(textBox2.Text),
                                                    Convert.ToDouble(textBox1.Text));
            GMarkerGoogle marker2 = new GMarkerGoogle(location2, GMarkerGoogleType.red_dot);
            marker2.Tag = 102;

            overlay1.Markers.Add(marker2);
        }
        */

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

        private void button3_Click(object sender, EventArgs e)
        {
            carsOpenMap();
        }


        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}