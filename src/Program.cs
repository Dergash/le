using System;
using System.Reflection;
using System.Linq;

/** TODO : Remove when Issue #1 closed 
 * 
 * As for the moment 'dotnet test' command does not work so well with debugging
 * NUnit tests code, we stick with NUnitLite for the moment. This includes dependency,
 * two additional using, runTests method and separate VSCode launch task.
 * See details: https://github.com/nunit/dotnet-test-nunit/issues/73 
 */
using NUnit.Common;
using NUnitLite;

namespace LE {
    public class Program {

        Config Config { get; set; }
        const String pathToFont = "assets/fonts/Now-Regular.otf";

        public static void Main(string[] args) {
            if (args.Contains("-debug")) {
                runTests();
            }
            
            Config.Build();
            using(Game game = new Game(GameContext.getInstance())) {
                game.Run(30.0);
            }
        }

        static void runTests() {
            var writer = new ExtendedTextWrapper(Console.Out);
            new AutoRun(typeof(Program).GetTypeInfo().Assembly).Execute(new String[] {}, writer, Console.In);
        }
    }
}
