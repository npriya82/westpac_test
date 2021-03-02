using System.IO;
using System.Net.Http;

namespace UiTest.Lib
{
    internal class GetInformation
    {
        public readonly static char separator = Path.DirectorySeparatorChar;
        private readonly static string startupPath = Directory.GetCurrentDirectory();
        private readonly static string startupPathName = Directory.GetParent(startupPath).Parent.FullName;
        public readonly static string projectDirectory = Directory.GetParent(startupPathName).FullName;
    }
}
