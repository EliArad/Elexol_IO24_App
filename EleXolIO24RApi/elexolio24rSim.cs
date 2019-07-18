using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading;

using FT_HANDLE = System.UInt32;

namespace EleXolIO24RApi
{

    public class elexolio24rSim : elexolio24r
    {
        byte[] m_writeValue = new byte[3];

        protected UInt32 dwListDescFlags;
        public static UInt32 m_hPort;
        protected bool fContinue;

        public elexolio24rSim() 
        {
            
        }

        public override unsafe bool ListUnopenDevices(out string [] deviceList)
        {
            deviceList = new string[1];
            deviceList[0] = "Elexxol Sim";
            return true;
        }

        //**************************************
        //Opens FTDI device from Drop Down list
        //**************************************
        unsafe public override bool Open(string deviceName)
        {
            return true;
        }

        unsafe public override bool Open(uint deviceNumber)
        {
            return true;
        }

        public override void Close()
        {
             
        }

        unsafe protected override bool Open(uint dwOpenFlag, uint deviceNumber, string deviceName)
        {
            return Open(dwOpenFlag, deviceNumber, string.Empty);

        }

        public override void setALLDirectionOutput()
        {
           

        }
        public override void setDirection(PORT_NUMBER portNum, byte direction)
        {

           
        }

        unsafe protected override void WriteDirection(char port, byte value)
        {
            
        }
        unsafe protected override void WritePullup(char port, byte value)
        {
            
        }

        unsafe public override void WriteValue(char port, byte value)
        {
            
        }
        unsafe public override void Write(PORT_NUMBER portNum, byte value)
        {
            switch (portNum)
            {
                case PORT_NUMBER.PORTA:
                    m_writeValue[0] = value;
                    break;
                case PORT_NUMBER.PORTB:
                    m_writeValue[1] = value;
                    break;
                case PORT_NUMBER.PORTC:
                    m_writeValue[2] = value;
                    break;
            }
        }

        public byte overridegetValue(PORT_NUMBER portNum)
        {
            return m_writeValue[(int)portNum];
        }
        public byte getValue(byte portNum)
        {
            return m_writeValue[portNum];
        }

        unsafe public override void Write(byte portNum, byte value)
        {
            m_writeValue[portNum] = value;
        }


        unsafe public byte[] ReadValue_SPI(UInt32 rxCount)
        {
            return new byte[2];
        }

        protected unsafe override void WriteSpeedTest()
        {
        }
    }
}
