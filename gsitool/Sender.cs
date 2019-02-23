using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System;

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
            try
            {
                System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
                byte[] bytes = encoding.GetBytes(json);
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
                httpWebRequest.ContentType = "application/json;charset=utf-8";
                httpWebRequest.Method = "POST";
                httpWebRequest.ContentLength = bytes.Length;
                httpWebRequest.KeepAlive = false;
                httpWebRequest.Timeout = 2000;
                using (Stream requestStream = httpWebRequest.GetRequestStream())
                {
                    requestStream.Write(bytes, 0, bytes.Length);
                    requestStream.Flush();
                    requestStream.Close();
                }
            }
            catch (Exception e)
            {
                Debug.Print("Exception when sending data: " + e.Message);
            }
        }
    }
}
