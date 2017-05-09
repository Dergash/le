using System;
using System.Reflection;
using System.Linq;
using System.IO;

namespace LE {
    public class Program {

        Config Config { get; set; }
        const String pathToFont = @"assets\fonts\Now-Regular.otf";

        public static void Main(string[] args) {
            
            String root = Directory.GetCurrentDirectory();
            Console.WriteLine("Root: " + root);
            Config.Build();

            using(Game game = new Game(GameContext.getInstance())) {
                game.Run(30.0);
            }
        }
    }
}
