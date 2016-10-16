using System;
using System.Linq;
using System.Collections.Generic;

namespace LE
{
    public class Program
    {
        public static void Main(string[] args) {
            using(Game game = new Game()) {
                game.Run(30.0);
            }
        }
    }
}
