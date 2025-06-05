using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CSharpWebServer
{
    internal class MyExcepton : Exception
    {
        public MyExcepton(string message) : base(message) { }
        public MyExcepton(string message, Exception innerException)
        : base(message, innerException) { }

        
    }
}
