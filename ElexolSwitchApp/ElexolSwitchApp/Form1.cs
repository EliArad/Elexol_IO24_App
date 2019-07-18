using EleXolIO24RApi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElexolSwitchApp
{
    public partial class Form1 : Form
    {
        byte[] m_port = new byte[3];
        elexolio24r m_exol;
        
        byte tos;
        public Form1()
        {
            InitializeComponent();
            m_exol = new elexolio24r();
            string[] list;
            m_exol.ListUnopenDevices(out list);
            
            groupBox1.Enabled = false;
            groupBox2.Enabled = false;
            groupBox3.Enabled = false;
            if (list.Length == 0)
            {
                MessageBox.Show("No Elexol devices found");
                return;
            }
            m_exol.Open(list[0]);
            groupBox1.Enabled = true;
            groupBox2.Enabled = true;
            groupBox3.Enabled = true;
            m_exol.setALLDirectionOutput();
            
            int  _tos;
            _tos = ~1;
            tos = (byte)_tos;

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            int _tos;
            _tos = ~1;
            tos = (byte)_tos;
            m_port[0] = checkBox1.Checked == true ? m_port[0] |= 1 : (byte)(m_port[0] &= tos);
            m_exol.Write(PORT_NUMBER.PORTA, m_port[0]);
            
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            int _tos;
            _tos = ~2;
            tos = (byte)_tos;
            m_port[0] = checkBox2.Checked == true ? m_port[0] |= 2 : (byte)(m_port[0] &= tos);
            m_exol.Write(PORT_NUMBER.PORTA, m_port[0]);
            
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            int _tos;
            _tos = ~4;
            tos = (byte)_tos;
            m_port[0] = checkBox4.Checked == true ? m_port[0] |= 4 : (byte)(m_port[0] &= tos);
            m_exol.Write(PORT_NUMBER.PORTA, m_port[0]);
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            int _tos;
            _tos = ~8;
            tos = (byte)_tos;
            m_port[0] = checkBox3.Checked == true ? m_port[0] |= 8 : (byte)(m_port[0] &= tos);
            m_exol.Write(PORT_NUMBER.PORTA, m_port[0]);
            
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            int _tos;
            _tos = ~0x10;
            tos = (byte)_tos;
            m_port[0] = checkBox6.Checked == true ? m_port[0] |= 0x10 : (byte)(m_port[0] &= tos);
            m_exol.Write(PORT_NUMBER.PORTA, m_port[0]);
            
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {

            int _tos;
            _tos = ~0x20;
            tos = (byte)_tos;

            m_port[0] = checkBox5.Checked == true ? m_port[0] |= 0x20 : (byte)(m_port[0] &= tos);
            m_exol.Write(PORT_NUMBER.PORTA, m_port[0]);            
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            int _tos;
            _tos = ~0x40;
            tos = (byte)_tos;

            m_port[0] = checkBox8.Checked == true ? m_port[0] |= 0x40 : (byte)(m_port[0] &= tos);
            m_exol.Write(PORT_NUMBER.PORTA, m_port[0]);
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            int _tos;
            _tos = ~0x80;
            tos = (byte)_tos;
            m_port[0] = checkBox7.Checked == true ? m_port[0] |= 0x80 : (byte)(m_port[0] &= tos);
            m_exol.Write(PORT_NUMBER.PORTA, m_port[0]);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (m_exol != null)
                m_exol.Close();
        }

        private void checkBox16_CheckedChanged(object sender, EventArgs e)
        {
            int _tos;
            _tos = ~1;
            tos = (byte)_tos;
            m_port[1] = checkBox16.Checked == true ? m_port[1] |= 1 : (byte)(m_port[1] &= tos);
            m_exol.Write(PORT_NUMBER.PORTB, m_port[1]);
        }

        private void checkBox15_CheckedChanged(object sender, EventArgs e)
        {
            int _tos;
            _tos = ~2;
            tos = (byte)_tos;
            m_port[1] = checkBox15.Checked == true ? m_port[1] |= 2 : (byte)(m_port[1] &= tos);
            m_exol.Write(PORT_NUMBER.PORTB, m_port[1]);
        }

        private void checkBox14_CheckedChanged(object sender, EventArgs e)
        {
            int _tos;
            _tos = ~4;
            tos = (byte)_tos;
            m_port[1] = checkBox14.Checked == true ? m_port[1] |= 4 : (byte)(m_port[1] &= tos);
            m_exol.Write(PORT_NUMBER.PORTB, m_port[1]);
        }

        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {
            int _tos;
            _tos = ~8;
            tos = (byte)_tos;
            m_port[1] = checkBox13.Checked == true ? m_port[1] |= 8 : (byte)(m_port[1] &= tos);
            m_exol.Write(PORT_NUMBER.PORTB, m_port[1]);
        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            int _tos;
            _tos = ~0x10;
            tos = (byte)_tos;
            m_port[1] = checkBox12.Checked == true ? m_port[1] |= 0x10 : (byte)(m_port[1] &= tos);
            m_exol.Write(PORT_NUMBER.PORTB, m_port[1]);
        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            int _tos;
            _tos = ~0x20;
            tos = (byte)_tos;
            m_port[1] = checkBox12.Checked == true ? m_port[1] |= 0x20 : (byte)(m_port[1] &= tos);
            m_exol.Write(PORT_NUMBER.PORTB, m_port[1]);
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            int _tos;
            _tos = ~0x40;
            tos = (byte)_tos;
            m_port[1] = checkBox10.Checked == true ? m_port[1] |= 0x40 : (byte)(m_port[1] &= tos);
            m_exol.Write(PORT_NUMBER.PORTB, m_port[1]);
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            int _tos;
            _tos = ~0x80;
            tos = (byte)_tos;
            m_port[1] = checkBox9.Checked == true ? m_port[1] |= 0x80 : (byte)(m_port[1] &= tos);
            m_exol.Write(PORT_NUMBER.PORTB, m_port[1]);
        }

        private void checkBox24_CheckedChanged(object sender, EventArgs e)
        {
            int _tos;
            _tos = ~1;
            tos = (byte)_tos;
            m_port[2] = checkBox16.Checked == true ? m_port[2] |= 1 : (byte)(m_port[2] &= tos);
            m_exol.Write(PORT_NUMBER.PORTC, m_port[2]);
        }

        private void checkBox23_CheckedChanged(object sender, EventArgs e)
        {
            int _tos;
            _tos = ~2;
            tos = (byte)_tos;
            m_port[2] = checkBox16.Checked == true ? m_port[2] |= 2 : (byte)(m_port[2] &= tos);
            m_exol.Write(PORT_NUMBER.PORTC, m_port[2]);
        }

        private void checkBox22_CheckedChanged(object sender, EventArgs e)
        {
            int _tos;
            _tos = ~4;
            tos = (byte)_tos;
            m_port[2] = checkBox16.Checked == true ? m_port[2] |= 4 : (byte)(m_port[2] &= tos);
            m_exol.Write(PORT_NUMBER.PORTC, m_port[2]);
        }

        private void checkBox21_CheckedChanged(object sender, EventArgs e)
        {
            int _tos;
            _tos = ~8;
            tos = (byte)_tos;
            m_port[2] = checkBox16.Checked == true ? m_port[2] |= 8 : (byte)(m_port[2] &= tos);
            m_exol.Write(PORT_NUMBER.PORTC, m_port[2]);
        }

        private void checkBox20_CheckedChanged(object sender, EventArgs e)
        {
            int _tos;
            _tos = ~0x10;
            tos = (byte)_tos;
            m_port[2] = checkBox16.Checked == true ? m_port[2] |= 0x10 : (byte)(m_port[2] &= tos);
            m_exol.Write(PORT_NUMBER.PORTC, m_port[2]);
        }

        private void checkBox19_CheckedChanged(object sender, EventArgs e)
        {
            int _tos;
            _tos = ~0x20;
            tos = (byte)_tos;
            m_port[2] = checkBox16.Checked == true ? m_port[2] |= 0x20 : (byte)(m_port[2] &= tos);
            m_exol.Write(PORT_NUMBER.PORTC, m_port[2]);
        }

        private void checkBox18_CheckedChanged(object sender, EventArgs e)
        {
            int _tos;
            _tos = ~0x40;
            tos = (byte)_tos;
            m_port[2] = checkBox16.Checked == true ? m_port[2] |= 0x40 : (byte)(m_port[2] &= tos);
            m_exol.Write(PORT_NUMBER.PORTC, m_port[2]);
        }

        private void checkBox17_CheckedChanged(object sender, EventArgs e)
        {
            int _tos;
            _tos = ~0x80;
            tos = (byte)_tos;
            m_port[2] = checkBox16.Checked == true ? m_port[2] |= 0x80 : (byte)(m_port[2] &= tos);
            m_exol.Write(PORT_NUMBER.PORTC, m_port[2]);
        }
    }
}
