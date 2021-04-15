using System;

namespace BankShot {
    public static class Program {
        public static Game1 game;

        [STAThread]
        static void Main() {
            using (game = new Game1())
                game.Run();
        }
    }
}
