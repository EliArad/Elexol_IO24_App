using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bulb;
using VectonJig;
using EleXolIO24RApi;
using System.Threading;

namespace ElexolControlApp
{
    public partial class Form1 : Form
    {

        bool m_open = false;
        elexol_asuart m_ttl;
        byte[] m_portValue = { 0, 0, 0 };
        bool m_running = false;
        Thread m_thread;
        
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = Properties.Settings.Default.COMPORT;
        }

        void ReadingPins()
        {
            m_running = true;


            CheckBox[] portaChecks = { checkBox32, checkBox31, checkBox30, checkBox29, checkBox28, checkBox27, checkBox26, checkBox25 };
            CheckBox[] portbChecks = { checkBox35, checkBox37, checkBox34, checkBox38, checkBox40, checkBox39, checkBox36, checkBox33 };
            CheckBox[] portcChecks = { checkBox43, checkBox35, checkBox42, checkBox46, checkBox48, checkBox47, checkBox44, checkBox41 };

            LedBulb[] ledA = { lbA1, lbA2, lbA3, lbA4, lbA5, lbA6, lbA7, lbA8 };
            LedBulb[] ledB = { lbB1, lbB2, lbB3, lbB4, lbB5, lbB6, lbB7, lbB8 };
            LedBulb[] ledC = { lbC1, lbC2, lbC3, lbC4, lbC5, lbC6, lbC7, lbC8 };

            try
            {

                byte[] value = { 0, 0, 0 };
                while (m_running)
                {
                    int i = 0;
                    foreach (CheckBox c in portaChecks)
                    {
                        if (c.Checked == false)
                        {
                            m_ttl.Read(PORT_NUMBER.PORTA, out value[0]);
                            ledA[i].On = ((value[0] >> i) & 0x1) == 1 ? true : false;
                        }
                        i++;
                    }
                    i = 0;

                    foreach (CheckBox c in portbChecks)
                    {
                        if (c.Checked == false)
                        {
                            m_ttl.Read(PORT_NUMBER.PORTB, (byte)(1 << i), out value[1]);
                            ledB[i].On = (value[1] >> i & 0x1) == 1 ? true : false;
                        }
                        i++;
                    }
                    i = 0;
                    foreach (CheckBox c in portcChecks)
                    {

                        if (c.Checked == false)
                        {
                            m_ttl.Read(PORT_NUMBER.PORTC, (byte)(1 << i), out value[2]);
                            ledC[i].On = (value[2] >> i & 0x1) == 1 ? true : false;
                        }
                        i++;
                    }
                    Thread.Sleep(0);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        void SetAllInput(PORT_NUMBER port)
        {

            int _port = (int)port;
            if ((_port & 0x1) == 0x1)
            {
                CheckBox[] portaChecks = { checkBox32, checkBox31, checkBox30, checkBox29, checkBox28, checkBox27, checkBox26, checkBox25 };
                foreach (CheckBox c in portaChecks)
                {
                    c.Checked = false;
                }
                m_ttl.setDirection(PORT_NUMBER.PORTA, DIRECTION.INPUT, 0xFF);
            }

            if ((_port & 0x2) == 0x2)
            {
                CheckBox[] portbChecks = { checkBox35, checkBox37, checkBox34, checkBox38, checkBox40, checkBox39, checkBox36, checkBox33 };
                foreach (CheckBox c in portbChecks)
                {
                    c.Checked = false;
                }
                m_ttl.setDirection(PORT_NUMBER.PORTB, DIRECTION.INPUT, 0xFF);
            }

            if ((_port & 0x4) == 0x4)
            {
                CheckBox[] portcChecks = { checkBox43, checkBox35, checkBox42, checkBox46, checkBox48, checkBox47, checkBox44, checkBox41 };
                foreach (CheckBox c in portcChecks)
                {
                    c.Checked = false;
                }
                m_ttl.setDirection(PORT_NUMBER.PORTC, DIRECTION.INPUT, 0xFF);
            }
        }
        void SetAllOutput(PORT_NUMBER port)
        {
            int _port  = (int)port;
            if ((_port & 0x1) == 0x1)
            {                
                CheckBox[] portaChecks = { checkBox32, checkBox31, checkBox30, checkBox29, checkBox28, checkBox27, checkBox26, checkBox25 };
                foreach (CheckBox c in portaChecks)
                {
                    c.Checked = true;
                }
                m_ttl.setDirection(PORT_NUMBER.PORTA , DIRECTION.OUTPUT , 0xFF);
            }

            if ((_port & 0x2) == 0x2)
            {
                CheckBox[] portbChecks = { checkBox35, checkBox37, checkBox34, checkBox38, checkBox40, checkBox39, checkBox36, checkBox33 };
                foreach (CheckBox c in portbChecks)
                {
                    c.Checked = true;
                }
                m_ttl.setDirection(PORT_NUMBER.PORTB, DIRECTION.OUTPUT, 0xFF);
            }

            if ((_port & 0x4) == 0x4)
            {
                CheckBox[] portcChecks = { checkBox43, checkBox35, checkBox42, checkBox46, checkBox48, checkBox47, checkBox44, checkBox41 };
                foreach (CheckBox c in portcChecks)
                {
                    c.Checked = true;
                }
                m_ttl.setDirection(PORT_NUMBER.PORTC, DIRECTION.OUTPUT, 0xFF);
            }
        }

        void SetAllInputs(PORT_NUMBER port)
        {
            int _port = (int)port;
            if ((_port & 0x1) == 0x1)
            {
                CheckBox[] portaChecks = { checkBox32, checkBox31, checkBox30, checkBox29, checkBox28, checkBox27, checkBox26, checkBox25 };
                foreach (CheckBox c in portaChecks)
                {
                    c.Checked = false;
                }
                m_ttl.setDirection(PORT_NUMBER.PORTA, DIRECTION.INPUT, 0xFF);
            }

            if ((_port & 0x2) == 0x2)
            {
                CheckBox[] portbChecks = { checkBox35, checkBox37, checkBox34, checkBox38, checkBox40, checkBox39, checkBox36, checkBox33 };
                foreach (CheckBox c in portbChecks)
                {
                    c.Checked = false;
                }
                m_ttl.setDirection(PORT_NUMBER.PORTB, DIRECTION.INPUT, 0xFF);
            }

            if ((_port & 0x4) == 0x4)
            {
                CheckBox[] portcChecks = { checkBox43, checkBox35, checkBox42, checkBox46, checkBox48, checkBox47, checkBox44, checkBox41 };
                foreach (CheckBox c in portcChecks)
                {
                    c.Checked = false;
                }
                m_ttl.setDirection(PORT_NUMBER.PORTC, DIRECTION.INPUT, 0xFF);
            }

        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_open == false)
                {
                    m_ttl = new elexol_asuart(textBox1.Text);
                    m_ttl.Open();
                    Properties.Settings.Default.COMPORT = textBox1.Text;
                    Properties.Settings.Default.Save();
                    m_open = true;
                    btnConnect.Text = "Disconnect";
                    SetAllOutput(PORT_NUMBER.PORT_ALL);

                    m_thread = new Thread(ReadingPins);
                    m_thread.Start();
                }
                else
                {
                    CloseApp();
                    btnConnect.Text = "Connect";
                    return;
                }
              
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            m_portValue[0] = checkBox1.Checked == true ? (byte)(m_portValue[0] | 0x1) : (byte)(m_portValue[1] & ~0x1);
            m_ttl.Write(PORT_NUMBER.PORTA, m_portValue[0]);
        }
        
        private void checkBox32_CheckedChanged(object sender, EventArgs e)
        {
            SetDirection(checkBox32, PORT_NUMBER.PORTA, 0x1);
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            m_portValue[0] = checkBox2.Checked == true ? (byte)(m_portValue[0] | 0x2) : (byte)(m_portValue[0] & ~0x2);
            m_ttl.Write(PORT_NUMBER.PORTA, m_portValue[0]);
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            m_portValue[0] = checkBox4.Checked == true ? (byte)(m_portValue[0] | 0x4) : (byte)(m_portValue[0] & ~0x4);
            m_ttl.Write(PORT_NUMBER.PORTA, m_portValue[0]);
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            m_portValue[0] = checkBox3.Checked == true ? (byte)(m_portValue[0] | 0x8) : (byte)(m_portValue[0] & ~0x8);
            m_ttl.Write(PORT_NUMBER.PORTA, m_portValue[0]);
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            m_portValue[0] = checkBox6.Checked == true ? (byte)(m_portValue[0] | 0x10) : (byte)(m_portValue[0] & ~0x10);
            m_ttl.Write(PORT_NUMBER.PORTA, m_portValue[0]);
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            m_portValue[0] = checkBox5.Checked == true ? (byte)(m_portValue[0] | 0x20) : (byte)(m_portValue[0] & ~0x20);
            m_ttl.Write(PORT_NUMBER.PORTA, m_portValue[0]);
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            m_portValue[0] = checkBox8.Checked == true ? (byte)(m_portValue[0] | 0x40) : (byte)(m_portValue[0] & ~0x40);
            m_ttl.Write(PORT_NUMBER.PORTA, m_portValue[0]);
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            m_portValue[0] = checkBox7.Checked == true ? (byte)(m_portValue[0] | 0x80) : ((byte)(m_portValue[0] & ~0x80));
            m_ttl.Write(PORT_NUMBER.PORTA, m_portValue[0]);
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {

            
        }

        private void checkBox16_CheckedChanged(object sender, EventArgs e)
        {
            m_portValue[1] = checkBox16.Checked == true ? (byte)(m_portValue[1] | 0x1) : (byte)(m_portValue[0] & ~0x1);
            m_ttl.Write(PORT_NUMBER.PORTB, m_portValue[1]);
        }

        private void checkBox15_CheckedChanged(object sender, EventArgs e)
        {
            m_portValue[1] = checkBox15.Checked == true ? (byte)(m_portValue[1] | 0x2) : (byte)(m_portValue[0] & ~0x2);
            m_ttl.Write(PORT_NUMBER.PORTB, m_portValue[1]);
        }

        private void checkBox31_CheckedChanged(object sender, EventArgs e)
        {
            SetDirection(checkBox31, PORT_NUMBER.PORTA, 0x2);
        }

        void SetDirection(CheckBox c, PORT_NUMBER port , byte pin)
        {
            if (c.Checked == true)
                m_ttl.setDirection(port, DIRECTION.OUTPUT, 0x2);
            else
                m_ttl.setDirection(port, DIRECTION.INPUT, 0x2);
        }

        private void checkBox30_CheckedChanged(object sender, EventArgs e)
        {
            SetDirection(checkBox30, PORT_NUMBER.PORTA, 0x4);
        }

        private void checkBox29_CheckedChanged(object sender, EventArgs e)
        {
            SetDirection(checkBox29,PORT_NUMBER.PORTA , 0x8);
        }

        private void checkBox28_CheckedChanged(object sender, EventArgs e)
        {
            SetDirection(checkBox28,PORT_NUMBER.PORTA, 0x10);
        }

        private void checkBox27_CheckedChanged(object sender, EventArgs e)
        {
            SetDirection(checkBox27, PORT_NUMBER.PORTA, 0x20);
        }

        private void checkBox26_CheckedChanged(object sender, EventArgs e)
        {
            SetDirection(checkBox26, PORT_NUMBER.PORTA, 0x40);
        }

        private void checkBox25_CheckedChanged(object sender, EventArgs e)
        {
            SetDirection(checkBox25, PORT_NUMBER.PORTA, 0x80);
        }

        private void checkBox24_CheckedChanged(object sender, EventArgs e)
        {
            m_portValue[2] = checkBox24.Checked == true ? (byte)(m_portValue[2] | 0x1) : (byte)(m_portValue[2] & ~0x1);
            m_ttl.Write(PORT_NUMBER.PORTC, m_portValue[2]);
        }

        private void checkBox23_CheckedChanged(object sender, EventArgs e)
        {
            m_portValue[2] = checkBox23.Checked == true ? (byte)(m_portValue[2] | 0x2) : (byte)(m_portValue[2] & ~0x2);
            m_ttl.Write(PORT_NUMBER.PORTC, m_portValue[2]);
        }

        private void checkBox22_CheckedChanged(object sender, EventArgs e)
        {
            m_portValue[2] = checkBox22.Checked == true ? (byte)(m_portValue[2] | 0x4) : (byte)(m_portValue[2] & ~0x4);
            m_ttl.Write(PORT_NUMBER.PORTC, m_portValue[2]);
        }

        private void checkBox21_CheckedChanged(object sender, EventArgs e)
        {
            m_portValue[2] = checkBox21.Checked == true ? (byte)(m_portValue[2] | 0x8) : (byte)(m_portValue[2] & ~0x8);
            m_ttl.Write(PORT_NUMBER.PORTC, m_portValue[2]);
        }

        private void checkBox20_CheckedChanged(object sender, EventArgs e)
        {
            m_portValue[2] = checkBox20.Checked == true ? (byte)(m_portValue[2] | 0x10) : (byte)(m_portValue[2] & ~0x10);
            m_ttl.Write(PORT_NUMBER.PORTC, m_portValue[2]);
        }

        private void checkBox19_CheckedChanged(object sender, EventArgs e)
        {
            m_portValue[2] = checkBox19.Checked == true ? (byte)(m_portValue[2] | 0x20) : (byte)(m_portValue[2] & ~0x20);
            m_ttl.Write(PORT_NUMBER.PORTC, m_portValue[2]);
        }

        private void checkBox18_CheckedChanged(object sender, EventArgs e)
        {
            m_portValue[2] = checkBox18.Checked == true ? (byte)(m_portValue[2] | 0x18) : (byte)(m_portValue[2] & ~0x18);
            m_ttl.Write(PORT_NUMBER.PORTC, m_portValue[2]);
        }

        private void checkBox17_CheckedChanged(object sender, EventArgs e)
        {
            m_portValue[2] = checkBox17.Checked == true ? (byte)(m_portValue[2] | 0x80) : (byte)(m_portValue[2] & ~0x80);
            m_ttl.Write(PORT_NUMBER.PORTC, m_portValue[2]);
        }

        private void checkBox41_CheckedChanged(object sender, EventArgs e)
        {
            SetDirection(checkBox41, PORT_NUMBER.PORTC, 0x80);
        }

        private void checkBox44_CheckedChanged(object sender, EventArgs e)
        {
            SetDirection(checkBox44, PORT_NUMBER.PORTC, 0x40);
        }

        private void checkBox48_CheckedChanged(object sender, EventArgs e)
        {
            SetDirection(checkBox48, PORT_NUMBER.PORTC, 0x10);
        }

        private void checkBox46_CheckedChanged(object sender, EventArgs e)
        {
            SetDirection(checkBox46, PORT_NUMBER.PORTC, 0x8);
        }

        void CloseApp()
        {
            m_running = false;
            if (m_thread != null)
                m_thread.Join();
            if (m_ttl != null)
                m_ttl.Close();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseApp();
        }

        private void checkBox43_CheckedChanged(object sender, EventArgs e)
        {
            SetDirection(checkBox43, PORT_NUMBER.PORTC, 0x1);
        }

        private void checkBox35_CheckedChanged(object sender, EventArgs e)
        {
            SetDirection(checkBox35, PORT_NUMBER.PORTB, 0x1);
        }

        private void checkBox45_CheckedChanged(object sender, EventArgs e)
        {
            SetDirection(checkBox45, PORT_NUMBER.PORTC, 0x2);
        }

        private void checkBox42_CheckedChanged(object sender, EventArgs e)
        {
            SetDirection(checkBox42, PORT_NUMBER.PORTC, 0x4);
        }

        private void checkBox47_CheckedChanged(object sender, EventArgs e)
        {
            SetDirection(checkBox47, PORT_NUMBER.PORTC, 0x20);
        }

        private void checkBox37_CheckedChanged(object sender, EventArgs e)
        {
            SetDirection(checkBox37, PORT_NUMBER.PORTB, 0x2);
        }

        private void checkBox34_CheckedChanged(object sender, EventArgs e)
        {
            SetDirection(checkBox34, PORT_NUMBER.PORTB, 0x4);
        }

        private void checkBox38_CheckedChanged(object sender, EventArgs e)
        {
            SetDirection(checkBox38, PORT_NUMBER.PORTB, 0x8);
        }

        private void checkBox40_CheckedChanged(object sender, EventArgs e)
        {
            SetDirection(checkBox40, PORT_NUMBER.PORTB, 0x10);
        }

        private void checkBox39_CheckedChanged(object sender, EventArgs e)
        {
            SetDirection(checkBox39, PORT_NUMBER.PORTB, 0x20);
        }

        private void checkBox36_CheckedChanged(object sender, EventArgs e)
        {
            SetDirection(checkBox36, PORT_NUMBER.PORTB, 0x40);
        }

        private void checkBox33_CheckedChanged(object sender, EventArgs e)
        {
            SetDirection(checkBox33, PORT_NUMBER.PORTB, 0x80);
        }

        private void allOutputToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetAllOutput(PORT_NUMBER.PORT_ALL);
        }

        private void allInputsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetAllInputs(PORT_NUMBER.PORT_ALL);
        }

        private void allOutputToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
            CheckBox[] portaChecks = { checkBox32, checkBox31, checkBox30, checkBox29, checkBox28, checkBox27, checkBox26, checkBox25 };
            foreach (CheckBox c in portaChecks)
            {
                c.Checked = true;
            }
            m_ttl.setDirection(PORT_NUMBER.PORTA, DIRECTION.OUTPUT, 0xFF);
             
        }

        private void allOutputsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckBox[] portbChecks = { checkBox35, checkBox37, checkBox34, checkBox38, checkBox40, checkBox39, checkBox36, checkBox33 };
            foreach (CheckBox c in portbChecks)
            {
                c.Checked = true;
            }
            m_ttl.setDirection(PORT_NUMBER.PORTB, DIRECTION.OUTPUT, 0xFF);
        }

        private void allOutputsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CheckBox[] portcChecks = { checkBox43, checkBox35, checkBox42, checkBox46, checkBox48, checkBox47, checkBox44, checkBox41 };
            foreach (CheckBox c in portcChecks)
            {
                c.Checked = true;
            }
            m_ttl.setDirection(PORT_NUMBER.PORTC, DIRECTION.OUTPUT, 0xFF);
        }

        private void allInputsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CheckBox[] portbChecks = { checkBox35, checkBox37, checkBox34, checkBox38, checkBox40, checkBox39, checkBox36, checkBox33 };
            foreach (CheckBox c in portbChecks)
            {
                c.Checked = false;
            }
            m_ttl.setDirection(PORT_NUMBER.PORTB, DIRECTION.INPUT, 0xFF);
        }

        private void allInputToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckBox[] portaChecks = { checkBox32, checkBox31, checkBox30, checkBox29, checkBox28, checkBox27, checkBox26, checkBox25 };
            foreach (CheckBox c in portaChecks)
            {
                c.Checked = false;
            }
            m_ttl.setDirection(PORT_NUMBER.PORTA, DIRECTION.INPUT, 0xFF);
        }

        private void allInputToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CheckBox[] portcChecks = { checkBox43, checkBox35, checkBox42, checkBox46, checkBox48, checkBox47, checkBox44, checkBox41 };
            foreach (CheckBox c in portcChecks)
            {
                c.Checked = false;
            }
            m_ttl.setDirection(PORT_NUMBER.PORTC, DIRECTION.INPUT, 0xFF);
        }

        private void allHighToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_portValue[0] = 0xFF;
            m_ttl.Write(PORT_NUMBER.PORTA, m_portValue[0]);
        }

        private void allHighToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            m_portValue[1] = 0xFF;
            m_ttl.Write(PORT_NUMBER.PORTB, m_portValue[1]);
        }

        private void allHighToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            m_portValue[2] = 0xFF;
            m_ttl.Write(PORT_NUMBER.PORTC, m_portValue[2]);
        }

        private void allLowToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            m_portValue[2] = 0;
            m_ttl.Write(PORT_NUMBER.PORTC, m_portValue[2]);
        }

        private void allLowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_portValue[0] = 0;
            m_ttl.Write(PORT_NUMBER.PORTA, m_portValue[0]);
        }

        private void allLowToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            m_portValue[1] = 0;
            m_ttl.Write(PORT_NUMBER.PORTB, m_portValue[1]);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SetAllOutput(PORT_NUMBER.PORT_ALL);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SetAllInput(PORT_NUMBER.PORT_ALL);
        }
    }
}
