using Nancy.Json;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Text;
using System.Text.Json.Serialization;
using System.Xml;
using TestLinq.Model;
using TestLinq.Utilities;

namespace Test
{
    public class TestProgram
    {
        static List<Book> bookList;

        static void Main(string[] args)
        {
            Console.WriteLine("Làm ơn làm phước nhá, nhấn chữ 'yes' để đọc cái file cũ lìn ét tờ ra nghe chưa con, ");
            Console.WriteLine("không thì nhấn cái mịa gì cũng đc nhá");
            var ans = Console.ReadLine();
            bookList = (ans.ToLower() != "yes") && (ans != "topic") ? Utilities.ReadData() : Utilities.ReadData(ans);

            PrintBooks(bookList);
        }

        static void PrintBooks(List<Book> books)
        {
            Console.WriteLine("List of Books: ");
            Console.WriteLine("------------------------------");

            foreach (var item in books)
            {
                Console.WriteLine($"{item.Title.PadRight(39, ' ')}" + $"|{item.Author.PadRight(35, ' ')}|{item.Price}");
            }

            Console.ReadLine();
        }

        ////string server = "127.0.0.1";
        ////int port = 13000;
        ////ConnectServer(server, port);

        //public static void ConnectServer(string server, int port)
        //{
        //    string message, responseData;
        //    TcpClient client;
        //    int bytes;

        //    try
        //    {
        //        client = new TcpClient(server, port);
        //        Console.Title = "Á đù cờ lai ần";
        //        NetworkStream stream = null;
        //        while (true)
        //        {
        //            Console.WriteLine("Nhập lừi nhén <nhấn en tơ để cook>: ");
        //            message = Console.ReadLine();
        //            if(message == string.Empty)
        //            {
        //                break;
        //            }
        //            Byte[] data = System.Text.Encoding.ASCII.GetBytes($"{message}");
        //            stream = client.GetStream();
        //            stream.Write(data, 0, data.Length);

        //            Console.WriteLine("Gử: {0}", message);
        //            data = new Byte[256];
        //            bytes = stream.Read(data, 0, data.Length);
        //            responseData = System.Text.Encoding.ASCII.GetString(data);
        //            Console.WriteLine("Nhựn: {0}", responseData);
        //        }

        //        client.Close();
        //    }
        //    catch(Exception ex)
        //    {
        //        Console.WriteLine("Exception: {0}", ex.Message);
        //    }
        //}

        //public static void GetHTTP()
        //{
        //    WebRequest request = WebRequest.Create("https://learn.unity.com/");
        //    request.Credentials = CredentialCache.DefaultCredentials;

        //    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        //    Console.WriteLine("Status: " + response.StatusDescription);
        //    Console.WriteLine(new string('*', 50));

        //    Stream dataStream = response.GetResponseStream();
        //    StreamReader reader = new StreamReader(dataStream);

        //    string responseFromServer = reader.ReadToEnd();

        //    Console.WriteLine(responseFromServer);
        //    Console.WriteLine(new string('*', 50));

        //    reader.Close();
        //    dataStream.Close();
        //    response.Close();
        //}
    }
}