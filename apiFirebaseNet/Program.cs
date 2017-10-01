using FirebaseNet.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apiFirebaseNet
{
    class Program
    {
        const string YOUR_APP_SERVER_KEY = "AIzaSyCAdAV35kJ5L3lHFRz3MFQVSQyYXGG4Ehk";
        static void Main(string[] args)
        {
            ConsoleKeyInfo _char;

            do
            {
                Console.Write("press Quit(Q), continous(anykey)");
                 _char = Console.ReadKey();
                SendAndroid();
            } while (_char.KeyChar.ToString().ToUpper()!="Q");

            Console.ReadKey();
        }

        static void SendAndroid()
        {
            Task.Run(async () =>
            {

                FCMClient client = new FCMClient(YOUR_APP_SERVER_KEY); //as derived from https://console.firebase.google.com/project/
                var message = new Message()
                {
                    To = "DEVICE_ID_OR_ANY_PARTICULAR_TOPIC", //topic example /topics/all
                    Notification = new AndroidNotification()
                    {
                        Body = "Hello World",
                        Title = "MyApp",
                    },

                    Data = new Dictionary<string, string>
                {
                    { "number", "1" },
                    { "count", "10" }
                }
                };

                var result = await client.SendMessageAsync(message);
                return result;
            });
        }
        static void SendIOS()
        {
            Task.Run(async () =>
            {

                FCMClient client = new FCMClient(YOUR_APP_SERVER_KEY); //as derived from https://console.firebase.google.com/project/

                var message = new Message()
                {
                    To = "DEVICE_ID_OR_ANY_PARTICULAR_TOPIC", //topic example /topics/all
                    Notification = new iOSNotification()
                    {
                        Body = "Hello World",
                        Title = "MyApp",
                    }
                };

                var result = await client.SendMessageAsync(message);
                return result;
            });
        }
    }
}
