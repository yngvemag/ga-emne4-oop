using GATools.String;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GATools.File
{
    public static class GAFileObjects<T>
    {
        public static ICollection<T> GetLineObjects(string fileName, Func<string, string[]> splitFunc, Func<string[], T?> parse)
        {
            var datas = new List<T>();
            using (StreamReader reader = new(fileName))
            {
                string? header = reader.ReadLine();
                string? line = reader.ReadLine();
                while (line != null)
                {
                    var arr = splitFunc(line);
                    var T = parse(arr);
                    if (T != null)
                        datas.Add(T);

                    line = reader.ReadLine();
                }
            }
            return datas;
        }
    }
}
