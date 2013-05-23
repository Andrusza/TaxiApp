using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Windows;
using System.Xml;

namespace TaxiApp
{
    public static class Http
    {
        private const string bingMapsKey = "Avqh7FnMA4sc2CO93qgYajN2tJ4QbY0r6kk0hshluwp1Q9DLw2r4WUC8TS36Zbvi";

        public static XmlDocument Request(string addressQuery)
        {
            string request = "http://dev.virtualearth.net/REST/v1/Locations/" + addressQuery + "?o=xml&key=" + bingMapsKey;
            XmlDocument response = GetXmlResponse(request);
            return (response);
        }

        public static XmlDocument Request(List<ViaLocation> addresses)
        {
            StringBuilder buldier = new StringBuilder();
            foreach (ViaLocation location in addresses)
            {
                buldier.Append(location.Address);
            }

            string request = "http://dev.virtualearth.net/REST/V1/Routes/Driving?o=xml" + buldier + "&optmz=distance&rpo=Points&key=" + bingMapsKey;
            XmlDocument response = GetXmlResponse(request);
            return (response);
        }

        public static XmlDocument GetXmlResponse(string requestUrl)
        {
            System.Diagnostics.Trace.WriteLine("Request URL (XML): " + requestUrl);
            HttpWebRequest request = WebRequest.Create(requestUrl) as HttpWebRequest;
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    MessageBox.Show(String.Format("Server error (HTTP {0}: {1}).", response.StatusCode, response.StatusDescription), "Error while procesing request", MessageBoxButton.OK, MessageBoxImage.Error);
                    return null;
                }
                else
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(response.GetResponseStream());
                    return xmlDoc;
                }
            }
        }
    }
}