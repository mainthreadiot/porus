using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Porus
{
    public partial class Socket : Form
    {
        System.Net.Sockets.Socket socket;
        public Socket()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                socket = new System.Net.Sockets.Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPAddress ip = IPAddress.Parse(txtIPAddress.Text);
                EndPoint ep = new IPEndPoint(ip, Convert.ToInt32(txtPort.Text));
                IAsyncResult result = socket.BeginConnect(txtIPAddress.Text, Convert.ToInt32(txtPort.Text), null, null);
                bool success = result.AsyncWaitHandle.WaitOne(3000, true);
                if (success)
                {
                    MessageBox.Show("Socket Connected");
                    btnConnect.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Socket non Connected");
                    btnConnect.Enabled = true;
                }
            }
            catch(Exception ae)
            {
                txtReceive.Text = ae.Message;
                btnConnect.Enabled = true;
            }
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                string sendData = txtSend.Text;
                byte[] msg = new byte[sendData.Length + 1];
                System.Text.Encoding.Default.GetBytes(sendData, 0, sendData.Length, msg, 0);
                msg[msg.Length - 1] = (byte)'\r';
                int sendret = socket.Send(msg, 0, msg.Length, SocketFlags.None);
                byte[] bb = new byte[10000];
                int reccount = socket.Receive(bb);
                txtReceive.Text = System.Text.Encoding.Default.GetString(bb);
            }
            catch (Exception ae)
            {
                txtReceive.Text = ae.Message;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Socket_Load(object sender, EventArgs e)
        {

        }
    }
}
