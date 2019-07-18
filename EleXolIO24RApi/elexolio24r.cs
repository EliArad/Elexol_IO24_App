using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading;

using FT_HANDLE = System.UInt32;

namespace EleXolIO24RApi
{
    public enum PORT_NUMBER
    {
        PORTA = 0x1,
        PORTB = 0x2,
        PORTC = 0x4,
        PORT_ALL = 0xF
    }
    public enum DIRECTION_ALL
    {
        OUTPUT = 0,
        INPUT = 0xFF
    }

    public enum DIRECTION 
    {
        OUTPUT = 0,
        INPUT = 0xFF
    }
    public class elexolio24r
    {

        public enum PIN_NUMBER
        {

        }

        public enum FT_STATUS//:Uint32
        {
            FT_OK = 0,
            FT_INVALID_HANDLE,
            FT_DEVICE_NOT_FOUND,
            FT_DEVICE_NOT_OPENED,
            FT_IO_ERROR,
            FT_INSUFFICIENT_RESOURCES,
            FT_INVALID_PARAMETER,
            FT_INVALID_BAUD_RATE,
            FT_DEVICE_NOT_OPENED_FOR_ERASE,
            FT_DEVICE_NOT_OPENED_FOR_WRITE,
            FT_FAILED_TO_WRITE_DEVICE,
            FT_EEPROM_READ_FAILED,
            FT_EEPROM_WRITE_FAILED,
            FT_EEPROM_ERASE_FAILED,
            FT_EEPROM_NOT_PRESENT,
            FT_EEPROM_NOT_PROGRAMMED,
            FT_INVALID_ARGS,
            FT_OTHER_ERROR
        };

        public const UInt32 FT_BAUD_300 = 300;
        public const UInt32 FT_BAUD_600 = 600;
        public const UInt32 FT_BAUD_1200 = 1200;
        public const UInt32 FT_BAUD_2400 = 2400;
        public const UInt32 FT_BAUD_4800 = 4800;
        public const UInt32 FT_BAUD_9600 = 9600;
        public const UInt32 FT_BAUD_14400 = 14400;
        public const UInt32 FT_BAUD_19200 = 19200;
        public const UInt32 FT_BAUD_38400 = 38400;
        public const UInt32 FT_BAUD_57600 = 57600;
        public const UInt32 FT_BAUD_115200 = 115200;
        public const UInt32 FT_BAUD_230400 = 230400;
        public const UInt32 FT_BAUD_460800 = 460800;
        public const UInt32 FT_BAUD_921600 = 921600;

        public const UInt32 FT_LIST_NUMBER_ONLY = 0x80000000;
        public const UInt32 FT_LIST_BY_INDEX = 0x40000000;
        public const UInt32 FT_LIST_ALL = 0x20000000;
        public const UInt32 FT_OPEN_BY_SERIAL_NUMBER = 1;
        public const UInt32 FT_OPEN_BY_DESCRIPTION = 2;

        // Word Lengths
        public const byte FT_BITS_8 = 8;
        public const byte FT_BITS_7 = 7;
        public const byte FT_BITS_6 = 6;
        public const byte FT_BITS_5 = 5;

        // Stop Bits
        public const byte FT_STOP_BITS_1 = 0;
        public const byte FT_STOP_BITS_1_5 = 1;
        public const byte FT_STOP_BITS_2 = 2;

        // Parity
        public const byte FT_PARITY_NONE = 0;
        public const byte FT_PARITY_ODD = 1;
        public const byte FT_PARITY_EVEN = 2;
        public const byte FT_PARITY_MARK = 3;
        public const byte FT_PARITY_SPACE = 4;

        // Flow Control
        public const UInt16 FT_FLOW_NONE = 0;
        public const UInt16 FT_FLOW_RTS_CTS = 0x0100;
        public const UInt16 FT_FLOW_DTR_DSR = 0x0200;
        public const UInt16 FT_FLOW_XON_XOFF = 0x0400;

        // Purge rx and tx buffers
        public const byte FT_PURGE_RX = 1;
        public const byte FT_PURGE_TX = 2;

        byte [] m_writeValue = new byte[3];
        // Events
        public const UInt32 FT_EVENT_RXCHAR = 1;
        public const UInt32 FT_EVENT_MODEM_STATUS = 2;

        byte[] m_direction = { 0, 0, 0 };
        //FTDI DLL import API Functions

        [DllImport("FTD2XX.dll")]
        static extern unsafe FT_STATUS FT_ListDevices(void* pvArg1, void* pvArg2, UInt32 dwFlags);	// FT_ListDevices by number only
        [DllImport("FTD2XX.dll")]
        static extern unsafe FT_STATUS FT_ListDevices(UInt32 pvArg1, void* pvArg2, UInt32 dwFlags);	// FT_ListDevcies by serial number or description by index only
        [DllImport("FTD2XX.dll")]
        static extern FT_STATUS FT_Open(UInt32 uiPort, ref FT_HANDLE ftHandle);
        [DllImport("FTD2XX.dll")]
        static extern unsafe FT_STATUS FT_OpenEx(void* pvArg1, UInt32 dwFlags, ref FT_HANDLE ftHandle);
        [DllImport("FTD2XX.dll")]
        static extern FT_STATUS FT_Close(FT_HANDLE ftHandle);
        [DllImport("FTD2XX.dll")]
        static extern unsafe public FT_STATUS FT_Read(FT_HANDLE ftHandle, void* lpBuffer, UInt32 dwBytesToRead, ref UInt32 lpdwBytesReturned);
        [DllImport("FTD2XX.dll")]
        static extern unsafe public FT_STATUS FT_Write(FT_HANDLE ftHandle, void* lpBuffer, UInt32 dwBytesToRead, ref UInt32 lpdwBytesWritten);
        [DllImport("FTD2XX.dll")]
        static extern unsafe FT_STATUS FT_SetBaudRate(FT_HANDLE ftHandle, UInt32 dwBaudRate);
        [DllImport("FTD2XX.dll")]
        static extern unsafe FT_STATUS FT_SetDataCharacteristics(FT_HANDLE ftHandle, byte uWordLength, byte uStopBits, byte uParity);
        [DllImport("FTD2XX.dll")]
        static extern unsafe FT_STATUS FT_SetFlowControl(FT_HANDLE ftHandle, char usFlowControl, byte uXon, byte uXoff);
        [DllImport("FTD2XX.dll")]
        static extern unsafe FT_STATUS FT_SetDtr(FT_HANDLE ftHandle);
        [DllImport("FTD2XX.dll")]
        static extern unsafe FT_STATUS FT_ClrDtr(FT_HANDLE ftHandle);
        [DllImport("FTD2XX.dll")]
        static extern unsafe FT_STATUS FT_SetRts(FT_HANDLE ftHandle);
        [DllImport("FTD2XX.dll")]
        static extern unsafe FT_STATUS FT_ClrRts(FT_HANDLE ftHandle);
        [DllImport("FTD2XX.dll")]
        static extern unsafe FT_STATUS FT_GetModemStatus(FT_HANDLE ftHandle, ref UInt32 lpdwModemStatus);
        [DllImport("FTD2XX.dll")]
        static extern unsafe FT_STATUS FT_SetChars(FT_HANDLE ftHandle, byte uEventCh, byte uEventChEn, byte uErrorCh, byte uErrorChEn);
        [DllImport("FTD2XX.dll")]
        static extern unsafe FT_STATUS FT_Purge(FT_HANDLE ftHandle, UInt32 dwMask);
        [DllImport("FTD2XX.dll")]
        static extern unsafe FT_STATUS FT_SetTimeouts(FT_HANDLE ftHandle, UInt32 dwReadTimeout, UInt32 dwWriteTimeout);
        [DllImport("FTD2XX.dll")]
        static extern unsafe public FT_STATUS FT_GetQueueStatus(FT_HANDLE ftHandle, ref UInt32 lpdwAmountInRxQueue);
        [DllImport("FTD2XX.dll")]
        static extern unsafe FT_STATUS FT_SetBreakOn(FT_HANDLE ftHandle);
        [DllImport("FTD2XX.dll")]
        static extern unsafe FT_STATUS FT_SetBreakOff(FT_HANDLE ftHandle);
        [DllImport("FTD2XX.dll")]
        static extern unsafe FT_STATUS FT_GetStatus(FT_HANDLE ftHandle, ref UInt32 lpdwAmountInRxQueue, ref UInt32 lpdwAmountInTxQueue, ref UInt32 lpdwEventStatus);
        [DllImport("FTD2XX.dll")]
        static extern unsafe FT_STATUS FT_SetEventNotification(FT_HANDLE ftHandle, UInt32 dwEventMask, void* pvArg);
        [DllImport("FTD2XX.dll")]
        static extern unsafe FT_STATUS FT_ResetDevice(FT_HANDLE ftHandle);
        [DllImport("FTD2XX.dll")]
        static extern unsafe FT_STATUS FT_SetDivisor(FT_HANDLE ftHandle, char usDivisor);
        [DllImport("FTD2XX.dll")]
        static extern unsafe FT_STATUS FT_GetLatencyTimer(FT_HANDLE ftHandle, ref byte pucTimer);
        [DllImport("FTD2XX.dll")]
        static extern unsafe FT_STATUS FT_SetLatencyTimer(FT_HANDLE ftHandle, byte ucTimer);
        [DllImport("FTD2XX.dll")]
        static extern unsafe FT_STATUS FT_GetBitMode(FT_HANDLE ftHandle, ref byte pucMode);
        [DllImport("FTD2XX.dll")]
        static extern unsafe FT_STATUS FT_SetBitMode(FT_HANDLE ftHandle, byte ucMask, byte ucEnable);
        [DllImport("FTD2XX.dll")]
        static extern unsafe FT_STATUS FT_SetUSBParameters(FT_HANDLE ftHandle, UInt32 dwInTransferSize, UInt32 dwOutTransferSize);
        protected UInt32 dwListDescFlags;
        public static UInt32 m_hPort;
        protected bool fContinue;

        public elexolio24r()
        {
            dwListDescFlags = FT_LIST_ALL;
            Array.Clear(m_writeValue, 0, m_writeValue.Length);
        }

        public virtual unsafe bool ListUnopenDevices(out string [] deviceList)
        {
            FT_STATUS ftStatus = FT_STATUS.FT_OTHER_ERROR;
            UInt32 numDevs;
            int i;
            byte[] sDevName = new byte[64];
            void* p1;
            string[] dlist = new string[100];

            int index = 0;
            p1 = (void*)&numDevs;
            ftStatus = FT_ListDevices(p1, null, FT_LIST_NUMBER_ONLY);

            dwListDescFlags = 0x40000002;
            if (ftStatus == FT_STATUS.FT_OK)
            {            
                for (i = 0; i < numDevs; i++)
                {
                    fixed (byte* pBuf = sDevName)
                    {
                        ftStatus = FT_ListDevices((UInt32)i, pBuf, dwListDescFlags);
                        if (ftStatus == FT_STATUS.FT_OK)
                        {
                            string str;
                            System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding();
                            str = enc.GetString(sDevName, 0, sDevName.Length);
                            if (str.Contains("USB I/O 24 R"))
                            {
                                dlist[index++] = str;
                            }
                        }
                        else
                        {
                           
                        }
                    }
                }
            }
            deviceList = new string[index];
            Array.Copy(dlist, 0, deviceList, 0, index);
            return true;
        }

        //**************************************
        //Opens FTDI device from Drop Down list
        //**************************************
        unsafe public virtual bool Open(string deviceName)
        {
            uint dwOpenFlag = 1;
            return Open(dwOpenFlag, 0 , deviceName);
        }

        unsafe public virtual bool Open(uint deviceNumber)
        {
            uint dwOpenFlag = 0;
            return Open(dwOpenFlag, deviceNumber , string.Empty);
        }

        public virtual void Close()
        {
            lock (this)
            {
                if (m_hPort != 0)
                {
                    fContinue = false;
                    // it will stop in 3 seconds - not sure if this is proper
                    //Thread.Sleep(3000);
                    FT_Close(m_hPort);
                    m_hPort = 0;
                }
            }
        }

        unsafe protected virtual bool Open(uint dwOpenFlag, uint deviceNumber, string deviceName)
        { 
            FT_STATUS ftStatus = FT_STATUS.FT_OTHER_ERROR;

            if (m_hPort == 0)
            {
                dwOpenFlag = dwListDescFlags & ~FT_LIST_BY_INDEX;
                dwOpenFlag = dwListDescFlags & ~FT_LIST_ALL;

                if (dwOpenFlag == 0)
                {
                    ftStatus = FT_Open(deviceNumber, ref m_hPort);
                }
                else
                {
                    System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding();
                    byte[] sDevName = enc.GetBytes(deviceName);
                    fixed (byte* pBuf = sDevName)
                    {
                        ftStatus = FT_OpenEx(pBuf, dwOpenFlag, ref m_hPort);
                    }
                }
            }

            if (ftStatus == FT_STATUS.FT_OK)
            {
                // Set up the port
                FT_SetBaudRate(m_hPort, 4800);
                FT_Purge(m_hPort, FT_PURGE_RX | FT_PURGE_TX);
                FT_SetTimeouts(m_hPort, 3000, 3000);
                // Start up the read and write thread
                fContinue = true;
                return true;
            }
            else
            {
                return false;
            }
        }

        public virtual void setALLDirectionOutput()
        {
            byte direction = 0x0;
            WriteDirection('A', direction); //set Port A to initialise A/D Board 
            WriteDirection('B', direction); //set Port A to initialise A/D Board 
            WriteDirection('C', direction); //set Port A to initialise A/D Board 

        }
        public virtual void setDirection(PORT_NUMBER portNum, byte direction)
        {

            for (int i = 0; i < 3; i++)
            {
                if (((1 << i) & (int)portNum) == (int)portNum)
                {
                    int pnum = (int)portNum;
                    pnum = (pnum >> i) & 0x1;
                    switch (i)
                    {
                        case 0:
                            WriteDirection('A', direction); //set Port A to initialise A/D Board 
                            break;
                        case 1:
                            WriteDirection('B', direction); //set Port B to input
                            break;
                        case 2:
                            WriteDirection('C', direction); //set Port C to input
                            break;
                    }
                }
            }
        }

        unsafe protected virtual void WriteDirection(char port, byte value)
        {
            UInt32 dwRet = 0;
            FT_STATUS ftStatus = FT_STATUS.FT_OTHER_ERROR;
            byte[] cBuf = new byte[5];

            cBuf[0] = (byte)'!';
            cBuf[1] = (byte)port;
            cBuf[2] = value;

            switch (port)
            {
                case 'A':
                    m_direction[0] = value;
                break;
                case 'B':
                    m_direction[1] = value;
                break;
                case 'C':
                    m_direction[2] = value;
                break;
            }   
            fixed (byte* pBuf = cBuf)
            {
                ftStatus = FT_Write(m_hPort, pBuf, 3, ref dwRet);
                if (ftStatus != FT_STATUS.FT_OK && dwRet != 3)
                    throw (new SystemException("Error WriteDirection"));
            }
        }
        unsafe protected virtual void WritePullup(char port, byte value)
        {
            UInt32 dwRet = 0;
            FT_STATUS ftStatus = FT_STATUS.FT_OTHER_ERROR;
            byte[] cBuf = new byte[5];

            cBuf[0] = (byte)'@';
            cBuf[1] = (byte)port;
            cBuf[2] = value;
            fixed (byte* pBuf = cBuf)
            {
                ftStatus = FT_Write(m_hPort, pBuf, 3, ref dwRet);
                if (ftStatus != FT_STATUS.FT_OK && dwRet != 3)
                    throw (new SystemException("Error WritePullup"));
            }
        }

        unsafe public virtual void WriteValue(char port, byte value)
        {
            UInt32 dwRet = 0;
            FT_STATUS ftStatus = FT_STATUS.FT_OTHER_ERROR;
            byte[] cBuf = new byte[5];

            cBuf[0] = (byte)port;
            cBuf[1] = value;
            fixed (byte* pBuf = cBuf)
            {
                ftStatus = FT_Write(m_hPort, pBuf, 2, ref dwRet);
                if (ftStatus != FT_STATUS.FT_OK && dwRet != 2)
                    throw (new SystemException("WriteValue error: " + ftStatus));

            }
        }

        unsafe public virtual void WriteValue(char port, char value)
        {
            UInt32 dwRet = 0;
            FT_STATUS ftStatus = FT_STATUS.FT_OTHER_ERROR;
            byte[] cBuf = new byte[5];

            cBuf[0] = (byte)port;
            cBuf[1] = (byte)value;
            fixed (byte* pBuf = cBuf)
            {
                ftStatus = FT_Write(m_hPort, pBuf, 2, ref dwRet);
                if (ftStatus != FT_STATUS.FT_OK && dwRet != 2)
                    throw (new SystemException("WriteValue error: " + ftStatus));

            }
        }
        unsafe public virtual void Write(PORT_NUMBER portNum, byte value)
        {
            try
            {
                switch (portNum)
                {
                    case PORT_NUMBER.PORTA:
                        m_writeValue[0] = value;
                        WriteValue('A', value); //set Port A to initialise A/D Board                   
                        break;
                    case PORT_NUMBER.PORTB:
                        m_writeValue[1] = value;
                        WriteValue('B', value); //set Port B to input
                        break;
                    case PORT_NUMBER.PORTC:
                        m_writeValue[2] = value;
                        WriteValue('C', value); //set Port C to input
                        break;
                }
            }
            catch (Exception err)
            {
                throw (new SystemException(err.Message));
            }
        }

        public byte getValue(PORT_NUMBER portNum)
        {
            return m_writeValue[(int)portNum];
        }
        public byte getValue(byte portNum)
        {
            return m_writeValue[portNum];
        }

        unsafe public virtual void Write(byte portNum, byte value)
        {
            try
            {
                m_writeValue[portNum] = value;
                switch (portNum)
                {
                    case 0:
                        WriteValue('A', value); //set Port A to initialise A/D Board 
                        break;
                    case 1:
                        WriteValue('B', value); //set Port B to input
                        break;
                    case 2:
                        WriteValue('C', value); //set Port C to input
                        break;
                }
            }
            catch (Exception err)
            {
                throw (new SystemException(err.Message));
            }
        }


        unsafe public byte[] ReadValue_SPI(UInt32 rxCount)
        {
            UInt32 dwRet = 0;
            FT_STATUS ftStatus = FT_STATUS.FT_OTHER_ERROR;
            byte[] cBuf = new byte[rxCount];

            dwRet = 0;
            long timeout;
            timeout = 0;

            do
            {
                ftStatus = FT_GetQueueStatus(m_hPort, ref dwRet);
                timeout++;
            } while ((dwRet < rxCount) && (timeout < 100000));

            if (timeout == 100000)
            {
                return null;
            }

            fixed (byte* pBuf = cBuf)
            {
                ftStatus = FT_Read(m_hPort, pBuf, rxCount, ref dwRet);
            }

            if (ftStatus != FT_STATUS.FT_OK)
            {
                return null;
            }

            return (cBuf);
        }

        unsafe public byte[] Read(UInt32 rxCount)
        {
            UInt32 dwRet = 0;
            FT_STATUS ftStatus = FT_STATUS.FT_OTHER_ERROR;
            byte[] cBuf = new byte[3];

            cBuf[0] = (byte)'!';
            cBuf[1] = (byte)0; // PORT A
            cBuf[2] = 0xFF;
            // write the direction to output 
            fixed (byte* pBuf = cBuf)
            {
                ftStatus = FT_Write(m_hPort, pBuf, 3, ref dwRet);
                if (ftStatus != FT_STATUS.FT_OK && dwRet != 3)
                    throw (new SystemException("Error WriteDirection"));
            }
                        
            fixed (byte* pBuf = cBuf)
            {
                ftStatus = FT_Read(m_hPort, pBuf, rxCount, ref dwRet);
            }


            if (ftStatus != FT_STATUS.FT_OK)
            {
                return null;
            }

            return (cBuf);
        }

        protected unsafe virtual void WriteSpeedTest()
        {
            UInt32 dwRet = 0;
            FT_STATUS ftStatus = FT_STATUS.FT_OTHER_ERROR;

            uint loopCount = 20;
            byte[] outBuffer = new byte[3];

            // Set Direction to Output
            outBuffer[0] = (byte)'!';
            outBuffer[1] = (byte)'A';
            outBuffer[2] = (byte)0x00;

            fixed (byte* pBuf = outBuffer)
            {
                ftStatus = FT_Write(m_hPort, pBuf, 3, ref dwRet);
                if (ftStatus != FT_STATUS.FT_OK && dwRet != 3)
                    throw (new SystemException("Error WriteSpeedTest"));
            }

            for (int i = 0; i < loopCount; i++)
            {
                // Load Write command 
                outBuffer[0] = (byte)'A';
                outBuffer[1] = (byte)0xFF;

                // Transmit command
                fixed (byte* pBuf = outBuffer)
                {
                    ftStatus = FT_Write(m_hPort, pBuf, 2, ref dwRet);
                    if (ftStatus != FT_STATUS.FT_OK && dwRet != 2)
                        throw (new SystemException("Error WriteSpeedTest"));
                }

                // Load Write command 
                outBuffer[0] = (byte)'A';
                outBuffer[1] = (byte)0x00;

                // Transmit command
                fixed (byte* pBuf = outBuffer)
                {
                    ftStatus = FT_Write(m_hPort, pBuf, 2, ref dwRet);
                    if (ftStatus != FT_STATUS.FT_OK && dwRet != 2)
                        throw (new SystemException("Error WriteSpeedTest"));

                }
            }
        }

    }
}
