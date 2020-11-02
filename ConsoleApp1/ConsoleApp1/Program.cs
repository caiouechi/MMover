using System;
using System.Threading;
using System.Runtime.InteropServices;

namespace ConsoleApp1
{
    class Program
    {
        public static void Main(string[] args)
        {
            for (int i = 0; i < 50000; i++)
            {
                Thread.Sleep(3000);
                Random rnd = new Random();
                int month = rnd.Next(1, 20);
                SetCursorPos(month * 300, month * 300);

                uint X = (uint)month * 300; 
                uint Y = (uint)month * 300;

                mouse_event(MOUSEEVENTF_RIGHTDOWN | MOUSEEVENTF_RIGHTUP, X,Y, 0 , 0);

                Console.WriteLine(String.Format("Test for {0}", i));
            }
            Console.ReadKey();
        }

        [DllImport("user32.dll")]
        static extern bool SetCursorPos(int X, int Y);

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);
        //Mouse actions
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;
    }
}
