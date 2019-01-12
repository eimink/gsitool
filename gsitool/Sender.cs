using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

namespace gsitool
{
    class Sender
    {
        private readonly List<string> endpoints;

        public Sender(List<string> endpoints)
        {
            this.endpoints = endpoints;
        }   

        public void OnNewData(object sender, DataEventArgs eventArgs)
        {
            ExtendedGSIData data = new ExtendedGSIData
            {
                gsidata = JObject.Parse(eventArgs.Data.JSON),
                seating = Program.playerSeats
            };
            Send(JsonConvert.SerializeObject(data));
        }

        private async void Send(string json)
        {
            Debug.Print(json);
            if (endpoints != null)
            {
                foreach (string uri in endpoints)
                {
                    if (uri != "")
                        await Task.Run(() => SendToEndpoint(uri, json));
                }
            }
        }

        private void SendToEndpoint(string uri, string json)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }
        }
    }
}
