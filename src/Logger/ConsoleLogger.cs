using System;

namespace LE {
    public class ConsoleLogger : ILogger {
        public void WriteDebug(String msg) {
            Console.WriteLine(msg);
        }
        public void WriteException(Exception e) {
            Console.WriteLine(e);
            Console.WriteLine(e.StackTrace);
        }
    }
}