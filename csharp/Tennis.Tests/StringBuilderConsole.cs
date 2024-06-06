using System.Text;
using Tennis.Interfaces;

namespace Tennis.Classes
{
    public class StringBuilderConsole : IConsole
    {
        private StringBuilder _output = new();

        public string Output => _output.ToString();

        public void WriteLine(string value)
        {
            _output.AppendLine(value);
        }
    }
}
