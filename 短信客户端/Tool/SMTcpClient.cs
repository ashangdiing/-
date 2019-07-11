using PublicApi;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace 短信客户端.Tool
{
    public class SMTcpClient
    {
        System.Net.Sockets.TcpClient tcp;
        NetworkStream ns;
        BinaryFormatter formatter = new BinaryFormatter();
        bool start = true;
        public SMTcpClient()
        {
            tcp = new System.Net.Sockets.TcpClient();
            tcp.Connect(ConfigurationManager.AppSettings["address"], int.Parse(ConfigurationManager.AppSettings["port"]));
            ns = tcp.GetStream();
            ns.ReadTimeout = 40 * 1000;
        }
        public event Action<string> Receive;
        public void Start()
        {
            try
            {
                Thread th = new Thread(() =>
                   {
                       try
                       {
                           byte[] bytes = new byte[1024];
                           int recv;
                           string mess;
                           while (start)
                           {
                               if ((recv = ns.Read(bytes, 0, bytes.Length)) == 0)
                               {
                                   Console.WriteLine("disconnected");
                                   break;
                               }
                               else if ((recv = ns.Read(bytes, 0, bytes.Length)) == 4)
                               {
                                   continue;
                               }
                               try
                               {
                                   mess = System.Text.Encoding.UTF8.GetString(bytes, 0, recv);
                                   if (Receive != null)
                                   {
                                       Receive(mess);
                                   }
                               }
                               catch { }
                           }
                           tcp.Close();
                       }
                       catch { }
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
                th2.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                try { tcp.Close(); } catch { }
                Application.Exit();
            }
        }
        public void SendMessage(string number,string message)
        {
            try
            {
                MemoryStream stream = new MemoryStream();
                SM sm = new SM();
                sm.Number = number;
                sm.Message = message;
                formatter.Serialize(stream, sm);
                stream.Seek(0, SeekOrigin.Begin);
                byte[] buffer = new byte[(int)stream.Length];
                stream.Read(buffer, 0, buffer.Length);
                stream.Close();
                ns.Write(buffer, 0, buffer.Length);
                ns.Flush();
            }
            catch { }
        }
        public void Stop()
        {
            start = false;
        }
    }
}
