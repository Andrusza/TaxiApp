using System.Collections.Generic;
using System.Windows;

namespace TaxiApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ViaLocation v = new ViaLocation("52.228683,20.881577");
            ViaLocation v2 = new ViaLocation("Rokokowa,Warszawa");
            List<ViaLocation> list = new List<ViaLocation>();
            list.Add(v);
            list.Add(v2);

            TravelData travelData = XML.ParseXMLToRoad(Http.Request(list));
            worldMap.Children.Add(WPF.DrawRoad(travelData));
        }
    }
}