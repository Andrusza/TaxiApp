using Microsoft.Maps.MapControl.WPF;
using System;
using System.Globalization;
using System.Windows;
using System.Xml;

namespace TaxiApp
{
    static public class XML
    {
        public static Location SetGeographicInfo(string latitude, string longitude)
        {
            return new Location(Double.Parse(latitude, CultureInfo.InvariantCulture), Double.Parse(longitude, CultureInfo.InvariantCulture));
        }

        public static TravelData ParseXMLToRoad(XmlDocument data)
        {
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(data.NameTable);
            nsmgr.AddNamespace("rest", "http://schemas.microsoft.com/search/local/ws/rest/v1");
            XmlNodeList roadElements = data.SelectNodes("//rest:Line", nsmgr);
            if (roadElements.Count == 0)
            {
                MessageBox.Show("No road found :(", "Highway to hell", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
            else
            {
                LocationCollection locations = new LocationCollection();
                XmlNodeList points = roadElements[0].SelectNodes(".//rest:Point", nsmgr);
                foreach (XmlNode point in points)
                {
                    string latitude = point.SelectSingleNode(".//rest:Latitude", nsmgr).InnerText;
                    string longitude = point.SelectSingleNode(".//rest:Longitude", nsmgr).InnerText;

                    locations.Add(XML.SetGeographicInfo(latitude, longitude));
                }
                TravelData travelData = new TravelData();
                travelData.StringDistance = data.SelectSingleNode(".//rest:TravelDistance", nsmgr).InnerText;
                travelData.StringTravelTime = data.SelectSingleNode(".//rest:TravelDuration", nsmgr).InnerText;
                travelData.Locations = locations;
                return travelData;
            }
        }
    }
}