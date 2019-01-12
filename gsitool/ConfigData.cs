using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace gsitool
{
    [Serializable]
    class ConfigData
    {
        public string bindIP = "localhost";
        public int bindPort = 3000;
        public List<String> listeners;

        public void Load()
        {
            string filePath = Directory.GetCurrentDirectory() + @"\config.json";
            if (File.Exists(filePath))
            {
                TextReader reader = null;
                try
                {
                    reader = new StreamReader(filePath);
                    var fileContents = reader.ReadToEnd();
                    var conf = JsonConvert.DeserializeObject<ConfigData>(fileContents);
                    bindIP = conf.bindIP;
                    bindPort = conf.bindPort;
                    listeners = conf.listeners;
                }
                catch (FileNotFoundException e)
                {
                    Debug.Print("Error loading config: " + e.Message);
                    Save();
                }
                finally
                {
                    if (reader != null)
                        reader.Close();
                }
            }
        }
        public void Save()
        {
            TextWriter writer = null;
            try
            {
                writer = new StreamWriter(Directory.GetCurrentDirectory() + @"\config.json", false);
                writer.Write(JsonConvert.SerializeObject(this, Formatting.Indented));
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }
    }
}
