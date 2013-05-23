using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.Windows;

namespace TaxiApp
{
    public class TaxiDriver : Beheviour
    {
        private static int globalid = 0;

        private int id;
        private TravelData destination;

        public TravelData Destination
        {
            get { return destination; }
            set { destination = value; }
        }

        private Location currentLocation;
        private double earning = 0;

        public void ProcessRequest()
        {
            List<ViaLocation> address = WPF.RandomLocationsFromOrigin(currentLocation, WPF.Rng.Next(5, 200));
            destination = XML.ParseXMLToRoad(Http.Request(address));
            Console.WriteLine(destination.StringTravelTime);

            bool drive = CalculateEarnings();

            //MessageBox.Show("Driver " + id + " earned " + earning, drive.ToString(), MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public bool CalculateEarnings()
        {
            double costs = destination.DoubleDistance * (1.0 / Math.Sqrt(destination.DoubleDistance)) * faulCost;
            double earn = startCost + costPerKm * destination.DoubleDistance - costs;
            if (earn > minEarning) { earning += earn; return true; }
            else return false;
        }

        public TaxiDriver(double currentl, double currentlo)
        {
            currentLocation = new Location(currentl, currentlo);
            id = globalid++;

            faulCost = WPF.RandomDouble(1.0, 100);

            startCost = WPF.RandomDouble(0.0, faulCost * 2);
            workSpan = WPF.RandomDouble(1.0, 10.0);
            workLeft = workSpan;

            costPerKm = WPF.RandomDouble(faulCost, faulCost * 10.0);

            minEarning = WPF.RandomDouble(faulCost, faulCost * 5.0);
        }
    }

    public abstract class Beheviour
    {
        public double costPerKm;
        public double startCost;
        public double workSpan;
        public double workLeft;
        public double minEarning;

        public double faulCost;
        public double attractive;
    }
}