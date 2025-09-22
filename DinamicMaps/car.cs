using GMap.NET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinamicMaps
{
    internal class car
    {
        private string model;
        private string plaka;
        private string tipi;
        private string from;
        private string to;
        private PointLatLng location;

        public car(string model, string plaka, string tipi, string from, string to, PointLatLng location)
        {
            this.Model = model;
            this.Plaka = plaka;
            this.Tipi = tipi;
            this.From = from;
            this.To = to;
            this.Location = location;
        }

        public string Model { get => model; set => model = value; }
        public string Plaka { get => plaka; set => plaka = value; }
        public string Tipi { get => tipi; set => tipi = value; }
        public string From { get => from; set => from = value; }
        public string To { get => to; set => to = value; }
        public PointLatLng Location { get => location; set => location = value; }

        public override string ToString()
        {
            string str = "\n" + Model + "\n" + Plaka + "\n" + Tipi + "\nFrom: " + From + "\nTo: " + To;
            return str;
        }
    }
}
