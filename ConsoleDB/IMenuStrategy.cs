using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDB
{
    internal interface IMenuStrategy
    {
        public void ShowMenuFor(string connString);
    }
}
