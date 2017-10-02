using FirebaseNet.Messaging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace apiFirebaseNet
{
    class Program
    {
        const string YOUR_APP_SERVER_KEY = "AAAAKZffKz8:APA91bFGI0TosFkaCAhWW_LCo0iPUQi7k8WUbj0iPWl5wPv_Rt0MjrQIctafxB-me3TP93MCW_dVUHfvCa1_wydebmfUzLGmE-oORi_AraGVB5xTKYRQZ7Uif8lCwFIA5sVwRcdsJr5K";
        const string sender = "178641644351";

        static void Main(string[] args)
        {
            ConsoleKeyInfo _char;

            do
            {
                Console.Write("press Quit(Q), continous(anykey)");
                _char = Console.ReadKey();
                SendAndroid();
            } while (_char.KeyChar.ToString().ToUpper() != "Q");

            Console.ReadKey();
        }

        static void SendAndroid()
        {
            string txtNoiDung = "noi dung";
            string txtTieuDe = "tieu de";

            WebRequest tRequest;
            //thiết lập FCM send
            tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
            tRequest.Method = "POST";
            tRequest.UseDefaultCredentials = true;

            tRequest.PreAuthenticate = true;

            tRequest.Credentials = CredentialCache.DefaultNetworkCredentials;

            //định dạng JSON
            tRequest.ContentType = "application/json";
            tRequest.Headers.Add(string.Format("Authorization: key={0}", YOUR_APP_SERVER_KEY));
            tRequest.Headers.Add(string.Format("Sender: id={0}", sender));

            //string[] arrRegid = dsFcm.Select(x => x.Token).ToArray();
            string RegArr = "dVhjCl3hbfk:APA91bH09KeY3aEiPDIxyMkE86QgDgIzKH-pPq2NyHoCZEtTTe0dllN9xgF8v3h8eoNgzPhyanjkx6nGd6aMJjYTuPAG7Gjj0TncYSXmgCY8hgXNODoeO_OWwlhHe6RewoO1sRJI289l";
            //RegArr = string.Join("\",\"", arrRegid);

            string postData = "{\"to\": \""+RegArr+"\",\"data\": {\"message\": \"This is a Firebase Cloud Messaging Topic Message!\",}}";

            Byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            tRequest.ContentLength = byteArray.Length;

            Stream dataStream = tRequest.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

            WebResponse tResponse = tRequest.GetResponse();

            dataStream = tResponse.GetResponseStream();

            StreamReader tReader = new StreamReader(dataStream);

            String sResponseFromServer = tReader.ReadToEnd();

            string txtKetQua = sResponseFromServer; //Lấy thông báo kết quả từ FCM server.
            Console.WriteLine("respones :" + txtKetQua);
            tReader.Close();
            dataStream.Close();
            tResponse.Close();

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
