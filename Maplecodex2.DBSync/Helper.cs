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
        public static void WriteProgressBar(int count, int itemNodesCount)
        {
            float percent = (float)count / itemNodesCount * 100f;
            switch (percent)
            {
                case <= 10:
                    Console.Write("[■         ] {0,1:0}% [{1}/{2}]\r".Red(), percent, count, itemNodesCount);
                    break;
                case <= 20:
                    Console.Write("[■■        ] {0,1:0}% [{1}/{2}]\r".Red(), percent, count, itemNodesCount);
                    break;
                case <= 30:
                    Console.Write("[■■■       ] {0,1:0}% [{1}/{2}]\r".Orange(), percent, count, itemNodesCount);
                    break;
                case <= 40:
                    Console.Write("[■■■■      ] {0,1:0}% [{1}/{2}]\r".Orange(), percent, count, itemNodesCount);
                    break;
                case <= 50:
                    Console.Write("[■■■■■     ] {0,1:0}% [{1}/{2}]\r".Orange(), percent, count, itemNodesCount);
                    break;
                case <= 60:
                    Console.Write("[■■■■■■    ] {0,1:0}% [{1}/{2}]\r".Yellow(), percent, count, itemNodesCount);
                    break;
                case <= 70:
                    Console.Write("[■■■■■■■   ] {0,1:0}% [{1}/{2}]\r".Yellow(), percent, count, itemNodesCount);
                    break;
                case <= 80:
                    Console.Write("[■■■■■■■■  ] {0,1:0}% [{1}/{2}]\r".Yellow(), percent, count, itemNodesCount);
                    break;
                case <= 90:
                    Console.Write("[■■■■■■■■■ ] {0,1:0}% [{1}/{2}]\r".Green(), percent, count, itemNodesCount);
                    break;
                default:
                    Console.Write("[■■■■■■■■■■] {0,1:0}% [{1}/{2}]\r".Green(), percent, count, itemNodesCount);
                    break;
            }
        }
    }
}
