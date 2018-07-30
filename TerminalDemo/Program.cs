using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TerminalDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var program = new Program();
            program.Start();
        }

        string[] input = { "", "", "" };
        int inputColumn = 17;
        int[] inputRow = { 5, 7, 9 };

        void Start()
        {
            Console.WindowWidth = leftMargin.Length + 38 + leftMargin.Length;
            Console.BufferWidth = Console.WindowWidth;
            Console.WindowHeight = 14;
            Console.BufferHeight = Console.WindowHeight;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;

            int currentInput = 0;
            int currentInputIndex = 0;

            DrawScreen();
            while (true)
            {
                Console.SetCursorPosition(inputColumn + currentInputIndex, inputRow[currentInput]);
                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.Tab)
                {
                    // Switch inputs
                    currentInput++;
                    if (currentInput > input.Length - 1)
                    {
                        Console.Clear();
                        DrawScreen();
                        currentInput = 0;
                    }
                    currentInputIndex = input[currentInput].Length;
                }
                else if (key.Key == ConsoleKey.F12)
                {
                    // Save
                    Console.CursorVisible = false;
                    DrawScreen(false);
                    Console.SetCursorPosition(leftMargin.Length + 12, 12);
                    Console.Write(leftMargin + "SAVING");
                    Thread.Sleep(500);
                    Console.Write(" .");
                    Thread.Sleep(500);
                    Console.Write(" .");
                    Thread.Sleep(500);
                    Console.Write(" .");
                    Thread.Sleep(850); // the tension is palpable
                    Console.Clear();
                    DrawScreen(false);
                    Console.SetCursorPosition(leftMargin.Length + 18, 12);
                    Console.Write("SAVED!");
                    Console.CursorVisible = true;
                }
                else if (key.KeyChar != '\u0000') // only printable characters
                {
                    input[currentInput] += key.KeyChar;
                    currentInputIndex++;
                }
            }
        }

        readonly string leftMargin = new String(' ', 3);
        void Print(string msg)
        {
            Console.WriteLine(leftMargin + msg);
        }

        void DrawScreen(bool saveDialog = true)
        {
            Console.Clear();
            Print("");
            Print("         CAT DATA PROCESSING ERP");
            Print("       (c) 1984 Cyberdyne Systems");
            Print("");
            Print("");
            Print("        NAME: " + input[0]);
            Print("");
            Print("       BREED: " + input[1]);
            Print("");
            Print("  BIRTH YEAR: " + input[2]);
            Print("");
            Print("");
            if (saveDialog)
            {
                Print("            PRESS F12 TO SAVE");
            }
        }
    }
}
