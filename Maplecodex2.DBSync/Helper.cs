using Maplecodex2.Data.Helpers;
using Maplecodex2.DBSync.Data.Types;
using Pastel;
using System.Xml;
using System;
using System.Text;
using System.Threading;

namespace Maplecodex2.DBSync
{
    public static class Color
    {
        public static string Green(this string input) => input.Pastel("#ACED66");

        public static string Red(this string input) => input.Pastel("#E05561");

        public static string Orange(this string input) => input.Pastel("#FFB300");

        public static string Yellow(this string input) => input.Pastel("#FFE212");
    }

    public static class XmlHelper
    {
        public static List<NodeAttribute> GetAttributesFromNode(XmlNode currentNode)
        {
            if (currentNode == null || currentNode.Attributes.Count == 0)
            {
                return new();
            }

            List<NodeAttribute> attributes = new();

            foreach (XmlAttribute xmlAttribute in currentNode.Attributes)
            {
                attributes.Add(new NodeAttribute(xmlAttribute.Name, xmlAttribute.Value));
            }

            return attributes;
        }

        public static List<Node> GetNodesFromChildNodes(XmlNodeList currentNodes)
        {
            if (currentNodes == null || currentNodes.Count == 0)
            {
                return new();
            }

            List<Node> nodes = new();
            foreach (XmlNode child in currentNodes)
            {
                Node node;

                if (child.ChildNodes.Count >= 1)
                {
                    node = new Node(child.Name, GetAttributesFromNode(child), GetNodesFromChildNodes(child.ChildNodes));
                }
                else
                {
                    node = new Node(child.Name, GetAttributesFromNode(child));
                }

                nodes.Add(node);
            }

            return nodes;
        }
    }

    public static class ConsoleUtility
    {
        public static int TotalProgressCount { get; set; } = 1;
        public static int ProgressCount { get; set; } = 1;
        public static string ClassName { get; set; } = "";

        public static void WriteProgressBar()
        {
            float percent = (float)ProgressCount / TotalProgressCount * 100f;
            switch (percent)
            {
                case <= 10:
                    Console.Write("[■         ] {0,1:0}% [{1}/{2}] {3}\r".Red(), percent, ProgressCount, TotalProgressCount, ClassName);
                    break;
                case <= 20:
                    Console.Write("[■■        ] {0,1:0}% [{1}/{2}] {3}\r".Red(), percent, ProgressCount, TotalProgressCount, ClassName);
                    break;
                case <= 30:
                    Console.Write("[■■■       ] {0,1:0}% [{1}/{2}] {3}\r".Orange(), percent, ProgressCount, TotalProgressCount, ClassName);
                    break;
                case <= 40:
                    Console.Write("[■■■■      ] {0,1:0}% [{1}/{2}] {3}\r".Orange(), percent, ProgressCount, TotalProgressCount, ClassName);
                    break;
                case <= 50:
                    Console.Write("[■■■■■     ] {0,1:0}% [{1}/{2}] {3}\r".Orange(), percent, ProgressCount, TotalProgressCount, ClassName);
                    break;
                case <= 60:
                    Console.Write("[■■■■■■    ] {0,1:0}% [{1}/{2}] {3}\r".Yellow(), percent, ProgressCount, TotalProgressCount, ClassName);
                    break;
                case <= 70:
                    Console.Write("[■■■■■■■   ] {0,1:0}% [{1}/{2}] {3}\r".Yellow(), percent, ProgressCount, TotalProgressCount, ClassName);
                    break;
                case <= 80:
                    Console.Write("[■■■■■■■■  ] {0,1:0}% [{1}/{2}] {3}\r".Yellow(), percent, ProgressCount, TotalProgressCount, ClassName);
                    break;
                case <= 90:
                    Console.Write("[■■■■■■■■■ ] {0,1:0}% [{1}/{2}] {3}\r".Green(), percent, ProgressCount, TotalProgressCount, ClassName);
                    break;
                default:
                    Console.Write("[■■■■■■■■■■] {0,1:0}% [{1}/{2}] {3}\r".Green(), percent, ProgressCount, TotalProgressCount, ClassName);
                    break;
            }
        }
    }
}
