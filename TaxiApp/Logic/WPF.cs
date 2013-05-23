using Microsoft.Maps.MapControl.WPF;

namespace TaxiApp
{
    public static class WPF
    {
        public static MapPolyline DrawRoad(TravelData data)
        {
            MapPolyline polyline = new MapPolyline();
            polyline.Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Blue);
            polyline.StrokeThickness = 5;
            polyline.Opacity = 0.7;
            polyline.Locations = data.Locations;
            return polyline;
        }
    }
}