using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoBookStore.Interfaces;

namespace MongoBookStore
{
    internal class TextIO : IUI
    {
        public void Print(string text)
        {
            Console.Write(text);
        }

        public void PrintLine(string text)
        {
            Console.WriteLine(text);
        }

        public string GetInput()
        {
            return Console.ReadLine();
        }

        public void PressToContinue()
        {
            Console.WriteLine("Press any button to continue...");
            Console.ReadKey();
            Clear();
        }

        public void Delay(int delay_seconds)
        {
            if(delay_seconds > 0 && delay_seconds <= 10)
                System.Threading.Thread.Sleep(delay_seconds*1000);
            Clear();
        }

        public void Clear()
        {
            Console.Clear();
        }

        public void Exit()
        {
            System.Environment.Exit(0);
        }
    }
}
