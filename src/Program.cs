using System;
using System.Linq;
using System.Collections.Generic;

using LETest;

namespace LE
{
    public class Program
    {
        public static void Main(string[] args) {
            runTests(Verbose.METHODS);
            using(Game game = new Game()) {
                game.Run(30.0);
            }
        }

        public static void runTests(Verbose verbose) {
            bool result = true;
            var tests = new List<ITest> {
                new CreatureTest()
            };
            tests.ForEach(test => {
                var classResult = test.testAll();
                result = result && classResult;
                if(verbose == Verbose.CLASS) {
                    Console.WriteLine(test + ": " + ((classResult) ? "SUCCESS" : "FAIL"));
                }
            });
        }
    }
}
