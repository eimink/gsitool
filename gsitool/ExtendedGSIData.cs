using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace gsitool
{
    [Serializable]
    class ExtendedGSIData
    {
        public PlayerSeatNode[] seating;
        public JObject gsidata;
    }
}
