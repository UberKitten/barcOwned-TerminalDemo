using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Security.Principal;

namespace UPCDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var program = new Program();
            program.Start();
        }
        

        void Start()
        {
            Console.WindowWidth = leftMargin.Length + 38 + leftMargin.Length;
            Console.BufferWidth = Console.WindowWidth;
            Console.WindowHeight = 14;
            Console.BufferHeight = Console.WindowHeight;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
           
            bool isElevated;
            using (WindowsIdentity identity = WindowsIdentity.GetCurrent())
            {
                WindowsPrincipal principal = new WindowsPrincipal(identity);
                isElevated = principal.IsInRole(WindowsBuiltInRole.Administrator);
            }

            if (isElevated)
            {
                while(true)
                {
                    DrawHeader();
                    Print("Scan UPC code: ", false);
                    var code = Console.ReadLine();
                    if (code.Trim() == "038000144158")
                    {
                        DrawHeader();
                        Print("Product scanned");
                        Print("");
                        Print("Kellogg’s Smorz Cereal");
                        Print("MSRP: $2.98");
                        Print("");
                        Print("Press any key to continue...");
                        Console.ReadKey();
                    }
                    else
                    {
                        DrawHeader();
                        Print("Unknown UPC code: " + code);
                        Print("");
                        Print("Press any key to continue...");
                        Console.ReadKey();
                    }
                }
            }
            else
            {
                DrawHeader();
                Print("ERROR! Not running as admin!");
                Print();
                Print("Press any key to continue...");
                Console.ReadKey();
            }
            /*
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
                        DrawHeader();
                        currentInput = 0;
                    }
                    currentInputIndex = input[currentInput].Length;
                }
                else if (key.Key == ConsoleKey.F12)
                {
                    // Save
                    Console.CursorVisible = false;
                    DrawHeader(false);
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
                    DrawHeader(false);
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
            */
        }

        readonly string leftMargin = new String(' ', 3);
        void Print(string msg = "", bool newLine = true)
        {
            if (newLine)
            {
                Console.WriteLine(leftMargin + msg);
            }
            else
            {
                Console.Write(leftMargin + msg);
            }
        }

        void DrawHeader()
        {
            Console.Clear();
            Print("");
            Print("            UPC Product Lookup");
            Print("       (c) 1984 Cyberdyne Systems");
            Print("");
            Print("");
        }
    }
}
