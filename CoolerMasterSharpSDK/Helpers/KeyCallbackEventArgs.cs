using System;
using System.Collections.Generic;
using System.Text;

namespace CoolerMasterSharpSDK.Helpers
{
    public class KeyCallbackEventArgs : EventArgs
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public bool Pressed { get; set; }

        public KeyCallbackEventArgs(int row, int column, bool pressed)
        {
            Row = row;
            Column = column;
            Pressed = pressed;
        }
    }
}
