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
            var reg = "APA91bEueKd7_tm4yAR1PO3U99beJyRbL_SzEGsNLdwWXbjbSxK4dTgchyEaCBu8HLnZx3wCXZjF8nAE5EqDcHhUeft2xCmM9PUe0mBZcilDRnEj2pJnfhxhhdgoWW1DGuLojtbLyHeOF7KmwFNXS0OQysc9piCw3A";
            var devices = new[] { reg };
            push.RegisterGcmService(new GcmPushChannelSettings("AIzaSyDFDXd-ktnMGHo_B-SIYnpijUAc1NsbZN4"));
            push.QueueNotification(new GcmNotification().ForDeviceRegistrationId(devices)// (Devices)
                        .WithJson("{\"alert\":\"測試推播2!\",\"badge\":7,\"sound\":\"sound.caf\"}"));
            push.StopAllServices();
            Console.WriteLine("Queue Finished, press return to exit...");
            Console.ReadLine();	
        }
    }
}
