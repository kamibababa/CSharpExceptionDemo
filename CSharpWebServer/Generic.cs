using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Encodings.Web;
namespace CSharpWebServer
{
    public class ApiResponse<T>
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public ApiResponse() { }

        public ApiResponse(int statusCode, string message, T data)
        {
            StatusCode = statusCode;
            Message = message;
            Data = data;
        }

        public string ToJson()
        {
            return JsonSerializer.Serialize(this);
        }
    }

    class Program2
    {
        static void Main()
        {

            var response1 = new ApiResponse<string>(200, "success", "hello");
            Console.WriteLine(response1.ToJson());

            var response3 = new ApiResponse<User>(
                200,
                "userinfo",
                new User { Id = 1, Name = "Alice" }
            );
            Console.WriteLine(response3.ToJson());
        }
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

}
