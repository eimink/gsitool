using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gsitool
{
    public class DataEventArgs : EventArgs
    {
        public CSGSI.GameState Data { get; set; }
    }
}
