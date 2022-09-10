using System;

namespace Business.CrossCuttingS
{
    public class DatabaseLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Veritabanına Loglandı !");
        }
    }

}
