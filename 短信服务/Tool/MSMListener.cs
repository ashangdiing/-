using PublicApi;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace 短信服务.Tool
{
    public delegate void SendMessage(string number,string message);
    public class MSMListener
    {
        private bool start = true;
        private TcpListener tcpListener;
        private event Action<string> ReceiveMessage;
        public void Receive(string msg)
        {
            if (ReceiveMessage != null)
            {
                ReceiveMessage(msg);
            }
        }
        public void Start(SendMessage send)
        {
            try
            {
                tcpListener.Start();
                while (start)
                {
                    TcpClient tcpClient = tcpListener.AcceptTcpClient();
                    NetworkStream ns = tcpClient.GetStream();
                    ns.ReadTimeout = 40*1000;
                    Action<string> act = new Action<string>((msg) =>
                    {
                        byte[] bytes = System.Text.Encoding.UTF8.GetBytes(msg);
                        ns.Write(bytes, 0, bytes.Length);
                    });
                    ReceiveMessage += act;
                    Thread th = new Thread(() =>
                    {
                        try
                        {
                            byte[] bytes = new byte[1024];
                            int recv;
                            //string mess;
                            BinaryFormatter formatter = new BinaryFormatter();
                            while (true)
                            {
                                if ((recv = ns.Read(bytes, 0, bytes.Length)) == 0)
                                {
                                    break;
                                }
                                else if ((recv = ns.Read(bytes, 0, bytes.Length)) == 4)
                                {
                                    continue;
                                }
                                try
                                {
                                    MemoryStream stream = new MemoryStream(bytes, 0, recv);
                                    SM sm = (SM)formatter.Deserialize(stream);
                                    send(sm.Number, sm.Message);
                                }
                                catch { }
                            }
                            ns.Close();
                            tcpClient.Close();
                        }
                        catch { }
                        ReceiveMessage -= act;
                    });
                    th.Start();
                    Thread th2 = new Thread(() =>
                    {
                        while (start)
                        {
                            byte[] b = System.Text.Encoding.UTF8.GetBytes("ping");
                            ns.Write(b, 0, b.Length);
                            ns.Flush();
                            Thread.Sleep(30 * 1000);
                        }
                    });
                }
                tcpListener.Stop();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Application.Exit();
            }
        }
        public MSMListener()
        {
            IPAddress ipAddress = IPAddress.Any;
            tcpListener = new TcpListener(ipAddress, int.Parse(System.Configuration.ConfigurationManager.AppSettings["port"]));
           
        }
        public void Stop()
        {
            start = false;
        }
    }
}
