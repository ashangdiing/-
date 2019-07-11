using PublicApi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using 短信客户端.Tool;

namespace 短信客户端
{
    public partial class SMClient : Form
    {
        public SMClient()
        {
            InitializeComponent();
        }
        SMTcpClient Client;
        private void SMClient_Load(object sender, EventArgs e)
        {
            Client = new SMTcpClient();
            Client.Receive += Client_Receive;
            Client.Start();
        }

        void Client_Receive(string obj)
        {
            this.Invoke(new Action<string>((msg) => {
                this.txt_Msg.AppendText(msg + "\r\n");
            }), obj);
        }

        private void btn_Send_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_Number.Text))
            {
                MessageBox.Show("请输入发送的电话号码！"); return;
            }
            if (string.IsNullOrEmpty(txt_Number.Text))
            {
                MessageBox.Show("请输入发送的消息！"); return;
            }
            string[] number = Regex.Split(txt_Number.Text, "[\\d]");
            foreach (string item in number)
            {
                if (!string.IsNullOrEmpty(item.Trim()))
                {
                    Client.SendMessage(item.Trim(), txt_Number.Text);
                    Thread.Sleep(1000);
                }
            }
            MessageBox.Show("发送成功！");
        }

        private void SMClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            Client.Stop();
        }
    }
}
