using PushSharp;
using PushSharp.Android;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L09_GCM_Server
{
    class Program
    {
        static void Main(string[] args)
        {
            var push = new PushBroker();
            var reg = "";//lab:放入你取德的Regid;
            var devices = new[] { reg };
            push.RegisterGcmService(new GcmPushChannelSettings(""));//lab:放入你在google中建立的金鑰
            push.QueueNotification(new GcmNotification().ForDeviceRegistrationId(devices)// (Devices)
                        .WithJson("{\"alert\":\"測試推播2!\",\"badge\":7,\"sound\":\"sound.caf\"}"));
            push.StopAllServices();
            Console.WriteLine("Queue Finished, press return to exit...");
            Console.ReadLine();	
        }
    }
}
