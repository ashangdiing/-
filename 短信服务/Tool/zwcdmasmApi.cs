using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
namespace 短信服务.Tool
{
    class zwcdmasmApi
    {
        [DllImport("zwcdmasm.dll", EntryPoint = "regmodule", CallingConvention = CallingConvention.StdCall)]
        public static extern void RegModule(string serial);

        [DllImport("zwcdmasm.dll", EntryPoint = "initsms", CallingConvention = CallingConvention.StdCall)]
        public static extern void InitSMS();

        [DllImport("zwcdmasm.dll", EntryPoint = "initcomm", CallingConvention = CallingConvention.StdCall)]
        public static extern void InitComm();

        [DllImport("zwcdmasm.dll", EntryPoint = "startcomm", CallingConvention = CallingConvention.StdCall)]
        public static extern void StartComm(string com);

        [DllImport("zwcdmasm.dll", EntryPoint = "stopcomm", CallingConvention = CallingConvention.StdCall)]
        public static extern void StopComm();

        [DllImport("zwcdmasm.dll", EntryPoint = "settip", CallingConvention = CallingConvention.StdCall)]
        public static extern void SetTip(byte tip);

        [DllImport("zwcdmasm.dll", EntryPoint = "getstatus", CallingConvention = CallingConvention.StdCall)]
        public static extern string GetStatus();

        [DllImport("zwcdmasm.dll", EntryPoint = "getrevsm", CallingConvention = CallingConvention.StdCall)]
        public static extern string GetRevSM();

        [DllImport("zwcdmasm.dll", EntryPoint = "clrrevsm", CallingConvention = CallingConvention.StdCall)]
        public static extern void ClrRevSM(string s);

        [DllImport("zwcdmasm.dll", EntryPoint = "sendsm", CallingConvention = CallingConvention.StdCall)]
        public static extern void SendSM(string phonenum, string sm);

        [DllImport("zwcdmasm.dll", EntryPoint = "sendcnsm", CallingConvention = CallingConvention.StdCall)]
        public static extern void SendCNSM(string phonenum, string sm);

        [DllImport("zwcdmasm.dll", EntryPoint = "setsvrnumber", CallingConvention = CallingConvention.StdCall)]
        public static extern void SetSvrNumber(string number);

        [DllImport("zwcdmasm.dll", EntryPoint = "stopsms", CallingConvention = CallingConvention.StdCall)]
        public static extern void StopSMS();

        [DllImport("zwcdmasm.dll", EntryPoint = "getcallid", CallingConvention = CallingConvention.StdCall)]
        public static extern string GetCallId();

        [DllImport("zwcdmasm.dll", EntryPoint = "clrcallid", CallingConvention = CallingConvention.StdCall)]
        public static extern void ClrCallId(string s);
    }
}
