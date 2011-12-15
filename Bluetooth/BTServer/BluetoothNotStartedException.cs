using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace BTServer
{
    public class BluetoothNotStartedException : Exception
    {
        public override string Message
        {
            get
            {
                return "Could not start Bluetooth Server";
            }
        }
    }
}
