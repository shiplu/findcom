using System;
using System.Collections.Generic;
using System.Text;

namespace findcom
{
    class Program
    {
        static void Main(string[] args)
        {
            FindFile f = new FindFile();
            string[] files;
            string prefix, suffix;
            prefix = suffix = String.Empty;

            switch (args.Length)
            {
                case 1:
                    files= f.Find(args[0],string.Empty);
                    break;
                case 2:
                    files = f.Find(args[0], args[1]);
                    break;
                default:
                    files = f.Find();
                    break;
            }

            foreach (string s in files)
            {
                Console.WriteLine(s);
            }
        }

    }
}
