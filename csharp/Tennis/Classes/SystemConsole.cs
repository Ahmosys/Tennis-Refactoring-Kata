using System;
using Tennis.Interfaces;

namespace Tennis.Classes
{
    public class SystemConsole : IConsole
    {
        public void WriteLine(string value)
        {
            Console.WriteLine(value);
        }
    }
}
