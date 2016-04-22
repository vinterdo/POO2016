using System;
using System.Collections;

namespace Lista5
{
    public class PuzzleNo15
    {

        internal static int IntComparer(int x, int y)
        {
            return x.CompareTo(y);
        }

        private static void Main(string[] args)
        {
            var a = new ArrayList() {1, 5, 3, 3, 2, 4, 3};
            
            a.Sort(new ComparisionAdapter());

            Console.ReadLine();
        }
    }

    internal class ComparisionAdapter : IComparer
    {
        public int Compare(object x, object y)
        {
            return PuzzleNo15.IntComparer((int) x, (int) y);
        }
    }
}
