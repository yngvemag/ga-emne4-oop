using System.Text;

namespace GATools.String
{
    public static class CSVTool
    {
        public static string[] Split(string customerLine, char forceReadChar = '\"')
        {
            StringBuilder sb = new();
            List<string> strings = new();

            bool _forceRead = false;
            foreach (var c in customerLine)
            {
                if (c.Equals(forceReadChar))
                    _forceRead = !_forceRead;

                if (_forceRead) sb.Append(c);
                else
                {
                    if (c.Equals(','))
                    {
                        strings.Add(sb.ToString());
                        sb = new();
                    }
                    else sb.Append(c);
                }
            }
            strings.Add(sb.ToString());

            return strings.ToArray();
        }
    }
}