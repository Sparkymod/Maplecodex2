using Pastel;

namespace Maplecodex2.DBSync
{
    public static class Color
    {
        public static string Green(this string input) => input.Pastel("#ACED66");

        public static string Red(this string input) => input.Pastel("#E05561");

        public static string Orange(this string input) => input.Pastel("#FFB300");

        public static string Yellow(this string input) => input.Pastel("#FFE212");
    }

    public static class ConsoleUtility
    {
        public static void WriteProgressBar(float percent)
        {
            switch (percent)
            {
                case <= 10:
                    Console.Write("[■         ] {0,1:0}%\r".Red(), percent);
                    break;
                case <= 20:
                    Console.Write("[■■        ] {0,1:0}%\r".Red(), percent);
                    break;
                case <= 30:
                    Console.Write("[■■■       ] {0,1:0}%\r".Orange(), percent);
                    break;
                case <= 40:
                    Console.Write("[■■■■      ] {0,1:0}%\r".Orange(), percent);
                    break;
                case <= 50:
                    Console.Write("[■■■■■     ] {0,1:0}%\r".Orange(), percent);
                    break;
                case <= 60:
                    Console.Write("[■■■■■■    ] {0,1:0}%\r".Yellow(), percent);
                    break;
                case <= 70:
                    Console.Write("[■■■■■■■   ] {0,1:0}%\r".Yellow(), percent);
                    break;
                case <= 80:
                    Console.Write("[■■■■■■■■  ] {0,1:0}%\r".Yellow(), percent);
                    break;
                case <= 90:
                    Console.Write("[■■■■■■■■■ ] {0,1:0}%\r".Green(), percent);
                    break;
                default:
                    Console.Write("[■■■■■■■■■■] {0,1:0}%\r".Green(), percent);
                    break;
            }
        }
    }
}
