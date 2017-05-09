using System;
using System.Reflection;
using System.Linq;


namespace LE {
    public class Program {

        Config Config { get; set; }
        const String pathToFont = "assets/fonts/Now-Regular.otf";

        public static void Main(string[] args) {
            Config.Build();

            if (args.Contains("-debug")) {
               // runTests();
            }
            
            using(Game game = new Game(GameContext.getInstance())) {
                game.Run(30.0);
            }
        }

    }
}
