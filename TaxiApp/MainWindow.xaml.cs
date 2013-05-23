using Microsoft.Maps.MapControl.WPF;
using System.Collections.Generic;
using System.Threading;
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

            Location origin = new Location(52.228683, 20.881577);

            List<TaxiDriver> drivers = new List<TaxiDriver>();
            drivers.Add(new TaxiDriver(52.228683, 20.181577));
            drivers.Add(new TaxiDriver(53.228683, 20.781577));
            drivers.Add(new TaxiDriver(52.258683, 20.881577));
            drivers.Add(new TaxiDriver(52.218683, 20.821577));
            drivers.Add(new TaxiDriver(54.228683, 21.181577));
            drivers.Add(new TaxiDriver(53.228683, 21.981577));
            drivers.Add(new TaxiDriver(52.258683, 21.881577));
            drivers.Add(new TaxiDriver(51.218683, 20.121577));

            List<Thread> threads = new List<Thread>();

            foreach (TaxiDriver driver in drivers)
            {
                Thread t = new Thread(driver.ProcessRequest);
                t.IsBackground = true;
                t.Start();
                threads.Add(t);
            }

            foreach (Thread t in threads)
            {
                t.Join();
            }

            foreach (TaxiDriver driver in drivers)
            {
                worldMap.Children.Add(WPF.DrawRoad(driver.Destination));
            }
        }
    }
}