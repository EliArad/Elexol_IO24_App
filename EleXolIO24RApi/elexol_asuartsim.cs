using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading;

using FT_HANDLE = System.UInt32;

namespace EleXolIO24RApi
{

    public class elexol_asuartsim : elexol_asuart
    {
        byte[] m_writeValue = new byte[3];

        protected UInt32 dwListDescFlags;
        public static UInt32 m_hPort;
        protected bool fContinue;

        public elexol_asuartsim(string COMPORT)
            : base(COMPORT)
        {
            
        }

        public override bool Open()
        {

            return true;
        }

        public override void setAllDirection(DIRECTION_ALL direction)
        {
            
        }
        public elexol_asuartsim GetBase()
        {
            return this;
        }
        public override void setDirection(PORT_NUMBER port, DIRECTION_ALL direction)
        {
            
        }

        public override void setDirection(PORT_NUMBER port, DIRECTION direction, byte inputPins)
        {
             
        }
        public override void Write(PORT_NUMBER port, byte value)
        {

            
        }

        public override void Write(char port, byte value)
        {

            
        }

        public override void Write(PORT_NUMBER port, byte writePins, byte value)
        {
            
        }
        public override bool ReadPort(PORT_NUMBER port, out byte valueRead)
        {
            valueRead = 1;
            return true;     

        }
        public override bool Read(PORT_NUMBER port, byte InputPins, out byte valueRead)
        {
            valueRead = 1;
            return true;
        }
    }
}
