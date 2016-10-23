using System;

namespace LE {
    public class ConsoleLogger : ILogger {
        public void WriteException(Exception e) {
            Console.WriteLine(e);
            Console.WriteLine(e.StackTrace);
        }
    }
}