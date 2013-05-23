using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Media;

namespace TaxiApp
{
    public static class WPF
    {
        private static Random rng = new Random();

        public static Random Rng
        {
            get { return WPF.rng; }
            set { WPF.rng = value; }
        }

        public static MapPolyline DrawRoad(TravelData data)
        {
            MapPolyline polyline = new MapPolyline();
            Color color = new Color();
            color.A = 255;
            color.R = (byte)rng.Next(1, 254);
            color.G = (byte)rng.Next(1, 254);
            color.B = (byte)rng.Next(1, 254);

            polyline.Stroke = new System.Windows.Media.SolidColorBrush(color);
            polyline.StrokeThickness = 5;
            polyline.Opacity = 0.7;
            polyline.Locations = data.Locations;
            return polyline;
        }

        public static double RandomDouble(double minimum, double maximum)
        {
            return rng.NextDouble() * (maximum - minimum) + minimum;
        }

        public static List<ViaLocation> RandomLocationsFromOrigin(Location origin, double radius)
        {
            List<ViaLocation> viaLocations = new List<ViaLocation>();
            int via = rng.Next(2, 10);
            for (int i = 0; i < via; i++)
            {
                double lat = WPF.RandomDouble(origin.Latitude - (radius / 110.567), origin.Latitude + (radius / 110.567));
                double lon = WPF.RandomDouble(origin.Longitude - (radius / 111.321), origin.Longitude + (radius / 111.321));
                viaLocations.Add(new ViaLocation(lat.ToString(CultureInfo.InvariantCulture) + "," + lon.ToString(CultureInfo.InvariantCulture), i));
            }
            return viaLocations;
        }
    }
}