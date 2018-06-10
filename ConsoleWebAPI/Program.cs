using System;

namespace ConsoleWebAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Types: ukraina, world, politics, crime, health, sport, culture, stories, life-stories, money, society, style, all");
            Console.Write("Enter type: ");
            string type = Console.ReadLine();   

            var item = JsonWorker.DeserializeJson(type);

            foreach (var i in item)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine();

                Console.WriteLine("Title: {0}\n" +
                                  "PublishDate: {1}\n" +
                                  "Content: {2}\n" +
                                  "Link: {3}\n", i.Title, i.PublishDate, i.Content, i.Link);

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(new string('-', 100));
            }

            Console.ReadKey();
        }
    }
}
