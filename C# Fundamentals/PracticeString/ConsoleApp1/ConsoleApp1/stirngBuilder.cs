using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class stirngBuilder
    {
        public static void modifyString()
        {
            var builder = new StringBuilder();

            builder.Append('-', 10)
                .AppendLine()
                .Append("Header")
                .AppendLine()
                .Append('-',10)
                .Replace('-', '*')
                .Remove(0,10)
                .Insert(0, new string('-', 5));
            
            Console.WriteLine(builder);

        }
    }
}
