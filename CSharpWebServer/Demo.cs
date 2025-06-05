using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpWebServer
{
    internal class Demo
    {
        public static void setAge(int age)
        {
            if(age > 120)
            {
                throw new MyExcepton("age is older than 120");
            }
        }

        public static void openFile(string path)
        {
            FileStream fs = null;
            try
            {
                fs = File.Open(path, FileMode.Open);
            }
            catch(FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                throw new MyExcepton("hahha",ex);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                fs?.Close();
            }
            
        }
        static void Main(string[] args)
        {
            try
            {
                //setAge(121);
                openFile("bbb.txt");
            }
            catch (MyExcepton ex)
            {
                Console.WriteLine(ex.Message);
                //Console.WriteLine(ex.InnerException);
            }
            
            Console.WriteLine("over");
        }
    }
}
