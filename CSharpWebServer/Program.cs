using System.Net;
using System.Text;

namespace CSharpWebServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 创建 HttpListener 实例
            HttpListener listener = new HttpListener();

            // 添加监听地址（必须以 / 结尾）
            listener.Prefixes.Add("http://localhost:8080/");

            // 开始监听
            listener.Start();
            Console.WriteLine("监听 http://localhost:8080/");
            Random random = new Random();

            while (true)
            {
                // 接收请求（阻塞调用）
                HttpListenerContext context = listener.GetContext();
                HttpListenerRequest request = context.Request;

                Console.WriteLine($"收到请求: {request.HttpMethod} {request.Url}");

                // 构造响应内容
                string responseString = "<h1>"+random.NextDouble()+"</h1>";
                byte[] buffer = Encoding.UTF8.GetBytes(responseString);
                
                try
                {
                    int x = 0;
                    int k = 9 / x;
                }
                catch(DivideByZeroException ex)
                {
                    Console.WriteLine(ex.Message);
                }
              
                // 写入响应
                HttpListenerResponse response = context.Response;
                //response.ContentLength64 = buffer.Length;
                //response.ContentType = "text/html; charset=UTF-8";

                // 写入响应数据
                response.OutputStream.Write(buffer, 0, buffer.Length);

                // 手动关闭流（推荐）
                response.OutputStream.Close();

                // 可选：只处理一个请求就退出
                // break;
            }

        }
    }
}
