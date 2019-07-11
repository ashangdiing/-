using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace 短信服务.Tool
{
    public class SMSAPI : IDisposable
    {
        private bool start = false;
        public event Action<string> ReceiveMessage;
        public event Action<string> ReceiveCallId;
        Thread th;
        public SMSAPI()
        {
            th = new Thread(() =>
            {
                string msg = string.Empty;
                while (start)
                {
                    msg = zwcdmasmApi.GetRevSM();
                    if (!string.IsNullOrEmpty(msg))
                    {
                        if (ReceiveMessage != null)
                        {
                            ReceiveMessage(msg);
                        }
                    }
                    zwcdmasmApi.ClrRevSM(string.Empty);
                    msg = string.Empty;
                    msg = zwcdmasmApi.GetCallId();
                    if (!string.IsNullOrEmpty(msg))
                    {
                        if (ReceiveCallId != null)
                        {
                            ReceiveCallId(msg);
                        }
                    }
                    zwcdmasmApi.ClrCallId(string.Empty);
                    msg = string.Empty;
                    Thread.Sleep(200);
                }
            });
        }
        ~SMSAPI()
        {
            start = false;
        }
        public void Dispose()
        {
            start = false;
        }
        public void RegModule(string serial)
        {
            zwcdmasmApi.RegModule(serial);
        }
        public void InitSMS()
        {
            zwcdmasmApi.InitSMS();
            if (!start)
            {
                start = true;
                th.Start();
            }
        }
        public void InitComm()
        {
            zwcdmasmApi.SetTip(0);
            zwcdmasmApi.InitComm();
        }
        public void InitComm(string com)
        {
            zwcdmasmApi.SetTip(0);
            zwcdmasmApi.StartComm(com);
        }
        public void StopComm()
        {
            zwcdmasmApi.StopComm();
        }
        public void SetTip(byte tip)
        {
            zwcdmasmApi.SetTip(tip);
        }
        public string GetStatus()
        {
            return zwcdmasmApi.GetStatus();
        }
        public void SendSM(string phonenum, string sm)
        {
            zwcdmasmApi.SendSM(phonenum, sm);
        }
        public void SendCNSM(string phonenum, string sm)
        {
            zwcdmasmApi.SendCNSM(phonenum, sm);
            try
            {
                //using (Sbw.DbClient.DbClient Client = new Sbw.DbClient.DbClient())
                //{
                //    Client.AddParameter("@number", phonenum);
               //     Client.AddParameter("@message", sm);
               //     Client.ExecuteNonQuery("insert into SMS(number,[message])value(@number,@message)");
               // }
            }
            catch { }
        }
        public void SetSvrNumber(string number)
        {
            zwcdmasmApi.SetSvrNumber(number);
        }
        public void StopSMS()
        {
            zwcdmasmApi.StopSMS();
        }
    }
}
