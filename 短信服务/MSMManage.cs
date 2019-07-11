using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using 短信服务.Tool;

namespace 短信服务
{
    public partial class MSMManage : Form
    {

        SMSAPI api;
        MSMListener ms;
        Thread th;
        public MSMManage()
        {
            InitializeComponent();
        }

        void api_ReceiveCallId(string obj)
        {
            this.Invoke(new Action<string>((str) =>
            {
                txt_MSG.AppendText(str + "\r\n\r\n");
            }), obj);
        }

        void api_ReceiveMessage(string obj)
        {
            this.Invoke(new Action<string>((str) =>
            {
                txt_CallId.AppendText(str + "\r\n\r\n");
            }), obj);
            ms.Receive(obj + "\r\n\r\n");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //api.InitComm();
            api.InitComm("com2");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            api.InitSMS();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            api.SendCNSM(txt_Number.Text, txt_Message.Text);
            //ms.Receive(txt_Message.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            api.RegModule(txt_Reg.Text);
        }
        /// <summary>
        /// 测试方法没有任何使用
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        private void Test(string s1, string s2)
        {
            this.Invoke(new Action<string>((s) => {
                txt_MSG.AppendText(s + "\r\n");
            }), s1 + s2);
        }
        private void MSMManage_Load(object sender, EventArgs e)
        {
            api = new SMSAPI();
            api.ReceiveMessage += api_ReceiveMessage;
            api.ReceiveCallId += api_ReceiveCallId;
            Thread th = new Thread(() => {
                ms = new MSMListener();
                //ms.Start(Test);//客户端发送消息后展示到窗体上
                ms.Start(api.SendCNSM);
            });
            th.TrySetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void MSMManage_FormClosing(object sender, FormClosingEventArgs e)
        {
            api.StopSMS();
            api.StopComm();
            ms.Stop();
        }
    }
}
