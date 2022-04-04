using System;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;

namespace PortScan
{
    class Program
    {
        private static string IP = ""; 
        private static int FirstRangeNum = 0;
        private static int SecondRangeNum = 0;
        private static void UserInputIP()
        { 
            bool work = true;  
            IPAddress address;
            try
            {
               while (work) {
                    // clean console
                   Console.Clear();
                    // change color of text to darkgreen
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("IP Address: ");
                    //reset color back to default
                    Console.ResetColor();
                    IP = Console.ReadLine();
                    //We use TryParse() ,because we want the boolean return value instead.
                    if (IPAddress.TryParse(IP, out address))
                    {
                        Console.Clear();
                        Console.WriteLine("Enter Port Range");
                        Console.WriteLine();
                        Console.WriteLine("Enter First range: ");
                        FirstRangeNum = Int16.Parse(Console.ReadLine());
                        Console.WriteLine("Enter Second range: ");
                        SecondRangeNum = Int16.Parse(Console.ReadLine());
                        //End loop
                        work = false;
                    } 
                } 
            }
            catch(Exception ex)  {}
        
        }


        private static void PortScan()
        {
            Console.Clear();
            Console.WriteLine("The scan has started, it may take some time ...");
            for (int i = FirstRangeNum; i <= SecondRangeNum; i++)
            { 
                using (TcpClient Scan = new TcpClient())
                {
                    try
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Scan.Connect(IP, i);
                        Console.WriteLine($"[{i}] | OPEN");
                        Console.ResetColor();
                    }
                    catch
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"[{i}] | CLOSED");
                        Console.ResetColor();
                    }
                }
            }

            Console.WriteLine("Scanning end!");
               
        }

        static void Main(string[] args)
        {
            UserInputIP();
            PortScan();
        }
   
    }
}
