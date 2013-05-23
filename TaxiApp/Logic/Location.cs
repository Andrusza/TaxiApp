using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace TaxiApp
{
    public class LocationData
    {
        public String Country;
        public String Town;
        public String Street;
        public String StreetNum;
        private Location geographicInfo;
    }

    public class TravelData
    {
        private string sDistance;
        private double dDistance;
        private string sTravelTime;
        private double dTravelTime;
        private LocationCollection locations;

        public LocationCollection Locations
        {
            get { return locations; }
            set { locations = value; }
        }

        public double DoubleDistance
        {
            get { return dDistance; }
            set { dDistance = value; sDistance = Convert.ToString(value); }
        }

        public string StringDistance
        {
            get { return sDistance; }
            set { sDistance = value; dDistance = Double.Parse(value, CultureInfo.InvariantCulture); }
        }

        public double DoubleTravelTime
        {
            get { return dTravelTime; }
            set { dTravelTime = value; sTravelTime = Convert.ToString(value); }
        }

        public string StringTravelTime
        {
            get { return sTravelTime; }
            set { sTravelTime = value; dTravelTime = Double.Parse(value, CultureInfo.InvariantCulture); }
        }
    }

    public class ViaLocation
    {
        private String address;
        private int instanceId;

        public int Id
        {
            get { return instanceId; }
            set { instanceId = value; }
        }

        private static int globalId = 0;

        public String Address
        {
            get { return String.Format("&wp.{0}={1}", Id, address); }
            set { address = value; }
        }

        public ViaLocation(String address)
        {
            Address = address;
            instanceId = globalId;
            globalId++;
        }
    }
}