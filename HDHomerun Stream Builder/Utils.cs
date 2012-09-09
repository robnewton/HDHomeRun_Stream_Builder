using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HDHomerun_Stream_Builder
{
    public static class Utils
    {
        public static string MakeSafeFilename(string filename, char replaceChar)
        {
            foreach (char c in System.IO.Path.GetInvalidFileNameChars())
            {
                filename = filename.Replace(c, replaceChar);
            }
            return filename;
        }

        public static bool Empty(string s)
        {
            return s == null || s.Length == 0;
        }
    }
}
