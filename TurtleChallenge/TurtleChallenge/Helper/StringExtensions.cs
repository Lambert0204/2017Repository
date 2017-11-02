using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleChallenge.Helper
{
    public static class StringExtensions
    {
        public static string[] SplitInfo(this String text)
        {
            return text.Split(' ');
        }

        public static string[] GetAxis(this String text)
        {
            return text.Split(',');
        }

        public static int ToInt(this object obj)
        {
            return Convert.ToInt32(obj);
        }

        public static bool IsFormatCorrect(this String[] lists, int numberOfStrings)
        {
            return lists.Count() == numberOfStrings;
        }
    }
}
