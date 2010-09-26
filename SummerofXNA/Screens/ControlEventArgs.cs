using System;
using Microsoft.Xna.Framework;
using SummerofXNA.DataHandler.ContentStructures;

namespace SummerofXNA.Screens
{
    class ControlEventArgs : EventArgs
    {
        ConfigContent control;

        public ControlEventArgs(ConfigContent control) 
        {
            this.control = control;
        }

        public ConfigContent Control 
        {
            get 
            {
                return control;
            }
        }
    }
}
