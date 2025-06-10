using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CSharpWebServer
{
    internal class MyWebServer
    {
        static void Main(string[] args)
        {
            HttpListener httpListener = new HttpListener();
            httpListener.Prefixes.Add("http://localhost:8088/");

            httpListener.Start();

            Console.WriteLine("server start");

            Random random = new Random();

            while (true)
            {
                HttpListenerContext httpListenerContext = httpListener.GetContext();
                HttpListenerRequest request = httpListenerContext.Request;

                Console.WriteLine(request.Url);

                string rsp = "<h1>" + random.NextDouble() + "</h1>";
                byte[] bytes = Encoding.UTF8.GetBytes(rsp);

                HttpListenerResponse httpListenerResponse = httpListenerContext.Response;

                httpListenerResponse.OutputStream.Write(bytes, 0, bytes.Length);

                httpListenerResponse.OutputStream.Close();
            }
        }
    }
}
