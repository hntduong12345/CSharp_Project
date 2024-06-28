using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestLinq.Model;

namespace TestLinq.Utilities
{
    public class Utilities
    {
        public static string ReadFile(string fileName)
        {
            return File.ReadAllText(fileName);
        }

        public static List<Book> ReadData()
        {
            var cadJSON = ReadFile("Data/BookStore_01.json");
            return JsonConvert.DeserializeObject<List<Book>>(cadJSON);
        }

        public static List<Book> ReadData(string extra)
        {
            List<Book> books = ReadData();
            var fileName = "Data/BookStore_02.json";
            var cadJSON = ReadFile(fileName);
            books.AddRange(JsonConvert.DeserializeObject<List<Book>>(cadJSON));

            if(extra == "topic")
            {
                fileName = "Data/BookStore_03.json";
                cadJSON = ReadFile(fileName);
                books.AddRange(JsonConvert.DeserializeObject<List<Book>>(cadJSON));
            }
            return books;
        }
    }
}
