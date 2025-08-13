using System;

namespace MiniProject_RRS
{
    public static class Ui
    {
        private static void WithColor(ConsoleColor fg, Action body)
        {
            var prev = Console.ForegroundColor;
            Console.ForegroundColor = fg;
            try { body(); } finally { Console.ForegroundColor = prev; }
        }

        public static void Banner(string title)
        {
            var line = new string('═', Math.Max(24, title.Length + 8));
            WithColor(ConsoleColor.Cyan, () =>
            {
                Console.WriteLine();
                Console.WriteLine(line);
                Console.WriteLine("  " + title);
                Console.WriteLine(line);
            });
        }

        public static void Divider() => Console.WriteLine(new string('─', 60));

        public static void Success(string msg) =>
            WithColor(ConsoleColor.Green, () => Console.WriteLine(" " + msg));

        public static void Info(string msg) =>
            WithColor(ConsoleColor.Gray, () => Console.WriteLine(" " + msg));

        public static void Warn(string msg) =>
            WithColor(ConsoleColor.Yellow, () => Console.WriteLine("! " + msg));

        public static void Error(string msg) =>
            WithColor(ConsoleColor.Red, () => Console.WriteLine(" " + msg));

        public static void Pause(string msg = "Press any key to continue...")
        {
            WithColor(ConsoleColor.DarkGray, () => Console.WriteLine(msg));
            Console.ReadKey(true);
        }

        public static bool Confirm(string prompt = "Are you sure? (y/n): ")
        {
            Console.Write(prompt);
            var k = Console.ReadKey(true);
            Console.WriteLine();
            return k.KeyChar == 'y' || k.KeyChar == 'Y';
        }

        public static void TableHeader(params string[] headers)
        {
            WithColor(ConsoleColor.DarkCyan, () => Console.WriteLine(string.Join("  ", headers)));
            Divider();
        }
    }
}
